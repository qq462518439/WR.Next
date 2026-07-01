using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using robotManager.Helpful;
using robotManager.MemoryClass;
using robotManager.Products;
using wManager;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace WR.OriginalUiHost
{
    public sealed class OriginalRuntimeBootstrap
    {
        private readonly string _runtimeRoot;
        private readonly object _productLock = new object();
        private readonly object _attachSessionLock = new object();
        private RuntimeSession _currentSession;
        private Task<OriginalRuntimeActionResult> _productStartTask;
        private OriginalRuntimeActionResult _lastProductStartResult = OriginalRuntimeActionResult.Success("产品链尚未启动");

        public OriginalRuntimeBootstrap(string runtimeRoot)
        {
            _runtimeRoot = runtimeRoot;
        }

        public OriginalRuntimeAttachResult AttachToWowProcess(int processId)
        {
            RuntimeSession session;
            lock (_attachSessionLock)
            {
                if (processId <= 0)
                {
                    _currentSession = null;
                    return OriginalRuntimeAttachResult.Fail("接管进程无效");
                }

                if (_currentSession == null || _currentSession.ProcessId != processId)
                {
                    _currentSession = new RuntimeSession(processId);
                }

                _currentSession.HealthState = SessionHealthState.Attaching;
                _currentSession.LastHeartbeatUtc = DateTime.UtcNow;
                session = _currentSession;
            }

            WriteProductAction("session-attach-request pid=" + processId);
            return RefreshAttachedProcess(session, forceHookPulse: true);
        }

        public OriginalRuntimeAttachResult RefreshAttachedProcess()
        {
            RuntimeSession session;
            lock (_attachSessionLock)
            {
                session = _currentSession;
            }

            WriteSessionRefreshTrace(session, "snapshot-refresh-request", forceHookPulse: false);
            return RefreshAttachedProcess(session, forceHookPulse: false);
        }

        public RuntimeSession GetCurrentSessionSnapshot()
        {
            lock (_attachSessionLock)
            {
                return CloneSession(_currentSession);
            }
        }

        private OriginalRuntimeAttachResult RefreshAttachedProcess(RuntimeSession session, bool forceHookPulse)
        {
            WriteSessionRefreshTrace(
                session,
                forceHookPulse ? "session-refresh-force" : "session-refresh-lite",
                forceHookPulse);

            if (session == null || session.ProcessId <= 0)
            {
                return OriginalRuntimeAttachResult.Fail("尚未接管进程");
            }

            if (!IsProcessAlive(session.ProcessId))
            {
                MarkSessionLost(session, "进程已退出或不可访问");
                return OriginalRuntimeAttachResult.Fail("接管进程已退出");
            }

            var processId = session.ProcessId;
            var result = ReadProcessSnapshot(session, forceHookPulse);
            if (!result.Ok && IsHandleFailure(result.Message))
            {
                lock (_attachSessionLock)
                {
                    if (_currentSession != null && _currentSession.ProcessId == processId)
                    {
                        _currentSession.SessionInitialized = false;
                        _currentSession.MemoryOpen = false;
                        _currentSession.HookReady = false;
                        _currentSession.LastError = result.Message;
                        _currentSession.HealthState = SessionHealthState.Faulted;
                        _currentSession.LastHeartbeatUtc = DateTime.UtcNow;
                    }
                }
            }

            return result;
        }

        private void WriteSessionRefreshTrace(RuntimeSession session, string stage, bool forceHookPulse)
        {
            try
            {
                var snapshot = session == null
                    ? "session=null"
                    : "pid=" + session.ProcessId +
                      " attached=" + session.IsAttached +
                      " initialized=" + session.SessionInitialized +
                      " memory=" + session.MemoryOpen +
                      " hook=" + session.HookReady +
                      " inGame=" + session.InGame +
                      " health=" + session.HealthState;

                WriteProductAction(stage + " forceHookPulse=" + forceHookPulse + " " + snapshot);
            }
            catch
            {
            }
        }

        public void Detach()
        {
            lock (_attachSessionLock)
            {
                if (_currentSession != null)
                {
                    _currentSession.IsAttached = false;
                    _currentSession.SessionInitialized = false;
                    _currentSession.MemoryOpen = false;
                    _currentSession.HookReady = false;
                    _currentSession.HealthState = SessionHealthState.Closed;
                    _currentSession.LastHeartbeatUtc = DateTime.UtcNow;
                }

                _currentSession = null;
            }
        }

        public void Shutdown()
        {
            try
            {
                WriteProductAction("runtime-shutdown begin");
                StopOriginalProduct();
            }
            catch (Exception ex)
            {
                WriteProductAction("runtime-shutdown stop-product failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                Fight.StopFight();
                WriteProductAction("runtime-shutdown stop-fight ok");
            }
            catch (Exception ex)
            {
                WriteProductAction("runtime-shutdown stop-fight failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                MovementManager.StopMoveTo();
                WriteProductAction("runtime-shutdown stop-move ok");
            }
            catch (Exception ex)
            {
                WriteProductAction("runtime-shutdown stop-move failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                Detach();
                WriteProductAction("runtime-shutdown detach ok");
            }
            catch (Exception ex)
            {
                WriteProductAction("runtime-shutdown detach failed " + ex.GetType().Name + ": " + ex.Message);
            }

            lock (_attachSessionLock)
            {
                if (_currentSession != null)
                {
                    _currentSession.HealthState = SessionHealthState.Closed;
                    _currentSession.LastHeartbeatUtc = DateTime.UtcNow;
                }
            }
            WriteProductAction("runtime-shutdown end");
        }

        private static bool IsHandleFailure(string message)
        {
            return !string.IsNullOrWhiteSpace(message) &&
                   (message.IndexOf("Memory.Open", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    message.IndexOf("进程句柄无效", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private static bool IsProcessAlive(int processId)
        {
            try
            {
                var process = Process.GetProcessById(processId);
                return process != null && !process.HasExited;
            }
            catch
            {
                return false;
            }
        }

        public OriginalRuntimeActionResult EnsureOriginalProductStartedInBackground()
        {
            lock (_productLock)
            {
                if (Products.IsAliveProduct && Products.IsStarted && !Products.InPause)
                {
                    _lastProductStartResult = OriginalRuntimeActionResult.Success("产品链已启动: WRotation");
                    return _lastProductStartResult;
                }

                if (_productStartTask != null && !_productStartTask.IsCompleted)
                {
                    return OriginalRuntimeActionResult.Success("产品链启动中: WRotation");
                }

                if (_productStartTask != null && _productStartTask.IsCompleted)
                {
                    _lastProductStartResult = _productStartTask.Result;
                }

                _productStartTask = Task.Run(() =>
                {
                    WriteProductAction("background-start-request");
                    var result = EnsureOriginalProductStarted();
                    lock (_productLock)
                    {
                        _lastProductStartResult = result;
                    }
                    WriteProductAction("background-start-result " + result.Message);

                    return result;
                });

                return OriginalRuntimeActionResult.Success("产品链启动中: WRotation");
            }
        }

        public OriginalRuntimeActionResult GetOriginalProductState()
        {
            lock (_productLock)
            {
                if (Products.IsAliveProduct && Products.IsStarted && !Products.InPause)
                {
                    return OriginalRuntimeActionResult.Success("产品链已启动: WRotation");
                }

                if (_productStartTask != null && !_productStartTask.IsCompleted)
                {
                    return OriginalRuntimeActionResult.Success("产品链启动中: WRotation");
                }

                if (_productStartTask != null && _productStartTask.IsCompleted)
                {
                    _lastProductStartResult = _productStartTask.Result;
                }

                return _lastProductStartResult;
            }
        }

        public OriginalRuntimeActionResult ApproachTargetOnce()
        {
            WriteProductAction("action-gate ApproachTargetOnce precheck");
            var snapshot = RefreshAttachedProcess();
            if (!snapshot.Ok)
            {
                return OriginalRuntimeActionResult.Fail(snapshot.Message);
            }

            if (!string.Equals(snapshot.HasTarget, "True", StringComparison.OrdinalIgnoreCase))
            {
                return OriginalRuntimeActionResult.Fail("当前没有有效目标");
            }

            try
            {
                var productResult = GetOriginalProductState();
                if (!Products.IsAliveProduct || !Products.IsStarted || Products.InPause)
                {
                    EnsureOriginalProductStartedInBackground();
                    return OriginalRuntimeActionResult.Fail(productResult.Message);
                }
                MovementManager.LaunchThreadMovementManager();
                var target = ObjectManager.Me.TargetObject;
                if (target == null || !target.IsValid)
                {
                    return OriginalRuntimeActionResult.Fail("目标对象无效");
                }

                var beforeDistance = target.GetDistance;
                var beforeCtm = ClickToMove.GetClickToMoveTypePush().ToString();
                var beforeMeMove = ObjectManager.Me.GetMove;
                MovementManager.MoveTo(target);
                Thread.Sleep(150);
                var afterMovementManagerCtm = ClickToMove.GetClickToMoveTypePush().ToString();
                var afterMovementManagerMeMove = ObjectManager.Me.GetMove;
                var usedDirectClickToMove = false;

                if (!ClickToMove.InMove && !ObjectManager.Me.GetMove)
                {
                    var position = target.Position;
                    ClickToMove.CGPlayer_C__ClickToMove(position.X, position.Y, position.Z, 0uL, 4, 0.5f);
                    usedDirectClickToMove = true;
                    Thread.Sleep(150);
                }

                return OriginalRuntimeActionResult.Success(
                    "已调用原版移动链; target=" + target.Name +
                    " distance=" + beforeDistance.ToString("0.00") +
                    " productStarted=" + Products.IsStarted +
                    " beforeCtm=" + beforeCtm +
                    " beforeMeMove=" + beforeMeMove +
                    " afterMMCtm=" + afterMovementManagerCtm +
                    " afterMMMeMove=" + afterMovementManagerMeMove +
                    " directCtm=" + usedDirectClickToMove +
                    " finalCtm=" + ClickToMove.GetClickToMoveTypePush() +
                    " finalMeMove=" + ObjectManager.Me.GetMove);
            }
            catch (Exception ex)
            {
                return OriginalRuntimeActionResult.Fail("跟近调用失败: " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        public OriginalRuntimeActionResult FaceTargetOnce()
        {
            WriteProductAction("action-gate FaceTargetOnce precheck");
            var snapshot = RefreshAttachedProcess();
            if (!snapshot.Ok)
            {
                return OriginalRuntimeActionResult.Fail(snapshot.Message);
            }

            if (!string.Equals(snapshot.HasTarget, "True", StringComparison.OrdinalIgnoreCase))
            {
                return OriginalRuntimeActionResult.Fail("当前没有有效目标");
            }

            try
            {
                var target = ObjectManager.Me.TargetObject;
                if (target == null || !target.IsValid)
                {
                    return OriginalRuntimeActionResult.Fail("目标对象无效");
                }

                var wasFacing = ObjectManager.Me.IsFacing(target.Position);
                MovementManager.Face(target);
                Thread.Sleep(120);
                var isFacing = ObjectManager.Me.IsFacing(target.Position);

                return OriginalRuntimeActionResult.Success(
                    "已调用原版朝向链; target=" + target.Name +
                    " distance=" + target.GetDistance.ToString("0.00") +
                    " beforeFacing=" + wasFacing +
                    " afterFacing=" + isFacing);
            }
            catch (Exception ex)
            {
                return OriginalRuntimeActionResult.Fail("朝向目标失败: " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        public OriginalRuntimeActionResult InteractTargetOnce()
        {
            WriteProductAction("action-gate InteractTargetOnce precheck");
            var snapshot = RefreshAttachedProcess();
            if (!snapshot.Ok)
            {
                return OriginalRuntimeActionResult.Fail(snapshot.Message);
            }

            if (!string.Equals(snapshot.HasTarget, "True", StringComparison.OrdinalIgnoreCase))
            {
                return OriginalRuntimeActionResult.Fail("当前没有有效目标");
            }

            try
            {
                var target = ObjectManager.Me.TargetObject;
                if (target == null || !target.IsValid)
                {
                    return OriginalRuntimeActionResult.Fail("目标对象无效");
                }

                var result = Interact.InteractGameObject(target.GetBaseAddress, stopMove: true, skipWaitTime: false);
                return result
                    ? OriginalRuntimeActionResult.Success(
                        "已调用原版交互链; target=" + target.Name +
                        " distance=" + target.GetDistance.ToString("0.00") +
                        " base=0x" + target.GetBaseAddress.ToString("X"))
                    : OriginalRuntimeActionResult.Fail(
                        "原版交互链返回 false; target=" + target.Name +
                        " distance=" + target.GetDistance.ToString("0.00"));
            }
            catch (Exception ex)
            {
                return OriginalRuntimeActionResult.Fail("交互目标失败: " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        public OriginalRuntimeActionResult StartFightOnCurrentTarget()
        {
            WriteProductAction("action-gate StartFightOnCurrentTarget precheck");
            var snapshot = RefreshAttachedProcess();
            if (!snapshot.Ok)
            {
                return OriginalRuntimeActionResult.Fail(snapshot.Message);
            }

            if (!string.Equals(snapshot.HasTarget, "True", StringComparison.OrdinalIgnoreCase))
            {
                return OriginalRuntimeActionResult.Fail("当前没有有效目标");
            }

            try
            {
                var productResult = GetOriginalProductState();
                if (!Products.IsAliveProduct || !Products.IsStarted || Products.InPause)
                {
                    EnsureOriginalProductStartedInBackground();
                    return OriginalRuntimeActionResult.Fail("产品未就绪: " + productResult.Message);
                }

                var target = ObjectManager.Me.TargetObject;
                if (target == null || !target.IsValid)
                {
                    return OriginalRuntimeActionResult.Fail("目标对象无效");
                }

                MovementManager.LaunchThreadMovementManager();
                WriteBattleTimeline("startfight-enter", BuildBattleExecutionStateSnapshot("before-startfight"));
                var targetGuid = target.Guid;
                var targetName = target.Name;
                var targetDistance = target.GetDistance;
                var beforeInFight = Fight.InFight;
                var fightResultGuid = Fight.StartFight(
                    targetGuid,
                    skipIfPlayerAttackedButNotByTheTarget: true,
                    managerMovement: true,
                    stopIfPlayerTargetChange: false,
                    rotationBot: true);
                Thread.Sleep(180);
                var afterSummary = BuildBattleExecutionStateSnapshot("after-startfight");
                WriteBattleTimeline("startfight-exit", afterSummary);

                return OriginalRuntimeActionResult.Success(
                    "已调用原版开战链; target=" + targetName +
                    " distance=" + targetDistance.ToString("0.00") +
                    " beforeFight=" + beforeInFight +
                    " returnedGuid=" + fightResultGuid +
                    " currentFight=" + Fight.InFight +
                    " meHasTarget=" + ObjectManager.Me.HasTarget +
                    " meMoving=" + ObjectManager.Me.GetMove +
                    " customClassAlive=" + CustomClass.IsAliveCustomClass +
                    " spellBookCount=" + SafeGetSpellBookCount());
            }
            catch (Exception ex)
            {
                WriteBattleTimeline("startfight-exception", ex.GetType().Name + ": " + ex.Message);
                return OriginalRuntimeActionResult.Fail("开始战斗失败: " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        public OriginalRuntimeActionResult ExecuteTargetActionSequence()
        {
            WriteProductAction("action-gate ExecuteTargetActionSequence precheck");
            var snapshot = RefreshAttachedProcess();
            if (!snapshot.Ok)
            {
                return OriginalRuntimeActionResult.Fail(snapshot.Message);
            }

            if (!string.Equals(snapshot.HasTarget, "True", StringComparison.OrdinalIgnoreCase))
            {
                return OriginalRuntimeActionResult.Fail("当前没有有效目标");
            }

            var faceResult = FaceTargetOnce();
            if (!faceResult.Ok)
            {
                return OriginalRuntimeActionResult.Fail("序列终止[朝向]: " + faceResult.Message);
            }

            Thread.Sleep(100);

            var approachResult = ApproachTargetOnce();
            if (!approachResult.Ok)
            {
                return OriginalRuntimeActionResult.Fail("序列终止[跟近]: " + approachResult.Message);
            }

            Thread.Sleep(120);

            var interactResult = InteractTargetOnce();
            if (!interactResult.Ok)
            {
                return OriginalRuntimeActionResult.Fail("序列终止[交互]: " + interactResult.Message);
            }

            return OriginalRuntimeActionResult.Success(
                "已调用目标动作序列: 朝向 -> 跟近 -> 交互" +
                Environment.NewLine + faceResult.Message +
                Environment.NewLine + approachResult.Message +
                Environment.NewLine + interactResult.Message);
        }

        public OriginalRuntimeActionResult ExecuteBattleActionSequence()
        {
            WriteProductAction("action-gate ExecuteBattleActionSequence precheck");
            var snapshot = RefreshAttachedProcess();
            if (!snapshot.Ok)
            {
                return OriginalRuntimeActionResult.Fail(snapshot.Message);
            }

            if (!string.Equals(snapshot.HasTarget, "True", StringComparison.OrdinalIgnoreCase))
            {
                return OriginalRuntimeActionResult.Fail("当前没有有效目标");
            }

            var faceResult = FaceTargetOnce();
            if (!faceResult.Ok)
            {
                return OriginalRuntimeActionResult.Fail("序列终止[朝向]: " + faceResult.Message);
            }

            Thread.Sleep(100);

            var approachResult = ApproachTargetOnce();
            if (!approachResult.Ok)
            {
                return OriginalRuntimeActionResult.Fail("序列终止[跟近]: " + approachResult.Message);
            }

            Thread.Sleep(150);

            var fightResult = StartFightOnCurrentTarget();
            if (!fightResult.Ok)
            {
                return OriginalRuntimeActionResult.Fail("序列终止[开战]: " + fightResult.Message);
            }

            return OriginalRuntimeActionResult.Success(
                "已调用战斗动作序列: 朝向 -> 跟近 -> 开战" +
                Environment.NewLine + faceResult.Message +
                Environment.NewLine + approachResult.Message +
                Environment.NewLine + fightResult.Message);
        }

        public OriginalRuntimeActionResult StopMoveTo()
        {
            try
            {
                MovementManager.StopMoveTo();
                return OriginalRuntimeActionResult.Success("已调用 MovementManager.StopMoveTo()");
            }
            catch (Exception ex)
            {
                return OriginalRuntimeActionResult.Fail("停止移动失败: " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        public OriginalRuntimeActionResult StopFightOnce()
        {
            try
            {
                Fight.StopFight();
                return OriginalRuntimeActionResult.Success("已调用 Fight.StopFight()");
            }
            catch (Exception ex)
            {
                return OriginalRuntimeActionResult.Fail("停止战斗失败: " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        public OriginalRuntimeActionResult StopOriginalProduct()
        {
            lock (_productLock)
            {
                try
                {
                    if (!Products.IsAliveProduct)
                    {
                        _lastProductStartResult = OriginalRuntimeActionResult.Success("产品链未运行");
                        return _lastProductStartResult;
                    }

                    var productName = Products.ProductName ?? "unknown";
                    Products.InPause = true;
                    WriteProductAction("ProductStop pre-stop pause=True");

                    try
                    {
                        Fight.StopFight();
                        WriteProductAction("ProductStop pre-stop fight-stop ok");
                    }
                    catch (Exception ex)
                    {
                        WriteProductAction("ProductStop pre-stop fight-stop failed " + ex.GetType().Name + ": " + ex.Message);
                    }

                    try
                    {
                        MovementManager.StopMoveTo();
                        WriteProductAction("ProductStop pre-stop move-stop ok");
                    }
                    catch (Exception ex)
                    {
                        WriteProductAction("ProductStop pre-stop move-stop failed " + ex.GetType().Name + ": " + ex.Message);
                    }

                    var stopResult = Products.ProductStop();
                    _lastProductStartResult = stopResult
                        ? OriginalRuntimeActionResult.Success("原版产品已停止: " + productName)
                        : OriginalRuntimeActionResult.Fail("原版产品停止失败: " + productName);
                    WriteProductAction("ProductStop " + _lastProductStartResult.Message);
                    return _lastProductStartResult;
                }
                catch (Exception ex)
                {
                    _lastProductStartResult = OriginalRuntimeActionResult.Fail("原版产品停止异常: " + ex.GetType().Name + ": " + ex.Message);
                    WriteProductAction("ProductStop exception " + ex.GetType().Name + ": " + ex.Message);
                    return _lastProductStartResult;
                }
            }
        }

        public OriginalRuntimeActionResult PauseOriginalProduct()
        {
            lock (_productLock)
            {
                try
                {
                    if (!Products.IsAliveProduct)
                    {
                        return OriginalRuntimeActionResult.Fail("产品链尚未启动");
                    }

                    Products.InPause = true;
                    try
                    {
                        Fight.StopFight();
                        WriteProductAction("ProductPause pre-stop fight-stop ok");
                    }
                    catch (Exception ex)
                    {
                        WriteProductAction("ProductPause pre-stop fight-stop failed " + ex.GetType().Name + ": " + ex.Message);
                    }

                    try
                    {
                        MovementManager.StopMoveTo();
                        WriteProductAction("ProductPause pre-stop move-stop ok");
                    }
                    catch (Exception ex)
                    {
                        WriteProductAction("ProductPause pre-stop move-stop failed " + ex.GetType().Name + ": " + ex.Message);
                    }

                    _lastProductStartResult = OriginalRuntimeActionResult.Success("原版产品已暂停: " + (Products.ProductName ?? "unknown"));
                    WriteProductAction("ProductPause " + _lastProductStartResult.Message);
                    return _lastProductStartResult;
                }
                catch (Exception ex)
                {
                    var result = OriginalRuntimeActionResult.Fail("原版产品暂停异常: " + ex.GetType().Name + ": " + ex.Message);
                    WriteProductAction("ProductPause exception " + ex.GetType().Name + ": " + ex.Message);
                    return result;
                }
            }
        }

        public OriginalRuntimeActionResult ResumeOriginalProduct()
        {
            lock (_productLock)
            {
                try
                {
                    if (!Products.IsAliveProduct)
                    {
                        return EnsureOriginalProductStartedInBackground();
                    }

                    Products.InPause = false;
                    _lastProductStartResult = OriginalRuntimeActionResult.Success("原版产品已恢复: " + (Products.ProductName ?? "unknown"));
                    WriteProductAction("ProductResume " + _lastProductStartResult.Message);
                    return _lastProductStartResult;
                }
                catch (Exception ex)
                {
                    var result = OriginalRuntimeActionResult.Fail("原版产品恢复异常: " + ex.GetType().Name + ": " + ex.Message);
                    WriteProductAction("ProductResume exception " + ex.GetType().Name + ": " + ex.Message);
                    return result;
                }
            }
        }

        public OriginalRuntimeProductSnapshot GetOriginalProductSnapshot()
        {
            lock (_productLock)
            {
                var productName = Products.ProductName;
                return new OriginalRuntimeProductSnapshot(
                    string.IsNullOrWhiteSpace(productName) ? "未选择产品" : productName,
                    Products.IsAliveProduct,
                    Products.IsStarted,
                    Products.InPause,
                    _productStartTask != null && !_productStartTask.IsCompleted,
                    _lastProductStartResult?.Message ?? "产品状态未知");
            }
        }

        private OriginalRuntimeAttachResult ReadProcessSnapshot(RuntimeSession session, bool forceHookPulse)
        {
            Directory.SetCurrentDirectory(_runtimeRoot);

            try
            {
                var processId = session.ProcessId;
                var hook = EnsureWowMemoryHook();
                var memory = hook.Memory;
                var opened = memory.Open(processId);

                if (!opened || !memory.IsValidAndOpenProcess())
                {
                    UpdateSessionState(session, SessionHealthState.Faulted, false, false, false, "Memory.Open 失败或进程句柄无效");
                    return OriginalRuntimeAttachResult.Fail("Memory.Open 失败或进程句柄无效");
                }

                EnsureHookRuntimeObjectsInitialized(hook, processId, "read-snapshot");
                TryPrimeHookPrivateInitializer(hook, processId, "read-snapshot");
                EnsureAttachedSessionReady(session, forceHookPulse ? "attach-or-force-refresh" : "snapshot-refresh", forceHookPulse);

                var isInGame = wManager.Wow.Memory.IsInGame(processId);
                var playerName = wManager.Wow.Memory.PlayerName(processId);
                var hookReady = IsWowHookThreadReady();
                if (!isInGame)
                {
                    UpdateSessionState(
                        session,
                        hookReady ? SessionHealthState.Attached : SessionHealthState.HookPending,
                        true,
                        true,
                        hookReady,
                        "未进入游戏");
                    return OriginalRuntimeAttachResult.Success(
                        "pid=" + memory.ProcessId +
                        " hwnd=" + memory.WindowHandleInt32 +
                        " mainModule=0x" + memory.MainModuleAddress.ToString("X") +
                        " inGame=False player=" + playerName,
                        playerName,
                        "-",
                        "-",
                        "-",
                        "False",
                        "False",
                        "False",
                        "False",
                        "False",
                        "False",
                        "False",
                        "0",
                        "-",
                        "False",
                        "-",
                        "-",
                        "-",
                        "-",
                        "-",
                        "-",
                        "0",
                        "False",
                        "0",
                        "未进入游戏");
                }

                wManager.Wow.ObjectManager.Pulsator.Initialize(false);
                var snapshot = ReadObjectManagerSnapshot();
                UpdateSessionState(
                    session,
                    hookReady ? SessionHealthState.Ready : SessionHealthState.HookPending,
                    true,
                    true,
                    hookReady,
                    isInGame ? "游戏中" : "未进入游戏",
                    string.IsNullOrWhiteSpace(snapshot.CharacterName) ? playerName : snapshot.CharacterName,
                    snapshot.Level,
                    snapshot.HealthPercent,
                    snapshot.Position);

                return OriginalRuntimeAttachResult.Success(
                    "pid=" + memory.ProcessId +
                    " hwnd=" + memory.WindowHandleInt32 +
                    " mainModule=0x" + memory.MainModuleAddress.ToString("X") +
                    " inGame=" + isInGame +
                    " player=" + playerName +
                    " objects=" + snapshot.ObjectCount,
                    string.IsNullOrWhiteSpace(snapshot.CharacterName) ? playerName : snapshot.CharacterName,
                    snapshot.Level,
                    snapshot.HealthPercent,
                    snapshot.Position,
                    snapshot.InCombat,
                    snapshot.IsMoving,
                    snapshot.IsMounted,
                    snapshot.IsFlying,
                    snapshot.IsSwimming,
                    snapshot.IsCasting,
                    snapshot.ObjectCount.ToString(),
                    snapshot.ClickToMoveType,
                    snapshot.ClickToMoveInMove,
                    snapshot.HasTarget,
                    snapshot.TargetName,
                    snapshot.TargetLevel,
                    snapshot.TargetHealthPercent,
                    snapshot.TargetDistance,
                    snapshot.IsFacingTarget,
                    snapshot.FightCurrentTargetName,
                    snapshot.FightCurrentTargetGuid,
                    snapshot.FightCurrentTargetIsMyTarget,
                    snapshot.FightCombatTimeMs,
                    isInGame ? "游戏中" : "未进入游戏");
            }
            catch (InvalidOperationException ex)
            {
                UpdateSessionState(session, SessionHealthState.Faulted, false, false, false, ex.Message);
                return OriginalRuntimeAttachResult.Fail("原版 Hook 初始化失败: " + ex.Message);
            }
            catch (TargetInvocationException ex)
            {
                UpdateSessionState(session, SessionHealthState.Faulted, false, false, false, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                return OriginalRuntimeAttachResult.Fail("原版运行时调用异常: " + ex.InnerException);
            }
            catch (Exception ex)
            {
                UpdateSessionState(session, SessionHealthState.Faulted, false, false, false, ex.Message);
                return OriginalRuntimeAttachResult.Fail("RuntimeBootstrap 异常: " + ex);
            }
        }

        private void EnsureAttachedSessionReady(RuntimeSession session, string stage, bool forceHookPulse)
        {
            var processId = session.ProcessId;
            var sessionInitialized = false;
            lock (_attachSessionLock)
            {
                if (_currentSession != null && _currentSession.ProcessId == processId)
                {
                    sessionInitialized = _currentSession.SessionInitialized;
                }
            }

            if (sessionInitialized && !forceHookPulse)
            {
                return;
            }

            if (!forceHookPulse && !IsWowHookThreadReady())
            {
                lock (_attachSessionLock)
                {
                    if (_currentSession != null && _currentSession.ProcessId == processId)
                    {
                        var previousSnapshot = CloneSession(_currentSession);
                        _currentSession.IsAttached = true;
                        _currentSession.MemoryOpen = true;
                        _currentSession.HookReady = false;
                        _currentSession.HealthState = SessionHealthState.HookPending;
                        _currentSession.RuntimeState = "Hook未就绪";
                        _currentSession.LastError = null;
                        _currentSession.LastHeartbeatUtc = DateTime.UtcNow;
                        WriteSessionStateTransition(previousSnapshot, _currentSession, "EnsureAttachedSessionReady-skip-fault");
                    }
                }

                WriteProductAction("hook-pulse " + stage + " skip lite-refresh hook-not-ready");
                return;
            }

            EnsureOriginalHookPulse(processId, stage);

            lock (_attachSessionLock)
            {
                if (_currentSession != null && _currentSession.ProcessId == processId && IsWowHookThreadReady())
                {
                    _currentSession.SessionInitialized = true;
                    _currentSession.IsAttached = true;
                    _currentSession.MemoryOpen = true;
                    _currentSession.HookReady = true;
                    if (_currentSession.HealthState == SessionHealthState.Attaching ||
                        _currentSession.HealthState == SessionHealthState.Selected)
                    {
                        _currentSession.HealthState = SessionHealthState.HookPending;
                    }

                    _currentSession.LastHeartbeatUtc = DateTime.UtcNow;
                }
            }
        }

        private static Hook EnsureWowMemoryHook()
        {
            var hook = wManager.Wow.Memory.WowMemory;
            if (hook == null)
            {
                hook = new Hook(0, 0u, new byte[0]);
                wManager.Wow.Memory.WowMemory = hook;
            }

            if (hook.Memory == null)
            {
                throw new InvalidOperationException("WowMemory.Hook.Memory 为空");
            }

            return hook;
        }

        private void EnsureHookRuntimeObjectsInitialized(Hook hook, int processId, string stage)
        {
            try
            {
                if (hook == null || hook.Memory == null || !hook.Memory.IsValidAndOpenProcess())
                {
                    WriteProductAction("hook-runtime-init " + stage + " skip invalid-memory pid=" + processId);
                    return;
                }

                var before = DescribeHookRuntimeObjects(hook);
                var initialized = false;
                var memory = hook.Memory;
                var memoryType = memory.GetType();
                var asmField = memoryType.GetField("Asm", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (asmField != null && asmField.GetValue(memory) == null)
                {
                    var asmAssembly = memoryType.Assembly;
                    var asmType = asmAssembly.GetType("MemoryRobot.Asm", throwOnError: false);
                    if (asmType != null)
                    {
                        var asmCtor = asmType.GetConstructor(new[] { memoryType, typeof(int) });
                        if (asmCtor != null)
                        {
                            asmField.SetValue(memory, asmCtor.Invoke(new object[] { memory, 4096 }));
                            initialized = true;
                        }
                    }
                }

                var allocAssembly = hook.GetType().Assembly;
                var allocType = allocAssembly.GetType("robotManager.MemoryClass.AllocManager", throwOnError: false);
                var memoryProtectionType = memoryType.Assembly.GetType("MemoryRobot.MemoryProtection", throwOnError: false);
                var allocCtor = allocType == null || memoryProtectionType == null
                    ? null
                    : allocType.GetConstructor(new[] { typeof(int), memoryType, memoryProtectionType, typeof(bool) });

                if (allocCtor != null)
                {
                    var allocTextField = hook.GetType().GetField("AllocText", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    if (allocTextField != null && allocTextField.GetValue(hook) == null)
                    {
                        var executeReadWrite = Enum.Parse(memoryProtectionType, "ExecuteReadWrite");
                        allocTextField.SetValue(hook, allocCtor.Invoke(new object[] { 4096, memory, executeReadWrite, false }));
                        initialized = true;
                    }

                    var allocDataField = hook.GetType().GetField("AllocData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    if (allocDataField != null && allocDataField.GetValue(hook) == null)
                    {
                        var readWrite = Enum.Parse(memoryProtectionType, "ReadWrite");
                        allocDataField.SetValue(hook, allocCtor.Invoke(new object[] { 1024, memory, readWrite, false }));
                        initialized = true;
                    }
                }

                var after = DescribeHookRuntimeObjects(hook);
                WriteProductAction(
                    "hook-runtime-init " + stage +
                    " pid=" + processId +
                    " changed=" + initialized +
                    " before=" + QuoteForLog(before) +
                    " after=" + QuoteForLog(after));
            }
            catch (Exception ex)
            {
                WriteProductAction("hook-runtime-init " + stage + " failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static string DescribeHookRuntimeObjects(Hook hook)
        {
            try
            {
                if (hook == null)
                {
                    return "hook=null";
                }

                var memory = hook.Memory;
                var memoryType = memory?.GetType();
                var asmField = memoryType == null ? null : memoryType.GetField("Asm", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var asmValue = asmField == null || memory == null ? null : asmField.GetValue(memory);
                var allocTextValue = hook.GetType().GetField("AllocText", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(hook);
                var allocDataValue = hook.GetType().GetField("AllocData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(hook);

                return string.Join(
                    " ",
                    "memoryOpen=" + (memory != null && memory.IsValidAndOpenProcess()),
                    "asm=" + QuoteForLog(asmValue?.GetType().FullName),
                    "allocText=" + QuoteForLog(allocTextValue?.GetType().FullName),
                    "allocData=" + QuoteForLog(allocDataValue?.GetType().FullName),
                    "threadHooked=" + hook.ThreadHooked,
                    "retnReady=" + (!string.IsNullOrWhiteSpace(hook.RetnToHookCode)),
                    "internal=" + QuoteForLog(DescribeHookPrimeInternals(hook)));
            }
            catch (Exception ex)
            {
                return "error=" + ex.GetType().Name + ":" + ex.Message;
            }
        }

        private static string DescribeHookPrimeInternals(Hook hook)
        {
            try
            {
                if (hook == null)
                {
                    return "null";
                }

                var fieldNames = new[]
                {
                    "_000F_2007",
                    "_0005_2007",
                    "_0003_2003",
                    "_000E_2003",
                    "_0006_2009",
                    "_0002_2004",
                    "_0002_2007",
                    "_0008_2007",
                    "_0006_2007",
                    "_000F_2007",
                    "_0005_2003",
                    "_000F_2003",
                    "RetnToHookCode"
                };

                var values = fieldNames
                    .Select(name => hook.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                    .Where(field => field != null)
                    .Select(field =>
                    {
                        object value;
                        try
                        {
                            value = field.GetValue(hook);
                        }
                        catch (Exception ex)
                        {
                            value = "error:" + ex.GetType().Name;
                        }

                        string rendered;
                        if (value == null)
                        {
                            rendered = "null";
                        }
                        else if (value is uint u)
                        {
                            rendered = "0x" + u.ToString("X");
                        }
                        else if (value is int i)
                        {
                            rendered = i.ToString();
                        }
                        else if (value is bool b)
                        {
                            rendered = b.ToString();
                        }
                        else
                        {
                            rendered = value.ToString();
                        }

                        return GetHookInternalAlias(field.Name) + "=" + rendered;
                    });

                return string.Join("|", values);
            }
            catch (Exception ex)
            {
                return "error=" + ex.GetType().Name + ":" + ex.Message;
            }
        }

        private static string GetHookInternalAlias(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return "null";
            }

            switch (fieldName)
            {
                case "_0002_2003":
                    return "searchStackMaxDistance";
                case "_0002_2004":
                    return "detourAddressCtorArg";
                case "_0002_2007":
                    return "jumpOrCallEsiWrapper";
                case "_0003_2003":
                    return "lockFrameEnter";
                case "_0005_2003":
                    return "codecaveDataPtr";
                case "_0005_2007":
                    return "frameLockFlagPtr";
                case "_0006_2007":
                    return "codecaveExecPtr";
                case "_0006_2009":
                    return "noDxWorkerCompleted";
                case "_0008_2007":
                    return "jumpOrCallEsiWrapperOffset";
                case "_000E_2003":
                    return "lockFrameExit";
                case "_000F_2003":
                    return "codecaveTextPtr";
                case "_000F_2007":
                    return "detourEnabledFlagPtr";
                case "RetnToHookCode":
                    return "retnToHookCode";
                default:
                    return EscapeForLog(fieldName) + "[" + ToUnicodeLiteral(fieldName) + "]";
            }
        }

        private void TryPrimeHookPrivateInitializer(Hook hook, int processId, string stage)
        {
            try
            {
                if (hook == null || hook.Memory == null || !hook.Memory.IsValidAndOpenProcess())
                {
                    WriteProductAction("hook-prime " + stage + " skip invalid-memory pid=" + processId);
                    return;
                }

                if (hook.ThreadHooked)
                {
                    WriteProductAction("hook-prime " + stage + " skip already-hooked pid=" + processId);
                    return;
                }

                var initializer = hook.GetType()
                    .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .FirstOrDefault(method =>
                        method.ReturnType == typeof(void) &&
                        method.GetParameters().Length == 0 &&
                        (string.Equals(method.Name, "\u0002", StringComparison.Ordinal) ||
                         string.Equals(method.Name, "_0002", StringComparison.Ordinal)));
                if (initializer == null)
                {
                    WriteProductAction("hook-prime " + stage + " skip initializer-null pid=" + processId);
                    return;
                }

                WriteProductAction("hook-prime " + stage + " before " + QuoteForLog(DescribeHookRuntimeObjects(hook)));
                initializer.Invoke(hook, null);
                WriteProductAction("hook-prime " + stage + " after " + QuoteForLog(DescribeHookRuntimeObjects(hook)));
            }
            catch (TargetInvocationException ex)
            {
                var inner = ex.InnerException ?? ex;
                WriteProductAction("hook-prime " + stage + " failed " + inner.GetType().Name + ": " + inner.Message);
            }
            catch (Exception ex)
            {
                WriteProductAction("hook-prime " + stage + " failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static bool IsWowHookThreadReady()
        {
            try
            {
                var hook = wManager.Wow.Memory.WowMemory;
                return hook != null &&
                       hook.Memory != null &&
                       hook.Memory.IsValidAndOpenProcess() &&
                       hook.ThreadHooked &&
                       !string.IsNullOrWhiteSpace(hook.RetnToHookCode);
            }
            catch
            {
                return false;
            }
        }

        private void EnsureOriginalHookPulse(int processId, string stage)
        {
            try
            {
                if (processId <= 0)
                {
                    WriteProductAction("hook-pulse " + stage + " skip invalid-process");
                    return;
                }

                if (IsWowHookThreadReady())
                {
                    WriteProductAction("hook-pulse " + stage + " skip already-ready");
                    return;
                }

                ApplyHookBridgeArguments(processId);
                WriteProductAction("hook-field-catalog " + stage + " " + BuildHookFieldCatalog(processId, "before"));
                WriteProductAction("hook-pulse " + stage + " state-before " + BuildHookActivationSnapshot(processId, "before"));
                WriteProductAction("nodx-snapshot " + stage + " before " + BuildNoDxSnapshot(processId, "before"));
                WriteProductAction("nodx-diagnostic " + stage + " before " + BuildNoDxScanDiagnostic(processId, "before"));
                WriteProductAction("hook-inject-probe " + stage + " before " + ProbeHookInjectGate(processId, "before"));
                WriteProductAction("hook-pulse " + stage + " begin pid=" + processId);
                wManager.Pulsator.Pulse(processId);
                var ready = WaitForHookThreadReady(2500, 100);
                if (!ready)
                {
                    WriteProductAction("nodx-starter " + stage + " before " + BuildNoDxSnapshot(processId, "starter-before"));
                    TryStartNoDxWorker(processId, stage);
                    WriteProductAction("nodx-starter " + stage + " after-start " + BuildNoDxSnapshot(processId, "starter-after"));
                    WriteProductAction("nodx-diagnostic " + stage + " after-start " + BuildNoDxScanDiagnostic(processId, "after-start"));
                    WriteProductAction("hook-pulse " + stage + " state-after-start " + BuildHookActivationSnapshot(processId, "after-start"));
                    ready = WaitForHookThreadReady(5000, 100);
                }
                if (!ready)
                {
                    if (IsLaunchBotBridgeEnabled())
                    {
                        ready = TryLaunchBotBridge(processId, stage);
                    }
                    else
                    {
                        WriteProductAction("launchbot-bridge " + stage + " skip disabled");
                    }
                }
                WriteProductAction("nodx-snapshot " + stage + " after " + BuildNoDxSnapshot(processId, "after"));
                WriteProductAction("nodx-diagnostic " + stage + " after " + BuildNoDxScanDiagnostic(processId, "after"));
                WriteProductAction("hook-inject-probe " + stage + " after " + ProbeHookInjectGate(processId, "after"));
                WriteProductAction("hook-pulse " + stage + " state-after " + BuildHookActivationSnapshot(processId, "after"));
                WriteProductAction("hook-field-catalog " + stage + " " + BuildHookFieldCatalog(processId, "after"));
                WriteProductAction("hook-pulse " + stage + " end ready=" + ready);
            }
            catch (Exception ex)
            {
                WriteProductAction("hook-pulse " + stage + " failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void TryStartNoDxWorker(int processId, string stage)
        {
            try
            {
                var assembly = typeof(wManager.Pulsator).Assembly;
                var nodxType = ResolveNoDxWorkerType(assembly);
                if (nodxType == null)
                {
                    WriteProductAction("nodx-starter " + stage + " skip type-null pid=" + processId);
                    return;
                }

                var flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
                var starter = nodxType
                    .GetMethods(flags)
                    .Where(method => method.ReturnType == typeof(void) && method.GetParameters().Length == 0)
                    .FirstOrDefault(IsNoDxStarterMethod);
                if (starter == null)
                {
                    WriteProductAction(
                        "nodx-starter " + stage +
                        " skip starter-null type=" + QuoteForLog(nodxType.FullName ?? nodxType.Name) +
                        " candidates=" + QuoteForLog(DescribeNoDxStarterCandidates(nodxType)));
                    return;
                }

                starter.Invoke(null, null);
                WriteProductAction(
                    "nodx-starter " + stage +
                    " invoked type=" + QuoteForLog(nodxType.FullName ?? nodxType.Name) +
                    " method=" + QuoteForLog(EscapeForLog(starter.Name)) +
                    " pid=" + processId);
            }
            catch (TargetInvocationException ex)
            {
                var inner = ex.InnerException ?? ex;
                WriteProductAction("nodx-starter " + stage + " failed " + inner.GetType().Name + ": " + inner.Message);
            }
            catch (Exception ex)
            {
                WriteProductAction("nodx-starter " + stage + " failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private string ProbeHookInjectGate(int processId, string label)
        {
            try
            {
                var hook = wManager.Wow.Memory.WowMemory;
                if (hook == null)
                {
                    return "label=" + label + " pid=" + processId + " hookNull=True";
                }

                if (hook.Memory == null || !hook.Memory.IsValidAndOpenProcess())
                {
                    return "label=" + label + " pid=" + processId + " memoryOpen=False";
                }

                EnsureHookRuntimeObjectsInitialized(hook, processId, "inject-probe-" + label);
                TryPrimeHookPrivateInitializer(hook, processId, "inject-probe-" + label);
                WriteProductAction("stealth-install-probe " + label + " before " + ProbeStealthInstallGate(hook, processId, "before"));

                uint baseCodecave;
                uint injectionStart;
                var beforeThreadHooked = hook.ThreadHooked;
                var ok = hook.Inject(new[] { "nop", "retn" }, out baseCodecave, out injectionStart);
                var afterThreadHooked = hook.ThreadHooked;
                WriteProductAction("stealth-install-probe " + label + " after " + ProbeStealthInstallGate(hook, processId, "after"));

                try
                {
                    if (ok && baseCodecave != 0 && hook.AllocText != null)
                    {
                        hook.AllocText.Free(baseCodecave);
                    }
                }
                catch
                {
                }

                return "label=" + label +
                       " pid=" + processId +
                       " ok=" + ok +
                       " baseCodecave=0x" + baseCodecave.ToString("X") +
                       " injectionStart=0x" + injectionStart.ToString("X") +
                       " beforeThreadHooked=" + beforeThreadHooked +
                       " afterThreadHooked=" + afterThreadHooked +
                       " detourInUse=" + SafeGetDetourInUse(hook) +
                       " detourAddress=0x" + SafeGetDetourAddress(processId).ToString("X");
            }
            catch (Exception ex)
            {
                return "label=" + label + " pid=" + processId + " error=" + ex.GetType().Name + ":" + ex.Message;
            }
        }

        private string ProbeStealthInstallGate(Hook hook, int processId, string stage)
        {
            try
            {
                if (hook == null)
                {
                    return "stage=" + stage + " pid=" + processId + " hookNull=True";
                }

                var hookType = hook.GetType();
                var stealthField = hookType
                    .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .FirstOrDefault(field => string.Equals(field.FieldType.FullName, "robotManager.MemoryClass.StealthProtection", StringComparison.Ordinal));
                var stealthBefore = stealthField == null ? null : stealthField.GetValue(hook);
                var installMethod = hookType.GetMethod("InstallStealthProtection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (installMethod == null)
                {
                    return "stage=" + stage + " pid=" + processId + " installMethod=False stealth=" + QuoteForLog(DescribeStealthInstance(stealthBefore));
                }

                var result = installMethod.Invoke(hook, null);
                var stealthAfter = stealthField == null ? stealthBefore : stealthField.GetValue(hook);
                return "stage=" + stage +
                       " pid=" + processId +
                       " result=" + (result == null ? "null" : result.ToString()) +
                       " beforeStealth=" + QuoteForLog(DescribeStealthInstance(stealthBefore)) +
                       " afterStealth=" + QuoteForLog(DescribeStealthInstance(stealthAfter)) +
                       " threadHooked=" + hook.ThreadHooked +
                       " detourInUse=" + SafeGetDetourInUse(hook);
            }
            catch (TargetInvocationException ex)
            {
                var inner = ex.InnerException ?? ex;
                return "stage=" + stage + " pid=" + processId + " error=" + inner.GetType().Name + ":" + inner.Message;
            }
            catch (Exception ex)
            {
                return "stage=" + stage + " pid=" + processId + " error=" + ex.GetType().Name + ":" + ex.Message;
            }
        }

        private static string DescribeStealthInstance(object stealth)
        {
            try
            {
                if (stealth == null)
                {
                    return "null";
                }

                var type = stealth.GetType();
                var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(field =>
                        field.FieldType == typeof(bool) ||
                        field.FieldType == typeof(uint) ||
                        string.Equals(field.FieldType.FullName, "robotManager.MemoryClass.Hook", StringComparison.Ordinal) ||
                        string.Equals(field.FieldType.FullName, "MemoryRobot.Memory", StringComparison.Ordinal))
                    .Select(field =>
                    {
                        object value;
                        try
                        {
                            value = field.GetValue(stealth);
                        }
                        catch (Exception ex)
                        {
                            value = "error:" + ex.GetType().Name;
                        }

                        var rendered = value == null
                            ? "null"
                            : value is uint u
                                ? "0x" + u.ToString("X")
                                : value is bool b
                                    ? b.ToString()
                                    : value.GetType().FullName;
                        return EscapeForLog(field.Name) + "=" + rendered;
                    });

                return type.FullName + "{" + string.Join("|", fields) + "}";
            }
            catch (Exception ex)
            {
                return "error=" + ex.GetType().Name + ":" + ex.Message;
            }
        }

        private static string DescribeNoDxStarterCandidates(Type nodxType)
        {
            try
            {
                if (nodxType == null)
                {
                    return "type-null";
                }

                var flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
                return string.Join(
                    "|",
                    nodxType
                        .GetMethods(flags)
                        .Where(method => method.ReturnType == typeof(void) && method.GetParameters().Length == 0)
                        .Select(method => EscapeForLog(method.Name))
                        .OrderBy(name => name, StringComparer.Ordinal)
                        .ToArray());
            }
            catch (Exception ex)
            {
                return "error=" + ex.GetType().Name + ": " + ex.Message;
            }
        }

        private static bool IsNoDxStarterMethod(MethodInfo method)
        {
            if (method == null || method.ReturnType != typeof(void) || method.GetParameters().Length != 0)
            {
                return false;
            }

            return string.Equals(method.Name, "\u0002", StringComparison.Ordinal) ||
                   string.Equals(method.Name, "_0002", StringComparison.Ordinal);
        }

        private static string EscapeForLog(string value)
        {
            if (value == null)
            {
                return "null";
            }

            var builder = new StringBuilder(value.Length);
            foreach (var ch in value)
            {
                if (char.IsControl(ch))
                {
                    builder.Append("\\u");
                    builder.Append(((int)ch).ToString("X4"));
                }
                else
                {
                    builder.Append(ch);
                }
            }

            return builder.ToString();
        }

        private static bool IsLaunchBotBridgeEnabled()
        {
            try
            {
                var raw = Environment.GetEnvironmentVariable("WR_ENABLE_LAUNCHBOT_BRIDGE");
                if (string.IsNullOrWhiteSpace(raw))
                {
                    return false;
                }

                raw = raw.Trim();
                return string.Equals(raw, "1", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(raw, "true", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(raw, "yes", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(raw, "on", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private bool TryLaunchBotBridge(int processId, string stage)
        {
            try
            {
                var args = robotManager.Helpful.ArgsParser.GetArgs;
                if (args == null)
                {
                    WriteProductAction("launchbot-bridge " + stage + " skip args-null");
                    return false;
                }

                var preAudit = BuildLaunchBotSideEffectSnapshot("launchbot-pre", processId);
                WriteProductAction("launchbot-bridge " + stage + " before " + BuildHookActivationSnapshot(processId, "launchbot-before"));
                WriteProductAction("launchbot-bridge " + stage + " audit-before " + preAudit);
                var result = wManager.Information.LaunchBot(string.Empty, args, false);
                var ready = WaitForHookThreadReady(3000, 100);
                var postAudit = BuildLaunchBotSideEffectSnapshot("launchbot-post", processId);
                WriteProductAction(
                    "launchbot-bridge " + stage +
                    " result=" + result +
                    " ready=" + ready +
                    " after " + BuildHookActivationSnapshot(processId, "launchbot-after"));
                WriteProductAction("launchbot-bridge " + stage + " audit-after " + postAudit);
                return ready;
            }
            catch (Exception ex)
            {
                WriteProductAction("launchbot-bridge " + stage + " failed " + ex.GetType().Name + ": " + ex.Message);
                return false;
            }
        }

        private void ApplyHookBridgeArguments(int processId)
        {
            try
            {
                var args = BuildHookBridgeArgs(processId);
                if (args == null)
                {
                    WriteProductAction("hook-args apply skip args-null");
                    return;
                }

                robotManager.Helpful.ArgsParser.GetArgs = args;
                PublishArgsEnvironmentSnapshot(args);

                WriteProductAction("assembly-snapshot hook-args " + BuildInterestingAssemblySnapshot("hook-args"));
                WriteProductAction("hook-args apply " + BuildHookActivationSnapshot(processId, "args-applied"));
            }
            catch (Exception ex)
            {
                WriteProductAction("hook-args apply failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static robotManager.Helpful.Args BuildHookBridgeArgs(int processId)
        {
            var current = robotManager.Helpful.ArgsParser.GetArgs;
            var args = new robotManager.Helpful.Args();
            if (current != null)
            {
                CopyWritableArgumentMembers(current, args);
            }

            args.ProcessId = processId;
            args.Product = "WRotation";
            args.NoDx = true;
            args.Dx = false;
            args.NoLockFrame = true;
            args.LockFrame = false;
            args.LogInject = true;
            args.BPHOOK = true;
            args.AutoAttachAndLog = false;
            args.LicenseKey = string.Empty;
            return args;
        }

        private static void CopyWritableArgumentMembers(object source, object destination)
        {
            if (source == null || destination == null)
            {
                return;
            }

            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            foreach (var field in source.GetType().GetFields(flags))
            {
                try
                {
                    var targetField = destination.GetType().GetField(field.Name, flags);
                    if (targetField != null && targetField.FieldType == field.FieldType)
                    {
                        targetField.SetValue(destination, field.GetValue(source));
                    }
                }
                catch
                {
                }
            }
        }

        private static void PublishArgsEnvironmentSnapshot(robotManager.Helpful.Args args)
        {
            try
            {
                var envName = robotManager.robotManagerGlobalSetting.CurrentSetting?.ArgsEnvironmentVariables;
                if (string.IsNullOrWhiteSpace(envName))
                {
                    return;
                }

                var payload = SerializeArgsPayload(args);
                if (string.IsNullOrWhiteSpace(payload))
                {
                    return;
                }
                Environment.SetEnvironmentVariable(envName, payload);
            }
            catch
            {
            }
        }

        private static string SerializeArgsPayload(robotManager.Helpful.Args args)
        {
            try
            {
                var jsonType = AppDomain.CurrentDomain.GetAssemblies()
                    .Select(assembly => assembly.GetType("Newtonsoft.Json.JsonConvert", throwOnError: false))
                    .FirstOrDefault(type => type != null);
                if (jsonType == null)
                {
                    return null;
                }

                var serializeMethod = jsonType.GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .FirstOrDefault(method =>
                        string.Equals(method.Name, "SerializeObject", StringComparison.Ordinal) &&
                        method.GetParameters().Length == 1);
                if (serializeMethod == null)
                {
                    return null;
                }

                return serializeMethod.Invoke(null, new object[] { args }) as string;
            }
            catch
            {
                return null;
            }
        }

        private static void SetArgumentMember(object target, string memberName, object value)
        {
            if (target == null || string.IsNullOrWhiteSpace(memberName))
            {
                return;
            }

            var type = target.GetType();
            var property = type.GetProperty(memberName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (property != null && property.CanWrite)
            {
                property.SetValue(target, value, null);
                return;
            }

            var field = type.GetField(memberName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null)
            {
                field.SetValue(target, value);
            }
        }

        private bool WaitForHookThreadReady(int timeoutMs, int pollMs)
        {
            var startedAt = Environment.TickCount;
            while (Environment.TickCount - startedAt < timeoutMs)
            {
                if (IsWowHookThreadReady())
                {
                    return true;
                }

                Thread.Sleep(pollMs);
            }

            return IsWowHookThreadReady();
        }

        private OriginalRuntimeActionResult EnsureOriginalProductStarted()
        {
            try
            {
                var sessionGate = EvaluateSessionReadiness();
                if (!sessionGate.Ok)
                {
                    WriteProductAction("session-gate failed " + sessionGate.Message);
                    return sessionGate;
                }

                var attachResult = RefreshAttachedProcess();
                if (!attachResult.Ok)
                {
                    WriteProductAction("attach-check failed " + attachResult.Message);
                    return OriginalRuntimeActionResult.Fail("原版产品启动前进程未就绪: " + attachResult.Message);
                }

                sessionGate = EvaluateSessionReadiness();
                if (!sessionGate.Ok)
                {
                    WriteProductAction("session-gate post-refresh failed " + sessionGate.Message);
                    return sessionGate;
                }

                WriteProductAction(
                    "attach-check ok" +
                    " runtimeState=" + (attachResult.RuntimeState ?? "-") +
                    " character=" + (attachResult.CharacterName ?? "-") +
                    " hasTarget=" + (attachResult.HasTarget ?? "-"));

                var processId = GetCurrentProcessId();
                EnsureOriginalHookPulse(processId, "ensure-product-start");
                lock (_attachSessionLock)
                {
                    if (_currentSession != null && _currentSession.ProcessId > 0 && IsWowHookThreadReady())
                    {
                        _currentSession.SessionInitialized = true;
                        _currentSession.HookReady = true;
                        _currentSession.LastHeartbeatUtc = DateTime.UtcNow;
                    }
                }

                if (!IsWowHookThreadReady())
                {
                    WriteProductAction("hook-thread-check failed threadHooked=False");
                    return OriginalRuntimeActionResult.Fail("原版 Hook 线程未就绪，禁止进入战斗产品链");
                }

                WriteProductAction("hook-thread-check ok threadHooked=True");

                if (!Products.IsAliveProduct)
                {
                    var loadResult = LoadWRotationProductStepwise();
                    if (!loadResult.Ok)
                    {
                        return loadResult;
                    }
                }

                if (!Products.IsAliveProduct)
                {
                    return OriginalRuntimeActionResult.Fail("原版产品 WRotation 加载失败");
                }

                EnsureCombatPrerequisites();
                Products.InPause = false;
                EnsureOriginalProductStartGate();
                if (!Products.IsStarted && !Products.ProductStart())
                {
                    WriteProductAction("ProductStart false alive=" + Products.IsAliveProduct + " started=" + Products.IsStarted + " pause=" + Products.InPause);
                    return OriginalRuntimeActionResult.Fail("原版产品 WRotation 启动失败");
                }

                WriteProductAction("ProductStart ok alive=" + Products.IsAliveProduct + " started=" + Products.IsStarted + " pause=" + Products.InPause);
                return OriginalRuntimeActionResult.Success("原版产品 WRotation 已启动");
            }
            catch (Exception ex)
            {
                WriteProductAction("exception " + ex.GetType().Name + ": " + ex.Message);
                return OriginalRuntimeActionResult.Fail("原版产品启动链异常: " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private int GetCurrentProcessId()
        {
            lock (_attachSessionLock)
            {
                return _currentSession == null ? 0 : _currentSession.ProcessId;
            }
        }

        private OriginalRuntimeActionResult EvaluateSessionReadiness()
        {
            RuntimeSession session;
            lock (_attachSessionLock)
            {
                session = CloneSession(_currentSession);
            }

            if (session == null)
            {
                return OriginalRuntimeActionResult.Fail("尚未建立接管会话");
            }

            if (session.HealthState == SessionHealthState.Lost)
            {
                return OriginalRuntimeActionResult.Fail("接管会话已丢失，请重新选择进程");
            }

            if (session.HealthState == SessionHealthState.Faulted)
            {
                return OriginalRuntimeActionResult.Fail("接管会话故障: " + (session.LastError ?? "未知错误"));
            }

            if (!session.IsAttached)
            {
                return OriginalRuntimeActionResult.Fail("接管会话尚未附着");
            }

            if (!session.MemoryOpen)
            {
                return OriginalRuntimeActionResult.Fail("接管会话内存句柄无效");
            }

            if (!session.HookReady)
            {
                return OriginalRuntimeActionResult.Fail("接管会话 Hook 未就绪");
            }

            if (!session.InGame)
            {
                return OriginalRuntimeActionResult.Fail("角色尚未进入世界");
            }

            return OriginalRuntimeActionResult.Success("接管会话可执行");
        }

        private void UpdateSessionState(
            RuntimeSession session,
            SessionHealthState healthState,
            bool isAttached,
            bool memoryOpen,
            bool hookReady,
            string runtimeState,
            string characterName = null,
            string level = null,
            string healthPercent = null,
            string position = null)
        {
            lock (_attachSessionLock)
            {
                if (_currentSession == null || session == null || _currentSession.ProcessId != session.ProcessId)
                {
                    return;
                }

                var previousSnapshot = CloneSession(_currentSession);
                _currentSession.IsAttached = isAttached;
                _currentSession.MemoryOpen = memoryOpen;
                _currentSession.HookReady = hookReady;
                _currentSession.InGame = string.Equals(runtimeState, "游戏中", StringComparison.OrdinalIgnoreCase);
                _currentSession.RuntimeState = runtimeState;
                _currentSession.HealthState = healthState;
                _currentSession.LastError = healthState == SessionHealthState.Faulted ? runtimeState : null;
                _currentSession.CharacterName = characterName ?? _currentSession.CharacterName;
                _currentSession.Level = level ?? _currentSession.Level;
                _currentSession.HealthPercent = healthPercent ?? _currentSession.HealthPercent;
                _currentSession.Position = position ?? _currentSession.Position;
                _currentSession.LastHeartbeatUtc = DateTime.UtcNow;
                WriteSessionStateTransition(previousSnapshot, _currentSession, "UpdateSessionState");
            }
        }

        private void MarkSessionLost(RuntimeSession session, string message)
        {
            lock (_attachSessionLock)
            {
                if (_currentSession == null || session == null || _currentSession.ProcessId != session.ProcessId)
                {
                    return;
                }

                var previousSnapshot = CloneSession(_currentSession);
                _currentSession.IsAttached = false;
                _currentSession.SessionInitialized = false;
                _currentSession.MemoryOpen = false;
                _currentSession.HookReady = false;
                _currentSession.InGame = false;
                _currentSession.HealthState = SessionHealthState.Lost;
                _currentSession.LastError = message;
                _currentSession.LastHeartbeatUtc = DateTime.UtcNow;
                WriteSessionStateTransition(previousSnapshot, _currentSession, "MarkSessionLost");
            }
        }

        private void WriteSessionStateTransition(RuntimeSession previous, RuntimeSession current, string source)
        {
            try
            {
                if (current == null)
                {
                    return;
                }

                if (previous != null &&
                    previous.HealthState == current.HealthState &&
                    previous.IsAttached == current.IsAttached &&
                    previous.MemoryOpen == current.MemoryOpen &&
                    previous.HookReady == current.HookReady &&
                    previous.InGame == current.InGame &&
                    string.Equals(previous.RuntimeState, current.RuntimeState, StringComparison.Ordinal) &&
                    string.Equals(previous.LastError, current.LastError, StringComparison.Ordinal))
                {
                    return;
                }

                WriteProductAction(
                    "session-state-transition" +
                    " source=" + source +
                    " pid=" + current.ProcessId +
                    " fromHealth=" + (previous == null ? "null" : previous.HealthState.ToString()) +
                    " toHealth=" + current.HealthState +
                    " fromAttached=" + (previous == null ? "null" : previous.IsAttached.ToString()) +
                    " toAttached=" + current.IsAttached +
                    " fromMemory=" + (previous == null ? "null" : previous.MemoryOpen.ToString()) +
                    " toMemory=" + current.MemoryOpen +
                    " fromHook=" + (previous == null ? "null" : previous.HookReady.ToString()) +
                    " toHook=" + current.HookReady +
                    " fromInGame=" + (previous == null ? "null" : previous.InGame.ToString()) +
                    " toInGame=" + current.InGame +
                    " runtime=" + (current.RuntimeState ?? "null") +
                    " error=" + (current.LastError ?? "null"));
            }
            catch
            {
            }
        }

        private static RuntimeSession CloneSession(RuntimeSession session)
        {
            if (session == null)
            {
                return null;
            }

            return new RuntimeSession(session.ProcessId)
            {
                IsAttached = session.IsAttached,
                SessionInitialized = session.SessionInitialized,
                MemoryOpen = session.MemoryOpen,
                HookReady = session.HookReady,
                InGame = session.InGame,
                CharacterName = session.CharacterName,
                Level = session.Level,
                HealthPercent = session.HealthPercent,
                Position = session.Position,
                RuntimeState = session.RuntimeState,
                LastError = session.LastError,
                HealthState = session.HealthState,
                LastHeartbeatUtc = session.LastHeartbeatUtc
            };
        }

        private OriginalRuntimeActionResult LoadWRotationProductStepwise()
        {
            try
            {
                var productPath = Path.Combine(_runtimeRoot, "Products", "WRotation.dll");
                WriteProductAction("Assembly.LoadFrom begin " + productPath);
                var assembly = Assembly.LoadFrom(productPath);
                WriteProductAction("Assembly.LoadFrom end " + assembly.FullName);

                WriteProductAction("CreateInstance begin Main");
                var instance = assembly.CreateInstance("Main", ignoreCase: false);
                WriteProductAction("CreateInstance end null=" + (instance == null));

                var product = instance as IProduct;
                if (product == null)
                {
                    return OriginalRuntimeActionResult.Fail("WRotation Main 不是 IProduct");
                }

                SetProductsStaticFieldByType(typeof(Assembly), assembly, "assembly");
                SetProductsStaticFieldByType(typeof(IProduct), product, "product");
                SetProductsObjectInstanceField(instance);
                SetProductsProductName("WRotation");

                WriteProductAction("Initialize begin");
                product.Initialize();
                WriteProductAction("Initialize end alive=" + Products.IsAliveProduct);

                return OriginalRuntimeActionResult.Success("WRotation 已按原版 LoadProducts 分步加载");
            }
            catch (Exception ex)
            {
                WriteProductAction("stepwise exception " + ex.GetType().Name + ": " + ex.Message);
                return OriginalRuntimeActionResult.Fail("WRotation 分步加载异常: " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void EnsureCombatPrerequisites()
        {
            try
            {
                wManagerSetting.Load(loadBlacklist: false);
                WriteProductAction("combat-prereq settings-load ok");
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq settings-load failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                RestorePreferredFightClassSelection();
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq fightclass-restore failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                NormalizeBattleModeGeneralSettings();
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq general-setting-normalize failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                NormalizeBattleModeWRotationSettings();
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq wrotation-setting-normalize failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                RefreshBattleModeBlacklistSession();
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq blacklist-session-refresh failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                SpellListManager.LoadSpellListe();
                SpellManager.SpellBook();
                WriteProductAction("combat-prereq spell-cache ok");
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq spell-cache failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                var continentNameMpq = Usefuls.ContinentNameMpq;
                if (!string.IsNullOrWhiteSpace(continentNameMpq))
                {
                    PathFinder.InitPather(continentNameMpq);
                    WriteProductAction("combat-prereq pathfinder-init ok continent=" + continentNameMpq);
                }
                else
                {
                    WriteProductAction("combat-prereq pathfinder-init skip continent-empty");
                }
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq pathfinder-init failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                if (!CustomClass.IsAliveCustomClass)
                {
                    CustomClass.LoadCustomClass();
                }

                WriteProductAction(
                    "combat-prereq customclass alive=" + CustomClass.IsAliveCustomClass +
                    " selected=" + (wManagerSetting.CurrentSetting?.CustomClass ?? "null"));
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq customclass-load failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                PersistBattleModeSettingsSnapshot();
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq setting-persist failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void RestorePreferredFightClassSelection()
        {
            var currentSetting = wManagerSetting.CurrentSetting;
            if (currentSetting == null)
            {
                WriteProductAction("combat-prereq fightclass-restore skip current-setting-null");
                return;
            }

            var selected = currentSetting.CustomClass;
            if (LooksUsableFightClass(selected))
            {
                WriteProductAction("combat-prereq fightclass-restore keep " + selected);
                return;
            }

            var fallback = PickFallbackFightClass();
            if (string.IsNullOrWhiteSpace(fallback))
            {
                WriteProductAction("combat-prereq fightclass-restore skip no-fallback");
                return;
            }

            currentSetting.CustomClass = fallback;
            currentSetting.Save(writeInLog: false, reloadBlackList: false);
            WriteProductAction("combat-prereq fightclass-restore fallback " + fallback);
        }

        private void NormalizeBattleModeGeneralSettings()
        {
            var currentSetting = wManagerSetting.CurrentSetting;
            if (currentSetting == null)
            {
                WriteProductAction("combat-prereq general-setting-normalize skip current-setting-null");
                return;
            }

            var changed = false;

            if (currentSetting.BlackListTrainingDummy)
            {
                currentSetting.BlackListTrainingDummy = false;
                changed = true;
                WriteProductAction("combat-prereq general-setting-normalize BlackListTrainingDummy True=>False");
            }

            if (currentSetting.BlackListIfNotCompletePath)
            {
                currentSetting.BlackListIfNotCompletePath = false;
                changed = true;
                WriteProductAction("combat-prereq general-setting-normalize BlackListIfNotCompletePath True=>False");
            }

            if (!currentSetting.UseCTM)
            {
                currentSetting.UseCTM = true;
                changed = true;
                WriteProductAction("combat-prereq general-setting-normalize UseCTM False=>True");
            }

            if (changed)
            {
                currentSetting.Save(writeInLog: false, reloadBlackList: false);
            }
            else
            {
                WriteProductAction("combat-prereq general-setting-normalize keep");
            }
        }

        private void NormalizeBattleModeWRotationSettings()
        {
            var wrotationAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(assembly => string.Equals(assembly.GetName().Name, "WRotation", StringComparison.OrdinalIgnoreCase));
            var settingType = wrotationAssembly?.GetType("WRotation.Bot.WRotationSetting", throwOnError: false);
            var currentSettingProperty = settingType?.GetProperty("CurrentSetting", BindingFlags.Static | BindingFlags.Public);
            var currentSetting = currentSettingProperty?.GetValue(null);
            if (currentSetting == null || settingType == null)
            {
                WriteProductAction("combat-prereq wrotation-setting-normalize skip current-setting-null");
                return;
            }

            var changed = false;

            changed |= SetBoolFieldIfDifferent(settingType, currentSetting, "ManageMovement", true, "combat-prereq wrotation-setting-normalize");
            changed |= SetBoolFieldIfDifferent(settingType, currentSetting, "AttackAll", true, "combat-prereq wrotation-setting-normalize");
            changed |= SetBoolFieldIfDifferent(settingType, currentSetting, "AttackOnlyIfFlaggedInCombat", false, "combat-prereq wrotation-setting-normalize");
            changed |= SetBoolFieldIfDifferent(settingType, currentSetting, "DisableCTM", false, "combat-prereq wrotation-setting-normalize");

            if (!changed)
            {
                WriteProductAction("combat-prereq wrotation-setting-normalize keep");
            }
        }

        private bool SetBoolFieldIfDifferent(Type ownerType, object instance, string fieldName, bool expectedValue, string stage)
        {
            var field = ownerType.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public);
            if (field == null || field.FieldType != typeof(bool))
            {
                WriteProductAction(stage + " " + fieldName + " missing");
                return false;
            }

            var currentValue = (bool)field.GetValue(instance);
            if (currentValue == expectedValue)
            {
                return false;
            }

            field.SetValue(instance, expectedValue);
            WriteProductAction(stage + " " + fieldName + " " + currentValue + "=>" + expectedValue);
            return true;
        }

        private void PersistBattleModeSettingsSnapshot()
        {
            var persisted = false;

            try
            {
                var currentSetting = wManagerSetting.CurrentSetting;
                if (currentSetting != null)
                {
                    currentSetting.Save(writeInLog: false, reloadBlackList: false);
                    persisted = true;
                    WriteProductAction("combat-prereq setting-persist general ok");
                }
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq setting-persist general failed " + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                var wrotationAssembly = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(assembly => string.Equals(assembly.GetName().Name, "WRotation", StringComparison.OrdinalIgnoreCase));
                var settingType = wrotationAssembly?.GetType("WRotation.Bot.WRotationSetting", throwOnError: false);
                var currentSettingProperty = settingType?.GetProperty("CurrentSetting", BindingFlags.Static | BindingFlags.Public);
                var currentSetting = currentSettingProperty?.GetValue(null);
                var saveMethod = settingType?.GetMethod("Save", BindingFlags.Instance | BindingFlags.Public, null, Type.EmptyTypes, null);

                if (currentSetting != null && saveMethod != null)
                {
                    saveMethod.Invoke(currentSetting, null);
                    persisted = true;
                    WriteProductAction("combat-prereq setting-persist wrotation ok");
                }
                else
                {
                    WriteProductAction("combat-prereq setting-persist wrotation skip");
                }
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq setting-persist wrotation failed " + ex.GetType().Name + ": " + ex.Message);
            }

            if (!persisted)
            {
                WriteProductAction("combat-prereq setting-persist skip");
            }
        }

        private void RefreshBattleModeBlacklistSession()
        {
            BlackListSerializable.AddBlackListToWRobotSession();
            WriteProductAction(
                "combat-prereq blacklist-session-refresh ok" +
                " trainingDummy=" + wManagerSetting.CurrentSetting?.BlackListTrainingDummy +
                " usePathFinder=" + wManagerSetting.CurrentSetting?.UsePathsFinder +
                " blacklistIfNoPath=" + wManagerSetting.CurrentSetting?.BlackListIfNotCompletePath);
        }

        private bool LooksUsableFightClass(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                return false;
            }

            var fullPath = Path.Combine(_runtimeRoot, "FightClass", relativePath);
            return File.Exists(fullPath);
        }

        private string PickFallbackFightClass()
        {
            try
            {
                var settings = wManagerSetting.CurrentSetting;
                var me = ObjectManager.Me;
                var candidates = Directory.Exists(Path.Combine(_runtimeRoot, "FightClass"))
                    ? Directory.EnumerateFiles(Path.Combine(_runtimeRoot, "FightClass"), "*.*", SearchOption.TopDirectoryOnly)
                        .Where(path =>
                        {
                            var ext = Path.GetExtension(path);
                            return ext.Equals(".xml", StringComparison.OrdinalIgnoreCase) ||
                                   ext.Equals(".cs", StringComparison.OrdinalIgnoreCase) ||
                                   ext.Equals(".dll", StringComparison.OrdinalIgnoreCase);
                        })
                        .Select(Path.GetFileName)
                        .Where(name => !string.IsNullOrWhiteSpace(name))
                        .ToList()
                    : new System.Collections.Generic.List<string>();

                if (candidates.Count == 0)
                {
                    return string.Empty;
                }

                var byExistingSetting = candidates.FirstOrDefault(name =>
                    !string.IsNullOrWhiteSpace(settings?.CustomClass) &&
                    string.Equals(name, settings.CustomClass, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrWhiteSpace(byExistingSetting))
                {
                    return byExistingSetting;
                }

                var classHints = new[]
                {
                    me?.WowClass.ToString(),
                    me?.WowClass.ToString().Replace("_", string.Empty)
                }
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .ToArray();

                foreach (var hint in classHints)
                {
                    var match = candidates.FirstOrDefault(name =>
                        name.IndexOf(hint, StringComparison.OrdinalIgnoreCase) >= 0);
                    if (!string.IsNullOrWhiteSpace(match))
                    {
                        return match;
                    }
                }

                return candidates
                    .OrderBy(name => Path.GetExtension(name).Equals(".xml", StringComparison.OrdinalIgnoreCase) ? 0 :
                                     Path.GetExtension(name).Equals(".cs", StringComparison.OrdinalIgnoreCase) ? 1 : 2)
                    .ThenBy(name => name.Length)
                    .ThenBy(name => name, StringComparer.OrdinalIgnoreCase)
                    .FirstOrDefault() ?? string.Empty;
            }
            catch (Exception ex)
            {
                WriteProductAction("combat-prereq fightclass-pick failed " + ex.GetType().Name + ": " + ex.Message);
                return string.Empty;
            }
        }

        private void EnsureOriginalProductStartGate()
        {
            var key = DecodeRobotManagerString(-1548820698);
            var set = Var.SetVar(key, true);
            var value = Var.GetVar<bool>(key);
            WriteProductAction("ProductStart gate key=" + key + " set=" + set + " value=" + value);
        }

        private static string DecodeRobotManagerString(int id)
        {
            foreach (var decoderType in typeof(Products).Assembly.GetTypes())
            {
                var hasStringCache = decoderType
                    .GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                    .Any(field => field.FieldType.FullName != null &&
                                  field.FieldType.FullName.StartsWith("System.Collections.Concurrent.ConcurrentDictionary`2", StringComparison.Ordinal) &&
                                  field.FieldType.GetGenericArguments().Length == 2 &&
                                  field.FieldType.GetGenericArguments()[0] == typeof(int) &&
                                  field.FieldType.GetGenericArguments()[1] == typeof(string));
                if (!hasStringCache)
                {
                    continue;
                }

                var decoder = decoderType
                    .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                    .FirstOrDefault(method =>
                    {
                        var parameters = method.GetParameters();
                        return method.ReturnType == typeof(string) &&
                               parameters.Length == 1 &&
                               parameters[0].ParameterType == typeof(int);
                    });
                if (decoder == null)
                {
                    continue;
                }

                var value = (string)decoder.Invoke(null, new object[] { id });
                if (!string.IsNullOrWhiteSpace(value))
                {
                    return value;
                }
            }

            throw new MissingMethodException(typeof(Products).Assembly.FullName, "string decoder(int)");
        }

        private static void SetProductsStaticFieldByType(Type fieldType, object value, string label)
        {
            var field = typeof(Products)
                .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                .FirstOrDefault(candidate => candidate.FieldType == fieldType && !candidate.IsInitOnly);
            if (field == null)
            {
                throw new MissingFieldException(typeof(Products).FullName, label + ":" + fieldType.FullName);
            }

            field.SetValue(null, value);
        }

        private static void SetProductsObjectInstanceField(object value)
        {
            var field = typeof(Products)
                .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                .FirstOrDefault(candidate => candidate.FieldType == typeof(object) && !candidate.IsInitOnly);
            if (field != null)
            {
                field.SetValue(null, value);
            }
        }

        private static void SetProductsProductName(string value)
        {
            var field = typeof(Products)
                .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                .FirstOrDefault(candidate => candidate.FieldType == typeof(string) && !candidate.IsInitOnly);
            if (field != null)
            {
                field.SetValue(null, value);
            }
        }

        private void WriteProductAction(string action)
        {
            try
            {
                var path = Path.Combine(_runtimeRoot, "Logs", "product-chain-actions.txt");
                File.AppendAllText(path, DateTime.Now.ToString("s") + " " + action + Environment.NewLine);
            }
            catch
            {
            }
        }

        private void WriteBattleTimeline(string stage, string details)
        {
            try
            {
                var path = Path.Combine(_runtimeRoot, "Logs", "battle-execution-timeline.txt");
                File.AppendAllText(
                    path,
                    DateTime.Now.ToString("s") + " " + stage + Environment.NewLine +
                    details + Environment.NewLine,
                    System.Text.Encoding.UTF8);
            }
            catch
            {
            }
        }

        private string BuildBattleExecutionStateSnapshot(string label)
        {
            try
            {
                var me = ObjectManager.Me;
                var target = me?.TargetObject;
                var fightTarget = Fight.CurrentTarget;
                var spellBookCount = SafeGetSpellBookCount();
                var spellBookReady = spellBookCount >= 0;
                var customClassAlive = CustomClass.IsAliveCustomClass;
                var customClassRange = SafeGetCustomClassRange();
                var targetValid = target != null && target.IsValid;
                var fightTargetValid = fightTarget != null && fightTarget.IsValid;

                return string.Join(
                    Environment.NewLine,
                    "label=" + label,
                    "product=" + (Products.ProductName ?? "null") +
                    " alive=" + Products.IsAliveProduct +
                    " started=" + Products.IsStarted +
                    " pause=" + Products.InPause,
                    "me.inGame=" + Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause +
                    " me.inCombat=" + me?.InCombat +
                    " me.moving=" + me?.GetMove +
                    " me.casting=" + me?.IsCast +
                    " me.hasTarget=" + me?.HasTarget +
                    " me.ctm=" + ClickToMove.GetClickToMoveTypePush() +
                    " me.ctmInMove=" + ClickToMove.InMove,
                    "target.valid=" + targetValid +
                    " target.name=" + (targetValid ? target.Name : "-") +
                    " target.guid=" + (targetValid ? target.Guid.ToString() : "0") +
                    " target.distance=" + (targetValid ? target.GetDistance.ToString("0.00") : "-") +
                    " target.attackable=" + (targetValid ? target.IsAttackable.ToString() : "-") +
                    " target.dead=" + (targetValid ? target.IsDead.ToString() : "-") +
                    " target.myTarget=" + (targetValid ? target.IsMyTarget.ToString() : "-") +
                    " target.inCombatWithMe=" + (targetValid ? target.InCombatWithMe.ToString() : "-"),
                    "fight.inFight=" + Fight.InFight +
                    " fight.currentTargetValid=" + fightTargetValid +
                    " fight.currentTarget=" + (fightTargetValid ? fightTarget.Name : "-") +
                    " fight.currentGuid=" + (fightTargetValid ? fightTarget.Guid.ToString() : "0") +
                    " fight.combatMs=" + Fight.CombatStartSince,
                    "customClass.alive=" + customClassAlive +
                    " customClass.range=" + customClassRange.ToString("0.00") +
                    " selected=" + (wManagerSetting.CurrentSetting?.CustomClass ?? "null"),
                    "spellBook.ready=" + spellBookReady +
                    " spellBook.count=" + spellBookCount +
                    " pathfinder.use=" + (wManagerSetting.CurrentSetting?.UsePathsFinder.ToString() ?? "null") +
                    " blacklistIfNoPath=" + (wManagerSetting.CurrentSetting?.BlackListIfNotCompletePath.ToString() ?? "null"));
            }
            catch (Exception ex)
            {
                return "label=" + label + Environment.NewLine +
                       "snapshot-error=" + ex.GetType().Name + ": " + ex.Message;
            }
        }

        private static int SafeGetSpellBookCount()
        {
            try
            {
                var spells = SpellManager.SpellBook();
                return spells?.Count ?? 0;
            }
            catch
            {
                return -1;
            }
        }

        private static float SafeGetCustomClassRange()
        {
            try
            {
                return CustomClass.GetRange;
            }
            catch
            {
                return -1f;
            }
        }

        private static string BuildHookActivationSnapshot(int processId, string label)
        {
            try
            {
                var hook = wManager.Wow.Memory.WowMemory;
                var args = robotManager.Helpful.ArgsParser.GetArgs;
                var memory = hook?.Memory;
                var memoryOpen = memory != null && memory.IsValidAndOpenProcess();
                var detourAddress = SafeGetDetourAddress(processId);
                var originalOpCodeLength = SafeGetOriginalOpCodeLength(processId);
                var detourInUse = SafeGetDetourInUse(hook);
                var hookType = hook == null ? "null" : hook.GetType().FullName;
                var memoryType = memory == null ? "null" : memory.GetType().FullName;
                var nonPublicSnapshot = SafeDescribeHookInternals(hook);

                return string.Join(
                    " ",
                    "label=" + label,
                    "pid=" + processId,
                    "memoryOpen=" + memoryOpen,
                    "hookType=" + QuoteForLog(hookType),
                    "memoryType=" + QuoteForLog(memoryType),
                    "hookNull=" + (hook == null),
                    "threadHooked=" + (hook?.ThreadHooked.ToString() ?? "null"),
                    "retnReady=" + (!string.IsNullOrWhiteSpace(hook?.RetnToHookCode)),
                    "detourInUse=" + detourInUse,
                    "detourAddress=0x" + detourAddress.ToString("X"),
                    "originalOpCodeLength=" + originalOpCodeLength,
                    "hookInternal=" + QuoteForLog(nonPublicSnapshot),
                    "args.processId=" + (args?.ProcessId.ToString() ?? "null"),
                    "args.product=" + QuoteForLog(args?.Product),
                    "args.noDx=" + (args?.NoDx.ToString() ?? "null"),
                    "args.dx=" + (args?.Dx.ToString() ?? "null"),
                    "args.bpHook=" + (args?.BPHOOK.ToString() ?? "null"),
                    "args.lockFrame=" + (args?.LockFrame.ToString() ?? "null"),
                    "args.noLockFrame=" + (args?.NoLockFrame.ToString() ?? "null"),
                    "args.autoStart=" + (args?.AutoStart.ToString() ?? "null"),
                    "args.logInject=" + (args?.LogInject.ToString() ?? "null"),
                    "args.autoAttachAndLog=" + (args?.AutoAttachAndLog.ToString() ?? "null"));
            }
            catch (Exception ex)
            {
                return "label=" + label + " snapshot-error=" + ex.GetType().Name + ": " + ex.Message;
            }
        }

        private static string BuildHookFieldCatalog(int processId, string label)
        {
            try
            {
                var hook = wManager.Wow.Memory.WowMemory;
                if (hook == null)
                {
                    return "label=" + label + " pid=" + processId + " hook=null";
                }

                var entries = hook.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .OrderBy(field => field.MetadataToken)
                    .Select(field =>
                    {
                        object value;
                        try
                        {
                            value = field.GetValue(hook);
                        }
                        catch (Exception ex)
                        {
                            value = "<error:" + ex.GetType().Name + ">";
                        }

                        string rendered;
                        if (value == null)
                        {
                            rendered = "null";
                        }
                        else if (value is uint u)
                        {
                            rendered = "0x" + u.ToString("X");
                        }
                        else if (value is int i)
                        {
                            rendered = i.ToString();
                        }
                        else if (value is bool b)
                        {
                            rendered = b.ToString();
                        }
                        else if (value is string s)
                        {
                            rendered = s;
                        }
                        else if (value is IntPtr ptr)
                        {
                            rendered = "0x" + ptr.ToInt64().ToString("X");
                        }
                        else
                        {
                            rendered = value.GetType().FullName ?? value.ToString();
                        }

                        return "token=" + field.MetadataToken +
                               ",name=" + EscapeForLog(field.Name) +
                               ",unicode=" + ToUnicodeLiteral(field.Name) +
                               ",type=" + EscapeForLog(field.FieldType.FullName ?? field.FieldType.Name) +
                               ",value=" + EscapeForLog(rendered);
                    })
                    .ToArray();

                return "label=" + label +
                       " pid=" + processId +
                       " count=" + entries.Length +
                       " entries=" + QuoteForLog(string.Join(" || ", entries));
            }
            catch (Exception ex)
            {
                return "label=" + label + " pid=" + processId + " error=" + ex.GetType().Name + ":" + ex.Message;
            }
        }

        private static string SafeDescribeHookInternals(Hook hook)
        {
            try
            {
                if (hook == null)
                {
                    return "null";
                }

                var fields = hook.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .Where(field =>
                        field.FieldType == typeof(bool) ||
                        field.FieldType == typeof(int) ||
                        field.FieldType == typeof(uint) ||
                        field.FieldType == typeof(string) ||
                        field.FieldType == typeof(IntPtr))
                    .OrderBy(field => field.Name, StringComparer.Ordinal)
                    .Select(field =>
                    {
                        object value;
                        try
                        {
                            value = field.GetValue(hook);
                        }
                        catch (Exception ex)
                        {
                            value = "<error:" + ex.GetType().Name + ">";
                        }

                        if (value is IntPtr ptr)
                        {
                            return GetHookInternalAlias(field.Name) + "=0x" + ptr.ToInt64().ToString("X");
                        }

                        return GetHookInternalAlias(field.Name) + "=" + (value ?? "null");
                    })
                    .ToArray();

                return string.Join("|", fields);
            }
            catch (Exception ex)
            {
                return "error:" + ex.GetType().Name;
            }
        }

        private static string BuildLaunchBotSideEffectSnapshot(string label, int processId)
        {
            try
            {
                var currentProcess = Process.GetCurrentProcess();
                var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .Select(assembly => assembly.GetName().Name)
                    .Where(name => !string.IsNullOrWhiteSpace(name))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
                    .ToArray();

                var currentWindows = Process.GetProcessesByName(currentProcess.ProcessName);
                var wrobotWindows = Process.GetProcessesByName("WRobot");
                var wrobotProcessIds = wrobotWindows
                    .Select(process => process.Id.ToString())
                    .OrderBy(id => id, StringComparer.Ordinal)
                    .ToArray();
                var wrobotWindowTitles = wrobotWindows
                    .Select(process =>
                    {
                        try
                        {
                            return string.IsNullOrWhiteSpace(process.MainWindowTitle) ? "-" : process.MainWindowTitle.Trim();
                        }
                        catch
                        {
                            return "<title-error>";
                        }
                    })
                    .OrderBy(title => title, StringComparer.Ordinal)
                    .ToArray();
                var targetProcess = processId > 0 ? Process.GetProcessById(processId) : null;
                var hook = wManager.Wow.Memory.WowMemory;
                var memory = hook?.Memory;
                var currentBoundProcessId = memory == null ? -1 : memory.ProcessId;
                var currentBoundWindowHandle = memory == null ? 0 : memory.WindowHandleInt32;
                var currentBoundMainModule = memory == null ? 0L : memory.MainModuleAddress;
                var memoryOpen = memory != null && memory.IsValidAndOpenProcess();

                return string.Join(
                    " ",
                    "label=" + label,
                    "hostPid=" + currentProcess.Id,
                    "hostThreads=" + currentProcess.Threads.Count,
                    "hostWindows=" + currentWindows.Length,
                    "wrobotWindows=" + wrobotWindows.Length,
                    "wrobotPids=" + QuoteForLog(string.Join("|", wrobotProcessIds)),
                    "wrobotTitles=" + QuoteForLog(string.Join("|", wrobotWindowTitles)),
                    "targetPid=" + processId,
                    "targetAlive=" + (targetProcess != null && !targetProcess.HasExited),
                    "targetThreads=" + (targetProcess == null || targetProcess.HasExited ? -1 : targetProcess.Threads.Count),
                    "boundProcessId=" + currentBoundProcessId,
                    "boundWindowHandle=" + currentBoundWindowHandle,
                    "boundMainModule=0x" + currentBoundMainModule.ToString("X"),
                    "memoryOpen=" + memoryOpen,
                    "assemblies=" + QuoteForLog(string.Join("|", assemblies)));
            }
            catch (Exception ex)
            {
                return "label=" + label + " audit-error=" + ex.GetType().Name + ": " + ex.Message;
            }
        }

        private static string BuildInterestingAssemblySnapshot(string label)
        {
            try
            {
                var entries = AppDomain.CurrentDomain.GetAssemblies()
                    .Select(assembly =>
                    {
                        try
                        {
                            var name = assembly.GetName();
                            return new
                            {
                                SimpleName = name.Name,
                                FullName = name.FullName,
                                assembly.Location
                            };
                        }
                        catch
                        {
                            return null;
                        }
                    })
                    .Where(entry => entry != null)
                    .Where(entry =>
                        string.Equals(entry.SimpleName, "MemoryRobot", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(entry.SimpleName, "wManager", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(entry.SimpleName, "robotManager", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(entry.SimpleName, "RDManaged", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(entry.SimpleName, "fasmdll_managed", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(entry.SimpleName, "WRobot", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(entry => entry.SimpleName, StringComparer.OrdinalIgnoreCase)
                    .Select(entry => entry.SimpleName + "=" + entry.FullName + " @ " + entry.Location)
                    .ToArray();

                return "label=" + label +
                       " count=" + entries.Length +
                       " entries=" + QuoteForLog(string.Join(" | ", entries));
            }
            catch (Exception ex)
            {
                return "label=" + label + " error=" + ex.GetType().Name + ": " + ex.Message;
            }
        }

        private static string BuildNoDxSnapshot(int processId, string label)
        {
            try
            {
                var assembly = typeof(wManager.Pulsator).Assembly;
                var nodxType = ResolveNoDxWorkerType(assembly);
                if (nodxType == null)
                {
                    return "label=" + label + " type=null";
                }

                var flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
                var fields = nodxType.GetFields(flags);
                var threadField = fields.FirstOrDefault(field => typeof(Thread).IsAssignableFrom(field.FieldType));
                var objectField = fields.FirstOrDefault(field => field.FieldType == typeof(object));
                var uintFields = fields
                    .Where(field => field.FieldType == typeof(uint))
                    .OrderBy(field => field.Name, StringComparer.Ordinal)
                    .ToArray();
                var workerThread = threadField?.GetValue(null) as System.Threading.Thread;
                var uintSnapshot = string.Join(
                    "|",
                    uintFields
                        .Select(field => GetNoDxAlias(field.Name) + "=0x" + SafeToUInt32(field.GetValue(null)).ToString("X"))
                        .ToArray());

                return string.Join(
                    " ",
                    "label=" + label,
                    "type=" + QuoteForLog(nodxType.FullName ?? nodxType.Name),
                    "pid=" + processId,
                    "threadField=" + QuoteForLog(GetNoDxAlias(threadField?.Name)),
                    "objectField=" + QuoteForLog(GetNoDxAlias(objectField?.Name)),
                    "threadNull=" + (workerThread == null),
                    "threadAlive=" + (workerThread?.IsAlive.ToString() ?? "null"),
                    "threadState=" + QuoteForLog(workerThread?.ThreadState.ToString() ?? "null"),
                    "uints=" + QuoteForLog(uintSnapshot));
            }
            catch (Exception ex)
            {
                return "label=" + label + " error=" + ex.GetType().Name + ": " + ex.Message;
            }
        }

        private static string GetNoDxAlias(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return "null";
            }

            switch (fieldName)
            {
                case "\u0003":
                    return "patternScanState";
                case "\u0005":
                    return "detourAddress";
                case "\u0006":
                    return "workerContext";
                case "\u0008":
                    return "workerThread";
                case "\u000E":
                    return "detourEnabledFlag";
                case "\u000F":
                    return "codecaveBase";
                default:
                    return EscapeForLog(fieldName) + "[" + ToUnicodeLiteral(fieldName) + "]";
            }
        }

        private static string ToUnicodeLiteral(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            var builder = new StringBuilder(value.Length * 6);
            foreach (var ch in value)
            {
                builder.Append("\\u");
                builder.Append(((int)ch).ToString("X4"));
            }

            return builder.ToString();
        }

        private static string BuildNoDxScanDiagnostic(int processId, string label)
        {
            try
            {
                var assembly = typeof(wManager.Pulsator).Assembly;
                var decoderType = ResolveStringDecoderType(assembly);
                if (decoderType == null)
                {
                    return "label=" + label + " decoderType=null";
                }

                var decode = decoderType.GetMethod(
                    "\u0002",
                    BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public,
                    null,
                    new[] { typeof(int) },
                    null);
                if (decode == null)
                {
                    decode = decoderType.GetMethod(
                        "_0002",
                        BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public,
                        null,
                        new[] { typeof(int) },
                        null);
                }

                if (decode == null)
                {
                    return "label=" + label + " decoderMethod=null";
                }

                var pattern = decode.Invoke(null, new object[] { -1389975677 }) as string;
                var mask = decode.Invoke(null, new object[] { -1389977523 }) as string;
                var wowMemory = wManager.Wow.Memory.WowMemory;
                var memory = wowMemory?.Memory;
                if (memory == null)
                {
                    return "label=" + label + " memory=null";
                }

                var allocManagerType = AppDomain.CurrentDomain.GetAssemblies()
                    .Select(assemblyItem => assemblyItem.GetType("robotManager.MemoryClass.AllocManager", throwOnError: false))
                    .FirstOrDefault(type => type != null);
                var allocDataObject = wowMemory.GetType().GetField("AllocData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(wowMemory);
                var asmObject = memory.GetType().GetProperty("Asm", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(memory, null);
                if (asmObject == null)
                {
                    asmObject = memory.GetType().GetField("Asm", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(memory);
                }
                var hookLocker = AppDomain.CurrentDomain.GetAssemblies()
                    .Select(assemblyItem => assemblyItem.GetType("robotManager.MemoryClass.Hook", throwOnError: false))
                    .Where(type => type != null)
                    .Select(type => type.GetField("Locker", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null))
                    .FirstOrDefault(value => value != null);

                var patternAddress = memory.FindPatternAllMemoryRegions(pattern, mask);
                byte? firstByte = null;
                try
                {
                    if (patternAddress != 0)
                    {
                        firstByte = memory.ReadByte(patternAddress);
                    }
                }
                catch
                {
                }

                var nodxType = ResolveNoDxWorkerType(assembly);
                byte? expectedFirstByte = null;
                if (nodxType != null)
                {
                    var flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
                    var opcodeSeedField = nodxType
                        .GetFields(flags)
                        .FirstOrDefault(field => field.FieldType == typeof(byte[]));
                    var opcodeSeed = opcodeSeedField?.GetValue(null) as byte[];
                    if (opcodeSeed != null && opcodeSeed.Length > 0)
                    {
                        expectedFirstByte = opcodeSeed[0];
                    }
                }

                return string.Join(
                    " ",
                    "label=" + label,
                    "pid=" + processId,
                    "decoderType=" + QuoteForLog(EscapeForLog(decoderType.FullName ?? decoderType.Name)),
                    "patternLen=" + (pattern?.Length ?? -1),
                    "maskLen=" + (mask?.Length ?? -1),
                    "patternAddress=0x" + patternAddress.ToString("X"),
                    "allocDataNull=" + (allocDataObject == null),
                    "allocDataType=" + QuoteForLog(EscapeForLog(allocDataObject?.GetType().FullName ?? allocManagerType?.FullName)),
                    "asmNull=" + (asmObject == null),
                    "asmType=" + QuoteForLog(EscapeForLog(asmObject?.GetType().FullName)),
                    "hookLockerNull=" + (hookLocker == null),
                    "firstByte=" + (firstByte.HasValue ? "0x" + firstByte.Value.ToString("X2") : "null"),
                    "expectedFirstByte=" + (expectedFirstByte.HasValue ? "0x" + expectedFirstByte.Value.ToString("X2") : "null"),
                    "patternPreview=" + QuoteForLog(PreviewBinaryString(pattern)),
                    "maskPreview=" + QuoteForLog(PreviewBinaryString(mask)));
            }
            catch (TargetInvocationException ex)
            {
                var inner = ex.InnerException ?? ex;
                return "label=" + label + " error=" + inner.GetType().Name + ": " + inner.Message;
            }
            catch (Exception ex)
            {
                return "label=" + label + " error=" + ex.GetType().Name + ": " + ex.Message;
            }
        }

        private static Type ResolveStringDecoderType(Assembly assembly)
        {
            if (assembly == null)
            {
                return null;
            }

            var decoderType = assembly.GetType("_0006_0010", throwOnError: false);
            if (IsStringDecoderTypeCandidate(decoderType))
            {
                return decoderType;
            }

            decoderType = GetLoadableTypes(assembly).FirstOrDefault(
                type => string.Equals(type.Name, "_0006_0010", StringComparison.Ordinal) ||
                        string.Equals(type.FullName, "_0006_0010", StringComparison.Ordinal) ||
                        ((type.FullName?.IndexOf("_0006_0010", StringComparison.Ordinal) ?? -1) >= 0));
            if (IsStringDecoderTypeCandidate(decoderType))
            {
                return decoderType;
            }

            return GetLoadableTypes(assembly).FirstOrDefault(IsStringDecoderTypeCandidate);
        }

        private static Type ResolveNoDxWorkerType(Assembly assembly)
        {
            if (assembly == null)
            {
                return null;
            }

            var nodxType = assembly.GetType("_0005_2009_2005", throwOnError: false);
            if (nodxType != null)
            {
                return nodxType;
            }

            nodxType = GetLoadableTypes(assembly).FirstOrDefault(
                type => string.Equals(type.Name, "_0005_2009_2005", StringComparison.Ordinal) ||
                        string.Equals(type.FullName, "_0005_2009_2005", StringComparison.Ordinal) ||
                        ((type.FullName?.IndexOf("_0005_2009_2005", StringComparison.Ordinal) ?? -1) >= 0));
            if (nodxType != null)
            {
                return nodxType;
            }

            return GetLoadableTypes(assembly).FirstOrDefault(IsNoDxWorkerTypeCandidate);
        }

        private static uint SafeToUInt32(object value)
        {
            try
            {
                if (value == null)
                {
                    return 0u;
                }

                return Convert.ToUInt32(value);
            }
            catch
            {
                return 0u;
            }
        }

        private static bool IsNoDxWorkerTypeCandidate(Type type)
        {
            try
            {
                var flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
                var fields = type.GetFields(flags);
                var hasThread = fields.Any(field => typeof(Thread).IsAssignableFrom(field.FieldType));
                var hasObject = fields.Any(field => field.FieldType == typeof(object));
                var uintCount = fields.Count(field => field.FieldType == typeof(uint));
                return hasThread && hasObject && uintCount >= 4;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsStringDecoderTypeCandidate(Type type)
        {
            try
            {
                if (type == null || !type.IsClass || !type.IsAbstract || !type.IsSealed)
                {
                    return false;
                }

                var flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
                var fields = type.GetFields(flags);
                var hasStringCache = fields.Any(field =>
                    field.FieldType.IsGenericType &&
                    field.FieldType.GetGenericTypeDefinition() == typeof(System.Collections.Concurrent.ConcurrentDictionary<,>) &&
                    field.FieldType.GenericTypeArguments.Length == 2 &&
                    field.FieldType.GenericTypeArguments[0] == typeof(int) &&
                    field.FieldType.GenericTypeArguments[1] == typeof(string));
                var hasByteArray = fields.Any(field => field.FieldType == typeof(byte[]));
                var hasIntToStringMethod = type.GetMethods(flags).Any(method =>
                    method.ReturnType == typeof(string) &&
                    method.GetParameters().Length == 1 &&
                    method.GetParameters()[0].ParameterType == typeof(int));

                return hasStringCache && hasByteArray && hasIntToStringMethod;
            }
            catch
            {
                return false;
            }
        }

        private static string PreviewBinaryString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value ?? "null";
            }

            var bytes = Encoding.Default.GetBytes(value);
            var take = System.Math.Min(bytes.Length, 16);
            return string.Join(" ", bytes.Take(take).Select(b => b.ToString("X2")));
        }

        private static System.Collections.Generic.IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(type => type != null)!;
            }
        }

        private static uint SafeGetDetourAddress(int processId)
        {
            try
            {
                return processId > 0 ? wManager.Wow.Memory.DetourAddress(processId) : 0u;
            }
            catch
            {
                return 0u;
            }
        }

        private static int SafeGetOriginalOpCodeLength(int processId)
        {
            try
            {
                return processId > 0 ? (wManager.Wow.Memory.OriginalOpCode(processId)?.Length ?? 0) : 0;
            }
            catch
            {
                return -1;
            }
        }

        private static string SafeGetDetourInUse(Hook hook)
        {
            try
            {
                return hook == null ? "null" : hook.DetourInUse().ToString();
            }
            catch (Exception ex)
            {
                return "error:" + ex.GetType().Name;
            }
        }

        private static string QuoteForLog(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "\"\"" : "\"" + value.Replace("\"", "'") + "\"";
        }

        private static OriginalRuntimeSnapshot ReadObjectManagerSnapshot()
        {
            try
            {
                var me = ObjectManager.Me;
                var objectList = ObjectManager.ObjectList as ICollection;
                if (me == null || !me.IsValid)
                {
                    return new OriginalRuntimeSnapshot(string.Empty, "-", "-", "-", objectList == null ? 0 : objectList.Count);
                }

                var target = me.TargetObject;
                var targetIsValid = target != null && target.IsValid;

                var targetDistance = targetIsValid ? target.GetDistance.ToString("0.00") : "-";
                var isFacingTarget = targetIsValid ? me.IsFacing(target.Position).ToString() : "-";
                var clickToMoveType = ClickToMove.GetClickToMoveTypePush().ToString();
                var clickToMoveInMove = ClickToMove.InMove.ToString();

                var fightCurrentTarget = Fight.CurrentTarget;
                var fightTargetValid = fightCurrentTarget != null && fightCurrentTarget.IsValid;

                return new OriginalRuntimeSnapshot(
                    me.Name,
                    me.Level.ToString(),
                    ((int)me.HealthPercent).ToString(),
                    me.Position.ToString(),
                    objectList == null ? 0 : objectList.Count,
                    me.InCombat.ToString(),
                    me.GetMove.ToString(),
                    me.IsMounted.ToString(),
                    me.IsFlying.ToString(),
                    me.IsSwimming.ToString(),
                    me.IsCast.ToString(),
                    clickToMoveType,
                    clickToMoveInMove,
                    me.HasTarget.ToString(),
                    targetIsValid ? target.Name : "-",
                    targetIsValid ? target.Level.ToString() : "-",
                    targetIsValid ? ((int)target.HealthPercent).ToString() : "-",
                    targetDistance,
                    isFacingTarget,
                    fightTargetValid ? fightCurrentTarget.Name : "-",
                    fightTargetValid ? fightCurrentTarget.Guid.ToString() : "0",
                    fightTargetValid ? fightCurrentTarget.IsMyTarget.ToString() : "False",
                    Fight.CombatStartSince.ToString());
            }
            catch (Exception ex)
            {
                return new OriginalRuntimeSnapshot(string.Empty, "-", "-", "ObjectManager读取失败: " + ex.GetType().Name, 0);
            }
        }
    }

    public sealed class OriginalRuntimeAttachResult
    {
        private OriginalRuntimeAttachResult(
            bool ok,
            string message,
            string characterName,
            string level,
            string healthPercent,
            string position,
            string inCombat,
            string isMoving,
            string isMounted,
            string isFlying,
            string isSwimming,
            string isCasting,
            string objectCount,
            string clickToMoveType,
            string clickToMoveInMove,
            string hasTarget,
            string targetName,
            string targetLevel,
            string targetHealthPercent,
            string targetDistance,
            string isFacingTarget,
            string fightCurrentTargetName,
            string fightCurrentTargetGuid,
            string fightCurrentTargetIsMyTarget,
            string fightCombatTimeMs,
            string runtimeState)
        {
            Ok = ok;
            Message = message;
            CharacterName = characterName;
            Level = level;
            HealthPercent = healthPercent;
            Position = position;
            InCombat = inCombat;
            IsMoving = isMoving;
            IsMounted = isMounted;
            IsFlying = isFlying;
            IsSwimming = isSwimming;
            IsCasting = isCasting;
            ObjectCount = objectCount;
            ClickToMoveType = clickToMoveType;
            ClickToMoveInMove = clickToMoveInMove;
            HasTarget = hasTarget;
            TargetName = targetName;
            TargetLevel = targetLevel;
            TargetHealthPercent = targetHealthPercent;
            TargetDistance = targetDistance;
            IsFacingTarget = isFacingTarget;
            FightCurrentTargetName = fightCurrentTargetName;
            FightCurrentTargetGuid = fightCurrentTargetGuid;
            FightCurrentTargetIsMyTarget = fightCurrentTargetIsMyTarget;
            FightCombatTimeMs = fightCombatTimeMs;
            RuntimeState = runtimeState;
        }

        public bool Ok { get; }

        public string Message { get; }

        public string CharacterName { get; }

        public string Level { get; }

        public string HealthPercent { get; }

        public string Position { get; }

        public string InCombat { get; }

        public string IsMoving { get; }

        public string IsMounted { get; }

        public string IsFlying { get; }

        public string IsSwimming { get; }

        public string IsCasting { get; }

        public string ObjectCount { get; }

        public string ClickToMoveType { get; }

        public string ClickToMoveInMove { get; }

        public string HasTarget { get; }

        public string TargetName { get; }

        public string TargetLevel { get; }

        public string TargetHealthPercent { get; }

        public string TargetDistance { get; }

        public string IsFacingTarget { get; }

        public string FightCurrentTargetName { get; }

        public string FightCurrentTargetGuid { get; }

        public string FightCurrentTargetIsMyTarget { get; }

        public string FightCombatTimeMs { get; }

        public string RuntimeState { get; }

        public static OriginalRuntimeAttachResult Success(string message)
        {
            return new OriginalRuntimeAttachResult(true, message, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
        }

        public static OriginalRuntimeAttachResult Success(
            string message,
            string characterName,
            string level,
            string healthPercent,
            string position,
            string inCombat,
            string isMoving,
            string isMounted,
            string isFlying,
            string isSwimming,
            string isCasting,
            string objectCount,
            string clickToMoveType,
            string clickToMoveInMove,
            string hasTarget,
            string targetName,
            string targetLevel,
            string targetHealthPercent,
            string targetDistance,
            string isFacingTarget,
            string fightCurrentTargetName,
            string fightCurrentTargetGuid,
            string fightCurrentTargetIsMyTarget,
            string fightCombatTimeMs,
            string runtimeState)
        {
            return new OriginalRuntimeAttachResult(true, message, characterName, level, healthPercent, position, inCombat, isMoving, isMounted, isFlying, isSwimming, isCasting, objectCount, clickToMoveType, clickToMoveInMove, hasTarget, targetName, targetLevel, targetHealthPercent, targetDistance, isFacingTarget, fightCurrentTargetName, fightCurrentTargetGuid, fightCurrentTargetIsMyTarget, fightCombatTimeMs, runtimeState);
        }

        public static OriginalRuntimeAttachResult Fail(string message)
        {
            return new OriginalRuntimeAttachResult(false, message, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
        }
    }

    public sealed class OriginalRuntimeSnapshot
    {
        public OriginalRuntimeSnapshot(
            string characterName,
            string level,
            string healthPercent,
            string position,
            int objectCount,
            string inCombat = "-",
            string isMoving = "-",
            string isMounted = "-",
            string isFlying = "-",
            string isSwimming = "-",
            string isCasting = "-",
            string clickToMoveType = "-",
            string clickToMoveInMove = "False",
            string hasTarget = "-",
            string targetName = "-",
            string targetLevel = "-",
            string targetHealthPercent = "-",
            string targetDistance = "-",
            string isFacingTarget = "-",
            string fightCurrentTargetName = "-",
            string fightCurrentTargetGuid = "0",
            string fightCurrentTargetIsMyTarget = "False",
            string fightCombatTimeMs = "0")
        {
            CharacterName = characterName;
            Level = level;
            HealthPercent = healthPercent;
            Position = position;
            ObjectCount = objectCount;
            InCombat = inCombat;
            IsMoving = isMoving;
            IsMounted = isMounted;
            IsFlying = isFlying;
            IsSwimming = isSwimming;
            IsCasting = isCasting;
            ClickToMoveType = clickToMoveType;
            ClickToMoveInMove = clickToMoveInMove;
            HasTarget = hasTarget;
            TargetName = targetName;
            TargetLevel = targetLevel;
            TargetHealthPercent = targetHealthPercent;
            TargetDistance = targetDistance;
            IsFacingTarget = isFacingTarget;
            FightCurrentTargetName = fightCurrentTargetName;
            FightCurrentTargetGuid = fightCurrentTargetGuid;
            FightCurrentTargetIsMyTarget = fightCurrentTargetIsMyTarget;
            FightCombatTimeMs = fightCombatTimeMs;
        }

        public string CharacterName { get; }

        public string Level { get; }

        public string HealthPercent { get; }

        public string Position { get; }

        public int ObjectCount { get; }

        public string InCombat { get; }

        public string IsMoving { get; }

        public string IsMounted { get; }

        public string IsFlying { get; }

        public string IsSwimming { get; }

        public string IsCasting { get; }

        public string ClickToMoveType { get; }

        public string ClickToMoveInMove { get; }

        public string HasTarget { get; }

        public string TargetName { get; }

        public string TargetLevel { get; }

        public string TargetHealthPercent { get; }

        public string TargetDistance { get; }

        public string IsFacingTarget { get; }

        public string FightCurrentTargetName { get; }

        public string FightCurrentTargetGuid { get; }

        public string FightCurrentTargetIsMyTarget { get; }

        public string FightCombatTimeMs { get; }
    }

    public sealed class OriginalRuntimeActionResult
    {
        private OriginalRuntimeActionResult(bool ok, string message)
        {
            Ok = ok;
            Message = message;
        }

        public bool Ok { get; }

        public string Message { get; }

        public static OriginalRuntimeActionResult Success(string message)
        {
            return new OriginalRuntimeActionResult(true, message);
        }

        public static OriginalRuntimeActionResult Fail(string message)
        {
            return new OriginalRuntimeActionResult(false, message);
        }
    }

    public sealed class OriginalRuntimeProductSnapshot
    {
        public OriginalRuntimeProductSnapshot(string productName, bool isAlive, bool isStarted, bool inPause, bool isBusy, string message)
        {
            ProductName = productName;
            IsAlive = isAlive;
            IsStarted = isStarted;
            InPause = inPause;
            IsBusy = isBusy;
            Message = message;
        }

        public string ProductName { get; }

        public bool IsAlive { get; }

        public bool IsStarted { get; }

        public bool InPause { get; }

        public bool IsBusy { get; }

        public string Message { get; }
    }
}

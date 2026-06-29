using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private int _attachedProcessId;
        private Task<OriginalRuntimeActionResult> _productStartTask;
        private OriginalRuntimeActionResult _lastProductStartResult = OriginalRuntimeActionResult.Success("产品链尚未启动");

        public OriginalRuntimeBootstrap(string runtimeRoot)
        {
            _runtimeRoot = runtimeRoot;
        }

        public OriginalRuntimeAttachResult AttachToWowProcess(int processId)
        {
            _attachedProcessId = processId;
            return RefreshAttachedProcess();
        }

        public OriginalRuntimeAttachResult RefreshAttachedProcess()
        {
            if (_attachedProcessId <= 0)
            {
                if (!TryAutoAttachSingleWowProcess())
                {
                    return OriginalRuntimeAttachResult.Fail("尚未接管进程");
                }
            }

            var result = ReadProcessSnapshot(_attachedProcessId);
            if (!result.Ok && IsHandleFailure(result.Message) && TryAutoAttachSingleWowProcess())
            {
                result = ReadProcessSnapshot(_attachedProcessId);
            }

            return result;
        }

        public void Detach()
        {
            _attachedProcessId = 0;
        }

        private bool TryAutoAttachSingleWowProcess()
        {
            try
            {
                var wowProcesses = Process.GetProcesses()
                    .Where(process => process.ProcessName.Equals("Wow", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(process => process.Id)
                    .ToList();

                if (wowProcesses.Count != 1)
                {
                    return false;
                }

                _attachedProcessId = wowProcesses[0].Id;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsHandleFailure(string message)
        {
            return !string.IsNullOrWhiteSpace(message) &&
                   (message.IndexOf("Memory.Open", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    message.IndexOf("进程句柄无效", StringComparison.OrdinalIgnoreCase) >= 0);
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

                return OriginalRuntimeActionResult.Success(
                    "已调用原版开战链; target=" + targetName +
                    " distance=" + targetDistance.ToString("0.00") +
                    " beforeFight=" + beforeInFight +
                    " returnedGuid=" + fightResultGuid +
                    " currentFight=" + Fight.InFight +
                    " meHasTarget=" + ObjectManager.Me.HasTarget +
                    " meMoving=" + ObjectManager.Me.GetMove);
            }
            catch (Exception ex)
            {
                return OriginalRuntimeActionResult.Fail("开始战斗失败: " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        public OriginalRuntimeActionResult ExecuteTargetActionSequence()
        {
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
                    var stopResult = Products.ProductStop();
                    Products.InPause = true;
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

        private OriginalRuntimeAttachResult ReadProcessSnapshot(int processId)
        {
            Directory.SetCurrentDirectory(_runtimeRoot);

            try
            {
                var hook = EnsureWowMemoryHook();
                var memory = hook.Memory;
                var opened = memory.Open(processId);

                if (!opened || !memory.IsValidAndOpenProcess())
                {
                    return OriginalRuntimeAttachResult.Fail("Memory.Open 失败或进程句柄无效");
                }

                var isInGame = wManager.Wow.Memory.IsInGame(processId);
                var playerName = wManager.Wow.Memory.PlayerName(processId);
                if (!isInGame)
                {
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
                return OriginalRuntimeAttachResult.Fail("原版 Hook 初始化失败: " + ex.Message);
            }
            catch (TargetInvocationException ex)
            {
                return OriginalRuntimeAttachResult.Fail("原版运行时调用异常: " + ex.InnerException);
            }
            catch (Exception ex)
            {
                return OriginalRuntimeAttachResult.Fail("RuntimeBootstrap 异常: " + ex);
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

        private OriginalRuntimeActionResult EnsureOriginalProductStarted()
        {
            try
            {
                var attachResult = RefreshAttachedProcess();
                if (!attachResult.Ok)
                {
                    WriteProductAction("attach-check failed " + attachResult.Message);
                    return OriginalRuntimeActionResult.Fail("原版产品启动前进程未就绪: " + attachResult.Message);
                }

                WriteProductAction(
                    "attach-check ok" +
                    " runtimeState=" + (attachResult.RuntimeState ?? "-") +
                    " character=" + (attachResult.CharacterName ?? "-") +
                    " hasTarget=" + (attachResult.HasTarget ?? "-"));

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

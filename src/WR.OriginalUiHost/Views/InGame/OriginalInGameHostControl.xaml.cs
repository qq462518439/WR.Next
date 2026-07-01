using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using robotManager.Products;
using wManager;
using wManager.Wow.Helpers;
using wManager.Wow.Forms;

namespace WR.OriginalUiHost
{
    public partial class OriginalInGameHostControl : UserControl, IOriginalThemeAware
    {
        private enum ActionKind
        {
            Unknown,
            StartProduct,
            StartFight,
            FaceTarget,
            ApproachTarget,
            InteractTarget,
            TargetSequence,
            BattleSequence,
            PauseProduct,
            ResumeProduct,
            StopProduct,
            StopMove,
            StopFight,
            Refresh
        }

        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;
        private readonly OriginalRuntimeBootstrap _runtimeBootstrap;
        private readonly DispatcherTimer _retryTimer;
        private UserControlTabInGame _originalControl;
        private OriginalRuntimeAttachResult _lastSnapshot;
        private ActionKind _lastActionKind = ActionKind.Unknown;

        public OriginalInGameHostControl(OriginalRuntimeBootstrap runtimeBootstrap)
        {
            _runtimeBootstrap = runtimeBootstrap;
            InitializeComponent();

            _retryTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000)
            };
            _retryTimer.Tick += OnRetryTick;

            Loaded += delegate
            {
                TryLoadOriginalInGameControl("loaded");
                var session = _runtimeBootstrap.GetCurrentSessionSnapshot();
                if (session != null && session.IsAttached && session.ProcessId > 0)
                {
                    _retryTimer.Start();
                }
                else
                {
                    _retryTimer.Stop();
                    WriteAction("loaded skip-retry-start no-attached-session");
                }
            };
            Unloaded += delegate { _retryTimer.Stop(); };
        }

        private void OnRetryTick(object sender, EventArgs e)
        {
            if (_originalControl != null)
            {
                _retryTimer.Stop();
                return;
            }

            var session = _runtimeBootstrap.GetCurrentSessionSnapshot();
            if (session == null || !session.IsAttached || session.ProcessId <= 0)
            {
                _retryTimer.Stop();
                WriteAction("retry-stop no-attached-session");
                return;
            }

            TryLoadOriginalInGameControl("retry");
        }

        private void TryLoadOriginalInGameControl(string stage)
        {
            try
            {
                var result = _runtimeBootstrap.RefreshAttachedProcess();
                _lastSnapshot = result;
                UpdateSummary(result);
                UpdateActionButtonStates(result);
                if (!result.Ok)
                {
                    StatusText.Text = result.Message;
                    if (stage == "loaded" || stage == "retry")
                    {
                        _retryTimer.Stop();
                    }
                    WriteAction(stage + " skip " + result.Message);
                    return;
                }

                EnsurePreferredProductState(stage);
                WarmUpSpellCaches(stage);

                if (_originalControl == null)
                {
                    Directory.SetCurrentDirectory(Paths.Root);
                    _originalControl = new UserControlTabInGame();
                    OriginalEmbeddedThemeStyler.Apply(_originalControl);
                    OriginalContentHost.Content = _originalControl;
                    OriginalContentHost.Visibility = Visibility.Visible;
                    FailurePanel.Visibility = Visibility.Collapsed;
                    _retryTimer.Stop();
                    WriteAction(stage + " attach-original-ingame success");
                }
            }
            catch (Exception ex)
            {
                StatusText.Text = "游戏中页加载失败";
                RuntimeDetailText.Text = ex.GetType().FullName + ": " + ex.Message + Environment.NewLine + ex.StackTrace;
                OriginalContentHost.Content = null;
                OriginalContentHost.Visibility = Visibility.Collapsed;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction(stage + " attach-original-ingame failed " + ex.GetType().Name + ": " + ex.Message);
                UpdateActionButtonStates(null);
            }
        }

        private static void WarmUpSpellCaches(string stage)
        {
            try
            {
                SpellListManager.LoadSpellListe();
                SpellManager.SpellBook();
                WriteAction(stage + " spell-cache-warmup ok");
            }
            catch (Exception ex)
            {
                WriteAction(stage + " spell-cache-warmup failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void EnsurePreferredProductState(string stage)
        {
            try
            {
                wManagerSetting.Load(loadBlacklist: false);
                var currentSetting = wManagerSetting.CurrentSetting;
                if (currentSetting != null &&
                    !string.Equals(currentSetting.LastProductSelected, "WRotation", StringComparison.OrdinalIgnoreCase))
                {
                    currentSetting.LastProductSelected = "WRotation";
                    currentSetting.Save(writeInLog: false, reloadBlackList: false);
                    WriteAction(stage + " preferred-product-setting WRotation");
                }

                if (!string.Equals(Products.ProductName, "WRotation", StringComparison.OrdinalIgnoreCase))
                {
                    var setProductsProductName = typeof(OriginalRuntimeBootstrap)
                        .GetMethod("SetProductsProductName", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                    setProductsProductName?.Invoke(null, new object[] { "WRotation" });
                    WriteAction(stage + " preferred-product-runtime " + (Products.ProductName ?? "null") + "=>WRotation");
                }
            }
            catch (Exception ex)
            {
                WriteAction(stage + " preferred-product-failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void WriteAction(string action)
        {
            try
            {
                var path = Path.Combine(Paths.LogsRoot, "original-ingame-host-actions.txt");
                File.AppendAllText(path, DateTime.Now.ToString("s") + " " + action + Environment.NewLine);
            }
            catch
            {
            }
        }

        private void OnRefreshClicked(object sender, RoutedEventArgs e)
        {
            _lastActionKind = ActionKind.Refresh;
            TryLoadOriginalInGameControl("manual-refresh");
        }

        private void OnStartProductClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.EnsureOriginalProductStartedInBackground();
                _lastActionKind = ActionKind.StartProduct;
                ShowActionResult(result.Message);
                WriteAction("manual-start-product " + result.Message);
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-start-product failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void OnStartFightClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.StartFightOnCurrentTarget();
                _lastActionKind = ActionKind.StartFight;
                ShowActionResult(result.Message);
                WriteAction("manual-start-fight " + result.Message);
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-start-fight failed " + ex.GetType().Name + ": " + ex.Message);
                RefreshActionLogs();
            }
        }

        private void OnFaceTargetClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.FaceTargetOnce();
                _lastActionKind = ActionKind.FaceTarget;
                ShowActionResult(result.Message);
                WriteAction("manual-face-target " + result.Message);
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-face-target failed " + ex.GetType().Name + ": " + ex.Message);
                RefreshActionLogs();
            }
        }

        private void OnApproachTargetClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.ApproachTargetOnce();
                _lastActionKind = ActionKind.ApproachTarget;
                ShowActionResult(result.Message);
                WriteAction("manual-approach-target " + result.Message);
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-approach-target failed " + ex.GetType().Name + ": " + ex.Message);
                RefreshActionLogs();
            }
        }

        private void OnInteractTargetClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.InteractTargetOnce();
                _lastActionKind = ActionKind.InteractTarget;
                ShowActionResult(result.Message);
                WriteAction("manual-interact-target " + result.Message);
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-interact-target failed " + ex.GetType().Name + ": " + ex.Message);
                RefreshActionLogs();
            }
        }

        private void OnTargetSequenceClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.ExecuteTargetActionSequence();
                _lastActionKind = ActionKind.TargetSequence;
                ShowActionResult(result.Message);
                WriteAction("manual-target-sequence " + result.Message.Replace(Environment.NewLine, " | "));
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-target-sequence failed " + ex.GetType().Name + ": " + ex.Message);
                RefreshActionLogs();
            }
        }

        private void OnBattleSequenceClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.ExecuteBattleActionSequence();
                _lastActionKind = ActionKind.BattleSequence;
                ShowActionResult(result.Message);
                WriteAction("manual-battle-sequence " + result.Message.Replace(Environment.NewLine, " | "));
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-battle-sequence failed " + ex.GetType().Name + ": " + ex.Message);
                RefreshActionLogs();
            }
        }

        private void OnPauseProductClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.PauseOriginalProduct();
                _lastActionKind = ActionKind.PauseProduct;
                ShowActionResult(result.Message);
                WriteAction("manual-pause-product " + result.Message);
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-pause-product failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void OnResumeProductClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.ResumeOriginalProduct();
                _lastActionKind = ActionKind.ResumeProduct;
                ShowActionResult(result.Message);
                WriteAction("manual-resume-product " + result.Message);
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-resume-product failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void OnStopProductClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.StopOriginalProduct();
                _lastActionKind = ActionKind.StopProduct;
                ShowActionResult(result.Message);
                WriteAction("manual-stop-product " + result.Message);
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-stop-product failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void OnStopMoveClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.StopMoveTo();
                _lastActionKind = ActionKind.StopMove;
                ShowActionResult(result.Message);
                WriteAction("manual-stop-move " + result.Message);
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-stop-move failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void OnStopFightClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _runtimeBootstrap.StopFightOnce();
                _lastActionKind = ActionKind.StopFight;
                ShowActionResult(result.Message);
                WriteAction("manual-stop-fight " + result.Message);
            }
            catch (Exception ex)
            {
                RuntimeDetailText.Text = ex.GetType().Name + ": " + ex.Message;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction("manual-stop-fight failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void ShowActionResult(string message)
        {
            var previous = _lastSnapshot;
            var productBefore = _runtimeBootstrap.GetOriginalProductSnapshot();
            var refreshed = _runtimeBootstrap.RefreshAttachedProcess();
            System.Threading.Thread.Sleep(300);
            var delayed = _runtimeBootstrap.RefreshAttachedProcess();
            var productDelayed = _runtimeBootstrap.GetOriginalProductSnapshot();
            _lastSnapshot = refreshed;
            if (refreshed != null && refreshed.Ok)
            {
                UpdateSummary(refreshed);
            }

            UpdateProductStateText();
            UpdateActionSummary(message, refreshed);
            ResultStateText.Text = "结果判定: " + BuildResultVerdict(_lastActionKind, message, refreshed);
            ActionDiagnosisText.Text = "动作诊断: " + BuildActionDiagnosis(_lastActionKind, message, refreshed);
            SequenceDiagnosisText.Text = "分步诊断: " + BuildSequenceDiagnosis(_lastActionKind, message);
            DeltaStateText.Text = "变化摘要: " + BuildDeltaSummary(previous, refreshed);
            TrendStateText.Text = "收敛判断: " + BuildTrendSummary(previous, refreshed);
            BeforeAfterStateText.Text = "前后对比: " + BuildBeforeAfterSummary(previous, refreshed);
            DelayedTrendStateText.Text = "延迟收敛: " + BuildDelayedTrendSummary(_lastActionKind, refreshed, delayed, productBefore, productDelayed);
            NextStepText.Text = "下一步建议: " + BuildNextStepSuggestion(_lastActionKind, refreshed);
            RuntimeDetailText.Text = BuildActionDetailBlock(message, previous, refreshed, delayed);
            WriteStructuredActionTimeline(
                _lastActionKind,
                ResultStateText.Text,
                ActionDiagnosisText.Text,
                SequenceDiagnosisText.Text,
                DelayedTrendStateText.Text,
                refreshed);
            FailurePanel.Visibility = Visibility.Visible;
            RefreshActionLogs();
        }

        private void UpdateSummary(OriginalRuntimeAttachResult result)
        {
            if (result == null)
            {
                UpdateActionButtonStates(null);
                StatusText.Text = "接管门未就绪";
                return;
            }

            CombatStateText.Text =
                "战斗状态: InCombat=" + NormalizeState(result.InCombat) +
                "  IsMoving=" + NormalizeState(result.IsMoving) +
                "  CtmInMove=" + NormalizeState(result.ClickToMoveInMove) +
                "  IsCasting=" + NormalizeState(result.IsCasting) +
                "  Runtime=" + NormalizeText(result.RuntimeState);

            TargetStateText.Text =
                "目标状态: HasTarget=" + NormalizeState(result.HasTarget) +
                "  Name=" + NormalizeText(result.TargetName) +
                "  Level=" + NormalizeText(result.TargetLevel) +
                "  HP=" + NormalizeText(result.TargetHealthPercent) +
                "  Dist=" + NormalizeText(result.TargetDistance) +
                "  Facing=" + NormalizeText(result.IsFacingTarget);

            ActionSummaryText.Text =
                "动作摘要: FightTarget=" + NormalizeText(result.FightCurrentTargetName) +
                "  Lock=" + NormalizeText(result.FightCurrentTargetIsMyTarget) +
                "  CombatMs=" + NormalizeText(result.FightCombatTimeMs) +
                "  Objects=" + NormalizeText(result.ObjectCount) +
                "  CtmType=" + NormalizeText(result.ClickToMoveType) +
                "  Guid=" + NormalizeCompactGuid(result.FightCurrentTargetGuid);

            AnomalyStateText.Text = "异常提示: " + BuildAnomalySummary(_lastActionKind, result);

            RuntimeDetailText.Text = BuildSnapshotBlock("当前快照", result);

            UpdateProductStateText();
            RefreshActionLogs();
            UpdateActionButtonStates(result);

            if (result.Ok)
            {
                FailurePanel.Visibility = _originalControl == null ? Visibility.Visible : Visibility.Collapsed;
                StatusText.Text = _originalControl == null ? "接管已通过，等待原始游戏中页加载" : "接管已通过";
            }
            else
            {
                FailurePanel.Visibility = Visibility.Visible;
                StatusText.Text = BuildGateHeadline(result.Message);
            }
        }

        private void UpdateProductStateText()
        {
            var snapshot = _runtimeBootstrap.GetOriginalProductSnapshot();
            ProductStateText.Text =
                "产品状态: " + snapshot.ProductName + Environment.NewLine +
                "Alive=" + snapshot.IsAlive +
                " Started=" + snapshot.IsStarted +
                " Pause=" + snapshot.InPause +
                " Busy=" + snapshot.IsBusy + Environment.NewLine +
                "说明: " + snapshot.Message;
        }

        private void RefreshActionLogs()
        {
            ActionLogText.Text =
                ReadLogTail("original-ingame-structured-timeline.txt", 12) +
                Environment.NewLine +
                ReadLogTail("product-chain-actions.txt", 8) +
                Environment.NewLine +
                ReadLogTail("original-ingame-host-actions.txt", 8);
        }

        private void UpdateActionButtonStates(OriginalRuntimeAttachResult snapshot)
        {
            var session = _runtimeBootstrap.GetCurrentSessionSnapshot();
            var gateReady =
                snapshot != null &&
                snapshot.Ok &&
                session != null &&
                session.IsAttached &&
                session.MemoryOpen &&
                session.HookReady &&
                session.InGame &&
                session.HealthState != SessionHealthState.Faulted &&
                session.HealthState != SessionHealthState.Lost;

            var controlReady = gateReady && _originalControl != null;

            StartProductButton.IsEnabled = gateReady;
            StartFightButton.IsEnabled = controlReady;
            FaceTargetButton.IsEnabled = controlReady;
            ApproachTargetButton.IsEnabled = controlReady;
            InteractTargetButton.IsEnabled = controlReady;
            TargetSequenceButton.IsEnabled = controlReady;
            BattleSequenceButton.IsEnabled = controlReady;
            PauseProductButton.IsEnabled = gateReady;
            ResumeProductButton.IsEnabled = gateReady;
            StopProductButton.IsEnabled = gateReady;
            StopMoveButton.IsEnabled = gateReady;
            StopFightButton.IsEnabled = gateReady;
            RefreshButton.IsEnabled = true;
        }

        private static string BuildGateHeadline(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return "接管门未就绪";
            }

            if (message.IndexOf("接管会话未完成", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "接管门未完成，请回到进程管理页重新接管";
            }

            if (message.IndexOf("尚未建立接管会话", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "尚未接管进程";
            }

            if (message.IndexOf("尚未附着", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "接管已选择，但尚未附着";
            }

            if (message.IndexOf("Hook 未就绪", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "接管已建立，但 Hook 未就绪";
            }

            if (message.IndexOf("进入世界", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "角色尚未进入世界";
            }

            if (message.IndexOf("Memory.Open", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "接管失败：内存句柄无效";
            }

            return message;
        }

        private void WriteStructuredActionTimeline(
            ActionKind actionKind,
            string resultText,
            string diagnosisText,
            string sequenceText,
            string delayedText,
            OriginalRuntimeAttachResult snapshot)
        {
            try
            {
                var path = Path.Combine(Paths.LogsRoot, "original-ingame-structured-timeline.txt");
                var entry =
                    DateTime.Now.ToString("HH:mm:ss") +
                    " | " + GetActionLabel(actionKind) +
                    " | " + CompactLogLine(resultText) +
                    " | " + CompactLogLine(diagnosisText) +
                    " | " + CompactLogLine(sequenceText) +
                    " | " + CompactLogLine(delayedText) +
                    " | Target=" + (snapshot == null ? "-" : NormalizeText(snapshot.TargetName)) +
                    " Dist=" + (snapshot == null ? "-" : NormalizeText(snapshot.TargetDistance)) +
                    " Lock=" + (snapshot == null ? "-" : NormalizeText(snapshot.FightCurrentTargetIsMyTarget)) +
                    " Combat=" + (snapshot == null ? "-" : NormalizeText(snapshot.InCombat));
                File.AppendAllText(path, entry + Environment.NewLine);
            }
            catch
            {
            }
        }

        private static string ReadLogTail(string fileName, int lineCount)
        {
            try
            {
                var path = Path.Combine(Paths.LogsRoot, fileName);
                if (!File.Exists(path))
                {
                    return fileName + ": <无日志>";
                }

                var lines = File.ReadAllLines(path);
                var tail = lines.Length <= lineCount ? lines : lines.Skip(lines.Length - lineCount).ToArray();
                return fileName + ":" + Environment.NewLine + string.Join(Environment.NewLine, tail);
            }
            catch (Exception ex)
            {
                return fileName + ": <读取失败> " + ex.GetType().Name + ": " + ex.Message;
            }
        }

        private static string NormalizeState(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "-" : value;
        }

        private static string NormalizeText(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "-" : value;
        }

        private static string CompactLogLine(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "-";
            }

            return value.Replace(Environment.NewLine, " ").Replace("  ", " ").Trim();
        }

        private static string GetActionLabel(ActionKind actionKind)
        {
            switch (actionKind)
            {
                case ActionKind.StartProduct: return "启动产品";
                case ActionKind.StartFight: return "开始战斗";
                case ActionKind.FaceTarget: return "朝向目标";
                case ActionKind.ApproachTarget: return "跟近一次";
                case ActionKind.InteractTarget: return "交互目标";
                case ActionKind.TargetSequence: return "目标连测";
                case ActionKind.BattleSequence: return "战斗连测";
                case ActionKind.PauseProduct: return "暂停产品";
                case ActionKind.ResumeProduct: return "恢复产品";
                case ActionKind.StopProduct: return "停止产品";
                case ActionKind.StopMove: return "停止移动";
                case ActionKind.StopFight: return "停止战斗";
                case ActionKind.Refresh: return "刷新状态";
                default: return "未知动作";
            }
        }

        private void UpdateActionSummary(string message, OriginalRuntimeAttachResult snapshot)
        {
            var firstLine = string.IsNullOrWhiteSpace(message)
                ? "-"
                : message.Split(new[] { Environment.NewLine }, StringSplitOptions.None)[0];
            var actionSummaryPrefix = _lastActionKind == ActionKind.TargetSequence
                ? "目标连测"
                : _lastActionKind == ActionKind.BattleSequence
                    ? "战斗连测"
                    : "动作摘要";
            ActionSummaryText.Text = actionSummaryPrefix + ": " + firstLine + BuildActionSummaryTail(_lastActionKind, snapshot);
        }

        private static string BuildActionSummaryTail(ActionKind actionKind, OriginalRuntimeAttachResult snapshot)
        {
            if (snapshot == null)
            {
                return string.Empty;
            }

            switch (actionKind)
            {
                case ActionKind.ApproachTarget:
                    return " | Dist=" + NormalizeText(snapshot.TargetDistance) +
                           " | CtmType=" + NormalizeText(snapshot.ClickToMoveType) +
                           " | CtmInMove=" + NormalizeText(snapshot.ClickToMoveInMove);
                case ActionKind.StartFight:
                case ActionKind.BattleSequence:
                    return " | Combat=" + NormalizeText(snapshot.InCombat) +
                           " | Lock=" + NormalizeText(snapshot.FightCurrentTargetIsMyTarget) +
                           " | FightTarget=" + NormalizeText(snapshot.FightCurrentTargetName);
                case ActionKind.TargetSequence:
                    return " | Facing=" + NormalizeText(snapshot.IsFacingTarget) +
                           " | Dist=" + NormalizeText(snapshot.TargetDistance) +
                           " | HasTarget=" + NormalizeText(snapshot.HasTarget);
                case ActionKind.StartProduct:
                case ActionKind.PauseProduct:
                case ActionKind.ResumeProduct:
                case ActionKind.StopProduct:
                    return " | Runtime=" + NormalizeText(snapshot.RuntimeState) +
                           " | Combat=" + NormalizeText(snapshot.InCombat) +
                           " | Target=" + NormalizeText(snapshot.TargetName);
                case ActionKind.FaceTarget:
                    return " | Facing=" + NormalizeText(snapshot.IsFacingTarget) +
                           " | Dist=" + NormalizeText(snapshot.TargetDistance);
                case ActionKind.InteractTarget:
                    return " | Target=" + NormalizeText(snapshot.TargetName) +
                           " | Dist=" + NormalizeText(snapshot.TargetDistance) +
                           " | Lock=" + NormalizeText(snapshot.FightCurrentTargetIsMyTarget);
                case ActionKind.StopMove:
                    return " | IsMoving=" + NormalizeText(snapshot.IsMoving) +
                           " | CtmInMove=" + NormalizeText(snapshot.ClickToMoveInMove) +
                           " | Dist=" + NormalizeText(snapshot.TargetDistance);
                case ActionKind.StopFight:
                    return " | Combat=" + NormalizeText(snapshot.InCombat) +
                           " | Lock=" + NormalizeText(snapshot.FightCurrentTargetIsMyTarget) +
                           " | FightTarget=" + NormalizeText(snapshot.FightCurrentTargetName);
                default:
                    return " | FightTarget=" + NormalizeText(snapshot.FightCurrentTargetName) +
                           " | Lock=" + NormalizeText(snapshot.FightCurrentTargetIsMyTarget) +
                           " | CombatMs=" + NormalizeText(snapshot.FightCombatTimeMs);
            }
        }

        private static string BuildBeforeAfterSummary(OriginalRuntimeAttachResult previous, OriginalRuntimeAttachResult current)
        {
            if (previous == null || current == null || !current.Ok)
            {
                return "-";
            }

            var parts = new[]
            {
                BuildBeforeAfterField("HasTarget", previous.HasTarget, current.HasTarget),
                BuildBeforeAfterField("Facing", previous.IsFacingTarget, current.IsFacingTarget),
                BuildBeforeAfterField("Distance", previous.TargetDistance, current.TargetDistance),
                BuildBeforeAfterField("InCombat", previous.InCombat, current.InCombat),
                BuildBeforeAfterField("Lock", previous.FightCurrentTargetIsMyTarget, current.FightCurrentTargetIsMyTarget),
                BuildBeforeAfterField("FightTarget", previous.FightCurrentTargetName, current.FightCurrentTargetName),
                BuildBeforeAfterField("CtmType", previous.ClickToMoveType, current.ClickToMoveType),
                BuildBeforeAfterField("CtmInMove", previous.ClickToMoveInMove, current.ClickToMoveInMove)
            }
            .Where(part => !string.IsNullOrWhiteSpace(part))
            .ToArray();

            return parts.Length == 0 ? "无关键变化" : string.Join(" | ", parts);
        }

        private static string BuildActionDetailBlock(string message, OriginalRuntimeAttachResult previous, OriginalRuntimeAttachResult current, OriginalRuntimeAttachResult delayed)
        {
            var blocks = new[]
            {
                "动作消息" + Environment.NewLine + NormalizeMultilineText(message),
                BuildSnapshotBlock("动作前快照", previous),
                BuildSnapshotBlock("动作后快照(即时)", current),
                BuildSnapshotBlock("动作后快照(延迟300ms)", delayed)
            };

            return string.Join(Environment.NewLine + Environment.NewLine, blocks);
        }

        private static string BuildSnapshotBlock(string title, OriginalRuntimeAttachResult snapshot)
        {
            if (snapshot == null)
            {
                return title + Environment.NewLine + "<无快照>";
            }

            return title + Environment.NewLine +
                   "角色: " + (string.IsNullOrWhiteSpace(snapshot.CharacterName) ? "未识别" : snapshot.CharacterName) + Environment.NewLine +
                   "运行时: " + (snapshot.RuntimeState ?? "-") + Environment.NewLine +
                   "状态: " + snapshot.Message + Environment.NewLine +
                   "等级: " + (string.IsNullOrWhiteSpace(snapshot.Level) ? "-" : snapshot.Level) + Environment.NewLine +
                   "血量: " + (string.IsNullOrWhiteSpace(snapshot.HealthPercent) ? "-" : snapshot.HealthPercent) + Environment.NewLine +
                   "坐标: " + (string.IsNullOrWhiteSpace(snapshot.Position) ? "-" : snapshot.Position) + Environment.NewLine +
                   "对象总数: " + NormalizeText(snapshot.ObjectCount) + Environment.NewLine +
                   "CTM类型: " + NormalizeText(snapshot.ClickToMoveType) + Environment.NewLine +
                   "CTM移动中: " + NormalizeText(snapshot.ClickToMoveInMove) + Environment.NewLine +
                   "目标: " + (string.IsNullOrWhiteSpace(snapshot.TargetName) ? "-" : snapshot.TargetName) + Environment.NewLine +
                   "目标等级: " + (string.IsNullOrWhiteSpace(snapshot.TargetLevel) ? "-" : snapshot.TargetLevel) + Environment.NewLine +
                   "目标血量: " + (string.IsNullOrWhiteSpace(snapshot.TargetHealthPercent) ? "-" : snapshot.TargetHealthPercent) + Environment.NewLine +
                   "目标距离: " + NormalizeText(snapshot.TargetDistance) + Environment.NewLine +
                   "是否朝向目标: " + NormalizeText(snapshot.IsFacingTarget) + Environment.NewLine +
                   "是否有目标: " + (string.IsNullOrWhiteSpace(snapshot.HasTarget) ? "-" : snapshot.HasTarget) + Environment.NewLine +
                   "战斗锁定目标: " + NormalizeText(snapshot.FightCurrentTargetName) + Environment.NewLine +
                   "锁定是否当前目标: " + NormalizeText(snapshot.FightCurrentTargetIsMyTarget) + Environment.NewLine +
                   "战斗持续毫秒: " + NormalizeText(snapshot.FightCombatTimeMs);
        }

        private static string BuildActionDiagnosis(ActionKind actionKind, string message, OriginalRuntimeAttachResult snapshot)
        {
            if (snapshot == null || !snapshot.Ok)
            {
                return "当前未拿到有效运行时快照";
            }

            var text = message ?? string.Empty;
            var hasTarget = string.Equals(snapshot.HasTarget, "True", StringComparison.OrdinalIgnoreCase);
            var isFacing = string.Equals(snapshot.IsFacingTarget, "True", StringComparison.OrdinalIgnoreCase);
            var inCombat = string.Equals(snapshot.InCombat, "True", StringComparison.OrdinalIgnoreCase);
            var locked = string.Equals(snapshot.FightCurrentTargetIsMyTarget, "True", StringComparison.OrdinalIgnoreCase);
            var ctmInMove = string.Equals(snapshot.ClickToMoveInMove, "True", StringComparison.OrdinalIgnoreCase);

            switch (actionKind)
            {
                case ActionKind.ApproachTarget:
                    if (!hasTarget) return "跟近前提不成立: 当前没有有效目标";
                    if (text.IndexOf("directCtm=True", StringComparison.OrdinalIgnoreCase) >= 0) return "已触发原版移动链，且回退触发了直接 CTM";
                    if (ctmInMove) return "已触发原版移动链，当前 CTM 正在推进";
                    if (text.IndexOf("afterMMMeMove=True", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        text.IndexOf("finalMeMove=True", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return "MovementManager 已接管移动，等待距离继续收敛";
                    }

                    return "已调用跟近链，但未观察到明确移动接管";
                case ActionKind.FaceTarget:
                    if (!hasTarget) return "朝向前提不成立: 当前没有有效目标";
                    if (isFacing) return "朝向链已生效: 当前角色已经朝向目标";
                    if (text.IndexOf("afterFacing=False", StringComparison.OrdinalIgnoreCase) >= 0) return "已调用原版朝向链，但朝向仍未收敛";
                    return "朝向调用已发出，等待 Facing 状态更新";
                case ActionKind.InteractTarget:
                    if (!hasTarget) return "交互前提不成立: 当前没有有效目标";
                    if (text.IndexOf("base=0x", StringComparison.OrdinalIgnoreCase) >= 0) return "已触发原版交互链，目标基址已传入";
                    if (text.IndexOf("返回 false", StringComparison.OrdinalIgnoreCase) >= 0) return "原版交互链已调用，但底层返回 false";
                    return "交互调用已发出，继续观察目标或战斗状态变化";
                case ActionKind.StartFight:
                    if (!hasTarget) return "开战前提不成立: 当前没有有效目标";
                    if (inCombat && locked) return "开战链已生效: 已入战斗且锁定到当前目标";
                    if (inCombat && !locked) return "已入战斗，但锁定仍未收敛到当前目标";
                    if (!inCombat && locked) return "已拿到战斗锁定，但尚未正式入战斗";
                    if (text.IndexOf("returnedGuid=", StringComparison.OrdinalIgnoreCase) >= 0) return "已调用原版 Fight.StartFight，但战斗态尚未完全收敛";
                    return "已发出开战调用，但未观察到入战斗或锁定";
                case ActionKind.TargetSequence:
                    if (!hasTarget) return "目标连测未开始: 当前没有有效目标";
                    if (isFacing && ctmInMove) return "目标链已推进到移动阶段，可继续观察交互结果";
                    if (isFacing) return "目标链已完成朝向，正在等待跟近/交互收敛";
                    return "目标链已执行，但朝向仍未稳定";
                case ActionKind.BattleSequence:
                    if (!hasTarget) return "战斗连测未开始: 当前没有有效目标";
                    if (inCombat && locked) return "战斗链整体已打通: 朝向/跟近/开战均已收敛";
                    if (inCombat) return "战斗链已推进到入战斗，但锁定仍需继续观察";
                    if (ctmInMove || text.IndexOf("directCtm=True", StringComparison.OrdinalIgnoreCase) >= 0) return "战斗链已推进到移动接敌阶段，尚未完成开战收敛";
                    return "战斗连测已调用，但主要停留在前置阶段";
                case ActionKind.StopMove:
                    if (ctmInMove) return "停止移动调用已发出，但 CTM 仍显示移动中";
                    if (!string.Equals(snapshot.IsMoving, "True", StringComparison.OrdinalIgnoreCase)) return "停止移动已基本生效: 当前未观察到继续移动";
                    return "停止移动已调用，等待移动状态回落";
                case ActionKind.StopFight:
                    if (!inCombat && !locked) return "停止战斗已基本生效: 战斗与锁定已回落";
                    if (!inCombat && locked) return "已脱离战斗，但锁定还未完全回落";
                    return "停止战斗已调用，等待 Combat/Lock 状态回落";
                default:
                    return "结合结果判定、变化摘要与前后对比继续观察";
            }
        }

        private static string BuildSequenceDiagnosis(ActionKind actionKind, string message)
        {
            if (actionKind != ActionKind.TargetSequence && actionKind != ActionKind.BattleSequence)
            {
                return "-";
            }

            var text = message ?? string.Empty;
            if (text.IndexOf("序列终止[", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var stopIndex = text.IndexOf("序列终止[", StringComparison.OrdinalIgnoreCase);
                return stopIndex >= 0 ? text.Substring(stopIndex).Replace(Environment.NewLine, " | ") : text.Replace(Environment.NewLine, " | ");
            }

            var lines = text
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(BuildSequenceStepSummary)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToArray();

            return lines.Length == 0 ? "-" : string.Join(" | ", lines);
        }

        private static string BuildSequenceStepSummary(string line)
        {
            var text = line ?? string.Empty;
            if (text.IndexOf("朝向链", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (text.IndexOf("afterFacing=True", StringComparison.OrdinalIgnoreCase) >= 0) return "朝向: 成功";
                return "朝向: 已调用但未确认收敛";
            }

            if (text.IndexOf("移动链", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (text.IndexOf("directCtm=True", StringComparison.OrdinalIgnoreCase) >= 0) return "跟近: 已触发直接 CTM";
                if (text.IndexOf("finalMeMove=True", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    text.IndexOf("afterMMMeMove=True", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return "跟近: MovementManager 已接管";
                }

                return "跟近: 已调用";
            }

            if (text.IndexOf("交互链", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return text.IndexOf("base=0x", StringComparison.OrdinalIgnoreCase) >= 0
                    ? "交互: 已触发"
                    : "交互: 已调用未确认";
            }

            if (text.IndexOf("开战链", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (text.IndexOf("currentFight=True", StringComparison.OrdinalIgnoreCase) >= 0) return "开战: 已入战斗";
                if (text.IndexOf("returnedGuid=", StringComparison.OrdinalIgnoreCase) >= 0) return "开战: 已调用 StartFight";
                return "开战: 已调用未确认";
            }

            return text;
        }

        private static string BuildDelayedTrendSummary(
            ActionKind actionKind,
            OriginalRuntimeAttachResult immediate,
            OriginalRuntimeAttachResult delayed,
            OriginalRuntimeProductSnapshot productBefore,
            OriginalRuntimeProductSnapshot productDelayed)
        {
            if ((immediate == null || delayed == null || !delayed.Ok) &&
                (productBefore == null || productDelayed == null))
            {
                return "-";
            }

            var immediateHasTarget = immediate != null && string.Equals(immediate.HasTarget, "True", StringComparison.OrdinalIgnoreCase);
            var delayedHasTarget = delayed != null && string.Equals(delayed.HasTarget, "True", StringComparison.OrdinalIgnoreCase);
            var immediateFacing = immediate != null && string.Equals(immediate.IsFacingTarget, "True", StringComparison.OrdinalIgnoreCase);
            var delayedFacing = delayed != null && string.Equals(delayed.IsFacingTarget, "True", StringComparison.OrdinalIgnoreCase);
            var immediateCombat = immediate != null && string.Equals(immediate.InCombat, "True", StringComparison.OrdinalIgnoreCase);
            var delayedCombat = delayed != null && string.Equals(delayed.InCombat, "True", StringComparison.OrdinalIgnoreCase);
            var immediateLock = immediate != null && string.Equals(immediate.FightCurrentTargetIsMyTarget, "True", StringComparison.OrdinalIgnoreCase);
            var delayedLock = delayed != null && string.Equals(delayed.FightCurrentTargetIsMyTarget, "True", StringComparison.OrdinalIgnoreCase);
            var immediateCtm = immediate != null && string.Equals(immediate.ClickToMoveInMove, "True", StringComparison.OrdinalIgnoreCase);
            var delayedCtm = delayed != null && string.Equals(delayed.ClickToMoveInMove, "True", StringComparison.OrdinalIgnoreCase);

            switch (actionKind)
            {
                case ActionKind.StartProduct:
                    if (productDelayed != null && productDelayed.IsBusy) return "产品链延迟推进: 300ms 后仍处于启动中";
                    if (productBefore != null && productDelayed != null &&
                        !productBefore.IsStarted && productDelayed.IsStarted && productDelayed.IsAlive && !productDelayed.InPause)
                    {
                        return "产品链延迟收敛: 300ms 后产品已完成启动";
                    }

                    return "产品链延迟无明显推进";
                case ActionKind.PauseProduct:
                    if (productBefore != null && productDelayed != null &&
                        !productBefore.InPause && productDelayed.InPause)
                    {
                        return "产品链延迟收敛: 300ms 后暂停状态已稳定";
                    }

                    return "产品暂停延迟无明显推进";
                case ActionKind.ResumeProduct:
                    if (productDelayed != null && productDelayed.IsBusy) return "产品恢复延迟推进: 300ms 后产品仍在恢复/启动中";
                    if (productBefore != null && productDelayed != null &&
                        productBefore.InPause && !productDelayed.InPause && productDelayed.IsAlive)
                    {
                        return "产品链延迟收敛: 300ms 后恢复状态已稳定";
                    }

                    return "产品恢复延迟无明显推进";
                case ActionKind.StopProduct:
                    if (productBefore != null && productDelayed != null &&
                        productBefore.IsAlive && !productDelayed.IsAlive)
                    {
                        return "产品链延迟收敛: 300ms 后产品已停止";
                    }

                    if (productDelayed != null && productDelayed.InPause) return "产品停止延迟推进: 300ms 后已进入暂停/停止态";
                    return "产品停止延迟无明显推进";
                case ActionKind.ApproachTarget:
                    if (!immediateHasTarget || !delayedHasTarget) return "延迟无收敛: 目标状态不稳定";
                    if (TryParseDistance(immediate.TargetDistance, out var approachImmediateDist) &&
                        TryParseDistance(delayed.TargetDistance, out var approachDelayedDist) &&
                        approachDelayedDist + 0.1f < approachImmediateDist)
                    {
                        return "跟近延迟收敛: 300ms 后距离继续缩短";
                    }

                    if (immediateCtm && !delayedCtm) return "跟近延迟收敛: CTM 已在延迟采样时回落";
                    if (!immediateCtm && delayedCtm) return "跟近延迟生效: 即时未动，300ms 后 CTM 才开始推进";
                    return "跟近延迟无明显推进";
                case ActionKind.StartFight:
                    if (!immediateCombat && delayedCombat && delayedLock) return "开战延迟收敛: 300ms 后已入战斗并锁定目标";
                    if (!immediateCombat && delayedCombat) return "开战延迟收敛: 300ms 后才正式入战斗";
                    if (!immediateLock && delayedLock) return "开战延迟收敛: 300ms 后才建立战斗锁定";
                    return "开战延迟无明显推进";
                case ActionKind.TargetSequence:
                    if (!immediateFacing && delayedFacing) return "目标连测延迟收敛: 300ms 后朝向已稳定";
                    if (TryParseDistance(immediate.TargetDistance, out var targetImmediateDist) &&
                        TryParseDistance(delayed.TargetDistance, out var targetDelayedDist) &&
                        targetDelayedDist + 0.1f < targetImmediateDist)
                    {
                        return "目标连测延迟收敛: 300ms 后继续贴近目标";
                    }

                    return "目标连测延迟无明显推进";
                case ActionKind.BattleSequence:
                    if (!immediateCombat && delayedCombat && delayedLock) return "战斗连测延迟收敛: 300ms 后完成入战斗并锁定";
                    if (!immediateCombat && delayedCombat) return "战斗连测延迟收敛: 300ms 后才进入战斗";
                    if (!immediateLock && delayedLock) return "战斗连测延迟收敛: 300ms 后才建立锁定";
                    if (immediateCtm && !delayedCtm) return "战斗连测延迟推进: 接敌移动已在 300ms 后回落";
                    return "战斗连测延迟无明显推进";
            }

            if (immediate == null || delayed == null || !delayed.Ok)
            {
                return "-";
            }

            var delayedDelta = BuildDeltaSummary(immediate, delayed);
            var delayedTrend = BuildTrendSummary(immediate, delayed);
            if (string.IsNullOrWhiteSpace(delayedDelta) || delayedDelta == "-")
            {
                return delayedTrend;
            }

            if (string.IsNullOrWhiteSpace(delayedTrend) || delayedTrend == "-")
            {
                return delayedDelta;
            }

            return delayedTrend + " | " + delayedDelta;
        }

        private static string NormalizeMultilineText(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "-" : value;
        }

        private static string BuildResultVerdict(ActionKind actionKind, string message, OriginalRuntimeAttachResult snapshot)
        {
            var text = message ?? string.Empty;
            if (text.IndexOf("失败", StringComparison.OrdinalIgnoreCase) >= 0 ||
                text.IndexOf("终止", StringComparison.OrdinalIgnoreCase) >= 0 ||
                text.IndexOf("无效", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "失败";
            }

            if (snapshot == null || !snapshot.Ok)
            {
                return "失败";
            }

            var hasTarget = string.Equals(snapshot.HasTarget, "True", StringComparison.OrdinalIgnoreCase);
            var inCombat = string.Equals(snapshot.InCombat, "True", StringComparison.OrdinalIgnoreCase);
            var isFacing = string.Equals(snapshot.IsFacingTarget, "True", StringComparison.OrdinalIgnoreCase);
            var locked = string.Equals(snapshot.FightCurrentTargetIsMyTarget, "True", StringComparison.OrdinalIgnoreCase);
            switch (actionKind)
            {
                case ActionKind.StartFight:
                case ActionKind.BattleSequence:
                    if (inCombat && locked) return "成功";
                    if (inCombat && !locked) return "部分成功: 已开战但未锁定";
                    if (!inCombat && locked) return "部分成功: 已锁定但未入战斗";
                    if (!hasTarget) return "失败: 无目标";
                    if (!isFacing) return "失败: 未朝向目标";
                    return "失败: 未进入战斗";
                case ActionKind.TargetSequence:
                    if (hasTarget && isFacing && (locked || inCombat)) return "成功";
                    if (hasTarget && isFacing) return "部分成功: 已朝向但未锁定";
                    if (hasTarget && !isFacing) return "部分成功: 仍有目标但未朝向";
                    return "失败: 目标动作链未收敛";
                case ActionKind.FaceTarget:
                    return isFacing ? "成功" : "失败: 朝向未收敛";
                case ActionKind.ApproachTarget:
                    if (hasTarget && isFacing) return "部分成功: 已朝向但贴近待确认";
                    if (hasTarget) return "部分成功: 目标仍在但朝向未收敛";
                    return "失败: 已丢失目标";
                case ActionKind.InteractTarget:
                    return hasTarget ? "部分成功: 已触发交互但结果待确认" : "失败: 交互前目标已丢失";
                case ActionKind.StartProduct:
                    return text.IndexOf("已启动", StringComparison.OrdinalIgnoreCase) >= 0 ? "成功" : "部分成功: 启动请求已发出";
                case ActionKind.StopFight:
                case ActionKind.StopMove:
                case ActionKind.StopProduct:
                case ActionKind.PauseProduct:
                case ActionKind.ResumeProduct:
                    return "成功";
                default:
                    return "部分成功";
            }
        }

        private static string BuildAnomalySummary(ActionKind actionKind, OriginalRuntimeAttachResult result)
        {
            if (result == null)
            {
                return "-";
            }

            var noTarget = string.Equals(result.HasTarget, "True", StringComparison.OrdinalIgnoreCase) ? null : "当前无目标";
            var combatLostTarget =
                string.Equals(result.InCombat, "True", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(result.HasTarget, "True", StringComparison.OrdinalIgnoreCase)
                    ? "已进战斗但目标丢失"
                    : null;
            var lockMismatch =
                !string.IsNullOrWhiteSpace(result.FightCurrentTargetName) &&
                result.FightCurrentTargetName != "-" &&
                !string.Equals(result.FightCurrentTargetIsMyTarget, "True", StringComparison.OrdinalIgnoreCase)
                    ? "战斗锁定与当前目标不一致"
                    : null;
            var notFacing =
                string.Equals(result.HasTarget, "True", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(result.IsFacingTarget, "False", StringComparison.OrdinalIgnoreCase)
                    ? "当前未朝向目标"
                    : null;
            var farTarget =
                string.Equals(result.HasTarget, "True", StringComparison.OrdinalIgnoreCase) &&
                TryParseDistance(result.TargetDistance, out var distance) && distance > 8f
                    ? "目标距离偏远"
                    : null;
            var ctmIdle =
                string.Equals(result.HasTarget, "True", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(result.ClickToMoveInMove, "False", StringComparison.OrdinalIgnoreCase) &&
                TryParseDistance(result.TargetDistance, out var ctmDistance) && ctmDistance > 4f
                    ? "目标仍偏远且 CTM 未推进"
                    : null;

            string[] ordered;
            switch (actionKind)
            {
                case ActionKind.ApproachTarget:
                    ordered = new[] { noTarget, notFacing, farTarget, ctmIdle, lockMismatch, combatLostTarget };
                    break;
                case ActionKind.StartFight:
                case ActionKind.BattleSequence:
                    ordered = new[] { noTarget, notFacing, lockMismatch, combatLostTarget, farTarget, ctmIdle };
                    break;
                case ActionKind.TargetSequence:
                    ordered = new[] { noTarget, notFacing, farTarget, ctmIdle, lockMismatch, combatLostTarget };
                    break;
                case ActionKind.StartProduct:
                case ActionKind.PauseProduct:
                case ActionKind.ResumeProduct:
                case ActionKind.StopProduct:
                    ordered = new[] { noTarget, combatLostTarget, lockMismatch, notFacing, farTarget };
                    break;
                default:
                    ordered = new[] { noTarget, combatLostTarget, lockMismatch, notFacing, farTarget };
                    break;
            }

            var flags = ordered
                .Where(flag => !string.IsNullOrWhiteSpace(flag))
                .ToArray();

            return flags.Length == 0 ? "无明显异常" : string.Join(" | ", flags);
        }

        private static string BuildDeltaSummary(OriginalRuntimeAttachResult previous, OriginalRuntimeAttachResult current)
        {
            if (previous == null || current == null || !current.Ok)
            {
                return "-";
            }

            var changes = new[]
            {
                BuildBoolDelta("Lock", previous.FightCurrentTargetIsMyTarget, current.FightCurrentTargetIsMyTarget),
                BuildBoolDelta("Combat", previous.InCombat, current.InCombat),
                BuildBoolDelta("Facing", previous.IsFacingTarget, current.IsFacingTarget),
                BuildDistanceDelta(previous.TargetDistance, current.TargetDistance),
                BuildBoolDelta("Target", previous.HasTarget, current.HasTarget),
                BuildTextDelta("FightTarget", previous.FightCurrentTargetName, current.FightCurrentTargetName)
            }
            .Where(change => !string.IsNullOrWhiteSpace(change))
            .Take(4)
            .ToArray();

            return changes.Length == 0 ? "无明显变化" : string.Join(" | ", changes);
        }

        private static string BuildTrendSummary(OriginalRuntimeAttachResult previous, OriginalRuntimeAttachResult current)
        {
            if (previous == null || current == null || !current.Ok)
            {
                return "-";
            }

            var beforeLock = string.Equals(previous.FightCurrentTargetIsMyTarget, "True", StringComparison.OrdinalIgnoreCase);
            var afterLock = string.Equals(current.FightCurrentTargetIsMyTarget, "True", StringComparison.OrdinalIgnoreCase);
            var beforeCombat = string.Equals(previous.InCombat, "True", StringComparison.OrdinalIgnoreCase);
            var afterCombat = string.Equals(current.InCombat, "True", StringComparison.OrdinalIgnoreCase);
            var beforeFacing = string.Equals(previous.IsFacingTarget, "True", StringComparison.OrdinalIgnoreCase);
            var afterFacing = string.Equals(current.IsFacingTarget, "True", StringComparison.OrdinalIgnoreCase);
            var beforeTarget = string.Equals(previous.HasTarget, "True", StringComparison.OrdinalIgnoreCase);
            var afterTarget = string.Equals(current.HasTarget, "True", StringComparison.OrdinalIgnoreCase);

            if (!beforeLock && afterLock)
            {
                return "更接近成功: 已锁定战斗目标";
            }

            if (!beforeCombat && afterCombat)
            {
                return "更接近成功: 已进入战斗";
            }

            if (!beforeFacing && afterFacing)
            {
                return "更接近成功: 已朝向目标";
            }

            if (!string.Equals(NormalizeText(previous.FightCurrentTargetName), NormalizeText(current.FightCurrentTargetName), StringComparison.OrdinalIgnoreCase) &&
                NormalizeText(current.FightCurrentTargetName) != "-")
            {
                return "更接近成功: 战斗锁定切到 " + NormalizeText(current.FightCurrentTargetName);
            }

            if (TryParseDistance(previous.TargetDistance, out var beforeDist) &&
                TryParseDistance(current.TargetDistance, out var afterDist) &&
                afterDist + 0.1f < beforeDist)
            {
                return "更接近成功: 与目标距离收敛";
            }

            if (beforeLock && !afterLock)
            {
                return "更偏离成功: 丢失战斗锁定";
            }

            if (beforeCombat && !afterCombat)
            {
                return "更偏离成功: 脱离战斗";
            }

            if (beforeTarget && !afterTarget)
            {
                return "更偏离成功: 当前目标丢失";
            }

            if (!beforeTarget && !afterTarget)
            {
                return "未观察到有效进展: 当前无目标";
            }

            if (beforeTarget && afterTarget && !afterFacing)
            {
                return "未观察到有效进展: 目标仍在但未朝向";
            }

            return "未观察到有效进展";
        }

        private static string BuildNextStepSuggestion(ActionKind actionKind, OriginalRuntimeAttachResult snapshot)
        {
            if (snapshot == null || !snapshot.Ok)
            {
                return "先刷新状态并确认进程已接管";
            }

            var hasTarget = string.Equals(snapshot.HasTarget, "True", StringComparison.OrdinalIgnoreCase);
            var inCombat = string.Equals(snapshot.InCombat, "True", StringComparison.OrdinalIgnoreCase);
            var isFacing = string.Equals(snapshot.IsFacingTarget, "True", StringComparison.OrdinalIgnoreCase);
            var locked = string.Equals(snapshot.FightCurrentTargetIsMyTarget, "True", StringComparison.OrdinalIgnoreCase);
            var ctmInMove = string.Equals(snapshot.ClickToMoveInMove, "True", StringComparison.OrdinalIgnoreCase);
            var targetFar =
                hasTarget &&
                TryParseDistance(snapshot.TargetDistance, out var targetDistance) &&
                targetDistance > 8f;

            switch (actionKind)
            {
                case ActionKind.StartProduct:
                    if (!hasTarget) return "产品启动后可先手动选目标，再继续测试动作链";
                    if (!isFacing) return "产品已启动，建议先点朝向目标或目标连测";
                    return "产品已启动，可继续测跟近、开战或连测";
                case ActionKind.StartFight:
                    if (!hasTarget) return "先手动选中一个真实目标，再点开始战斗";
                    if (!isFacing) return "先点朝向目标，再试开始战斗";
                    if (inCombat && !locked) return "已进战斗但未锁定，建议再点一次开始战斗";
                    if (!inCombat && locked) return "已锁定但未入战斗，建议补一次跟近";
                    if (targetFar && !ctmInMove) return "目标仍偏远且未推进移动，建议先点跟近一次，再重新开始战斗";
                    if (!inCombat) return "建议观察距离变化，必要时先点跟近一次";
                    return "开始战斗已基本生效，继续观察锁定是否稳定";
                case ActionKind.FaceTarget:
                    if (!hasTarget) return "先手动选中一个真实目标，再点朝向目标";
                    if (!isFacing) return "可再点一次朝向目标，观察 Facing 是否变为 True";
                    return "朝向已基本收敛，可继续点跟近一次或开始战斗";
                case ActionKind.ApproachTarget:
                    if (!hasTarget) return "先手动重新选目标，再点跟近一次";
                    if (!isFacing) return "建议先点朝向目标，再继续跟近";
                    if (targetFar && !ctmInMove) return "目标仍偏远且 CTM 未推进，建议再点一次跟近；若仍无变化，再补一次朝向目标";
                    if (!inCombat && !locked) return "贴近后可继续点开始战斗";
                    return "跟近已基本生效，继续观察距离是否持续收敛";
                case ActionKind.InteractTarget:
                    if (!hasTarget) return "先手动重新选目标，再点交互目标";
                    if (!isFacing) return "建议先点朝向目标，再重试交互";
                    return "交互已触发，继续观察目标状态与战斗锁定是否变化";
                case ActionKind.TargetSequence:
                    if (!hasTarget) return "先手动选中一个真实目标，再重试目标连测";
                    if (!isFacing) return "先点朝向目标，再重试目标连测";
                    if (targetFar && !ctmInMove) return "目标链卡在接敌前，建议先单点跟近一次，确认 CTM 推进后再重试目标连测";
                    if (!locked && !inCombat) return "接着点开始战斗，观察是否进入战斗或获得锁定";
                    return "目标链已基本收敛，可以继续测战斗连测";
                case ActionKind.BattleSequence:
                    if (!hasTarget) return "先手动重新选目标，再重试战斗连测";
                    if (!isFacing) return "先点朝向目标，确认已朝向后再测战斗连测";
                    if (inCombat && !locked) return "已入战斗但未锁定，建议再点一次开始战斗";
                    if (!inCombat && locked) return "已锁定但未入战斗，建议观察距离并补一次跟近";
                    if (targetFar && !ctmInMove) return "战斗链卡在接敌前，建议先单点跟近一次；确认贴近后再重试战斗连测";
                    if (!inCombat) return "建议先点开始战斗，再看是否进入战斗或获得锁定";
                    return "战斗链已基本收敛，可以继续观察锁定是否稳定";
                case ActionKind.PauseProduct:
                    if (inCombat || locked) return "产品已暂停，建议先刷新状态，确认战斗与锁定是否停止继续变化";
                    return "产品已暂停，建议观察角色状态是否保持稳定，再决定是否恢复产品";
                case ActionKind.ResumeProduct:
                    if (!hasTarget) return "产品已恢复，建议先手动选目标，再继续测试动作链";
                    if (!isFacing) return "产品已恢复，建议先点朝向目标，确认动作链重新推进";
                    if (!inCombat && !locked) return "产品已恢复，可继续点跟近一次、开始战斗或战斗连测";
                    return "产品已恢复，建议继续观察锁定、距离和战斗状态是否重新变化";
                case ActionKind.StopProduct:
                    if (inCombat || locked) return "产品已停止，建议刷新状态，确认战斗与锁定是否已经回落";
                    return "产品已停止，建议确认后续动作不再推进，再重新启动产品进入下一轮测试";
                case ActionKind.StopMove:
                    return "停止移动已触发，建议观察距离是否停止变化";
                case ActionKind.StopFight:
                    return "停止战斗已触发，建议观察 Combat 和 Lock 是否回落";
                default:
                    return "继续看结果判定与收敛判断";
            }
        }

        private static string BuildDistanceDelta(string previous, string current)
        {
            if (!TryParseDistance(previous, out var before) || !TryParseDistance(current, out var after))
            {
                return null;
            }

            var delta = after - before;
            if (Math.Abs(delta) < 0.05f)
            {
                return "距离基本不变";
            }

            return delta < 0f
                ? "明显贴近了 (" + before.ToString("0.00") + "->" + after.ToString("0.00") + ")"
                : "距离拉远了 (" + before.ToString("0.00") + "->" + after.ToString("0.00") + ")";
        }

        private static string BuildBoolDelta(string label, string previous, string current)
        {
            var before = NormalizeText(previous);
            var after = NormalizeText(current);
            if (string.Equals(before, after, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            switch (label)
            {
                case "Lock":
                    return after == "True" ? "已获得战斗锁定" : "战斗锁定已丢失";
                case "Combat":
                    return after == "True" ? "已进入战斗" : "已脱离战斗";
                case "Facing":
                    return after == "True" ? "已朝向目标" : "朝向已偏离";
                case "Target":
                    return after == "True" ? "已重新获得目标" : "当前目标已丢失";
                default:
                    return label + " " + before + "->" + after;
            }
        }

        private static string BuildTextDelta(string label, string previous, string current)
        {
            var before = NormalizeText(previous);
            var after = NormalizeText(current);
            if (before == "-" && after == "-")
            {
                return null;
            }

            if (string.Equals(before, after, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            if (label == "FightTarget")
            {
                if (before == "-" && after != "-")
                {
                    return "战斗锁定 -> " + after;
                }

                if (before != "-" && after == "-")
                {
                    return "战斗锁定丢失";
                }

                return "战斗锁定 " + before + "->" + after;
            }

            return label + " " + before + "->" + after;
        }

        private static string BuildBeforeAfterField(string label, string previous, string current)
        {
            var before = NormalizeText(previous);
            var after = NormalizeText(current);
            if (string.Equals(before, after, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            return label + "=" + before + "->" + after;
        }

        private static bool TryParseDistance(string value, out float distance)
        {
            distance = 0f;
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return float.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out distance) ||
                   float.TryParse(value, out distance);
        }

        private static string NormalizeCompactGuid(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value == "0")
            {
                return "-";
            }

            return value.Length > 10 ? value.Substring(0, 10) + "..." : value;
        }

        public void RefreshTheme()
        {
            if (_originalControl != null)
            {
                OriginalEmbeddedThemeStyler.Apply(_originalControl);
            }
        }
    }
}

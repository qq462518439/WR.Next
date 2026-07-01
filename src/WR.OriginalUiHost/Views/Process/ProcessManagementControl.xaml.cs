using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WR.OriginalUiHost
{
    public partial class ProcessManagementControl : UserControl
    {
        private readonly string _runtimeRoot;
        private readonly OriginalRuntimeBootstrap _runtimeBootstrap;
        private readonly DispatcherTimer _refreshTimer;
        private bool _autoAttachEnabled;
        private bool _autoAttachInitializationComplete;
        private bool _autoAttachAttemptPending;
        private bool _refreshInProgress;
        private int _refreshGeneration;

        public ProcessManagementControl(string runtimeRoot, OriginalRuntimeBootstrap runtimeBootstrap)
        {
            _runtimeRoot = runtimeRoot;
            _runtimeBootstrap = runtimeBootstrap;
            Processes = new ObservableCollection<ManagedWowProcessItem>();
            InitializeComponent();
            ProcessGrid.ItemsSource = Processes;
            _autoAttachEnabled = OriginalProcessManagerSettings.GetAutoAttachEnabled();
            WriteControlAction("ctor auto-attach-enabled=" + _autoAttachEnabled);

            _refreshTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            _refreshTimer.Tick += async delegate { await RefreshProcessesAsync(); };
            _refreshTimer.Start();
            Dispatcher.BeginInvoke(new Action(async delegate { await RefreshProcessesAsync(); }), DispatcherPriority.Background);

            Loaded += delegate
            {
                AutoAttachCheckBox.IsChecked = _autoAttachEnabled;
                _autoAttachInitializationComplete = true;
                _autoAttachAttemptPending = _autoAttachEnabled;
                WriteControlAction("control-loaded auto-attach-enabled=" + _autoAttachEnabled);
                _ = RefreshProcessesAsync();
            };
            Unloaded += delegate
            {
                WriteControlAction("control-unloaded");
                _refreshTimer.Stop();
            };
        }

        private ObservableCollection<ManagedWowProcessItem> Processes { get; }

        private async Task RefreshProcessesAsync()
        {
            if (_refreshInProgress)
            {
                WriteControlAction("refresh-skip in-progress");
                return;
            }

            _refreshInProgress = true;
            WriteControlAction("refresh-begin");

            try
            {
                var refreshGeneration = ++_refreshGeneration;
                var current = await Task.Run(() => WowProcessDiscovery.FindCandidateProcesses());
                WriteControlAction("refresh-candidates count=" + current.Count);

                foreach (var process in current)
                {
                    var existing = Processes.FirstOrDefault(item => item.ProcessId == process.Id);
                    if (existing == null)
                    {
                        existing = new ManagedWowProcessItem(_runtimeRoot, _runtimeBootstrap, process.Id);
                        Processes.Add(existing);
                    }

                    existing.UpdateFrom(process);
                }

                foreach (var stale in Processes.Where(item => current.All(process => process.Id != item.ProcessId)).ToList())
                {
                    stale.Detach();
                    Processes.Remove(stale);
                }

                var attached = Processes.Where(item => item.IsAttached).OrderBy(item => item.ProcessId).ToList();
                if (attached.Count > 1)
                {
                    var keep = attached.First();
                    foreach (var extra in attached.Where(item => item != keep))
                    {
                        extra.Detach();
                    }
                    StatusText.Text = "已保留一个接管进程，其余接管状态已清除。";
                }
                else
                {
                    StatusText.Text = Processes.Count == 0
                        ? "未发现有效 Wow 进程，保持自动扫描。"
                        : "发现 " + Processes.Count + " 个有效 Wow 进程，请只勾选一个进程进入本地接管状态。";
                }

                var attachedItem = Processes.FirstOrDefault(item => item.IsAttached);
                if (attachedItem != null)
                {
                    WriteControlAction("refresh-attached pid=" + attachedItem.ProcessId);
                    await attachedItem.RefreshRuntimeSnapshotIfAttachedAsync(refreshGeneration, _refreshGeneration);
                    WriteControlAction("refresh-session " + DescribeSession(_runtimeBootstrap.GetCurrentSessionSnapshot()));
                }
                else
                {
                    WriteControlAction("refresh-no-attached");
                    WriteControlAction("refresh-session session=null");
                    TryAutoAttachSingleCandidate();
                }
            }
            finally
            {
                WriteControlAction("refresh-end");
                _refreshInProgress = false;
            }
        }

        private void OnRefreshClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            WriteControlAction("refresh-click");
            _ = RefreshProcessesAsync();
        }

        private void AutoAttachCheckBox_OnChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!_autoAttachInitializationComplete)
            {
                return;
            }

            _autoAttachEnabled = AutoAttachCheckBox.IsChecked == true;
            OriginalProcessManagerSettings.SetAutoAttachEnabled(_autoAttachEnabled);
            _autoAttachAttemptPending = _autoAttachEnabled;
            WriteControlAction("auto-attach-setting value=" + _autoAttachEnabled);
            if (_autoAttachEnabled)
            {
                TryAutoAttachSingleCandidate();
            }
        }

        private void OnAttachButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is ManagedWowProcessItem item)
            {
                WriteControlAction("attach-button-click pid=" + item.ProcessId + " attached=" + item.IsAttached);

                foreach (var processItem in Processes.Where(processItem => processItem != item && processItem.IsAttached).ToList())
                {
                    processItem.Detach();
                }

                item.ToggleAttach();
            }
        }

        private void WriteControlAction(string action)
        {
            try
            {
                var path = Path.Combine(_runtimeRoot, "logs", "process-management-host-actions.txt");
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.AppendAllText(path, DateTime.Now.ToString("s") + " " + action + Environment.NewLine);
            }
            catch
            {
            }
        }

        private void TryAutoAttachSingleCandidate()
        {
            if (!_autoAttachEnabled)
            {
                WriteControlAction("auto-attach-skip reason=disabled");
                return;
            }

            if (!_autoAttachAttemptPending)
            {
                WriteControlAction("auto-attach-skip reason=already-attempted");
                return;
            }

            if (Processes.Count != 1)
            {
                WriteControlAction("auto-attach-skip reason=count count=" + Processes.Count);
                return;
            }

            var item = Processes[0];
            if (item == null || item.IsAttached)
            {
                WriteControlAction("auto-attach-skip reason=already-attached");
                return;
            }

            WriteControlAction("auto-attach-trigger pid=" + item.ProcessId);
            _autoAttachAttemptPending = false;
            item.Attach();
        }

        private static string DescribeSession(RuntimeSession session)
        {
            if (session == null)
            {
                return "session=null";
            }

            return "pid=" + session.ProcessId +
                   " attached=" + session.IsAttached +
                   " initialized=" + session.SessionInitialized +
                   " memory=" + session.MemoryOpen +
                   " hook=" + session.HookReady +
                   " inGame=" + session.InGame +
                   " health=" + session.HealthState +
                   " name=" + Quote(session.CharacterName) +
                   " level=" + Quote(session.Level) +
                   " hp=" + Quote(session.HealthPercent) +
                   " state=" + Quote(session.RuntimeState) +
                   " error=" + Quote(session.LastError);
        }

        private static string Quote(string value)
        {
            return value == null ? "null" : "\"" + value.Replace("\"", "'") + "\"";
        }
    }

    internal sealed class ManagedWowProcessItem : INotifyPropertyChanged
    {
        private readonly string _runtimeRoot;
        private readonly OriginalRuntimeBootstrap _runtimeBootstrap;
        private bool _isAttached;
        private string _windowTitle;
        private string _characterName;
        private string _level;
        private string _healthPercent;
        private string _position;
        private string _gateState;
        private string _state;

        public ManagedWowProcessItem(string runtimeRoot, OriginalRuntimeBootstrap runtimeBootstrap, int processId)
        {
            _runtimeRoot = runtimeRoot;
            _runtimeBootstrap = runtimeBootstrap;
            ProcessId = processId;
            CharacterName = "待接线";
            Level = "-";
            HealthPercent = "-";
            Position = "-";
            State = "未接管";
        }

        public int ProcessId { get; }

        public string AttachButtonText
        {
            get { return IsAttached ? "断开" : "接管"; }
        }

        public bool IsAttached
        {
            get { return _isAttached; }
            set
            {
                if (_isAttached == value)
                {
                    return;
                }

                _isAttached = value;
                if (value)
                {
                    Attach();
                }
                else
                {
                    Detach();
                }

                OnPropertyChanged(nameof(AttachButtonText));
                OnPropertyChanged();
            }
        }

        public string WindowTitle
        {
            get { return _windowTitle; }
            private set
            {
                if (_windowTitle != value)
                {
                    _windowTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CharacterName
        {
            get { return _characterName; }
            private set
            {
                if (_characterName != value)
                {
                    _characterName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Level
        {
            get { return _level; }
            private set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged();
                }
            }
        }

        public string HealthPercent
        {
            get { return _healthPercent; }
            private set
            {
                if (_healthPercent != value)
                {
                    _healthPercent = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Position
        {
            get { return _position; }
            private set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChanged();
                }
            }
        }

        public string GateState
        {
            get { return _gateState; }
            private set
            {
                if (_gateState != value)
                {
                    _gateState = value;
                    OnPropertyChanged();
                }
            }
        }

        public string State
        {
            get { return _state; }
            private set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateFrom(Process process)
        {
            WindowTitle = string.IsNullOrWhiteSpace(process.MainWindowTitle) ? "Wow.exe" : process.MainWindowTitle;
        }

        public async Task RefreshRuntimeSnapshotIfAttachedAsync(int requestedGeneration, int currentGeneration)
        {
            if (!IsAttached)
            {
                return;
            }

            var result = await Task.Run(() => _runtimeBootstrap.RefreshAttachedProcess());
            WriteAction("refresh-result ok=" + result.Ok + " message=" + Quote(result.Message));
            if (requestedGeneration != currentGeneration)
            {
                WriteAction("refresh-result-stale requested=" + requestedGeneration + " current=" + currentGeneration);
                return;
            }

            if (result.Ok)
            {
                ApplyRuntimeResult(result);
                ApplySessionSnapshot(_runtimeBootstrap.GetCurrentSessionSnapshot());
            }
            else
            {
                var session = _runtimeBootstrap.GetCurrentSessionSnapshot();
                if (session != null && session.HealthState == SessionHealthState.Ready)
                {
                    ApplySessionSnapshot(session);
                }
                else
                {
                    ApplyRuntimeResult(result);
                    ApplySessionSnapshot(session);
                }
            }
        }

        public void Attach()
        {
            if (!_isAttached)
            {
                _isAttached = true;
                OnPropertyChanged(nameof(IsAttached));
                OnPropertyChanged(nameof(AttachButtonText));
            }

            State = "接管中...";
            GateState = "接管中";
            WriteAction("attach-request");
            _ = AttachAsync();
        }

        public void Detach()
        {
            if (_isAttached)
            {
                _isAttached = false;
                OnPropertyChanged(nameof(IsAttached));
            }

            _runtimeBootstrap.Detach();
            CharacterName = "待接线";
            Level = "-";
            HealthPercent = "-";
            Position = "-";
            GateState = "未评估";
            State = "未接管";
            WriteAction("detach session=closed");
            OnPropertyChanged(nameof(AttachButtonText));
        }

        public void ToggleAttach()
        {
            if (IsAttached)
            {
                Detach();
                return;
            }

            Attach();
        }

        private void ApplyRuntimeResult(OriginalRuntimeAttachResult result)
        {
            if (result.Ok)
            {
                GateState = "可读状态";
                CharacterName = string.IsNullOrWhiteSpace(result.CharacterName) ? "已连接" : result.CharacterName;
                Level = string.IsNullOrWhiteSpace(result.Level) ? "-" : result.Level;
                HealthPercent = string.IsNullOrWhiteSpace(result.HealthPercent) ? "-" : result.HealthPercent;
                Position = NormalizePosition(result.Position);
                State = DescribeStateText(result.RuntimeState);
            }
            else
            {
                GateState = DescribeGateState(result.Message);
                State = DescribeStateText(result.Message);
            }
        }

        private static string DescribeGateState(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return "失败";
            }

            if (message.IndexOf("尚未建立接管会话", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "未接管";
            }

            if (message.IndexOf("接管会话未完成", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "接管未完成";
            }

            if (message.IndexOf("尚未附着", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "未附着";
            }

            if (message.IndexOf("Memory.Open", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "内存失败";
            }

            if (message.IndexOf("Hook 未就绪", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "Hook未就绪";
            }

            if (message.IndexOf("进入世界", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "未进世界";
            }

            if (message.IndexOf("丢失", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "已丢失";
            }

            if (message.IndexOf("故障", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "故障";
            }

            return "失败";
        }

        private void WriteAction(string action)
        {
            try
            {
                var path = Path.Combine(_runtimeRoot, "Logs", "process-management-actions.txt");
                File.AppendAllText(path, DateTime.Now.ToString("s") + " " + action + " pid=" + ProcessId + Environment.NewLine);
            }
            catch
            {
            }
        }

        private static string Quote(string value)
        {
            return value == null ? "null" : "\"" + value.Replace("\"", "'") + "\"";
        }

        private void ApplySessionSnapshot(RuntimeSession session)
        {
            if (session == null || session.ProcessId != ProcessId)
            {
                return;
            }

            if (session.HealthState == SessionHealthState.Ready)
            {
                GateState = "已通过";
            }
            else if (session.HealthState == SessionHealthState.HookPending)
            {
                GateState = "Hook未就绪";
                if (string.Equals(State, "游戏中", StringComparison.OrdinalIgnoreCase) ||
                    string.IsNullOrWhiteSpace(State) ||
                    State == "-")
                {
                    State = "可读状态";
                }
            }
            else if (!string.IsNullOrWhiteSpace(session.LastError))
            {
                GateState = DescribeGateState(session.LastError);
            }
            else
            {
                GateState = session.HealthState.ToString();
            }

            if (!string.IsNullOrWhiteSpace(session.CharacterName))
            {
                CharacterName = session.CharacterName;
            }

            if (!string.IsNullOrWhiteSpace(session.Level))
            {
                Level = session.Level;
            }

            if (!string.IsNullOrWhiteSpace(session.HealthPercent))
            {
                HealthPercent = session.HealthPercent;
            }

            if (!string.IsNullOrWhiteSpace(session.Position))
            {
                Position = NormalizePosition(session.Position);
            }

            var healthLabel = session.HealthState.ToString();
            if (!string.IsNullOrWhiteSpace(session.RuntimeState))
            {
                State = DescribeStateText(session.RuntimeState);
            }
            else if (!string.IsNullOrWhiteSpace(session.LastError))
            {
                State = DescribeStateText(session.LastError);
            }
            else
            {
                State = DescribeHealthState(session.HealthState);
            }
        }

        private static string NormalizePosition(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "-";
            }

            var compact = value.Trim();
            return compact.Length <= 24 ? compact : compact.Substring(0, 24) + "...";
        }

        private static string DescribeStateText(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return "-";
            }

            if (message.IndexOf("接管会话未完成", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "需重新接管";
            }

            if (message.IndexOf("尚未建立接管会话", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "尚未接管";
            }

            if (message.IndexOf("尚未附着", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "等待附着";
            }

            if (message.IndexOf("Hook 未就绪", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "等待 Hook";
            }

            if (message.IndexOf("Memory.Open", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "内存句柄无效";
            }

            if (message.IndexOf("进入世界", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "等待进世界";
            }

            if (message.IndexOf("故障", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "会话故障";
            }

            if (message.IndexOf("丢失", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "会话已丢失";
            }

            if (string.Equals(message, "游戏中", StringComparison.OrdinalIgnoreCase))
            {
                return "可读状态";
            }

            if (string.Equals(message, "未进入游戏", StringComparison.OrdinalIgnoreCase))
            {
                return "未进世界";
            }

            return message.Length <= 20 ? message : message.Substring(0, 20) + "...";
        }

        private static string DescribeHealthState(SessionHealthState healthState)
        {
            switch (healthState)
            {
                case SessionHealthState.Selected:
                    return "已选择";
                case SessionHealthState.Attaching:
                    return "接管中";
                case SessionHealthState.Attached:
                    return "已附着";
                case SessionHealthState.HookPending:
                    return "Hook未就绪";
                case SessionHealthState.Ready:
                    return "已通过";
                case SessionHealthState.Faulted:
                    return "会话故障";
                case SessionHealthState.Lost:
                    return "会话已丢失";
                case SessionHealthState.Closed:
                    return "已关闭";
                default:
                    return healthState.ToString();
            }
        }

        private async Task AttachAsync()
        {
            var result = await Task.Run(() => _runtimeBootstrap.AttachToWowProcess(ProcessId));
            if (result.Ok)
            {
                ApplyRuntimeResult(result);
                ApplySessionSnapshot(_runtimeBootstrap.GetCurrentSessionSnapshot());
                WriteAction("attach-ok message=" + Quote(result.Message));
            }
            else
            {
                if (OriginalProcessManagerSettings.GetAutoAttachEnabled())
                {
                    // Allow a future refresh cycle to retry when attach failed due to transient process state.
                    var parentControl = FindOwningControl();
                    parentControl?.RearmAutoAttachAttempt();
                }

                _isAttached = false;
                OnPropertyChanged(nameof(IsAttached));
                OnPropertyChanged(nameof(AttachButtonText));
                ApplyRuntimeResult(result);
                ApplySessionSnapshot(_runtimeBootstrap.GetCurrentSessionSnapshot());
                WriteAction("attach-failed message=" + Quote(result.Message));
            }
        }

        private ProcessManagementControl FindOwningControl()
        {
            return System.Windows.Application.Current?.Windows
                .OfType<System.Windows.Window>()
                .SelectMany(window => FindVisualChildren<ProcessManagementControl>(window))
                .FirstOrDefault();
        }

        private static System.Collections.Generic.IEnumerable<T> FindVisualChildren<T>(System.Windows.DependencyObject root)
            where T : System.Windows.DependencyObject
        {
            if (root == null)
            {
                yield break;
            }

            var count = System.Windows.Media.VisualTreeHelper.GetChildrenCount(root);
            for (var i = 0; i < count; i++)
            {
                var child = System.Windows.Media.VisualTreeHelper.GetChild(root, i);
                if (child is T match)
                {
                    yield return match;
                }

                foreach (var nested in FindVisualChildren<T>(child))
                {
                    yield return nested;
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class ProcessManagementControl
    {
        internal void RearmAutoAttachAttempt()
        {
            _autoAttachAttemptPending = _autoAttachEnabled;
            WriteControlAction("auto-attach-rearmed pending=" + _autoAttachAttemptPending);
        }
    }

    internal static class WowProcessDiscovery
    {
        private sealed class CachedIdentityDecision
        {
            public bool IsValidWow { get; set; }
            public DateTime ExpiresAtUtc { get; set; }
        }

        private sealed class ProcessIdentityInfo
        {
            public string ExecutablePath { get; set; }
            public string CommandLine { get; set; }
        }

        private static readonly string[] CandidateProcessNames =
        {
            "WoW",
            "Wow",
            "wow",
            "WowClassic",
            "World of Warcraft",
            "Warcraft"
        };

        private static readonly System.Collections.Generic.Dictionary<int, CachedIdentityDecision> IdentityDecisionCache =
            new System.Collections.Generic.Dictionary<int, CachedIdentityDecision>();

        private static readonly object IdentityDecisionCacheLock = new object();
        private static readonly TimeSpan ValidIdentityCacheLifetime = TimeSpan.FromSeconds(30);
        private static readonly TimeSpan InvalidIdentityCacheLifetime = TimeSpan.FromSeconds(5);

        public static System.Collections.Generic.List<Process> FindCandidateProcesses()
        {
            var processIds = new System.Collections.Generic.HashSet<int>();
            var processes = new System.Collections.Generic.List<Process>();

            foreach (var processName in CandidateProcessNames)
            {
                Process[] foundProcesses;
                try
                {
                    foundProcesses = Process.GetProcessesByName(processName);
                }
                catch
                {
                    continue;
                }

                foreach (var process in foundProcesses)
                {
                    if (!processIds.Add(process.Id))
                    {
                        continue;
                    }

                    if (!IsLikelyRealWowProcess(process))
                    {
                        continue;
                    }

                    processes.Add(process);
                }
            }

            TrimIdentityDecisionCache(processIds);
            return processes.OrderBy(process => process.Id).ToList();
        }

        private static bool IsLikelyRealWowProcess(Process process)
        {
            if (process == null)
            {
                return false;
            }

            try
            {
                if (process.HasExited)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            if (TryGetCachedIdentityDecision(process.Id, out var cachedIsValid))
            {
                return cachedIsValid;
            }

            var identity = TryReadProcessIdentity(process.Id);
            if (identity == null)
            {
                StoreCachedIdentityDecision(process.Id, false);
                return false;
            }

            if (string.IsNullOrWhiteSpace(identity.ExecutablePath) ||
                !identity.ExecutablePath.EndsWith("\\Wow.exe", StringComparison.OrdinalIgnoreCase))
            {
                StoreCachedIdentityDecision(process.Id, false);
                return false;
            }

            if (string.IsNullOrWhiteSpace(identity.CommandLine) ||
                identity.CommandLine.IndexOf("Wow.exe", StringComparison.OrdinalIgnoreCase) < 0)
            {
                StoreCachedIdentityDecision(process.Id, false);
                return false;
            }

            StoreCachedIdentityDecision(process.Id, true);
            return true;
        }

        private static ProcessIdentityInfo TryReadProcessIdentity(int processId)
        {
            try
            {
                using (var searcher = new System.Management.ManagementObjectSearcher(
                    "SELECT ExecutablePath, CommandLine FROM Win32_Process WHERE ProcessId = " + processId))
                using (var results = searcher.Get())
                {
                    foreach (System.Management.ManagementObject process in results)
                    {
                        return new ProcessIdentityInfo
                        {
                            ExecutablePath = process["ExecutablePath"] as string,
                            CommandLine = process["CommandLine"] as string
                        };
                    }
                }
            }
            catch
            {
            }

            return null;
        }

        private static bool TryGetCachedIdentityDecision(int processId, out bool isValidWow)
        {
            lock (IdentityDecisionCacheLock)
            {
                if (IdentityDecisionCache.TryGetValue(processId, out var cached))
                {
                    if (cached.ExpiresAtUtc > DateTime.UtcNow)
                    {
                        isValidWow = cached.IsValidWow;
                        return true;
                    }

                    IdentityDecisionCache.Remove(processId);
                }
            }

            isValidWow = false;
            return false;
        }

        private static void StoreCachedIdentityDecision(int processId, bool isValidWow)
        {
            lock (IdentityDecisionCacheLock)
            {
                IdentityDecisionCache[processId] = new CachedIdentityDecision
                {
                    IsValidWow = isValidWow,
                    ExpiresAtUtc = DateTime.UtcNow + (isValidWow ? ValidIdentityCacheLifetime : InvalidIdentityCacheLifetime)
                };
            }
        }

        private static void TrimIdentityDecisionCache(System.Collections.Generic.HashSet<int> liveProcessIds)
        {
            lock (IdentityDecisionCacheLock)
            {
                foreach (var pid in IdentityDecisionCache.Keys.ToList())
                {
                    if (IdentityDecisionCache[pid].ExpiresAtUtc <= DateTime.UtcNow ||
                        (liveProcessIds != null && liveProcessIds.Count > 0 && !liveProcessIds.Contains(pid)))
                    {
                        IdentityDecisionCache.Remove(pid);
                    }
                }
            }
        }
    }
}

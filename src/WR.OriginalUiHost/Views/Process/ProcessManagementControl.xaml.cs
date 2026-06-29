using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WR.OriginalUiHost
{
    public partial class ProcessManagementControl : UserControl
    {
        private readonly string _runtimeRoot;
        private readonly OriginalRuntimeBootstrap _runtimeBootstrap;
        private readonly DispatcherTimer _refreshTimer;
        private bool _refreshInProgress;

        public ProcessManagementControl(string runtimeRoot, OriginalRuntimeBootstrap runtimeBootstrap)
        {
            _runtimeRoot = runtimeRoot;
            _runtimeBootstrap = runtimeBootstrap;
            Processes = new ObservableCollection<ManagedWowProcessItem>();
            InitializeComponent();
            ProcessGrid.ItemsSource = Processes;

            _refreshTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };
            _refreshTimer.Tick += delegate { RefreshProcesses(); };
            _refreshTimer.Start();
            Dispatcher.BeginInvoke(new Action(RefreshProcesses), DispatcherPriority.Background);

            Loaded += delegate
            {
                RefreshProcesses();
            };
            Unloaded += delegate { _refreshTimer.Stop(); };
        }

        private ObservableCollection<ManagedWowProcessItem> Processes { get; }

        private void RefreshProcesses()
        {
            if (_refreshInProgress)
            {
                return;
            }

            _refreshInProgress = true;
            var current = Process.GetProcesses()
                .Where(process => process.ProcessName.Equals("Wow", StringComparison.OrdinalIgnoreCase))
                .OrderBy(process => process.Id)
                .ToList();

            try
            {
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

                var attached = Processes.Where(item => item.IsAttached).ToList();
                if (attached.Count > 1)
                {
                    var keep = attached.OrderBy(item => item.ProcessId).First();
                    foreach (var extra in attached.Where(item => item != keep))
                    {
                        extra.Detach();
                    }
                    StatusText.Text = "已保留一个接管进程，其余接管状态已清除。";
                }
                else if (current.Count == 1 && !Processes[0].IsAttached)
                {
                    Processes[0].Attach();
                    StatusText.Text = "发现 1 个 Wow.exe，已自动接管并刷新基础状态。";
                }
                else
                {
                    StatusText.Text = Processes.Count == 0
                        ? "未发现 Wow.exe，保持自动扫描。"
                        : "发现 " + Processes.Count + " 个 Wow.exe，请只勾选一个进程进入本地接管状态。";
                }

                foreach (var item in Processes.Where(item => item.IsAttached))
                {
                    item.RefreshRuntimeSnapshotIfAttached();
                }
            }
            finally
            {
                _refreshInProgress = false;
            }
        }

        private void OnRefreshClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            RefreshProcesses();
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

        public void RefreshRuntimeSnapshotIfAttached()
        {
            if (!IsAttached)
            {
                return;
            }

            var result = _runtimeBootstrap.RefreshAttachedProcess();
            ApplyRuntimeResult(result);
        }

        public void Attach()
        {
            if (!_isAttached)
            {
                _isAttached = true;
                OnPropertyChanged(nameof(IsAttached));
            }

            var result = _runtimeBootstrap.AttachToWowProcess(ProcessId);
            ApplyRuntimeResult(result);
            WriteAction("attach " + result.Message);
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
            State = "未接管";
            WriteAction("detach");
        }

        private void ApplyRuntimeResult(OriginalRuntimeAttachResult result)
        {
            if (result.Ok)
            {
                CharacterName = string.IsNullOrWhiteSpace(result.CharacterName) ? "已连接" : result.CharacterName;
                Level = string.IsNullOrWhiteSpace(result.Level) ? "-" : result.Level;
                HealthPercent = string.IsNullOrWhiteSpace(result.HealthPercent) ? "-" : result.HealthPercent;
                Position = string.IsNullOrWhiteSpace(result.Position) ? "-" : result.Position;
                State = result.RuntimeState;
            }
            else
            {
                State = result.Message;
            }
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

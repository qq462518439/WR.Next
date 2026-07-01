using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using wManager;
using wManager.Wow.ObjectManager;
using wManager.Wow.Forms;

namespace WR.OriginalUiHost
{
    public partial class OriginalModeSelectionHostControl : UserControl, IOriginalThemeAware
    {
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;
        private readonly OriginalModeSelectionTakeoverAdapter _adapter;
        private readonly OriginalRuntimeBootstrap _runtimeBootstrap;
        private UserControlTabMain _originalControl;
        private DispatcherTimer _takeoverRetryTimer;
        private int _takeoverAttemptCount;

        public OriginalModeSelectionHostControl(OriginalRuntimeBootstrap runtimeBootstrap)
        {
            _runtimeBootstrap = runtimeBootstrap;
            _adapter = new OriginalModeSelectionTakeoverAdapter(Paths.Root, runtimeBootstrap);
            InitializeComponent();
            Loaded += OnLoaded;
            LoadOriginalModeSelectionUi();
        }

        private void LoadOriginalModeSelectionUi()
        {
            try
            {
                WriteHostAction("args-before-load " + DescribeArgsState());
                wManager.Pulsator.DontCloseWhenPlayerChanges = true;
                WriteHostAction("dont-close-when-player-changes=true");
                TryForcePreferredProductSetting();
                WriteHostAction("args-after-force " + DescribeArgsState());
                _originalControl = new UserControlTabMain();
                _adapter.Attach(_originalControl);
                ModeSelectionContent.Content = _originalControl;
                FailurePanel.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                ModeSelectionContent.Content = null;
                FailureText.Text = ex.GetType().FullName + ": " + ex.Message + Environment.NewLine + ex.StackTrace;
                FailurePanel.Visibility = Visibility.Visible;
            }
        }

        private static void TryForcePreferredProductSetting()
        {
            try
            {
                var hasCharacterContext = ObjectManager.Me != null &&
                                          ObjectManager.Me.IsValid &&
                                          !string.IsNullOrWhiteSpace(ObjectManager.Me.Name) &&
                                          !string.IsNullOrWhiteSpace(wManager.Wow.Helpers.Usefuls.RealmName);

                WriteHostAction(
                    "preferred-product-context" +
                    " hasCharacterContext=" + hasCharacterContext +
                    " me=" + (ObjectManager.Me?.Name ?? "null") +
                    " realm=" + (wManager.Wow.Helpers.Usefuls.RealmName ?? "null"));

                if (ObjectManager.Me != null &&
                    ObjectManager.Me.IsValid &&
                    !string.IsNullOrWhiteSpace(ObjectManager.Me.Name) &&
                    !string.IsNullOrWhiteSpace(wManager.Wow.Helpers.Usefuls.RealmName))
                {
                    wManagerSetting.Load(loadBlacklist: false);
                    WriteHostAction("preferred-product-reload " + ObjectManager.Me.Name + "." + wManager.Wow.Helpers.Usefuls.RealmName);
                }

                var currentSetting = wManagerSetting.CurrentSetting;
                if (currentSetting == null)
                {
                    return;
                }

                if (!hasCharacterContext)
                {
                    wManagerSetting.CurrentSetting = currentSetting;
                }

                WriteHostAction("preferred-product-observe persisted=" + (currentSetting.LastProductSelected ?? "null"));
            }
            catch (Exception ex)
            {
                WriteHostAction("preferred-product-set-failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static string DescribeArgsState()
        {
            try
            {
                return "argsProduct=" + (robotManager.Helpful.ArgsParser.GetArgs?.Product ?? "null") +
                       " argsProfile=" + (robotManager.Helpful.ArgsParser.GetArgs?.Profile ?? "null") +
                       " lastProduct=" + (wManagerSetting.CurrentSetting?.LastProductSelected ?? "null") +
                       " currentDir=" + robotManager.Helpful.Others.GetCurrentDirectory;
            }
            catch (Exception ex)
            {
                return "args-state-error " + ex.GetType().Name + ": " + ex.Message;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            WriteHostAction("host-control-loaded");
            if (_originalControl != null)
            {
                Dispatcher.BeginInvoke(
                    DispatcherPriority.Loaded,
                    new Action(delegate
                    {
                        WriteHostAction("host-control-idle");
                        StartTakeoverRetryLoop();
                    }));
            }
        }

        private void StartTakeoverRetryLoop()
        {
            var session = _runtimeBootstrap.GetCurrentSessionSnapshot();
            if (session == null || !session.IsAttached || session.ProcessId <= 0)
            {
                WriteHostAction("retry-loop-skip no-attached-session");
                _takeoverRetryTimer?.Stop();
                return;
            }

            WriteHostAction("retry-loop-start");
            _takeoverRetryTimer?.Stop();
            _takeoverAttemptCount = 0;
            _takeoverRetryTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(250)
            };
            _takeoverRetryTimer.Tick += OnTakeoverRetryTick;
            _takeoverRetryTimer.Start();
        }

        private void OnTakeoverRetryTick(object sender, EventArgs e)
        {
            if (_originalControl == null || _takeoverRetryTimer == null)
            {
                WriteHostAction("retry-skip");
                return;
            }

            var session = _runtimeBootstrap.GetCurrentSessionSnapshot();
            if (session == null || !session.IsAttached || session.ProcessId <= 0)
            {
                WriteHostAction("retry-stop-no-attached-session");
                _takeoverRetryTimer.Stop();
                _takeoverRetryTimer.Tick -= OnTakeoverRetryTick;
                _takeoverRetryTimer = null;
                return;
            }

            _takeoverAttemptCount++;
            WriteHostAction("retry-tick-" + _takeoverAttemptCount);
            _adapter.ApplyNow(_originalControl, "retry-" + _takeoverAttemptCount);

            if (_adapter.IsReady(_originalControl) || _takeoverAttemptCount >= 20)
            {
                WriteHostAction("retry-stop-" + _takeoverAttemptCount);
                _takeoverRetryTimer.Stop();
                _takeoverRetryTimer.Tick -= OnTakeoverRetryTick;
                _takeoverRetryTimer = null;
            }
        }

        private void OnOpenModeSettingsClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                OriginalShellNavigator.NavigateTo("_0004_CFG");
            }
            catch (Exception ex)
            {
                WriteHostAction("open-mode-settings-failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void WriteHostAction(string action)
        {
            try
            {
                var path = Path.Combine(Paths.LogsRoot, "original-mode-selection-host-actions.txt");
                File.AppendAllText(path, DateTime.Now.ToString("s") + " " + action + Environment.NewLine);
            }
            catch
            {
            }
        }

        public void RefreshTheme()
        {
            if (_originalControl != null)
            {
                _adapter.ApplyNow(_originalControl, "theme-refresh");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using wManager.Wow.Forms;

namespace WR.OriginalUiHost
{
    public partial class OriginalToolsHostControl : UserControl, IOriginalLanguageAware
    {
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;

        private static readonly string[] HighRiskButtonFields =
        {
            "_0002",
            "_0008",
            "_0005_2004",
            "_0003_2004",
            "_000E_2004",
            "_0002_2007",
            "_0008_2007",
            "_0006_2007",
            "_000F_2007",
            "_0005_2007",
            "_0003_2007",
            "_000E_2007",
            "_0002_2003",
            "_0008_2003",
            "_0006_2003",
            "_000F_2003",
            "_0005_2003",
            "_0003_2003"
        };

        private UserControlTabTools _originalControl;
        private bool _languageInitialized;
        private bool _languageSwitchInProgress;
        private bool _themeInitialized;
        private bool _themeSwitchInProgress;
        private static readonly TimeSpan LoadTimeout = TimeSpan.FromSeconds(6);

        public OriginalToolsHostControl()
        {
            InitializeComponent();
            Loaded += delegate
            {
                InitializeLanguageSelector();
                InitializeThemeSelector();
                EnsureOriginalControlLoaded("loaded");
            };
        }

        private void EnsureOriginalControlLoaded(string stage)
        {
            if (_originalControl != null && OriginalContentHost.Content == _originalControl)
            {
                return;
            }

            try
            {
                ShowLoading(stage);
                var probeFailure = ProbeToolControl(stage);
                if (!string.IsNullOrWhiteSpace(probeFailure))
                {
                    LoadingPanel.Visibility = Visibility.Collapsed;
                    OriginalContentHost.Visibility = Visibility.Collapsed;
                    FailureText.Text = probeFailure;
                    FailurePanel.Visibility = Visibility.Visible;
                    WriteAction(stage + " probe-blocked");
                    return;
                }

                Directory.SetCurrentDirectory(Paths.Root);
                OriginalLanguageManager.EnsureLanguageAssets();
                OriginalLanguageManager.ApplyLanguage(OriginalLanguageManager.GetCurrentLanguageFileName());
                _originalControl = new UserControlTabTools();
                HideHighRiskButtons(_originalControl);
                OriginalContentHost.Content = _originalControl;
                OriginalContentHost.Visibility = Visibility.Visible;
                LoadingPanel.Visibility = Visibility.Collapsed;
                FailurePanel.Visibility = Visibility.Collapsed;
                WriteAction(stage + " attach-original-tools success");
            }
            catch (Exception ex)
            {
                ShowFailure(stage, ex);
                WriteAction(stage + " attach-original-tools failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private string ProbeToolControl(string stage)
        {
            Exception probeException = null;
            var completed = false;
            var thread = new Thread(
                delegate()
                {
                    try
                    {
                        Directory.SetCurrentDirectory(Paths.Root);
                        OriginalLanguageManager.EnsureLanguageAssets();
                        OriginalLanguageManager.ApplyLanguage(OriginalLanguageManager.GetCurrentLanguageFileName());
                        var control = new UserControlTabTools();
                        HideHighRiskButtons(control);
                        completed = true;
                    }
                    catch (Exception ex)
                    {
                        probeException = ex;
                        completed = true;
                    }
                });

            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();

            if (!thread.Join(LoadTimeout))
            {
                WriteAction(stage + " probe-timeout");
                return OriginalHostFailureFormatter.FormatProbeTimeout("工具页", Paths.Root, LoadTimeout) +
                       Environment.NewLine + Environment.NewLine +
                       "阶段: " + stage;
            }

            if (probeException != null)
            {
                WriteAction(stage + " probe-failed " + probeException.GetType().Name + ": " + probeException.Message);
                return OriginalHostFailureFormatter.Format("工具页", probeException, Paths.Root) +
                       Environment.NewLine + Environment.NewLine +
                       "阶段: " + stage + Environment.NewLine +
                       "说明: 失败发生在独立预探测线程，主界面已阻止继续进入阻塞态。";
            }

            if (!completed)
            {
                WriteAction(stage + " probe-incomplete");
                return OriginalHostFailureFormatter.FormatProbeTimeout("工具页", Paths.Root, LoadTimeout) +
                       Environment.NewLine + Environment.NewLine +
                       "阶段: " + stage;
            }

            WriteAction(stage + " probe-success");
            return null;
        }

        public void RefreshLanguage()
        {
            try
            {
                _languageInitialized = false;
                _themeInitialized = false;
                _originalControl = null;
                OriginalContentHost.Content = null;
                InitializeLanguageSelector();
                InitializeThemeSelector();
                EnsureOriginalControlLoaded("language-refresh");
            }
            catch (Exception ex)
            {
                WriteAction("language-refresh failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void ShowLoading(string stage)
        {
            OriginalContentHost.Content = null;
            OriginalContentHost.Visibility = Visibility.Collapsed;
            FailurePanel.Visibility = Visibility.Collapsed;
            LoadingText.Text = "正在加载原版工具控件..." + Environment.NewLine +
                               "阶段: " + stage + Environment.NewLine +
                               "运行根: " + Paths.Root;
            LoadingPanel.Visibility = Visibility.Visible;
        }

        private void ShowFailure(string stage, Exception ex)
        {
            _originalControl = null;
            OriginalContentHost.Content = null;
            OriginalContentHost.Visibility = Visibility.Collapsed;
            LoadingPanel.Visibility = Visibility.Collapsed;
            FailureText.Text = OriginalHostFailureFormatter.Format("工具页", ex, Paths.Root) +
                               Environment.NewLine + Environment.NewLine +
                               "阶段: " + stage;
            FailurePanel.Visibility = Visibility.Visible;
        }

        private void InitializeLanguageSelector()
        {
            if (_languageInitialized)
            {
                return;
            }

            try
            {
                var options = OriginalLanguageManager.GetAvailableLanguages();
                LanguageComboBox.ItemsSource = options;
                var currentLanguage = OriginalLanguageManager.GetCurrentLanguageFileName();
                LanguageComboBox.SelectedItem = FindOption(options, currentLanguage) ?? FindOption(options, "中文-默认.xml") ?? (options.Count > 0 ? options[0] : null);
                _languageInitialized = true;
            }
            catch (Exception ex)
            {
                WriteAction("init-language-selector failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void InitializeThemeSelector()
        {
            if (_themeInitialized)
            {
                return;
            }

            try
            {
                var options = OriginalThemeManager.GetAvailableThemes();
                ThemeComboBox.ItemsSource = options;
                ThemeComboBox.SelectedItem = FindThemeOption(options, OriginalThemeManager.CurrentThemeKey) ?? (options.Count > 0 ? options[0] : null);
                _themeInitialized = true;
            }
            catch (Exception ex)
            {
                WriteAction("init-theme-selector failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void LanguageComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_languageInitialized || _languageSwitchInProgress)
            {
                return;
            }

            if (LanguageComboBox.SelectedItem is not OriginalLanguageOption option)
            {
                return;
            }

            try
            {
                _languageSwitchInProgress = true;
                if (!OriginalLanguageManager.ApplyLanguage(option.FileName))
                {
                    WriteAction("apply-language failed " + option.FileName);
                    return;
                }
                WriteAction("apply-language success " + option.FileName);
            }
            catch (Exception ex)
            {
                WriteAction("apply-language exception " + option.FileName + " " + ex.GetType().Name + ": " + ex.Message);
            }
            finally
            {
                _languageSwitchInProgress = false;
            }
        }

        private void ThemeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_themeInitialized || _themeSwitchInProgress)
            {
                return;
            }

            if (ThemeComboBox.SelectedItem is not OriginalThemeOption option)
            {
                return;
            }

            try
            {
                _themeSwitchInProgress = true;
                OriginalThemeManager.ApplyTheme(Application.Current, option.Key);
                WriteAction("apply-theme success " + option.Key);
            }
            catch (Exception ex)
            {
                WriteAction("apply-theme failed " + option.Key + " " + ex.GetType().Name + ": " + ex.Message);
            }
            finally
            {
                _themeSwitchInProgress = false;
            }
        }

        private static OriginalLanguageOption FindOption(IReadOnlyList<OriginalLanguageOption> options, string fileName)
        {
            foreach (var option in options)
            {
                if (string.Equals(option.FileName, fileName, StringComparison.OrdinalIgnoreCase))
                {
                    return option;
                }
            }

            return null;
        }

        private static OriginalThemeOption FindThemeOption(IReadOnlyList<OriginalThemeOption> options, string themeKey)
        {
            foreach (var option in options)
            {
                if (string.Equals(option.Key, themeKey, StringComparison.OrdinalIgnoreCase))
                {
                    return option;
                }
            }

            return null;
        }

        private static void HideHighRiskButtons(UserControlTabTools control)
        {
            foreach (var fieldName in HighRiskButtonFields)
            {
                try
                {
                    var field = typeof(UserControlTabTools).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    if (field?.GetValue(control) is Button button)
                    {
                        button.Visibility = Visibility.Collapsed;
                        button.IsEnabled = false;
                    }
                }
                catch
                {
                }
            }
        }

        public void RefreshTheme()
        {
            if (_originalControl != null)
            {
                OriginalEmbeddedThemeStyler.Apply(_originalControl);
            }
        }

        private static void WriteAction(string action)
        {
            try
            {
                var path = Path.Combine(Paths.LogsRoot, "original-tools-host-actions.txt");
                File.AppendAllText(path, DateTime.Now.ToString("s") + " " + action + Environment.NewLine);
            }
            catch
            {
            }
        }
    }
}

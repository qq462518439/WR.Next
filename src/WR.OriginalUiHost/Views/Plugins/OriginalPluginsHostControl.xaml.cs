using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using wManager.Wow.Forms;

namespace WR.OriginalUiHost
{
    public partial class OriginalPluginsHostControl : UserControl, IOriginalThemeAware
    {
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;
        private PluginsUserControl _originalControl;

        public OriginalPluginsHostControl()
        {
            InitializeComponent();
            Loaded += delegate { EnsureOriginalControlLoaded("loaded"); };
        }

        private void EnsureOriginalControlLoaded(string stage)
        {
            if (_originalControl != null)
            {
                return;
            }

            try
            {
                Directory.SetCurrentDirectory(Paths.Root);
                _originalControl = new PluginsUserControl();
                HidePluginSettingsButton(_originalControl);
                OriginalEmbeddedThemeStyler.Apply(_originalControl);
                OriginalContentHost.Content = _originalControl;
                OriginalContentHost.Visibility = Visibility.Visible;
                FailurePanel.Visibility = Visibility.Collapsed;
                WriteAction(stage + " attach-original-plugins success");
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.GetType().FullName + ": " + ex.Message + Environment.NewLine + ex.StackTrace;
                OriginalContentHost.Content = null;
                OriginalContentHost.Visibility = Visibility.Collapsed;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction(stage + " attach-original-plugins failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void HidePluginSettingsButton(PluginsUserControl control)
        {
            try
            {
                var field = typeof(PluginsUserControl).GetField("_0008", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
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

        private static void WriteAction(string action)
        {
            try
            {
                var path = Path.Combine(Paths.LogsRoot, "original-plugins-host-actions.txt");
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
                OriginalEmbeddedThemeStyler.Apply(_originalControl);
            }
        }
    }
}

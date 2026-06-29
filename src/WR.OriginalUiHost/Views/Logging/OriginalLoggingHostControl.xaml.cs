using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using robotManager.Helpful.Forms.UserControls;

namespace WR.OriginalUiHost
{
    public partial class OriginalLoggingHostControl : UserControl, IOriginalThemeAware
    {
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;
        private LoggingUserControl _originalControl;

        public OriginalLoggingHostControl()
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
                LoggingUserControl.CanSendLog = false;
                var field = typeof(LoggingUserControl).GetField("SendLogProductName", BindingFlags.Public | BindingFlags.Static);
                if (field != null)
                {
                    field.SetValue(null, string.Empty);
                }
                _originalControl = new LoggingUserControl();
                OriginalEmbeddedThemeStyler.Apply(_originalControl);
                OriginalContentHost.Content = _originalControl;
                OriginalContentHost.Visibility = Visibility.Visible;
                WriteAction(stage + " attach-original-logging success");
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.GetType().FullName + ": " + ex.Message + Environment.NewLine + ex.StackTrace;
                OriginalContentHost.Content = null;
                OriginalContentHost.Visibility = Visibility.Collapsed;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction(stage + " attach-original-logging failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void WriteAction(string action)
        {
            try
            {
                var path = Path.Combine(Paths.LogsRoot, "original-logging-host-actions.txt");
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

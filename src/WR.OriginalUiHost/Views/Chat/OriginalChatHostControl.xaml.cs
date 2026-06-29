using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using wManager.Wow.Forms;

namespace WR.OriginalUiHost
{
    public partial class OriginalChatHostControl : UserControl, IOriginalThemeAware
    {
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;
        private ChatUserControler _originalControl;

        public OriginalChatHostControl()
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
                _originalControl = new ChatUserControler();
                DisableChatSendControls(_originalControl);
                OriginalEmbeddedThemeStyler.Apply(_originalControl);
                OriginalContentHost.Content = _originalControl;
                OriginalContentHost.Visibility = Visibility.Visible;
                WriteAction(stage + " attach-original-chat success");
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.GetType().FullName + ": " + ex.Message + Environment.NewLine + ex.StackTrace;
                OriginalContentHost.Content = null;
                OriginalContentHost.Visibility = Visibility.Collapsed;
                FailurePanel.Visibility = Visibility.Visible;
                WriteAction(stage + " attach-original-chat failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void DisableChatSendControls(ChatUserControler control)
        {
            DisableTextBox(control, "_0006_2004");
            DisableTextBox(control, "_0005_2004");
            DisableComboBox(control, "_000F_2004");
            DisableButton(control, "_0003_2004");
        }

        private static void DisableTextBox(ChatUserControler control, string fieldName)
        {
            try
            {
                var field = typeof(ChatUserControler).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (field?.GetValue(control) is TextBox textBox)
                {
                    textBox.IsReadOnly = true;
                    textBox.IsEnabled = false;
                }
            }
            catch
            {
            }
        }

        private static void DisableComboBox(ChatUserControler control, string fieldName)
        {
            try
            {
                var field = typeof(ChatUserControler).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (field?.GetValue(control) is ComboBox comboBox)
                {
                    comboBox.IsEnabled = false;
                }
            }
            catch
            {
            }
        }

        private static void DisableButton(ChatUserControler control, string fieldName)
        {
            try
            {
                var field = typeof(ChatUserControler).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
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
                var path = Path.Combine(Paths.LogsRoot, "original-chat-host-actions.txt");
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

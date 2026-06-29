using System;
using System.Windows;
using System.Windows.Controls;
using authManager;

namespace WR.OriginalUiHost
{
    public partial class OriginalLoginHostControl : UserControl
    {
        public OriginalLoginHostControl(string runtimeRoot)
        {
            InitializeComponent();
            LoadOriginalLoginUi(runtimeRoot);
        }

        private void LoadOriginalLoginUi(string runtimeRoot)
        {
            try
            {
                var control = new LoginUserControl
                {
                    ProductName = "WRotation",
                    OptionalVersionName = string.Empty
                };

                OriginalLoginContent.Content = control;
                new OriginalLoginTakeoverAdapter(runtimeRoot).Attach(control);
                FailurePanel.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                OriginalLoginContent.Content = null;
                FailureText.Text = ex.GetType().FullName + ": " + ex.Message + Environment.NewLine + ex.StackTrace;
                FailurePanel.Visibility = Visibility.Visible;
            }
        }
    }
}

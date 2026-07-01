using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace WR.OriginalUiHost
{
    internal static class OriginalShellNavigator
    {
        public static bool NavigateTo(string originalField)
        {
            if (string.IsNullOrWhiteSpace(originalField))
            {
                return false;
            }

            var window = Application.Current?.MainWindow;
            var viewModel = window?.DataContext as OriginalMainShellViewModel;
            var page = viewModel?.Pages.FirstOrDefault(item =>
                string.Equals(item.OriginalField, originalField, StringComparison.OrdinalIgnoreCase));

            if (page == null)
            {
                WriteNavigationTrace("navigate-miss", originalField);
                return false;
            }

            viewModel.SelectedPage = page;
            WriteNavigationTrace("navigate-hit", originalField);
            return true;
        }

        private static void WriteNavigationTrace(string action, string originalField)
        {
            try
            {
                var path = Path.Combine(OriginalRuntimePaths.Current.LogsRoot, "shell-navigation-actions.txt");
                var line =
                    DateTime.Now.ToString("s") +
                    " " + action +
                    " field=" + (originalField ?? "null");
                File.AppendAllText(path, line + Environment.NewLine);
            }
            catch
            {
            }
        }
    }
}

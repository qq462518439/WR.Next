using System;
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
                return false;
            }

            viewModel.SelectedPage = page;
            return true;
        }
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System;
using robotManager;

namespace WR.OriginalUiHost
{
    internal sealed class OriginalMainShellViewModel : INotifyPropertyChanged
    {
        private OriginalMainShellPage _selectedPage;

        public OriginalMainShellViewModel()
        {
            Pages = new ObservableCollection<OriginalMainShellPage>();
        }

        public ObservableCollection<OriginalMainShellPage> Pages { get; }

        public OriginalMainShellPage SelectedPage
        {
            get { return _selectedPage; }
            set
            {
                if (!ReferenceEquals(_selectedPage, value))
                {
                    var previous = _selectedPage;
                    _selectedPage = value;
                    WritePageSwitchTrace(previous, value);
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RefreshLanguage()
        {
            foreach (var page in Pages)
            {
                page.RefreshLanguage();
            }
        }

        public void RefreshTheme()
        {
            foreach (var page in Pages)
            {
                page.RefreshTheme();
            }
        }

        public OriginalMainShellPage FindPage(string originalField)
        {
            foreach (var page in Pages)
            {
                if (page.OriginalField == originalField)
                {
                    return page;
                }
            }

            return null;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static void WritePageSwitchTrace(OriginalMainShellPage previous, OriginalMainShellPage current)
        {
            try
            {
                var path = Path.Combine(OriginalRuntimePaths.Current.LogsRoot, "shell-navigation-actions.txt");
                var line =
                    DateTime.Now.ToString("s") +
                    " selected-page" +
                    " from=" + (previous?.OriginalField ?? "null") +
                    " to=" + (current?.OriginalField ?? "null") +
                    " title=" + (current?.Title ?? "null");
                File.AppendAllText(path, line + Environment.NewLine);
            }
            catch
            {
            }
        }
    }
}

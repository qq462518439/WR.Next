using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
                    _selectedPage = value;
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
    }
}

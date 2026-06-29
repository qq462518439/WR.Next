using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace WR.OriginalUiHost
{
    internal sealed class OriginalMainShellPage : INotifyPropertyChanged
    {
        private readonly Func<UserControl> _contentFactory;
        private readonly Func<string> _titleFactory;
        private UserControl _content;
        private string _title;

        public OriginalMainShellPage(string originalField, Func<string> titleFactory, Func<UserControl> contentFactory)
        {
            OriginalField = originalField;
            _titleFactory = titleFactory ?? throw new ArgumentNullException(nameof(titleFactory));
            _title = _titleFactory();
            _contentFactory = contentFactory ?? throw new ArgumentNullException(nameof(contentFactory));
        }

        public string OriginalField { get; }

        public string Title
        {
            get { return _title; }
            private set
            {
                if (!string.Equals(_title, value, StringComparison.Ordinal))
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public UserControl Content
        {
            get
            {
                if (_content == null)
                {
                    _content = _contentFactory();
                    OnPropertyChanged();
                }

                return _content;
            }
        }

        public void RefreshLanguage()
        {
            Title = _titleFactory();
            if (_content is IOriginalLanguageAware languageAware)
            {
                languageAware.RefreshLanguage();
            }
        }

        public void RefreshTheme()
        {
            if (_content is IOriginalThemeAware themeAware)
            {
                themeAware.RefreshTheme();
            }
        }

        public void InvalidateContent()
        {
            _content = null;
            OnPropertyChanged(nameof(Content));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

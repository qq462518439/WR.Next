using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using robotManager;
using robotManager.Products;

namespace WR.OriginalUiHost
{
    public partial class MainWindow : Window
    {
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;
        private readonly OriginalPopupSuppressor _popupSuppressor;
        private readonly OriginalRuntimeBootstrap _runtimeBootstrap;
        private readonly OriginalMainShellViewModel _viewModel;
        private bool _isClosing;

        public MainWindow()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(Paths.Root);
            _popupSuppressor = new OriginalPopupSuppressor(Paths.Root);
            _popupSuppressor.Start();
            _runtimeBootstrap = new OriginalRuntimeBootstrap(Paths.Root);
            _viewModel = BuildMainShellViewModel(_runtimeBootstrap);
            DataContext = _viewModel;
            OriginalLanguageManager.EnsureLanguageAssets();
            OriginalLanguageManager.ApplyLanguage(OriginalLanguageManager.GetCurrentLanguageFileName());
            OriginalLanguageManager.LanguageChanged += OnLanguageChanged;
            OriginalThemeManager.ThemeChanged += OnThemeChanged;
            Products.OnProductNeedSettings += OnProductNeedSettings;
            Loaded += OnLoaded;
            Closed += OnClosed;
        }

        private static OriginalMainShellViewModel BuildMainShellViewModel(OriginalRuntimeBootstrap runtimeBootstrap)
        {
            var viewModel = new OriginalMainShellViewModel();

            viewModel.Pages.Add(
                new OriginalMainShellPage(
                    "_0002",
                    () => Translate.Get("Select game process"),
                    () => new ProcessManagementControl(Paths.Root, runtimeBootstrap)));
            viewModel.Pages.Add(new OriginalMainShellPage("_0004", () => Translate.Get("Launch Bot"), () => new OriginalModeSelectionHostControl(runtimeBootstrap)));
            viewModel.Pages.Add(new OriginalMainShellPage("_0004_CFG", () => Translate.Get("Settings"), () => new OriginalModeSettingsHostControl()));
            viewModel.Pages.Add(new OriginalMainShellPage("_0008", () => Translate.Get("Game Information"), () => new OriginalInGameHostControl(runtimeBootstrap)));
            viewModel.Pages.Add(new OriginalMainShellPage("_0006", () => Translate.Get("Settings"), () => new OriginalGeneralSettingsHostControl()));
            viewModel.Pages.Add(new OriginalMainShellPage("_000F", () => Translate.Get("Plugins"), () => new OriginalPluginsHostControl()));
            viewModel.Pages.Add(new OriginalMainShellPage("_0005", () => Translate.Get("Logs"), () => new OriginalLoggingHostControl()));
            viewModel.Pages.Add(new OriginalMainShellPage("_0003", () => Translate.Get("Chat"), () => new OriginalChatHostControl()));
            viewModel.Pages.Add(new OriginalMainShellPage("_000E", () => Translate.Get("Tools"), () => new OriginalToolsHostControl()));
            viewModel.Pages.Add(new OriginalMainShellPage("_0002_2004", () => Translate.Get("MiniMap"), () => new OriginalMiniMapHostControl()));
            viewModel.SelectedPage = viewModel.Pages[0];

            return viewModel;
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            Dispatcher.Invoke(delegate
            {
                Title = Translate.Get("WRobot");
                _viewModel.RefreshLanguage();
            });
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            Dispatcher.Invoke(delegate
            {
                _viewModel.RefreshTheme();
            });
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(
                DispatcherPriority.ApplicationIdle,
                new Action(PrewarmSecondaryPages));
        }

        private void OnClosed(object sender, EventArgs e)
        {
            if (_isClosing)
            {
                return;
            }

            _isClosing = true;
            Products.OnProductNeedSettings -= OnProductNeedSettings;
            OriginalLanguageManager.LanguageChanged -= OnLanguageChanged;
            OriginalThemeManager.ThemeChanged -= OnThemeChanged;
            try
            {
                _popupSuppressor.Stop();
            }
            catch
            {
            }
            try
            {
                _runtimeBootstrap.Shutdown();
            }
            catch
            {
            }

            try
            {
                if (Application.Current != null)
                {
                    Application.Current.Shutdown();
                }
            }
            catch
            {
            }

            // Final hard-exit guard: some original runtime/UI threads survive normal WPF shutdown.
            try
            {
                Environment.Exit(0);
            }
            catch
            {
            }
        }

        private void OnProductNeedSettings(Products.ProductNeedSettingsEventArgs e)
        {
            if (e == null || !e.NeedSettings)
            {
                return;
            }

            Dispatcher.BeginInvoke(
                DispatcherPriority.Loaded,
                new Action(delegate
                {
                    if (OriginalShellNavigator.NavigateTo("_0004_CFG"))
                    {
                        TrySyncModeSettingsPage();
                    }
                }));
        }

        private void PrewarmSecondaryPages()
        {
            try
            {
                var modeSettingsPage = _viewModel.FindPage("_0004_CFG");
                _ = modeSettingsPage?.Content;
            }
            catch
            {
            }
        }

        private void TrySyncModeSettingsPage()
        {
            try
            {
                var modeSettingsPage = _viewModel.FindPage("_0004_CFG");
                var control = modeSettingsPage?.Content as OriginalModeSettingsHostControl;
                control?.SyncNow();
            }
            catch
            {
            }
        }

    }
}

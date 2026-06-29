using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using wManager.Wow.Helpers;
using wManager.Wow.Forms;

namespace WR.OriginalUiHost
{
    public partial class OriginalMiniMapHostControl : UserControl
    {
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;
        private static Slider _mapZoomSlider;
        private readonly DispatcherTimer _diagnosticTimer;
        private UserControlMiniMap _originalControl;

        public OriginalMiniMapHostControl()
        {
            InitializeComponent();
            _diagnosticTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1.5)
            };
            _diagnosticTimer.Tick += delegate { RefreshDiagnostics(); };
            Loaded += delegate { EnsureOriginalControlLoaded("loaded"); };
            Loaded += delegate
            {
                RefreshDiagnostics();
                _diagnosticTimer.Start();
            };
            Unloaded += delegate { _diagnosticTimer.Stop(); };
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
                _originalControl = new UserControlMiniMap();
                DisableHighRiskInteraction(_originalControl);
                OriginalContentHost.Content = _originalControl;
                OriginalContentHost.Visibility = Visibility.Visible;
                FailurePanel.Visibility = Visibility.Collapsed;
                RefreshDiagnostics();
                WriteAction(stage + " attach-original-minimap success");
            }
            catch (Exception ex)
            {
                OriginalContentHost.Content = null;
                OriginalContentHost.Visibility = Visibility.Collapsed;
                FailurePanel.Visibility = Visibility.Visible;
                DiagnosticText.Text = ex.GetType().FullName + ": " + ex.Message + Environment.NewLine + ex.StackTrace;
                WriteAction(stage + " attach-original-minimap failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void DisableHighRiskInteraction(UserControlMiniMap control)
        {
            try
            {
                control.Focusable = false;

                if (control.Content is UIElement rootElement)
                {
                    DisableButtonsRecursive(rootElement);
                }
            }
            catch
            {
            }

            try
            {
                var mapGridField = typeof(UserControlMiniMap).GetField("_0008_2004", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (mapGridField?.GetValue(control) is Grid mapGrid)
                {
                    mapGrid.MouseDown -= SuppressMapMouseDown;
                    mapGrid.PreviewMouseWheel -= RelayMapMouseWheel;
                    mapGrid.IsHitTestVisible = true;
                    mapGrid.MouseDown += SuppressMapMouseDown;
                    mapGrid.PreviewMouseWheel += RelayMapMouseWheel;
                }
            }
            catch
            {
            }

            try
            {
                var imageField = typeof(UserControlMiniMap).GetField("_0006_2004", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (imageField?.GetValue(control) is Image image)
                {
                    image.IsEnabled = false;
                    image.IsHitTestVisible = false;
                }
            }
            catch
            {
            }

            try
            {
                DisableCheckBox(control, "_000E_2004");
                DisableCheckBox(control, "_0002_2003");
                DisableCheckBox(control, "_0008_2003");
            }
            catch
            {
            }

            try
            {
                var savePathField = typeof(UserControlMiniMap).GetField("_000F_2003", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (savePathField?.GetValue(control) is TextBox savePathTextBox)
                {
                    savePathTextBox.IsReadOnly = true;
                    savePathTextBox.IsEnabled = false;
                }
            }
            catch
            {
            }

            try
            {
                var sliderField = typeof(UserControlMiniMap).GetField("_0003_2004", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (sliderField?.GetValue(control) is Slider slider)
                {
                    slider.IsEnabled = true;
                    slider.IsHitTestVisible = true;
                    _mapZoomSlider = slider;
                }
            }
            catch
            {
            }
        }

        private static void SuppressMapMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private static void RelayMapMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (_mapZoomSlider == null)
            {
                return;
            }

            try
            {
                var nextValue = _mapZoomSlider.Value + (0.1 * e.Delta / 120.0);
                if (nextValue > _mapZoomSlider.Maximum)
                {
                    _mapZoomSlider.Value = _mapZoomSlider.Maximum;
                }
                else if (nextValue < _mapZoomSlider.Minimum)
                {
                    _mapZoomSlider.Value = _mapZoomSlider.Minimum;
                }
                else
                {
                    _mapZoomSlider.Value = nextValue;
                }

                e.Handled = true;
            }
            catch
            {
            }
        }

        private static void DisableCheckBox(UserControlMiniMap control, string fieldName)
        {
            var field = typeof(UserControlMiniMap).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (field?.GetValue(control) is CheckBox checkBox)
            {
                checkBox.IsEnabled = false;
                checkBox.IsHitTestVisible = false;
            }
        }

        private static void DisableButtonsRecursive(DependencyObject root)
        {
            if (root == null)
            {
                return;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is Button button)
                {
                    button.Visibility = Visibility.Collapsed;
                    button.IsEnabled = false;
                }

                DisableButtonsRecursive(child);
            }
        }

        private static void WriteAction(string action)
        {
            try
            {
                var path = Path.Combine(Paths.LogsRoot, "original-minimap-host-actions.txt");
                File.AppendAllText(path, DateTime.Now.ToString("s") + " " + action + Environment.NewLine);
            }
            catch
            {
            }
        }

        private void RefreshDiagnostics()
        {
            try
            {
                Directory.SetCurrentDirectory(Paths.Root);

                var threadHooked = wManager.Wow.Memory.WowMemory.ThreadHooked;
                var inGame = Conditions.InGameAndConnected;
                var continent = SafeValue(delegate { return Usefuls.ContinentNameMpq; });
                var tileDirectory = string.IsNullOrWhiteSpace(continent)
                    ? string.Empty
                    : Path.Combine(Paths.MinimapsRoot, continent);
                var directoryExists = !string.IsNullOrWhiteSpace(tileDirectory) && Directory.Exists(tileDirectory);
                var jpgCount = directoryExists ? Directory.GetFiles(tileDirectory, "*.jpg").Length : 0;
                var sampleTile = directoryExists
                    ? GetSampleTileSummary(tileDirectory)
                    : "未命中目录";

                DiagnosticText.Text =
                    BuildDiagnosticText(threadHooked, inGame, continent, directoryExists, jpgCount, sampleTile) +
                    Environment.NewLine + Environment.NewLine +
                    "Hook: " + (threadHooked ? "True" : "False") + Environment.NewLine +
                    "游戏内: " + (inGame ? "True" : "False") + Environment.NewLine +
                    "大陆: " + (string.IsNullOrWhiteSpace(continent) ? "-" : continent) + Environment.NewLine +
                    "瓦片目录: " + (string.IsNullOrWhiteSpace(tileDirectory)
                        ? "-"
                        : tileDirectory + (directoryExists ? " [存在]" : " [不存在]")) + Environment.NewLine +
                    "样本瓦片: " + sampleTile + " / jpg=" + jpgCount;
            }
            catch (Exception ex)
            {
                DiagnosticText.Text = ex.GetType().Name + ": " + ex.Message;
            }
        }

        private static string BuildDiagnosticText(bool threadHooked, bool inGame, string continent, bool directoryExists, int jpgCount, string sampleTile)
        {
            if (!threadHooked)
            {
                return "地图未绘制：ThreadHooked=False。";
            }

            if (!inGame)
            {
                return "地图未绘制：InGameAndConnected=False。";
            }

            if (string.IsNullOrWhiteSpace(continent))
            {
                return "地图未绘制：大陆名为空。";
            }

            if (!directoryExists)
            {
                return "地图未绘制：当前大陆未命中本地瓦片目录。";
            }

            if (jpgCount == 0)
            {
                return "地图未绘制：当前大陆目录存在，但没有 jpg 瓦片。";
            }

            if (sampleTile.IndexOf("[0KB]", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "地图可能空白：命中了 0KB 瓦片样本。";
            }

            return "前置状态已满足，若仍空白，问题更可能在原控件内部绘制或当前角色地图命中。";
        }

        private static string GetSampleTileSummary(string tileDirectory)
        {
            try
            {
                var files = Directory.GetFiles(tileDirectory, "*.jpg");
                if (files.Length == 0)
                {
                    return "目录存在，但没有 jpg 瓦片";
                }

                Array.Sort(files, StringComparer.OrdinalIgnoreCase);
                var file = files[0];
                var info = new FileInfo(file);
                var sizeLabel = info.Length == 0 ? "0KB" : (info.Length / 1024.0).ToString("0.##") + "KB";
                return Path.GetFileName(file) + " [" + sizeLabel + "]";
            }
            catch (Exception ex)
            {
                return ex.GetType().Name + ": " + ex.Message;
            }
        }

        private static string SafeValue(Func<string> getter)
        {
            try
            {
                return getter();
            }
            catch (Exception ex)
            {
                return "ERR:" + ex.GetType().Name;
            }
        }

        private void OnRefreshClicked(object sender, RoutedEventArgs e)
        {
            RefreshDiagnostics();
            EnsureOriginalControlLoaded("manual-refresh");
        }

        private void OnOpenTileFolderClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var folder = Paths.MinimapsRoot;
                if (!Directory.Exists(folder))
                {
                    DiagnosticText.Text = "瓦片目录不存在: " + folder;
                    return;
                }

                System.Diagnostics.Process.Start("explorer.exe", folder);
            }
            catch (Exception ex)
            {
                DiagnosticText.Text = ex.GetType().Name + ": " + ex.Message;
            }
        }
    }
}

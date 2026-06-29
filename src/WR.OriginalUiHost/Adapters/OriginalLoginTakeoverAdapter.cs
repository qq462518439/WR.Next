using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using authManager;

namespace WR.OriginalUiHost
{
    internal sealed class OriginalLoginTakeoverAdapter
    {
        private readonly string _runtimeRoot;

        public OriginalLoginTakeoverAdapter(string runtimeRoot)
        {
            _runtimeRoot = runtimeRoot;
        }

        public void Attach(LoginUserControl control)
        {
            control.Loaded += delegate
            {
                ApplyTakeover(control, "loaded");
                control.Dispatcher.BeginInvoke(
                    DispatcherPriority.ApplicationIdle,
                    new Action(delegate { ApplyTakeover(control, "idle"); }));
            };
        }

        private void ApplyTakeover(LoginUserControl control, string stage)
        {
            WriteControlDiagnostics(control, stage + "-before-takeover");
            ReplaceProcessList(control);
            TakeOverOriginalFields(control);
            TakeOverLaunchButton(control);
            TakeOverRefreshButton(control);
            OverlayLocalButtons(control);
            HideOriginalBusyOverlays(control);
            WriteControlDiagnostics(control, stage + "-after-takeover");
            DumpControlTree(control);
        }

        private void WriteControlDiagnostics(LoginUserControl control, string stage)
        {
            try
            {
                var path = Path.Combine(_runtimeRoot, "Logs", "original-ui-host-diagnostics.txt");
                var line = DateTime.Now.ToString("s") + " " + stage +
                    " listBoxProcess=" + (control.listBoxProcess != null) +
                    " buttonRefresh=" + (control.buttonRefresh != null) +
                    " buttonLaunchBot=" + (control.buttonLaunchBot != null) +
                    " textBlockLaunchBot=" + (control.textBlockLaunchBot != null) +
                    " descendants=" + CountDescendants(control);
                File.AppendAllText(path, line + Environment.NewLine);
            }
            catch
            {
            }
        }

        private static int CountDescendants(DependencyObject root)
        {
            var count = 0;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                count++;
                count += CountDescendants(child);
            }

            return count;
        }

        private void DumpControlTree(DependencyObject root)
        {
            try
            {
                var path = Path.Combine(_runtimeRoot, "Logs", "original-ui-host-tree.txt");
                File.WriteAllText(path, string.Empty);
                DumpControlTree(root, path, 0);
            }
            catch
            {
            }
        }

        private static void DumpControlTree(DependencyObject root, string path, int depth)
        {
            var frameworkElement = root as FrameworkElement;
            var control = root as Control;
            var textBlock = root as TextBlock;
            var line = new string(' ', depth * 2) +
                root.GetType().Name +
                " name=" + (frameworkElement == null ? string.Empty : frameworkElement.Name) +
                " visibility=" + (frameworkElement == null ? string.Empty : frameworkElement.Visibility.ToString()) +
                " enabled=" + (control == null ? string.Empty : control.IsEnabled.ToString()) +
                " size=" + (frameworkElement == null ? string.Empty : frameworkElement.ActualWidth.ToString("0") + "x" + frameworkElement.ActualHeight.ToString("0")) +
                " text=" + (textBlock == null ? string.Empty : textBlock.Text);
            File.AppendAllText(path, line + Environment.NewLine);

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                DumpControlTree(VisualTreeHelper.GetChild(root, i), path, depth + 1);
            }
        }

        private static void HideOriginalBusyOverlays(DependencyObject root)
        {
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is ProgressBar progressBar)
                {
                    progressBar.Visibility = Visibility.Collapsed;
                }
                else if (child is Image image && image.ActualWidth >= 80 && image.ActualHeight >= 80)
                {
                    image.Visibility = Visibility.Collapsed;
                }

                HideOriginalBusyOverlays(child);
            }
        }

        private static void ReplaceProcessList(LoginUserControl control)
        {
            if (control.listBoxProcess == null)
            {
                return;
            }

            var wowProcesses = Process.GetProcesses()
                .Where(process => process.ProcessName.Equals("Wow", StringComparison.OrdinalIgnoreCase))
                .OrderBy(process => process.Id)
                .Select(process => new ProcessListItem(process.Id, process.MainWindowTitle, SafePath(process)))
                .ToList();

            control.listBoxProcess.ItemsSource = wowProcesses;
            control.listBoxProcess.DisplayMemberPath = "DisplayName";
            control.listBoxProcess.Visibility = Visibility.Visible;
            control.listBoxProcess.IsEnabled = true;
            if (wowProcesses.Count > 0)
            {
                control.listBoxProcess.SelectedIndex = 0;
            }
        }

        private static void TakeOverOriginalFields(LoginUserControl control)
        {
            var productComboBox = GetField<ComboBox>(control, "_0008");
            if (productComboBox != null)
            {
                productComboBox.Visibility = Visibility.Visible;
                productComboBox.IsEnabled = false;
                productComboBox.ItemsSource = null;
                productComboBox.Items.Clear();
                productComboBox.Items.Add("本地接管");
                productComboBox.SelectedIndex = 0;
            }

            HideField<Image>(control, "_0006");
            HideField<Image>(control, "_000E");
            HideField<Image>(control, "_0002_2004");
            DisableField<Button>(control, "_0005", "本地模式");

            var statusText = GetField<TextBlock>(control, "_000F");
            if (statusText != null)
            {
                statusText.Text = "本地进程接管";
                statusText.Visibility = Visibility.Visible;
            }

            var secondaryText = GetField<TextBlock>(control, "_0003");
            if (secondaryText != null)
            {
                secondaryText.Text = "账号/订阅/远程验证已隔离";
                secondaryText.Visibility = Visibility.Visible;
            }

            if (control.textBlockLaunchBot != null)
            {
                control.textBlockLaunchBot.Visibility = Visibility.Visible;
                control.textBlockLaunchBot.Text = "请选择 Wow.exe 后接管";
            }
        }

        private static void HideField<T>(LoginUserControl control, string fieldName) where T : UIElement
        {
            var element = GetField<T>(control, fieldName);
            if (element != null)
            {
                element.Visibility = Visibility.Collapsed;
            }
        }

        private static void DisableField<T>(LoginUserControl control, string fieldName, object content) where T : Button
        {
            var button = GetField<T>(control, fieldName);
            if (button != null)
            {
                button.Content = content;
                button.IsEnabled = false;
                button.IsHitTestVisible = false;
            }
        }

        private static T GetField<T>(LoginUserControl control, string fieldName) where T : class
        {
            var field = typeof(LoginUserControl).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return field == null ? null : field.GetValue(control) as T;
        }

        private void TakeOverLaunchButton(LoginUserControl control)
        {
            if (control.buttonLaunchBot == null)
            {
                return;
            }

            control.buttonLaunchBot.Content = "接管进程";
            control.buttonLaunchBot.Visibility = Visibility.Visible;
            control.buttonLaunchBot.IsEnabled = true;
            control.buttonLaunchBot.Command = new RelayCommand(delegate { HandleLaunch(control); });
            control.buttonLaunchBot.IsHitTestVisible = false;
            control.buttonLaunchBot.AddHandler(
                Button.ClickEvent,
                new RoutedEventHandler(delegate(object sender, RoutedEventArgs args)
                {
                    args.Handled = true;
                    HandleLaunch(control);
                }),
                true);
            control.buttonLaunchBot.Click += delegate(object sender, RoutedEventArgs args)
            {
                args.Handled = true;
                HandleLaunch(control);
            };
        }

        private void TakeOverRefreshButton(LoginUserControl control)
        {
            if (control.buttonRefresh == null)
            {
                return;
            }

            control.buttonRefresh.Visibility = Visibility.Visible;
            control.buttonRefresh.IsEnabled = true;
            control.buttonRefresh.Command = new RelayCommand(delegate { HandleRefresh(control); });
            control.buttonRefresh.IsHitTestVisible = false;
            control.buttonRefresh.AddHandler(
                Button.ClickEvent,
                new RoutedEventHandler(delegate(object sender, RoutedEventArgs args)
                {
                    args.Handled = true;
                    HandleRefresh(control);
                }),
                true);
            control.buttonRefresh.Click += delegate(object sender, RoutedEventArgs args)
            {
                args.Handled = true;
                HandleRefresh(control);
            };
        }

        private void HandleLaunch(LoginUserControl control)
        {
            var selected = control.listBoxProcess == null ? null : control.listBoxProcess.SelectedItem as ProcessListItem;
            WriteAction("launch-click selected=" + (selected == null ? "none" : selected.ProcessId.ToString()));
            if (control.textBlockLaunchBot != null)
            {
                control.textBlockLaunchBot.Text = selected == null
                    ? "未发现 Wow.exe"
                    : "已接管进程 " + selected.ProcessId + "，原始登录/订阅链已隔离";
            }
        }

        private void HandleRefresh(LoginUserControl control)
        {
            ReplaceProcessList(control);
            WriteAction("refresh-click");
            if (control.textBlockLaunchBot != null)
            {
                control.textBlockLaunchBot.Text = "进程列表已由新宿主刷新";
            }
        }

        private void OverlayLocalButtons(LoginUserControl control)
        {
            OverlayButton(control.buttonLaunchBot, "接管进程", delegate { HandleLaunch(control); });
            OverlayButton(control.buttonRefresh, "Refresh", delegate { HandleRefresh(control); });
        }

        private static void OverlayButton(Button originalButton, object content, Action clickAction)
        {
            if (originalButton == null || originalButton.Parent == null)
            {
                return;
            }

            var parent = originalButton.Parent as Panel;
            if (parent == null)
            {
                return;
            }

            var marker = "LocalTakeoverOverlay:" + content;
            foreach (UIElement child in parent.Children)
            {
                var existing = child as FrameworkElement;
                if (existing != null && Equals(existing.Tag, marker))
                {
                    return;
                }
            }

            var overlay = new Button
            {
                Content = content,
                Width = originalButton.ActualWidth > 0 ? originalButton.ActualWidth : originalButton.Width,
                Height = originalButton.ActualHeight > 0 ? originalButton.ActualHeight : originalButton.Height,
                Margin = originalButton.Margin,
                HorizontalAlignment = originalButton.HorizontalAlignment,
                VerticalAlignment = originalButton.VerticalAlignment,
                FontSize = originalButton.FontSize,
                FontFamily = originalButton.FontFamily,
                FontWeight = originalButton.FontWeight,
                Tag = marker
            };

            overlay.Click += delegate
            {
                clickAction();
            };

            Grid.SetColumn(overlay, Grid.GetColumn(originalButton));
            Grid.SetColumnSpan(overlay, Grid.GetColumnSpan(originalButton));
            Grid.SetRow(overlay, Grid.GetRow(originalButton));
            Grid.SetRowSpan(overlay, Grid.GetRowSpan(originalButton));
            Panel.SetZIndex(overlay, 1000);
            parent.Children.Add(overlay);
        }

        private void WriteAction(string action)
        {
            try
            {
                var path = Path.Combine(_runtimeRoot, "Logs", "original-ui-host-actions.txt");
                File.AppendAllText(path, DateTime.Now.ToString("s") + " " + action + Environment.NewLine);
            }
            catch
            {
            }
        }

        private static string SafePath(Process process)
        {
            try
            {
                return process.MainModule == null ? string.Empty : process.MainModule.FileName;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}

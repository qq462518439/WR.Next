using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
        private readonly bool _preserveOriginalAuthChain;
        private readonly bool _autoInvokeOriginalLaunch;

        public OriginalLoginTakeoverAdapter(string runtimeRoot)
        {
            _runtimeRoot = runtimeRoot;
            _preserveOriginalAuthChain = string.Equals(
                Environment.GetEnvironmentVariable("WR_AUTH_CHAIN_PROBE"),
                "1",
                StringComparison.Ordinal);
            _autoInvokeOriginalLaunch = string.Equals(
                Environment.GetEnvironmentVariable("WR_ALLOW_AUTH_EXPERIMENTS"),
                "1",
                StringComparison.Ordinal) &&
                string.Equals(
                Environment.GetEnvironmentVariable("WR_AUTH_AUTO_INVOKE"),
                "1",
                StringComparison.Ordinal);
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
            AttachAuthChainProbe(control);
            ReplaceProcessList(control);
            TakeOverOriginalFields(control);
            TakeOverLaunchButton(control);
            TakeOverRefreshButton(control);
            if (!_preserveOriginalAuthChain)
            {
                OverlayLocalButtons(control);
            }
            HideOriginalBusyOverlays(control);
            DumpAuthRuntimeBindings(control, stage);
            WriteControlDiagnostics(control, stage + "-after-takeover");
            DumpControlTree(control);
            TryAutoInvokeOriginalLaunch(control, stage);
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
            if (!_preserveOriginalAuthChain)
            {
                control.buttonLaunchBot.Command = new RelayCommand(delegate { HandleLaunch(control); });
                control.buttonLaunchBot.IsHitTestVisible = false;
            }
            control.buttonLaunchBot.AddHandler(
                Button.ClickEvent,
                new RoutedEventHandler(delegate(object sender, RoutedEventArgs args)
                {
                    DumpAuthRuntimeBindings(control, "launch-routed-click-before");
                    WriteAction(
                        "auth-chain launch-button routed-click handledBefore=" + args.Handled +
                        " preserveOriginal=" + _preserveOriginalAuthChain +
                        " selected=" + DescribeSelectedProcess(control));
                    if (!_preserveOriginalAuthChain)
                    {
                        args.Handled = true;
                        HandleLaunch(control);
                    }
                }),
                true);
            control.buttonLaunchBot.Click += delegate(object sender, RoutedEventArgs args)
            {
                DumpAuthRuntimeBindings(control, "launch-click-before");
                WriteAction(
                    "auth-chain launch-button click handledBefore=" + args.Handled +
                    " preserveOriginal=" + _preserveOriginalAuthChain +
                    " selected=" + DescribeSelectedProcess(control));
                if (!_preserveOriginalAuthChain)
                {
                    args.Handled = true;
                    HandleLaunch(control);
                }
                DumpAuthRuntimeBindings(control, "launch-click-after");
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
            if (!_preserveOriginalAuthChain)
            {
                control.buttonRefresh.Command = new RelayCommand(delegate { HandleRefresh(control); });
                control.buttonRefresh.IsHitTestVisible = false;
            }
            control.buttonRefresh.AddHandler(
                Button.ClickEvent,
                new RoutedEventHandler(delegate(object sender, RoutedEventArgs args)
                {
                    WriteAction(
                        "auth-chain refresh-button routed-click handledBefore=" + args.Handled +
                        " preserveOriginal=" + _preserveOriginalAuthChain);
                    if (!_preserveOriginalAuthChain)
                    {
                        args.Handled = true;
                        HandleRefresh(control);
                    }
                }),
                true);
            control.buttonRefresh.Click += delegate(object sender, RoutedEventArgs args)
            {
                WriteAction(
                    "auth-chain refresh-button click handledBefore=" + args.Handled +
                    " preserveOriginal=" + _preserveOriginalAuthChain);
                if (!_preserveOriginalAuthChain)
                {
                    args.Handled = true;
                    HandleRefresh(control);
                }
            };
        }

        private void HandleLaunch(LoginUserControl control)
        {
            var selected = control.listBoxProcess == null ? null : control.listBoxProcess.SelectedItem as ProcessListItem;
            WriteAction(
                "launch-click selected=" + (selected == null ? "none" : selected.ProcessId.ToString()) +
                " preserveOriginal=" + _preserveOriginalAuthChain +
                " textBefore=" + Quote(control.textBlockLaunchBot == null ? null : control.textBlockLaunchBot.Text));
            if (control.textBlockLaunchBot != null)
            {
                control.textBlockLaunchBot.Text = selected == null
                    ? "未发现 Wow.exe"
                    : "已接管进程 " + selected.ProcessId + "，原始登录/订阅链已隔离";
            }
            WriteAction("launch-click after text=" + Quote(control.textBlockLaunchBot == null ? null : control.textBlockLaunchBot.Text));
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

        private void AttachAuthChainProbe(LoginUserControl control)
        {
            if (control == null)
            {
                return;
            }

            if (control.listBoxProcess != null)
            {
                control.listBoxProcess.SelectionChanged += delegate(object sender, SelectionChangedEventArgs args)
                {
                    WriteAction(
                        "auth-chain process-selection changed selected=" + DescribeSelectedProcess(control) +
                        " added=" + args.AddedItems.Count +
                        " removed=" + args.RemovedItems.Count);
                };
            }

            if (control.buttonLaunchBot != null)
            {
                control.buttonLaunchBot.PreviewMouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs args)
                {
                    WriteAction(
                        "auth-chain launch-button preview-mousedown handledBefore=" + args.Handled +
                        " preserveOriginal=" + _preserveOriginalAuthChain +
                        " selected=" + DescribeSelectedProcess(control));
                };
            }

            if (control.buttonRefresh != null)
            {
                control.buttonRefresh.PreviewMouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs args)
                {
                    WriteAction(
                        "auth-chain refresh-button preview-mousedown handledBefore=" + args.Handled +
                        " preserveOriginal=" + _preserveOriginalAuthChain);
                };
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

        private void DumpAuthRuntimeBindings(LoginUserControl control, string stage)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append(DateTime.Now.ToString("s"));
                sb.Append(" auth-binding ");
                sb.Append(stage);
                sb.Append(" ");
                sb.Append(DescribeRoutedHandlers(control?.buttonLaunchBot, Button.ClickEvent, "buttonLaunchBot"));
                sb.Append(" ");
                sb.Append(DescribeRoutedHandlers(control?.buttonRefresh, Button.ClickEvent, "buttonRefresh"));
                sb.Append(" ");
                sb.Append(DescribeLoginServerState());
                sb.Append(" ");
                sb.Append(DescribeRemoteState());
                sb.Append(Environment.NewLine);
                File.AppendAllText(Path.Combine(_runtimeRoot, "Logs", "original-ui-host-actions.txt"), sb.ToString());
            }
            catch (Exception ex)
            {
                WriteAction("auth-binding-failed " + stage + " " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void TryAutoInvokeOriginalLaunch(LoginUserControl control, string stage)
        {
            if (!_preserveOriginalAuthChain || !_autoInvokeOriginalLaunch || !string.Equals(stage, "idle", StringComparison.Ordinal))
            {
                return;
            }

            try
            {
                var originalLaunch = GetOriginalLaunchDelegate(control);
                if (originalLaunch == null)
                {
                    WriteAction("auth-auto-invoke missing-original-launch-delegate");
                    return;
                }

                WriteAction(
                    "auth-auto-invoke begin method=" + originalLaunch.Method.Name +
                    " target=" + (originalLaunch.Target == null ? "static" : originalLaunch.Target.GetType().FullName) +
                    " selected=" + DescribeSelectedProcess(control));
                DumpAuthRuntimeBindings(control, "auto-invoke-before");
                originalLaunch.DynamicInvoke(control.buttonLaunchBot, new RoutedEventArgs(Button.ClickEvent, control.buttonLaunchBot));
                DumpAuthRuntimeBindings(control, "auto-invoke-after");
                WriteAction("auth-auto-invoke end");
            }
            catch (Exception ex)
            {
                var error = ex is TargetInvocationException tie && tie.InnerException != null ? tie.InnerException : ex;
                WriteAction("auth-auto-invoke failed " + error.GetType().FullName + ": " + error.Message);
            }
        }

        private static Delegate GetOriginalLaunchDelegate(LoginUserControl control)
        {
            if (control?.buttonLaunchBot == null)
            {
                return null;
            }

            var eventHandlersStoreProperty = typeof(UIElement).GetProperty("EventHandlersStore", BindingFlags.Instance | BindingFlags.NonPublic);
            var store = eventHandlersStoreProperty?.GetValue(control.buttonLaunchBot, null);
            if (store == null)
            {
                return null;
            }

            var getRoutedEventHandlers = store.GetType().GetMethod("GetRoutedEventHandlers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var handlers = getRoutedEventHandlers?.Invoke(store, new object[] { Button.ClickEvent }) as Array;
            if (handlers == null)
            {
                return null;
            }

            foreach (var handlerInfo in handlers.Cast<object>())
            {
                var handlerProperty = handlerInfo.GetType().GetProperty("Handler", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var del = handlerProperty?.GetValue(handlerInfo, null) as Delegate;
                if (del?.Target is LoginUserControl)
                {
                    return del;
                }
            }

            return null;
        }

        private static string DescribeLoginServerState()
        {
            try
            {
                var type = typeof(LoginServer);
                var flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
                var fields = type.GetFields(flags)
                    .Where(field => field.FieldType == typeof(bool) || field.FieldType == typeof(long) || field.FieldType == typeof(string))
                    .OrderBy(field => field.Name, StringComparer.Ordinal)
                    .Select(field => "LoginServer." + field.Name + "=" + SafeValue(field.GetValue(null)));
                return string.Join("|", fields);
            }
            catch (Exception ex)
            {
                return "LoginServerStateError=" + ex.GetType().Name;
            }
        }

        private static string DescribeRemoteState()
        {
            try
            {
                var type = typeof(Remote);
                var flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
                var fields = type.GetFields(flags)
                    .Where(field => field.FieldType == typeof(bool) || field.FieldType == typeof(long) || field.FieldType == typeof(string) || typeof(IRemote).IsAssignableFrom(field.FieldType))
                    .OrderBy(field => field.Name, StringComparer.Ordinal)
                    .Select(field => "Remote." + field.Name + "=" + SafeValue(field.GetValue(null)));
                return string.Join("|", fields);
            }
            catch (Exception ex)
            {
                return "RemoteStateError=" + ex.GetType().Name;
            }
        }

        private static string DescribeRoutedHandlers(UIElement element, RoutedEvent routedEvent, string name)
        {
            if (element == null)
            {
                return name + "=null";
            }

            try
            {
                var eventHandlersStoreProperty = typeof(UIElement).GetProperty("EventHandlersStore", BindingFlags.Instance | BindingFlags.NonPublic);
                var store = eventHandlersStoreProperty?.GetValue(element, null);
                if (store == null)
                {
                    return name + "=store:null";
                }

                var getRoutedEventHandlers = store.GetType().GetMethod("GetRoutedEventHandlers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var handlers = getRoutedEventHandlers?.Invoke(store, new object[] { routedEvent }) as Array;
                if (handlers == null || handlers.Length == 0)
                {
                    return name + "=handlers:0";
                }

                var desc = handlers.Cast<object>().Select(handlerInfo =>
                {
                    var handlerProperty = handlerInfo.GetType().GetProperty("Handler", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    var invokeHandledProperty = handlerInfo.GetType().GetProperty("InvokeHandledEventsToo", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    var del = handlerProperty?.GetValue(handlerInfo, null) as Delegate;
                    var method = del?.Method;
                    var target = del?.Target;
                    return (target == null ? "static" : target.GetType().FullName) +
                           "::" + (method == null ? "null" : method.Name) +
                           "(handledToo=" + SafeValue(invokeHandledProperty?.GetValue(handlerInfo, null)) + ")";
                });
                return name + "=" + string.Join(",", desc);
            }
            catch (Exception ex)
            {
                return name + "=error:" + ex.GetType().Name;
            }
        }

        private static string SafeValue(object value)
        {
            if (value == null)
            {
                return "null";
            }

            if (value is string text)
            {
                return "\"" + text.Replace("\"", "'") + "\"";
            }

            return value.ToString();
        }

        private static string DescribeSelectedProcess(LoginUserControl control)
        {
            var selected = control.listBoxProcess == null ? null : control.listBoxProcess.SelectedItem as ProcessListItem;
            if (selected == null)
            {
                return "none";
            }

            return selected.ProcessId + ":" + selected.WindowTitle;
        }

        private static string Quote(string text)
        {
            return text == null ? "null" : "\"" + text.Replace("\"", "'") + "\"";
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

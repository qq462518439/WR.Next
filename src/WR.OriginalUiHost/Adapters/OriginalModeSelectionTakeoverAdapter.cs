using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using robotManager;
using robotManager.Helpful;
using robotManager.Products;
using wManager.Wow.Forms;

namespace WR.OriginalUiHost
{
    internal sealed class OriginalModeSelectionTakeoverAdapter
    {
        private readonly string _runtimeRoot;
        private readonly OriginalRuntimeBootstrap _runtimeBootstrap;

        public OriginalModeSelectionTakeoverAdapter(string runtimeRoot, OriginalRuntimeBootstrap runtimeBootstrap)
        {
            _runtimeRoot = runtimeRoot;
            _runtimeBootstrap = runtimeBootstrap;
        }

        public void Attach(UserControlTabMain control)
        {
            ApplyTakeover(control, "attach");
            control.Loaded += delegate
            {
                ApplyTakeover(control, "loaded");
                control.Dispatcher.BeginInvoke(
                    DispatcherPriority.ApplicationIdle,
                    new Action(delegate { ApplyTakeover(control, "idle"); }));
                control.Dispatcher.BeginInvoke(
                    DispatcherPriority.ContextIdle,
                    new Action(delegate { ApplyTakeover(control, "context-idle"); }));
            };
        }

        public void ApplyNow(UserControlTabMain control, string stage)
        {
            ApplyTakeover(control, stage);
        }

        public bool IsReady(UserControlTabMain control)
        {
            var listView = GetProductListView(control);
            if (listView == null)
            {
                return false;
            }

            return listView.Items.Count > 0;
        }

        public string DescribeLiveState(UserControlTabMain control)
        {
            var listView = GetProductListView(control);
            if (listView == null)
            {
                return "未找到原始模式列表控件。";
            }

            var count = listView.Items.Count;
            var selected = listView.SelectedItem?.ToString() ?? "未选中";
            var settingsType = Products.ProductSettings?.GetType().Name ?? "未加载设置面板";
            return "已探测模式 " + count + " 个，当前: " + selected + "，设置面板: " + settingsType;
        }

        private void ApplyTakeover(UserControlTabMain control, string stage)
        {
            try
            {
                WriteAction(stage + " step=begin");
                WriteAction(stage + " step=HideSubscriptionBlock-enter");
                HideSubscriptionBlock(control);
                WriteAction(stage + " step=HideSubscriptionBlock-exit");
                NormalizeProductListVisuals(control);
                WriteAction(stage + " step=WireModeSettingsButton-enter");
                WireModeSettingsButton(control);
                WriteAction(stage + " step=WireModeSettingsButton-exit");
                WriteAction(stage + " step=WireStartButton-enter");
                WireStartButton(control);
                WriteAction(stage + " step=WireStartButton-exit");
                WriteAction(stage + " step=EnsureProductItems-enter");
                EnsureProductItems(control);
                WriteAction(stage + " step=EnsureProductItems-exit");
                if (!HasAttachedSession())
                {
                    WriteAction(stage + " step=skip-session-gated-resync reason=no-attached-session");
                    WriteAction(stage + " step=end");
                    return;
                }

                if (CanSkipHeavyResync(control, stage))
                {
                    WriteAction(
                        stage + " step=skip-heavy-resync" +
                        " currentProduct=" + (Products.ProductName ?? "null") +
                        " selected=" + DescribeSelectedProduct(control) +
                        " settingsType=" + DescribeSettingsType() +
                        " settingsHostChildType=" + DescribeSettingsHostChildType(control));
                    WriteAction(stage + " step=end");
                    return;
                }

                WriteAction(stage + " step=SelectPreferredProduct-skip");
                WriteAction(stage + " step=EnsureProductLoaded-enter");
                EnsureProductLoaded(control);
                WriteAction(stage + " step=EnsureProductLoaded-exit");
                WriteAction(stage + " step=ReloadWRotationSettingsIfReady-enter");
                ReloadWRotationSettingsIfReady(stage);
                WriteAction(stage + " step=ReloadWRotationSettingsIfReady-exit");
                WriteAction(stage + " step=RefreshProductSettings-enter");
                RefreshProductSettings(control);
                WriteAction(stage + " step=RefreshProductSettings-exit");
                WriteAction(
                    stage + " dir=" + Others.GetCurrentDirectory +
                    " runtimeProducts=" + OriginalRuntimePaths.Current.ProductsRoot +
                    " settingsType=" + DescribeSettingsType() +
                    " settingsHostChildType=" + DescribeSettingsHostChildType(control) +
                    " listViewType=" + DescribeListViewType(control) + " " +
                    stage + " ok items=" + DescribeItemCount(control) +
                    " selected=" + DescribeSelectedProduct(control) +
                    " children=" + DescribeSettingsChildren(control) +
                    " subscriptionHits=" + CountSubscriptionMarkers(control) +
                    " visualListView=" + CountVisualChildren<ListView>(control) +
                    " tag=" + (control.Tag ?? "null"));
                WriteWRotationSettingState(stage);
                WriteAction(stage + " step=end");
            }
            catch (Exception ex)
            {
                WriteAction(stage + " exception " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static bool CanSkipHeavyResync(UserControlTabMain control, string stage)
        {
            if (string.Equals(stage, "attach", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            var listView = GetProductListView(control);
            if (listView == null || listView.Items.Count == 0)
            {
                return false;
            }

            var selected = ResolveCurrentProductSelection(listView);
            if (!IsSelectionAlreadySynchronized(listView, selected))
            {
                return false;
            }

            return IsProductSettingsAlreadyAttached(control);
        }

        private static void NormalizeProductListVisuals(UserControlTabMain control)
        {
            OriginalEmbeddedThemeStyler.Apply(control);

            var listView = GetProductListView(control);
            if (listView == null)
            {
                return;
            }

            listView.SelectionMode = SelectionMode.Single;
            listView.Background = Application.Current.TryFindResource("AppSurfaceBrush") as Brush ?? Brushes.Black;
            listView.Foreground = Application.Current.TryFindResource("AppTextBrush") as Brush ?? Brushes.White;
            listView.BorderBrush = Application.Current.TryFindResource("AppBorderBrush") as Brush ?? Brushes.Gray;
            listView.ItemContainerStyle = BuildProductListItemStyle();
        }

        private static Style BuildProductListItemStyle()
        {
            var style = new Style(typeof(ListViewItem));
            style.Setters.Add(new Setter(Control.BackgroundProperty, Application.Current.TryFindResource("AppSurfaceBrush") as Brush ?? Brushes.Black));
            style.Setters.Add(new Setter(Control.ForegroundProperty, Application.Current.TryFindResource("AppTextBrush") as Brush ?? Brushes.White));
            style.Setters.Add(new Setter(Control.BorderBrushProperty, Brushes.Transparent));
            style.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(1)));
            style.Setters.Add(new Setter(Control.PaddingProperty, new Thickness(8, 4, 8, 4)));
            style.Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Stretch));
            style.Setters.Add(new Setter(Control.FocusVisualStyleProperty, null));

            var selectedTrigger = new Trigger
            {
                Property = ListViewItem.IsSelectedProperty,
                Value = true
            };
            selectedTrigger.Setters.Add(new Setter(Control.BackgroundProperty, Application.Current.TryFindResource("AppPanelAltBrush") as Brush ?? Brushes.DimGray));
            selectedTrigger.Setters.Add(new Setter(Control.ForegroundProperty, Application.Current.TryFindResource("AppSelectionTextBrush") as Brush ?? Brushes.White));
            selectedTrigger.Setters.Add(new Setter(Control.BorderBrushProperty, Application.Current.TryFindResource("AppBorderStrongBrush") as Brush ?? Brushes.White));
            style.Triggers.Add(selectedTrigger);

            var inactiveTrigger = new MultiTrigger();
            inactiveTrigger.Conditions.Add(new Condition(ListViewItem.IsSelectedProperty, false));
            inactiveTrigger.Setters.Add(new Setter(Control.BackgroundProperty, Application.Current.TryFindResource("AppSurfaceBrush") as Brush ?? Brushes.Black));
            inactiveTrigger.Setters.Add(new Setter(Control.ForegroundProperty, Application.Current.TryFindResource("AppTextBrush") as Brush ?? Brushes.White));
            inactiveTrigger.Setters.Add(new Setter(Control.BorderBrushProperty, Brushes.Transparent));
            style.Triggers.Add(inactiveTrigger);

            return style;
        }

        private void WireModeSettingsButton(UserControlTabMain control)
        {
            var button = FindModeSettingsButton(control);
            if (button == null)
            {
                return;
            }

            button.Click -= OnModeSettingsButtonClick;
            button.Click += OnModeSettingsButtonClick;
            ApplyModeSettingsButtonGate(button);
        }

        private void WireStartButton(UserControlTabMain control)
        {
            var button = control?.ButtonStartBot ?? GetField<Button>(control, "ButtonStartBot");
            if (button == null)
            {
                return;
            }

            button.Click -= control.ButtonStartBotClick;
            button.Click -= OnStartButtonClick;
            button.Click += OnStartButtonClick;
            ApplyStartButtonGate(button);
        }

        private void OnModeSettingsButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var sessionGate = GetSessionGateResult();
                if (!sessionGate.ok)
                {
                    if (sender is Button blockedButton)
                    {
                        ApplyModeSettingsButtonGate(blockedButton);
                    }

                    WriteAction("mode-settings-button-click skipped reason=session-gate message=" + sessionGate.message);
                    return;
                }

                Products.ProductNeedSettings();
                WriteAction("mode-settings-button-click event=ProductNeedSettings");
            }
            catch (Exception ex)
            {
                WriteAction("mode-settings-button-click-failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private bool HasAttachedSession()
        {
            if (_runtimeBootstrap == null)
            {
                return false;
            }

            var session = _runtimeBootstrap.GetCurrentSessionSnapshot();
            return session != null && session.IsAttached && session.ProcessId > 0;
        }

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_runtimeBootstrap == null)
                {
                    WriteAction("start-button-click skipped reason=runtime-bootstrap-null");
                    return;
                }

                var sessionGate = GetSessionGateResult();
                if (!sessionGate.ok)
                {
                    if (sender is Button blockedButton)
                    {
                        ApplyStartButtonGate(blockedButton);
                    }

                    WriteAction("start-button-click skipped reason=session-gate message=" + sessionGate.message);
                    return;
                }

                var result = Products.IsStarted && !Products.InPause
                    ? _runtimeBootstrap.StopOriginalProduct()
                    : _runtimeBootstrap.EnsureOriginalProductStartedInBackground();
                WriteAction("start-button-click result=" + (result?.Message ?? "null"));
            }
            catch (Exception ex)
            {
                WriteAction("start-button-click-failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void ApplyStartButtonGate(Button button)
        {
            if (button == null)
            {
                return;
            }

            var sessionGate = GetSessionGateResult();
            button.IsEnabled = sessionGate.ok;
            button.ToolTip = sessionGate.ok ? null : sessionGate.message;
            WriteAction(
                "start-button-gate enabled=" + sessionGate.ok +
                " message=" + (sessionGate.message ?? "null"));
        }

        private void ApplyModeSettingsButtonGate(Button button)
        {
            if (button == null)
            {
                return;
            }

            var sessionGate = GetSessionGateResult();
            button.IsEnabled = sessionGate.ok;
            button.ToolTip = sessionGate.ok ? null : sessionGate.message;
            WriteAction(
                "mode-settings-button-gate enabled=" + sessionGate.ok +
                " message=" + (sessionGate.message ?? "null"));
        }

        private (bool ok, string message) GetSessionGateResult()
        {
            if (_runtimeBootstrap == null)
            {
                return (false, "运行时未初始化");
            }

            var session = _runtimeBootstrap.GetCurrentSessionSnapshot();
            if (session == null)
            {
                return (false, "尚未建立接管会话");
            }

            if (!session.IsAttached)
            {
                return (false, "接管会话尚未附着");
            }

            if (!session.MemoryOpen)
            {
                return (false, "接管会话内存句柄无效");
            }

            if (!session.HookReady)
            {
                return (false, "接管会话 Hook 未就绪");
            }

            if (!session.InGame)
            {
                return (false, "角色尚未进入世界");
            }

            if (session.HealthState == SessionHealthState.Faulted)
            {
                return (false, "接管会话故障: " + (session.LastError ?? "未知错误"));
            }

            if (session.HealthState == SessionHealthState.Lost)
            {
                return (false, "接管会话已丢失，请重新选择进程");
            }

            return (true, null);
        }

        private void ReloadWRotationSettingsIfReady(string stage)
        {
            try
            {
                var settingsType = Products.ProductSettings?.GetType();
                if (settingsType == null ||
                    !string.Equals(settingsType.FullName, "WRotation.SettingsUserControl", StringComparison.Ordinal))
                {
                    WriteAction(stage + " wrotation-load-skip reason=settingsType");
                    return;
                }

                var meName = SafeReadPlayerName();
                var realmName = SafeReadRealmName();
                if (string.IsNullOrWhiteSpace(meName) ||
                    string.IsNullOrWhiteSpace(realmName) ||
                    string.Equals(meName, "null", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(realmName, "null", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(meName, "error", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(realmName, "error", StringComparison.OrdinalIgnoreCase))
                {
                    WriteAction(stage + " wrotation-load-skip reason=context me=" + meName + " realm=" + realmName);
                    return;
                }

                var assembly = settingsType.Assembly;
                var settingType = assembly.GetType("WRotation.Bot.WRotationSetting", throwOnError: false);
                var loadMethod = settingType?.GetMethod("Load", BindingFlags.Public | BindingFlags.Static);
                if (loadMethod == null)
                {
                    WriteAction(stage + " wrotation-load-skip reason=load-missing");
                    return;
                }

                var result = loadMethod.Invoke(null, null);
                WriteAction(stage + " wrotation-load-invoke result=" + (result ?? "null") + " me=" + meName + " realm=" + realmName);
            }
            catch (Exception ex)
            {
                WriteAction(stage + " wrotation-load-error " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void EnsureProductItems(UserControlTabMain control)
        {
            var listView = GetProductListView(control);
            if (listView == null || listView.Items.Count > 0)
            {
                return;
            }

            var productsRoot = OriginalRuntimePaths.Current.ProductsRoot;
            if (!Directory.Exists(productsRoot))
            {
                throw new DirectoryNotFoundException("Products root not found: " + productsRoot);
            }

            var files = Directory.GetFiles(productsRoot, "*.dll");
            var added = 0;
            foreach (var item in files)
            {
                var name = Path.GetFileNameWithoutExtension(item);
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                listView.Items.Add(BuildOriginalProductLabel(name));
                added++;
            }

            var tag = "files=" + files.Length + " added=" + added + " itemCountAfter=" + listView.Items.Count;
            var adapter = control.Tag as string;
            control.Tag = string.IsNullOrWhiteSpace(adapter) ? tag : adapter + " | " + tag;
        }

        private static string BuildOriginalProductLabel(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return string.Empty;
            }

            var descriptionKey = productName.Trim() + "Description";
            var translated = Translate.Get(descriptionKey);
            if (!string.Equals(translated, descriptionKey, StringComparison.Ordinal))
            {
                return productName.Trim() + " - " + translated;
            }

            return productName.Trim();
        }

        private static void HideSubscriptionBlock(UserControlTabMain control)
        {
            HideField<TextBlock>(control, "_0002_2007");
            HideField<TextBlock>(control, "_0006_2007");
            HideField<TextBlock>(control, "_000F_2007");
            HideField<TextBlock>(control, "_0003_2007");
            HideField<Button>(control, "_0008_2007");
            HideField<Button>(control, "_0005_2007");
            HideField<CheckBox>(control, "_0002_2004");
            HideVisualText(control, "subscription");
            HideVisualText(control, "expire");
            HideVisualText(control, "key:");
        }

        private static void RefreshProductSettings(UserControlTabMain control)
        {
            if (IsProductSettingsAlreadyAttached(control))
            {
                return;
            }

            var clearMethod = typeof(UserControlTabMain).GetMethod("_0006_2004", BindingFlags.Instance | BindingFlags.NonPublic);
            var loadMethod = typeof(UserControlTabMain).GetMethod("_000F_2004", BindingFlags.Instance | BindingFlags.NonPublic);
            clearMethod?.Invoke(control, null);
            loadMethod?.Invoke(control, null);

            var settingsGrid = GetProductSettingsGrid(control);
            if (settingsGrid != null && Products.ProductSettings != null)
            {
                DetachFromCurrentParent(Products.ProductSettings);
                if (!settingsGrid.Children.Contains(Products.ProductSettings))
                {
                    settingsGrid.Children.Clear();
                    settingsGrid.Children.Add(Products.ProductSettings);
                }

                OriginalEmbeddedThemeStyler.Apply(Products.ProductSettings);
                settingsGrid.Visibility = Visibility.Visible;
                settingsGrid.UpdateLayout();
            }
        }

        private static bool IsProductSettingsAlreadyAttached(UserControlTabMain control)
        {
            var settingsGrid = GetProductSettingsGrid(control);
            if (settingsGrid == null || Products.ProductSettings == null)
            {
                return false;
            }

            if (settingsGrid.Children.Count != 1)
            {
                return false;
            }

            return ReferenceEquals(settingsGrid.Children[0], Products.ProductSettings);
        }

        private void EnsureProductLoaded(UserControlTabMain control)
        {
            var listView = GetProductListView(control);
            if (listView == null)
            {
                return;
            }

            var preferred = listView.Items
                .Cast<object>()
                .FirstOrDefault(item => item != null &&
                                        item.ToString().IndexOf("WRotation", StringComparison.OrdinalIgnoreCase) >= 0);

            var selected = ResolveCurrentProductSelection(listView);

            if (selected == null && listView.Items.Count > 0)
            {
                selected = listView.Items[0];
            }

            if (selected == null)
            {
                return;
            }

            if (IsSelectionAlreadySynchronized(listView, selected))
            {
                listView.SelectedItem = selected;
                WriteAction("EnsureProductLoaded skip-resync selected=" + selected + " currentProduct=" + (Products.ProductName ?? "null") + " settings=" + DescribeSettingsType());
                return;
            }

            listView.SelectedItem = selected;
            var selectionChanged = typeof(UserControlTabMain).GetMethod("_0002", BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(object) }, null);
            WriteAction("EnsureProductLoaded target=" + selected + " beforeSettings=" + DescribeSettingsType());
            selectionChanged?.Invoke(control, new[] { selected });
            WriteProductSelectionEvidence("selection", selected?.ToString(), DescribeSettingsType(), DescribeSettingsHostChildType(control));
            if (preferred != null && selected != null && !ReferenceEquals(preferred, selected))
            {
                WriteAction("EnsureProductLoaded fallback-disabled preferred=" + preferred + " selected=" + selected + " currentSettings=" + DescribeSettingsType());
            }
            WriteAction("EnsureProductLoaded afterSettings=" + DescribeSettingsType() + " afterChild=" + DescribeSettingsHostChildType(control));
        }

        private static object ResolveCurrentProductSelection(ListView listView)
        {
            if (listView == null)
            {
                return null;
            }

            var currentProductName = Products.ProductName;
            if (!string.IsNullOrWhiteSpace(currentProductName))
            {
                var exactMatch = listView.Items
                    .Cast<object>()
                    .FirstOrDefault(item => item != null &&
                                            string.Equals(
                                                NormalizeProductLabel(item.ToString()),
                                                currentProductName,
                                                StringComparison.OrdinalIgnoreCase));
                if (exactMatch != null)
                {
                    return exactMatch;
                }
            }

            return listView.SelectedItem;
        }

        private static bool IsSelectionAlreadySynchronized(ListView listView, object selected)
        {
            if (listView == null || selected == null)
            {
                return false;
            }

            var normalizedSelected = NormalizeProductLabel(selected.ToString());
            var currentProductName = Products.ProductName ?? string.Empty;
            if (!string.Equals(normalizedSelected, currentProductName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (!ReferenceEquals(listView.SelectedItem, selected) &&
                !string.Equals(NormalizeProductLabel(listView.SelectedItem?.ToString()), normalizedSelected, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return Products.ProductSettings != null;
        }

        private static string NormalizeProductLabel(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
            {
                return string.Empty;
            }

            var separatorIndex = label.IndexOf(" - ", StringComparison.Ordinal);
            if (separatorIndex > 0)
            {
                return label.Substring(0, separatorIndex).Trim();
            }

            return label.Trim();
        }

        private static string DescribeSelectedProduct(UserControlTabMain control)
        {
            var listView = GetProductListView(control);
            return listView?.SelectedItem?.ToString() ?? "null";
        }

        private static string DescribeItemCount(UserControlTabMain control)
        {
            var listView = GetProductListView(control);
            return listView == null ? "null" : listView.Items.Count.ToString();
        }

        private static string DescribeSettingsChildren(UserControlTabMain control)
        {
            var settingsGrid = GetProductSettingsGrid(control);
            return settingsGrid == null
                ? "grid-null"
                : settingsGrid.Children.Count.ToString();
        }

        private static string DescribeSettingsType()
        {
            return Products.ProductSettings == null ? "null" : Products.ProductSettings.GetType().FullName;
        }

        private static string DescribeSettingsHostChildType(UserControlTabMain control)
        {
            var settingsGrid = GetProductSettingsGrid(control);
            if (settingsGrid == null || settingsGrid.Children.Count == 0)
            {
                return "null";
            }

            return settingsGrid.Children[0]?.GetType().FullName ?? "null";
        }

        private static Button FindModeSettingsButton(DependencyObject root)
        {
            if (root == null)
            {
                return null;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is Button button && IsModeSettingsButton(button))
                {
                    return button;
                }

                var nested = FindModeSettingsButton(child);
                if (nested != null)
                {
                    return nested;
                }
            }

            return null;
        }

        private static bool IsModeSettingsButton(Button button)
        {
            if (button == null)
            {
                return false;
            }

            if (string.Equals(button.Name, "ButtonProductSettings", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Equals(System.Windows.Automation.AutomationProperties.GetAutomationId(button), "ButtonProductSettings", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return ContainsText(button, "模式设置");
        }

        private static void WriteProductSelectionEvidence(string stage, string selectedProduct, string settingsType, string hostChildType)
        {
            try
            {
                var path = Path.Combine(OriginalRuntimePaths.Current.LogsRoot, "original-mode-product-settings-evidence.txt");
                var line =
                    DateTime.Now.ToString("s") +
                    " stage=" + stage +
                    " selectedProduct=" + (selectedProduct ?? "null") +
                    " productsProductName=" + (Products.ProductName ?? "null") +
                    " settingsType=" + (settingsType ?? "null") +
                    " settingsHostChildType=" + (hostChildType ?? "null");
                File.AppendAllText(path, line + Environment.NewLine);
            }
            catch
            {
            }
        }

        private static string DescribeListViewType(UserControlTabMain control)
        {
            var listView = GetProductListView(control);
            return listView == null ? "null" : listView.GetType().FullName;
        }

        private static ListView GetProductListView(UserControlTabMain control)
        {
            return GetField<ListView>(control, "_0008_2004") ?? FindVisualDescendant<ListView>(control);
        }

        private static Grid GetProductSettingsGrid(UserControlTabMain control)
        {
            if (control.ProductSettingsGrid != null)
            {
                return control.ProductSettingsGrid;
            }

            return FindSettingsHostGrid(control);
        }

        private static void DetachFromCurrentParent(UIElement element)
        {
            if (element == null)
            {
                return;
            }

            var parent = LogicalTreeHelper.GetParent(element);
            switch (parent)
            {
                case Panel panel:
                    panel.Children.Remove(element);
                    break;
                case ContentControl contentControl when ReferenceEquals(contentControl.Content, element):
                    contentControl.Content = null;
                    break;
                case Decorator decorator when ReferenceEquals(decorator.Child, element):
                    decorator.Child = null;
                    break;
            }
        }

        private static int CountVisualChildren<T>(DependencyObject root) where T : DependencyObject
        {
            if (root == null)
            {
                return 0;
            }

            var count = 0;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is T)
                {
                    count++;
                }

                count += CountVisualChildren<T>(child);
            }

            return count;
        }

        private static T FindVisualDescendant<T>(DependencyObject root) where T : DependencyObject
        {
            if (root == null)
            {
                return null;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is T matched)
                {
                    return matched;
                }

                var nested = FindVisualDescendant<T>(child);
                if (nested != null)
                {
                    return nested;
                }
            }

            return null;
        }

        private static Grid FindSettingsHostGrid(DependencyObject root)
        {
            if (root == null)
            {
                return null;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is Grid grid && grid != root && grid.Children.Count == 0)
                {
                    return grid;
                }

                var nested = FindSettingsHostGrid(child);
                if (nested != null)
                {
                    return nested;
                }
            }

            return null;
        }

        private static void HideField<T>(UserControlTabMain control, string fieldName) where T : UIElement
        {
            var element = GetField<T>(control, fieldName);
            if (element == null)
            {
                return;
            }

            element.Visibility = Visibility.Collapsed;
            if (element is FrameworkElement frameworkElement)
            {
                frameworkElement.Height = 0;
                frameworkElement.MinHeight = 0;
                frameworkElement.Margin = new Thickness(0);
            }
        }

        private static void HideVisualText(DependencyObject root, string keyword)
        {
            if (root == null || string.IsNullOrWhiteSpace(keyword))
            {
                return;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is TextBlock textBlock &&
                    !string.IsNullOrWhiteSpace(textBlock.Text) &&
                    textBlock.Text.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    textBlock.Visibility = Visibility.Collapsed;
                    textBlock.Height = 0;
                    textBlock.Margin = new Thickness(0);
                }

                HideVisualText(child, keyword);
            }
        }

        private static int CountSubscriptionMarkers(DependencyObject root)
        {
            return CountVisibleTextMatches(root, "subscription") +
                   CountVisibleTextMatches(root, "expire") +
                   CountVisibleTextMatches(root, "key:");
        }

        private static bool ContainsText(DependencyObject root, string text)
        {
            if (root == null || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is TextBlock textBlock &&
                    !string.IsNullOrWhiteSpace(textBlock.Text) &&
                    textBlock.Text.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }

                if (ContainsText(child, text))
                {
                    return true;
                }
            }

            return false;
        }

        private static int CountVisibleTextMatches(DependencyObject root, string keyword)
        {
            if (root == null || string.IsNullOrWhiteSpace(keyword))
            {
                return 0;
            }

            var count = 0;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is TextBlock textBlock &&
                    textBlock.Visibility == Visibility.Visible &&
                    !string.IsNullOrWhiteSpace(textBlock.Text) &&
                    textBlock.Text.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    count++;
                }

                count += CountVisibleTextMatches(child, keyword);
            }

            return count;
        }

        private static T GetField<T>(UserControlTabMain control, string fieldName) where T : class
        {
            var field = typeof(UserControlTabMain).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return field == null ? null : field.GetValue(control) as T;
        }

        private void WriteWRotationSettingState(string stage)
        {
            try
            {
                var settingsType = Products.ProductSettings?.GetType();
                if (settingsType == null ||
                    !string.Equals(settingsType.FullName, "WRotation.SettingsUserControl", StringComparison.Ordinal))
                {
                    return;
                }

                var assembly = settingsType.Assembly;
                var settingType = assembly.GetType("WRotation.Bot.WRotationSetting", throwOnError: false);
                var currentProperty = settingType?.GetProperty("CurrentSetting", BindingFlags.Public | BindingFlags.Static);
                var current = currentProperty?.GetValue(null);
                if (current == null)
                {
                    WriteAction(stage + " wrotation-setting=null");
                    return;
                }

                var manageMovement = ReadBooleanField(current, "ManageMovement");
                var attackAll = ReadBooleanField(current, "AttackAll");
                var useMiniMapClick = ReadBooleanField(current, "UseMiniMapClick");
                var autoResurrect = ReadBooleanField(current, "AutoResurrect");
                var lootInRange = ReadBooleanField(current, "LootInRange");
                var attackOnlyIfFlaggedInCombat = ReadBooleanField(current, "AttackOnlyIfFlaggedInCombat");
                var disableCTM = ReadBooleanField(current, "DisableCTM");
                var meName = SafeReadPlayerName();
                var realmName = SafeReadRealmName();
                var expectedSettingsFile = Path.Combine(
                    Others.GetCurrentDirectory,
                    "Settings",
                    "WRotation-" + meName + "." + realmName + ".xml");

                WriteAction(
                    stage +
                    " wrotation-setting" +
                    " me=" + meName +
                    " realm=" + realmName +
                    " expectedFile=" + expectedSettingsFile +
                    " exists=" + File.Exists(expectedSettingsFile) +
                    " manageMovement=" + manageMovement +
                    " attackAll=" + attackAll +
                    " useMiniMapClick=" + useMiniMapClick +
                    " autoResurrect=" + autoResurrect +
                    " lootInRange=" + lootInRange +
                    " attackOnlyIfFlaggedInCombat=" + attackOnlyIfFlaggedInCombat +
                    " disableCTM=" + disableCTM);
            }
            catch (Exception ex)
            {
                WriteAction(stage + " wrotation-setting-error " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static string ReadBooleanField(object instance, string fieldName)
        {
            var field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field == null)
            {
                return "missing";
            }

            var value = field.GetValue(instance);
            return value == null ? "null" : value.ToString();
        }

        private static string SafeReadPlayerName()
        {
            try
            {
                return wManager.Wow.ObjectManager.ObjectManager.Me?.Name ?? "null";
            }
            catch
            {
                return "error";
            }
        }

        private static string SafeReadRealmName()
        {
            try
            {
                return wManager.Wow.Helpers.Usefuls.RealmName ?? "null";
            }
            catch
            {
                return "error";
            }
        }

        private void WriteAction(string action)
        {
            try
            {
                var path = Path.Combine(_runtimeRoot, "Logs", "original-mode-selection-actions.txt");
                File.AppendAllText(path, DateTime.Now.ToString("s") + " " + action + Environment.NewLine);
            }
            catch
            {
            }
        }

        private static void WriteStaticAction(string action)
        {
            try
            {
                var path = Path.Combine(OriginalRuntimePaths.Current.LogsRoot, "original-mode-selection-actions.txt");
                File.AppendAllText(path, DateTime.Now.ToString("s") + " " + action + Environment.NewLine);
            }
            catch
            {
            }
        }
    }
}

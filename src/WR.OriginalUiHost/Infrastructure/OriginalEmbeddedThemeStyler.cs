using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WR.OriginalUiHost
{
    internal static class OriginalEmbeddedThemeStyler
    {
        public static void Apply(DependencyObject root)
        {
            if (root == null)
            {
                return;
            }

            ApplyCore(root);
            Traverse(root);
        }

        private static void Traverse(DependencyObject root)
        {
            var count = VisualTreeHelper.GetChildrenCount(root);
            for (var i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                ApplyCore(child);
                Traverse(child);
            }
        }

        private static void ApplyCore(DependencyObject node)
        {
            var windowBrush = GetBrush("AppWindowBrush");
            var surfaceBrush = GetBrush("AppSurfaceBrush");
            var surfaceAltBrush = GetBrush("AppSurfaceAltBrush");
            var panelBrush = GetBrush("AppPanelBrush");
            var controlBrush = GetBrush("AppControlBrush");
            var borderBrush = GetBrush("AppBorderBrush");
            var borderStrongBrush = GetBrush("AppBorderStrongBrush");
            var textBrush = GetBrush("AppTextBrush");
            var mutedBrush = GetBrush("AppMutedTextBrush");
            var selectionBrush = GetBrush("AppSelectionBrush");
            var selectionTextBrush = GetBrush("AppSelectionTextBrush");

            switch (node)
            {
                case Panel panel:
                    if (ShouldOverride(panel.Background))
                    {
                        panel.Background = windowBrush;
                    }
                    break;

                case Border border:
                    if (ShouldOverride(border.Background))
                    {
                        border.Background = panelBrush;
                    }

                    if (ShouldOverride(border.BorderBrush))
                    {
                        border.BorderBrush = borderBrush;
                    }
                    break;

                case TextBlock textBlock:
                    if (ShouldOverride(textBlock.Foreground))
                    {
                        textBlock.Foreground = textBrush;
                    }
                    break;

                case TextBox textBox:
                    textBox.Background = controlBrush;
                    textBox.Foreground = textBrush;
                    textBox.BorderBrush = borderBrush;
                    textBox.CaretBrush = textBrush;
                    textBox.SelectionBrush = selectionBrush;
                    textBox.SelectionTextBrush = selectionTextBrush;
                    break;

                case ComboBox comboBox:
                    comboBox.Background = controlBrush;
                    comboBox.Foreground = textBrush;
                    comboBox.BorderBrush = borderBrush;
                    break;

                case ListView listView:
                    listView.Background = surfaceBrush;
                    listView.Foreground = textBrush;
                    listView.BorderBrush = borderBrush;
                    break;

                case ListBox listBox:
                    listBox.Background = surfaceBrush;
                    listBox.Foreground = textBrush;
                    listBox.BorderBrush = borderBrush;
                    break;

                case ListViewItem listViewItem:
                    if (ShouldOverride(listViewItem.Background))
                    {
                        listViewItem.Background = surfaceBrush;
                    }

                    if (ShouldOverride(listViewItem.Foreground))
                    {
                        listViewItem.Foreground = textBrush;
                    }
                    break;

                case ListBoxItem listBoxItem:
                    if (ShouldOverride(listBoxItem.Background))
                    {
                        listBoxItem.Background = surfaceBrush;
                    }

                    if (ShouldOverride(listBoxItem.Foreground))
                    {
                        listBoxItem.Foreground = textBrush;
                    }
                    break;

                case Button button:
                    button.Background = controlBrush;
                    button.Foreground = textBrush;
                    button.BorderBrush = borderBrush;
                    break;

                case CheckBox checkBox:
                    checkBox.Foreground = textBrush;
                    break;

                case DataGrid dataGrid:
                    dataGrid.Background = surfaceBrush;
                    dataGrid.Foreground = textBrush;
                    dataGrid.BorderBrush = borderBrush;
                    dataGrid.RowBackground = surfaceBrush;
                    dataGrid.AlternatingRowBackground = surfaceAltBrush;
                    dataGrid.HorizontalGridLinesBrush = borderBrush;
                    dataGrid.VerticalGridLinesBrush = borderBrush;
                    break;

                case DataGridCell dataGridCell:
                    dataGridCell.Foreground = textBrush;
                    break;

                case DataGridColumnHeader header:
                    header.Background = panelBrush;
                    header.Foreground = textBrush;
                    header.BorderBrush = borderBrush;
                    break;

                case ScrollBar scrollBar:
                    if (ShouldOverride(scrollBar.Background))
                    {
                        scrollBar.Background = panelBrush;
                    }

                    if (ShouldOverride(scrollBar.Foreground))
                    {
                        scrollBar.Foreground = textBrush;
                    }
                    break;

                case ScrollViewer scrollViewer:
                    if (ShouldOverride(scrollViewer.Background))
                    {
                        scrollViewer.Background = surfaceBrush;
                    }
                    break;

                case GridViewColumnHeader gridHeader:
                    gridHeader.Background = panelBrush;
                    gridHeader.Foreground = textBrush;
                    gridHeader.BorderBrush = borderStrongBrush;
                    break;

                case TreeView treeView:
                    treeView.Background = surfaceBrush;
                    treeView.Foreground = textBrush;
                    treeView.BorderBrush = borderBrush;
                    break;

                case TreeViewItem treeViewItem:
                    if (ShouldOverride(treeViewItem.Background))
                    {
                        treeViewItem.Background = surfaceBrush;
                    }

                    if (ShouldOverride(treeViewItem.Foreground))
                    {
                        treeViewItem.Foreground = textBrush;
                    }
                    break;

                case Control control:
                    if (ShouldOverride(control.Background))
                    {
                        control.Background = controlBrush;
                    }

                    if (ShouldOverride(control.BorderBrush))
                    {
                        control.BorderBrush = borderBrush;
                    }

                    if (ShouldOverride(control.Foreground))
                    {
                        control.Foreground = mutedBrush;
                    }
                    break;
            }
        }

        private static SolidColorBrush GetBrush(string key)
        {
            return Application.Current?.TryFindResource(key) as SolidColorBrush ?? Brushes.Transparent;
        }

        private static bool ShouldOverride(Brush brush)
        {
            if (brush == null)
            {
                return true;
            }

            if (brush is SolidColorBrush solid)
            {
                var c = solid.Color;
                if (c.A == 0)
                {
                    return false;
                }

                var brightness = c.R + c.G + c.B;
                return brightness > 520 || brightness < 24;
            }

            return false;
        }
    }
}

# 模式产品列表残留选中态修复

## 结论

模式选择页里“切出去又切回来后，多个条目还带着像选中的高亮边框”这个问题，根因不是列表被改成了多选，而是：

- 原始嵌入 `ListViewItem` 的视觉状态没有被彻底钉死
- 未选中项在返回后残留了接近选中态的边框表现

因此这次修的是：

- **视觉残留**

不是：

- **真实多选逻辑**

## 已确认事实

代码位置：

- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)

已确认：

- 当前模式产品列表一直使用 `SelectedItem`
- 没有走 `SelectedItems`
- 没有引入多选业务逻辑

所以截图里看到的多条高亮，不应理解成“系统同时选中了多个产品”，而应理解成：

- 未选中项的视觉状态没有被正确恢复

## 本次修复

同一文件中新增了两项关键处理：

### 1. 明确列表为单选

- `listView.SelectionMode = SelectionMode.Single;`

作用：

- 把业务语义钉死
- 不给后续样式或控件默认值留下歧义

### 2. 为模式产品列表注入统一 `ItemContainerStyle`

新增：

- `BuildProductListItemStyle()`

作用：

- 对 `ListViewItem` 的未选中态和选中态做明确覆盖

规则：

- `IsSelected = true`
  - 使用高亮背景
  - 使用高亮文字
  - 使用高亮边框
- `IsSelected = false`
  - 强制恢复普通背景
  - 强制恢复普通文字
  - 强制把边框设为透明

含义：

- 返回模式页后，未选中项不会再残留像“被选中”的边框

## 构建结果

已完成构建与发布：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\WR.OriginalUiHost.exe`

构建结果：

- `0 warnings`
- `0 errors`

## 这次修复的边界

这次只处理：

- 模式产品列表条目高亮的视觉一致性

这次不涉及：

- 产品切换逻辑重写
- 设置页跳转链重写
- 多产品设置承载链改造

## 后续判断标准

后面如果再看到类似问题，应先按下面顺序判断：

1. 是否真的存在 `SelectedItems` / 多选逻辑
2. 如果没有，再看是不是 `ListViewItem` / `ListBoxItem` 的视觉状态残留
3. 优先在样式层修，不轻易误判成业务选择逻辑错误

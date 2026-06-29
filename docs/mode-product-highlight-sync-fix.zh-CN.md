# 模式产品高亮与真实当前产品同步修复

## 结论

模式页返回后，如果列表高亮和真实当前产品不一致，根因通常不是：

- 设置页没有跳回
- 或列表控件彻底失效

而是：

- 模式页恢复时优先沿用了旧的 `SelectedItem`
- 没有优先根据真实的 `Products.ProductName` 重新对齐高亮

因此这次修的是：

- **返回模式页时，列表高亮与真实当前产品的同步优先级**

## 已确认问题

代码位置：

- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)

修复前的逻辑特征：

- `EnsureProductLoaded(...)`
  - 先读 `listView.SelectedItem`
  - 再沿用它继续设置

问题在于：

- 如果从设置页回来时，真实当前产品已经是 `Products.ProductName = X`
- 但列表里保留的上一次视觉选择还是 `Y`
- 那模式页恢复时就会继续拿 `Y`，导致高亮和真实产品错位

## 本次修复

新增：

- `ResolveCurrentProductSelection(ListView listView)`
- `NormalizeProductLabel(string label)`

新优先级：

1. 先看 `Products.ProductName`
2. 在模式列表中按产品名反查对应条目
3. 找到就优先用这个条目作为 `SelectedItem`
4. 只有找不到时，才退回旧的 `listView.SelectedItem`

### 关键含义

现在模式页恢复时：

- 列表高亮优先跟随真实当前产品
- 不再优先沿用旧的视觉选择残留

## 构建结果

已完成构建与发布：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\WR.OriginalUiHost.exe`

构建结果：

- `0 warnings`
- `0 errors`

## 当前边界

这次只处理：

- 返回模式页时的高亮同步优先级

这次不处理：

- 多产品设置控件差异
- 设置页内部业务逻辑
- 模式页其他视觉微调

## 后续判断标准

后续如果再出现“高亮看起来不对”，优先按这两个维度区分：

1. 是不是视觉残留
2. 还是高亮没有跟随真实 `Products.ProductName`

这两类问题应分别处理，不再混为一个“选中态异常”问题。

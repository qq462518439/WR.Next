# 模式页返回时重复回放选择跳过

## 结论

模式页与设置页来回切换时，如果体感上出现：

- 回来后轻微抖一下
- 高亮像又重刷了一次
- 当前产品像又被重新选中一次

根因往往不是：

- 按钮又失效
- 页面没切回来

而是：

- 模式页恢复时，即使当前状态已经对齐
- 仍然又强行回放了一次原始 `selectionChanged` 私有链

因此本次修的是：

- **已对齐状态下，跳过不必要的重复产品重载**

## 已确认问题

代码位置：

- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)

修复前的特征：

- `EnsureProductLoaded(...)`
  - 即使 `SelectedItem`
  - `Products.ProductName`
  - `Products.ProductSettings`
  - 三者其实已经对齐
- 仍然会继续调用：
  - 原始 `_0002(...)` 选择变更链

这会带来：

- 不必要的重载
- 模式页返回时的轻微抖动
- 体感上的“又被回放了一次”

## 本次修复

新增：

- `IsSelectionAlreadySynchronized(ListView listView, object selected)`

判断条件：

1. 当前列表目标项能归一化匹配到 `Products.ProductName`
2. 列表当前选中项也已经是同一产品
3. `Products.ProductSettings != null`

当这三点同时成立时：

- 不再重复调用原始 `selectionChanged`
- 直接记录：
  - `EnsureProductLoaded skip-resync ...`

## 关键含义

现在模式页恢复时：

- 如果当前产品、高亮、设置控件都已经一致
- 就不会再额外回放一遍产品切换链

这会直接压住：

- 返回时轻微抖动
- 不必要的重复刷新
- 体感上的“像又卡一下”

## 构建结果

已完成构建与发布：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\WR.OriginalUiHost.exe`

构建结果：

- `0 warnings`
- `0 errors`

## 当前边界

这次只处理：

- 已对齐状态下的重复选择回放

这次不处理：

- 某些产品自己的设置控件初始化慢
- 模式页其它视觉微调
- 多产品设置承载差异

## 下一步

如果还有体感抖动，下一包才继续分层看：

1. 是不是某些产品自己的设置控件内部初始化慢
2. 还是模式页右侧原始控件在恢复时还有别的重复刷新

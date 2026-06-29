# 模式页整页级重同步短路

## 结论

选中产品时那种“要顿一下”的体感，主要不是列表高亮本身慢，而是：

- 模式页接管在多个阶段都会再次触发产品加载链
- 即使当前产品、高亮和右侧设置控件其实已经同步完成

因此这次补的是：

- **整页级已同步判定**
- **已同步后跳过重型重放链**

## 已确认问题

代码位置：

- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)

修复前 `ApplyTakeover(...)` 在这些阶段都会继续走重链：

- `attach`
- `loaded`
- `idle`
- `context-idle`
- `retry-*`
- `theme-refresh`

而重链至少包含：

- `EnsureProductLoaded(...)`
- `ReloadWRotationSettingsIfReady(...)`
- `RefreshProductSettings(...)`

这意味着：

- 用户选中一次产品后
- 后续空闲阶段和重试阶段还可能再补打一轮同步
- 体感上就像“明明已经选中了，还又卡一下”

## 本次修复

新增：

- `CanSkipHeavyResync(UserControlTabMain control, string stage)`

判定规则：

1. 不是首次 `attach`
2. 产品列表已存在且有条目
3. 当前选中产品已与 `Products.ProductName` 对齐
4. `Products.ProductSettings` 已存在
5. 右侧设置宿主已经正确挂着当前 `Products.ProductSettings`

满足后：

- `ApplyTakeover(...)` 在轻量视觉整理和按钮接线后直接返回
- 不再继续执行重型产品重载链
- 日志会记录：
  - `step=skip-heavy-resync`

## 关键含义

现在模式页进入“已经稳定同步”的状态后：

- 不会再在 `loaded/idle/context-idle/retry-*` 阶段反复重放产品切换
- 选中产品后的额外停顿会明显收敛
- 返回页面后也更不容易再留下“又补同步了一次”的体感

## 构建后验证点

重点只看这三件事：

1. 首次选中产品是否仍有明显 1 秒级停顿
2. 从设置页切回模式页后，当前条目是否还会再次卡顿
3. 日志里是否出现：
   - `step=skip-heavy-resync`

日志文件：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Logs\original-mode-selection-actions.txt`

## 当前边界

这次只压：

- 模式页适配器自身的重复重同步

这次不声称已经消灭：

- 原始产品 DLL 自身的首帧初始化耗时
- 某些具体产品设置控件内部慢加载

## 下一步

如果这包落地后仍然能稳定复现 1 秒卡顿，再继续只拆两类来源：

1. 原始 `_0002(...)` 选择链本身慢
2. 某个具体产品设置控件首次初始化慢

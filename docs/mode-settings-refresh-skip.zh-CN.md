# 模式页返回时重复设置宿主刷新跳过

## 结论

模式页与设置页来回切换时，如果仍感觉：

- 会轻微闪一下
- 内容像又被挂一次
- 列表与右侧面板像又同步一遍

其中一个明显来源是：

- `RefreshProductSettings(...)` 在多个接管阶段里被重复执行
- 即使当前设置控件其实已经挂在正确宿主里

因此本次修的是：

- **已正确挂载时，跳过不必要的设置宿主重复刷新**

## 已确认问题

代码位置：

- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)

修复前的特征：

- `ApplyTakeover(...)` 在以下多个阶段都会调用：
  - `attach`
  - `loaded`
  - `idle`
  - `context-idle`
  - `retry-*`
- 每个阶段都会继续走：
  - `RefreshProductSettings(control)`

而 `RefreshProductSettings(...)` 内部会：

1. 调原始清理方法
2. 调原始加载方法
3. 再把 `Products.ProductSettings` 从当前父级摘下
4. 再重新加回宿主
5. 再 `UpdateLayout()`

如果当前控件本来就已经在正确位置，这一整套属于重复动作。

## 本次修复

新增：

- `IsProductSettingsAlreadyAttached(UserControlTabMain control)`

判断条件：

1. `settingsGrid` 存在
2. `Products.ProductSettings` 存在
3. `settingsGrid.Children.Count == 1`
4. `settingsGrid.Children[0]` 就是当前 `Products.ProductSettings`

当这四点同时成立时：

- `RefreshProductSettings(...)` 直接返回
- 不再重复执行清理、重挂载和布局刷新

## 关键含义

现在模式页恢复时：

- 如果右侧设置宿主本来就已经正确挂好了
- 就不会再被重复清空、重复加回、重复刷布局

这一步主要压的是：

- 返回时轻微闪动
- “像又挂一次”的体感
- 不必要的宿主层重复同步

## 构建结果

已完成构建与发布：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\WR.OriginalUiHost.exe`

构建结果：

- `0 warnings`
- `0 errors`

## 当前边界

这次只处理：

- 设置宿主层的重复刷新

这次不处理：

- 某些具体产品自己的内部设置控件初始化慢
- 模式页其它视觉层细节
- 多产品设置控件分布差异

## 下一步

如果模式页往返体感仍不够顺，下一包再继续分层看：

1. 某些产品控件内部首帧初始化是否偏慢
2. 原始 `UserControlTabMain` 内部是否还有其它重复事件链

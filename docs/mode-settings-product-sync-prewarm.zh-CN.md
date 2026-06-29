# 模式设置页产品级同步预热

## 结论

前一包已经处理了：

- 独立设置页 `_0004_CFG` 的首开预热

这一包继续处理更下一层的体感问题：

- 点击“模式设置”后，独立设置页虽然已跳转，但当前产品设置控件可能还要再等一次页内刷新节拍才真正同步完成

因此本次新增的是：

- **按钮点击后的产品级立即同步**

## 已确认问题层级

当前设置链分两层：

1. 页级：
   - `_0004_CFG` 对应 `OriginalModeSettingsHostControl`
2. 产品级：
   - `Products.ProductSettings` 对应当前产品的原始设置控件

前一包解决的是第 1 层。

这次解决的是第 2 层：

- 跳到 `_0004_CFG` 后，不只等 `DispatcherTimer`
- 而是主动把当前产品设置控件立刻同步过去

## 本次修改

### 1. 设置页增加显式同步入口

代码位置：

- [OriginalModeSettingsHostControl.xaml.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Views\Settings\OriginalModeSettingsHostControl.xaml.cs)

新增：

- `public void SyncNow()`

作用：

- 直接调用 `RefreshState()`
- 让外部能在导航完成后，立刻触发一次设置页同步

### 2. 模式设置按钮点击后立即同步独立设置页

代码位置：

- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)

新增：

- `SyncModeSettingsPageNow()`

处理顺序：

1. `OriginalShellNavigator.NavigateTo("_0004_CFG")`
2. 找到 `_0004_CFG` 对应页面
3. 取到 `OriginalModeSettingsHostControl`
4. 用 `DispatcherPriority.Loaded` 调一次 `control.SyncNow()`

含义：

- 点击按钮后，不再只依赖设置页自己的定时器 400ms 轮询
- 当前产品设置控件会更快同步进独立设置页

## 构建结果

已完成构建与发布：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\WR.OriginalUiHost.exe`

构建结果：

- `0 warnings`
- `0 errors`

## 当前阶段判断

现在“模式设置”体感优化已经拆成两层完成：

1. **页级预热**
   - 先把独立设置页本身实例化
2. **产品级立即同步**
   - 点击按钮后立即把当前产品设置控件同步进去

这两步叠加后，首次进入设置页的“像预热、像慢半拍”问题应该会进一步收敛。

## 下一步

如果体感仍不够顺，下一包才继续看：

1. 某些具体产品自己的 `SettingsUserControl` 内部初始化慢
2. 是否需要只对高频产品做更细的产品控件预创建

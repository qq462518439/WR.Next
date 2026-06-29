# 模式设置页首开预热说明

## 结论

当前“模式设置”按钮已经能稳定跳转，剩下的主要体感问题是：

- 第一次进入独立设置页时，有明显“预热感”
- 后续再进会顺很多

这类现象更像壳层内容首次实例化成本，而不是按钮链或导航链再次断开。

## 已确认原因

代码位置：

- [OriginalMainShellPage.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Shell\OriginalMainShellPage.cs)

已确认：

- 页面内容 `Content` 采用懒实例化
- `_content == null` 时才真正创建页面控件

含义：

- `_0004_CFG` 对应的 `OriginalModeSettingsHostControl` 在第一次切过去前并不存在
- 第一次点击“模式设置”时，才会创建独立设置页，再去挂原始产品设置控件
- 这就是“首次选中需要预热”的主要来源

## 本次处理

代码位置：

- [MainWindow.xaml.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Shell\MainWindow.xaml.cs)

新增处理：

1. 在主窗口 `Loaded` 后
2. 通过 `DispatcherPriority.ApplicationIdle`
3. 后台轻量预热 `_0004_CFG`

实现方式：

- `PrewarmSecondaryPages()`
- 先取到：
  - `_viewModel.FindPage("_0004_CFG")`
- 再触发一次：
  - `modeSettingsPage.Content`

## 处理边界

这次做的是：

- 壳层独立设置页预热

这次没有做：

- 大规模缓存所有页面
- 预加载所有产品设置控件
- 改产品内部设置逻辑

这样可以先压掉“第一次点设置”的最明显卡顿，同时避免把初始化成本一次性堆到启动时。

## 构建结果

已完成构建与发布：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\WR.OriginalUiHost.exe`

构建结果：

- `0 warnings`
- `0 errors`

## 下一步

如果体感仍然有明显首次卡顿，下一包再继续分层判断：

1. 是独立设置页首次实例化慢
2. 还是某些产品自己的 `SettingsUserControl` 首次挂载慢
3. 再决定要不要对高频产品做更细的产品级预热

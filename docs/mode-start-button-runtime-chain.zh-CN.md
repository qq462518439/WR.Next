# 模式页开始按钮接回原版启动链

## 结论

这次不再停留在“开始按钮有外观但不工作”的状态，而是把模式页里的原始开始按钮接回了当前已验证的原版产品启动链：

- 模式页开始按钮
- `OriginalRuntimeBootstrap.EnsureOriginalProductStartedInBackground()`

目标很明确：

- 优先把战斗模式产品链真正启动起来

## 为什么这样做

已确认原版 `Products.ProductStart()` 本身带前置门：

- 只有特定 `Var` gate 为 `true`
- 且产品已完成加载
- 才会真正启动

而当前宿主里，最稳定、已专门兜住这层前置门的实现，不在原始按钮内部，而在：

- [OriginalRuntimeBootstrap.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Runtime\OriginalRuntimeBootstrap.cs)

其中已经明确做了：

1. `WRotation` 分步加载
2. `ProductStart` gate 写入
3. `Products.ProductStart()` 调用
4. 启动结果日志落盘
5. 启动前先校验当前 Wow 进程接管状态

## 本次落地

涉及代码：

- [OriginalModeSelectionHostControl.xaml.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Views\InGame\OriginalModeSelectionHostControl.xaml.cs)
- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)
- [MainWindow.xaml.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Shell\MainWindow.xaml.cs)

变更点：

1. 模式页宿主改为接收 `OriginalRuntimeBootstrap`
2. 模式页适配器改为持有同一个 `OriginalRuntimeBootstrap`
3. 接管时对原始 `ButtonStartBot` 补接线
4. 点击开始按钮后直接调用：
   - `EnsureOriginalProductStartedInBackground()`
5. 启动链正式执行前，先调用：
   - `RefreshAttachedProcess()`
   - 若当前进程未就绪，则直接返回明确失败信息
6. 写入动作日志：
   - `start-button-click result=...`

## 关键意义

这一步不是“自造一个新开始按钮”，而是：

- 保留原始模式页外观和控件位置
- 但把开始按钮动作接到当前最可靠的原版启动链

这样更适合当前阶段：

- 先把战斗模式真正启动起来
- 再继续测跟近、开战、战斗链

## 当前边界

这次只处理：

- 模式页开始按钮不工作
- 产品链启动前置门未被稳定满足
- 启动前未先确认 Wow 进程接管状态

这次不宣称已经完成：

- 战斗链全量验证
- 战斗动作收敛验证
- 所有产品都能启动

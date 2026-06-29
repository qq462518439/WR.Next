# 模式设置页按原版产品事件链接回

## 结论

这次不是继续给模式页按钮单独打补丁，而是把原版更上游的设置请求链接回来了：

- 原版 `UserControlTabMain`
  - 点“模式设置”
  - 触发 `Products.ProductNeedSettings()`
- 主宿主窗口
  - 监听 `Products.OnProductNeedSettings`
  - 统一切到设置页

这比“按钮自己直接跳页”更贴近原版职责分层。

## 已确认原版依据

原始反编译源码位置：

- [UserControlTabMain.cs](D:\666\work\WR.Next\external\decompiled-runtime\wManager\wManager.Wow.Forms\UserControlTabMain.cs)
- [Products.cs](D:\666\work\WR.Next\external\decompiled-runtime\robotManager\robotManager.Products\Products.cs)

已确认：

1. `UserControlTabMain` 的设置按钮事件处理里直接调用：
   - `Products.ProductNeedSettings();`
2. `robotManager.Products.Products` 提供：
   - `OnProductNeedSettings`
   - `ProductNeedSettingsEventArgs`

含义：

- 原版里“切到设置页”的信号不是模式页私有导航逻辑
- 而是产品层向宿主层发出的统一事件

## 本次落地

代码位置：

- [MainWindow.xaml.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Shell\MainWindow.xaml.cs)

新增：

1. 构造时订阅：
   - `Products.OnProductNeedSettings += OnProductNeedSettings;`
2. 窗口关闭时解除订阅
3. 在 `OnProductNeedSettings(...)` 中：
   - 判断 `NeedSettings == true`
   - 导航到 `_0004_CFG`
   - 立即尝试 `SyncNow()`

## 关键意义

现在模式设置跳转链有两层分工：

1. 模式页适配器层
   - 保证原始按钮可被接线
   - 点击后发出 `ProductNeedSettings`
2. 主宿主事件层
   - 按原版事件语义处理“需要设置”

这一步更接近原版的地方在于：

- 页面只负责发出设置请求
- 壳层负责真正切页和承载设置页

## 当前边界

这次只恢复：

- 原版 `ProductNeedSettings` 事件链

这次不宣称已经完成：

- 全产品设置页行为验证
- 各产品内部设置控件稳定性验证
- 全链接管完成

## 下一步验证点

接下来人工体感测试时，重点只看：

1. 模式页点击“模式设置”是否稳定切到独立设置页
2. 切页后是否更像原版宿主统一接管，而不是列表自己乱跳
3. 不同产品切到设置页时，内容是否继续跟随当前产品

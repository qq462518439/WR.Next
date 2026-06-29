# 多产品设置页承载证据收口

## 结论

当前 `WR.OriginalUiHost` 已经补出一条可验证的“模式选择 -> 设置页”证据链，用来确认：

- 选中的产品名是什么
- `Products.ProductName` 实际切到了什么
- `Products.ProductSettings` 的类型是什么
- 设置页宿主里真正挂载的控件类型是什么

这一步的目标不是宣布“多产品设置链已全部打通”，而是先把“当前到底挂了谁”变成可核对的事实。

## 新增证据日志

### 1. 模式选择页侧

日志文件：

- `logs\original-mode-product-settings-evidence.txt`

记录内容：

- `selectedProduct`
- `productsProductName`
- `settingsType`
- `settingsHostChildType`

含义：

- 模式列表里用户/宿主实际选中了哪个产品
- 原版 `Products.ProductName` 最终切到了哪个产品
- 原版 `Products.ProductSettings` 当前是什么类型
- 模式页设置宿主里真正挂上的子控件是什么类型

### 2. 设置页侧

日志文件：

- `logs\original-mode-settings-host-evidence.txt`

记录内容：

- `productName`
- `settingsType`
- `controlType`

含义：

- 进入设置页时，当前产品名是什么
- 设置页认为当前设置控件类型是什么
- 实际承载到设置页 `ContentControl` 里的控件类型是什么

## 代码位置

- [OriginalModeSelectionTakeoverAdapter.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/Adapters/OriginalModeSelectionTakeoverAdapter.cs)
- [OriginalModeSettingsHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/Views/Settings/OriginalModeSettingsHostControl.xaml.cs)

## 当前边界

这次已完成：

- 为多产品设置页切换补齐双侧证据日志
- 让设置页直接显示当前产品名和设置控件类型
- 让后续验证不再只靠肉眼猜测页面内容

这次未完成：

- 未证明所有产品都能成功加载
- 未证明所有产品都有独立设置控件
- 未消除 `WRotation` 优先/回退逻辑
- 未收口 `Archaeologist`、`Prospecting` 等产品缺依赖/加载失败问题

## 下一步

按顺序继续应做：

1. 用新增日志核对不同产品切换时，`selectedProduct / productsProductName / settingsType / controlType` 是否一致变化
2. 将已验证成功的产品与失败产品分组
3. 再决定是否进入“去 WRotation 偏置”或“补产品依赖缺口”的下一包

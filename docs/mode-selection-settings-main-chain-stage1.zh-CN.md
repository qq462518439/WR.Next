# 模式选择 / 模式设置主链阶段说明（第一阶段）

## 结论

当前 `WR.OriginalUiHost` 的主施工线已经不是“继续围着战斗模式填内容”，而是回到更基础、也更接近原版操作顺序的这条链：

1. 模式选择页列出产品
2. 选中不同产品
3. 点击“设置”
4. 跳转到独立设置页
5. 设置页承载当前产品对应的原始设置控件

这条链已经在代码层落地；当前缺的不是再造页面，而是按产品分组拿到运行证据。

## 已确认事实

### 1. 设置按钮走的是独立设置页

代码位置：

- [OriginalModeSelectionHostControl.xaml.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Views\InGame\OriginalModeSelectionHostControl.xaml.cs)

已确认：

- `OnOpenModeSettingsClicked()` 直接调用 `OriginalShellNavigator.NavigateTo("_0004_CFG")`

含义：

- 当前不是把“模式选择”和“模式设置”混成一页
- 已经按原版思路拆成“选择页 -> 设置页”

### 2. 设置页内容来自当前产品

代码位置：

- [OriginalModeSettingsHostControl.xaml.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Views\Settings\OriginalModeSettingsHostControl.xaml.cs)

已确认：

- 设置页直接读取 `Products.ProductSettings as UIElement`
- 并显示当前 `Products.ProductName`

含义：

- 只要产品切换成功，设置页理论上就该承载不同产品的不同设置控件
- 这正是后续人工体感测试需要的真实链路

### 3. 模式选择页已经去掉 WRotation 强推偏置

代码位置：

- [OriginalModeSelectionHostControl.xaml.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Views\InGame\OriginalModeSelectionHostControl.xaml.cs)
- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)

已确认：

- 不再强行把 `LastProductSelected` 改回 `WRotation`
- 不再在选择其他产品后自动 fallback 回 `WRotation`
- 仅保留：
  - `preferred-product-observe ...`
  - `fallback-disabled ...`

含义：

- 现在测“不同产品 -> 设置页内容不同”时，证据不再被 `WRotation` 覆盖污染

### 4. 运行根已经是完整布局，不是空壳

已确认运行目录：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout`

已确认存在：

- `Products\*.dll`
- `RDManaged.dll`
- `authManager.dll`
- `Settings\*`
- `Data\Lang\English.xml`
- 多个中文语言文件

含义：

- 当前问题已不是“基础运行布局没铺出来”
- 当前问题收窄为“具体产品能否真实切换并带出对应设置控件”

## 当前证据边界

### 已有硬证据

- 代码上，主链已经对
- 运行根里，产品与关键依赖已经铺好
- 历史日志里，曾明确出现过多产品加载失败样本：
  - `Tracker.dll`
  - `WRotation.dll`
  - `Archaeologist.dll`

### 还缺的硬证据

以下两份新增日志目前还没有新样本落盘：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-mode-product-settings-evidence.txt`
- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-mode-settings-host-evidence.txt`

这意味着：

- 代码已写好双侧证据链
- 但还缺一次新的运行采样，才能严肃分组每个产品的真实结果

## 为什么现在不能再继续围着战斗模式转

因为当前更上游、更基础的问题不是“战斗页里多一个按钮少一个按钮”，而是：

- 模式产品有没有被正确切换
- 切换后设置页挂的是不是这个产品自己的控件
- 哪些产品只是没设置控件
- 哪些产品其实是缺依赖或加载失败

这一步不先收实，后面无论战斗页还是其他页，都会继续混着测。

## 下一包顺序

下一包只做这件事：

1. 启动 `WR.OriginalUiHost`
2. 在模式选择页依次切几个产品
3. 每次都点击“设置”
4. 读取双侧证据日志
5. 输出一份产品结果分组文档：
   - 成功切换且有设置控件
   - 切换成功但没有设置控件
   - 加载失败 / 缺依赖

## 当前阶段判断

当前阶段最准确的说法是：

- 主链方向已纠正
- 代码承载已就位
- 运行布局已基本到位
- 下一步应做“多产品切换结果分组审计”

不应说：

- 已完成接管
- 已完成所有模式设置页
- 已完成全链测试

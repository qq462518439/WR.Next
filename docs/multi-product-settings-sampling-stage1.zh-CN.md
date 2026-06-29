# 多产品设置链采样审计（第一轮）

## 结论

当前 `WR.OriginalUiHost` 的“模式选择 -> 模式设置”主链，已经拿到第一轮**运行期新样本**，可以确认两件关键事实：

1. 这条链现在不是假跳转，也不是固定壳页。
2. 至少 `Archaeologist` 与 `WRotation` 两个产品，已经能把各自的原始 `SettingsUserControl` 挂到设置链上。

因此，当前阶段不应再把主问题描述为“只会围着战斗模式填充”。更准确的说法是：

- 主链已经接通
- 已有多产品样本
- 下一步应继续扩样本分组，而不是回头重写页面框架

## 本轮采样方法

运行目标：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\WR.OriginalUiHost.exe`

本轮关注点仅限：

1. 模式选择页产品切换
2. 点击“模式设置”
3. 双侧证据日志是否落盘

本轮不扩展到：

- 战斗链验证
- 其他页面外观修补
- 全量产品遍历

## 新证据文件

本轮已确认落盘：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-mode-product-settings-evidence.txt`
- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-mode-settings-host-evidence.txt`
- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-mode-selection-actions.txt`

这说明：

- 之前只是代码里加了日志，现在已经真正拿到了运行期样本

## 已确认样本

### 1. Archaeologist

来自：

- `original-mode-product-settings-evidence.txt`
- `original-mode-selection-actions.txt`

已确认关键字段：

- `selectedProduct=Archaeologist - 考古学`
- `productsProductName=Archaeologist`
- `settingsType=Archaeologist.SettingsUserControl`
- `settingsHostChildType=Archaeologist.SettingsUserControl`

判断：

- 产品切换成功
- 产品设置控件类型明确
- 模式选择链上的设置宿主最终挂到了 `Archaeologist.SettingsUserControl`

当前分组：

- **成功切换且有设置控件**

### 2. WRotation

来自：

- `original-mode-product-settings-evidence.txt`
- `original-mode-settings-host-evidence.txt`
- `original-mode-selection-actions.txt`

已确认关键字段：

- `selectedProduct=WRotation - 战斗模式`
- `productsProductName=WRotation`
- `settingsType=WRotation.SettingsUserControl`
- `settingsHostChildType=WRotation.SettingsUserControl`
- `controlType=WRotation.SettingsUserControl`

判断：

- 产品切换成功
- 模式选择页与设置页两侧证据一致
- 设置页实际承载的是 `WRotation.SettingsUserControl`

当前分组：

- **成功切换且有设置控件**

## 本轮同时确认的顺序性事实

### 1. 没有再强推回 WRotation

`Archaeologist` 样本中能看到：

- `fallback-disabled preferred=WRotation - 战斗模式 selected=Archaeologist - 考古学`

含义：

- 宿主仍然记得“偏好产品是 WRotation”
- 但当前不会再把 `Archaeologist` 自动切回去

这说明主链顺序已经更接近原版真实操作，而不是宿主自作主张改结果。

### 2. WRotation 样本已打通到设置页侧

设置页日志里已出现：

- `productName=WRotation`
- `settingsType=WRotation.SettingsUserControl`
- `controlType=WRotation.SettingsUserControl`

含义：

- 不是只有模式选择页内部切到了 `WRotation`
- 连独立设置页承载侧也已经对齐

## 当前还不能说的事

这轮证据还**不能**支持以下说法：

- 所有产品都已打通
- 所有产品都有独立设置控件
- 所有产品都能成功进入设置页
- 缺依赖问题已经全部消失

原因很简单：

- 本轮新样本只严格确认了 `Archaeologist` 和 `WRotation`
- 其他产品还没完成同样强度的逐个分组

## 当前阶段分组

### 已确认：成功切换且有设置控件

- `Archaeologist`
- `WRotation`

### 尚未重新采样确认

- `Auction`
- `Automaton`
- `Battlegrounder`
- `Custom Profile`
- `Fisherbot`
- `Gatherer`
- `Grinder`
- `Milling`
- `Party`
- `Pet Battle`
- `Profiles Converters`
- `Prospecting`
- `Quester`
- `Schedule`
- `Tracker`

### 暂不能据本轮新样本下结论

- 切换成功但无设置控件
- 加载失败 / 缺依赖

这两类在旧日志中出现过历史样本，但本轮新采样还没完成全量覆盖。

## 控制面建议

当前建议：

- **hold 主链方向**
- **promote 到“继续扩产品样本分组”的下一包**

不建议：

- 回头把问题重新定义成“只修战斗模式”
- 因为少数页面视觉毛边而打断这条主链
- 在没有更多样本前宣布“多产品全部打通”

## 下一包

下一包继续按同一顺序：

1. 继续在模式选择页切其他产品
2. 每次都点“模式设置”
3. 读取双侧日志
4. 把剩余产品分入三类：
   - 成功切换且有设置控件
   - 切换成功但无设置控件
   - 加载失败 / 缺依赖

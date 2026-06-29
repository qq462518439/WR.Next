# 模式设置页产品分布阶段审计

## 结论

截至当前阶段，`WR.OriginalUiHost` 的“模式选择 -> 模式设置”链已经不再停留在“按钮是否能跳”的层面，而是进入到**产品设置控件分布审计**阶段。

目前可明确分成两类：

1. **已证实为产品专用设置控件**
2. **已证实落到通用壳控件**

这份分组不是理论推测，而是基于前几轮已跑出的运行期证据整理出来的阶段结论。

## 分组原则

按运行期日志里的 `settingsType / settingsHostChildType / controlType` 判断：

- 如果出现 `Xxx.SettingsUserControl`
  - 归为“产品专用设置控件”
- 如果只落到 `System.Windows.Controls.UserControl`
  - 归为“通用壳控件”

## 已证实：产品专用设置控件

以下产品已经拿到过明确的专用设置控件证据：

- `Archaeologist`
  - `Archaeologist.SettingsUserControl`
- `WRotation`
  - `WRotation.SettingsUserControl`
- `Auction`
  - `Auction.SettingsUserControl`
- `Fisherbot`
  - `Fisherbot.SettingsUserControl`

这些产品说明：

- 不是只有页面跳转成功
- 而是独立设置页确实承载到了对应产品自己的设置控件

## 已证实：通用壳控件

以下产品已经拿到过“只落到通用壳控件”的证据：

- `Profiles Converters`
  - `System.Windows.Controls.UserControl`
- `Prospecting`
  - `System.Windows.Controls.UserControl`
- `Tracker`
  - `System.Windows.Controls.UserControl`

这些产品当前更准确的判断是：

- 设置页链条是通的
- 但现阶段承载到的不是清晰可辨识的产品专用设置控件

## 已在运行链里出现过，但本阶段未单独落盘归档

以下产品在之前的运行轨迹中已经出现过被选中或被加载：

- `Gatherer`
- `Custom Profile`
- `Grinder`
- `Quester`
- `Schedule`
- `Party`
- `Automaton`
- `Battlegrounder`

但当前这份阶段文档里，还没有把它们逐个升级成“已严格归档”的单项结论。

原因不是它们一定有问题，而是：

- 本阶段更重视先把已明确证据的产品固定下来
- 不拿弱证据冒充硬结论

## 当前最准确的阶段判断

### 已完成确认

1. “模式设置”按钮可以真实跳转
2. 独立设置页 `_0004_CFG` 已成立
3. 已有多产品样本证明：
   - 有些产品具备明确专用设置控件
   - 有些产品当前只落到通用壳控件

### 尚未完成确认

1. 全部产品逐一完成硬归档
2. 每个产品的设置页是否都达到“原版体感完整”
3. 通用壳控件产品到底是原版本就如此，还是还缺进一步接线/承载

## 当前控制面建议

建议保持当前主线：

- **hold**

即：

- 不回头再讨论“按钮是否能跳”
- 不混回战斗模式话题
- 继续沿“多产品设置控件分布”往下收口

## 下一包建议

下一包只做一个窄动作：

1. 重新跑一轮当前最新版主程序
2. 逐个补齐尚未硬归档的产品
3. 把它们继续分入两类：
   - 产品专用设置控件
   - 通用壳控件

如果届时某个产品表现出第三类特征，再单开包处理：

- 跳转成功，但设置控件缺失 / 挂载失败

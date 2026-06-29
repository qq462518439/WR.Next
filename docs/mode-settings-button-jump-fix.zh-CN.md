# 模式设置按钮不跳转修复

## 结论

“模式设置”按钮不跳转的根因，不是用户点击问题，也不是导航目标页不存在，而是：

- 当前模式选择页只是承载了原始 `UserControlTabMain`
- 画面里那颗“模式设置”按钮属于原始控件
- 宿主接管层此前没有显式把这颗按钮接回原版设置请求链

因此按钮虽然显示正常，但未必能把“需要设置”这件事正确抛给宿主层处理。

## 本次修复

代码位置：

- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)

已补内容：

1. 在接管流程中加入 `WireModeSettingsButton(control)`
2. 通过以下特征查找原始按钮：
   - `Name == "ButtonProductSettings"`
   - `AutomationId == "ButtonProductSettings"`
   - 或按钮内部文本包含 `模式设置`
3. 为这颗按钮补统一点击事件：
   - `Products.ProductNeedSettings()`
4. 写入动作日志：
   - `mode-settings-button-click event=ProductNeedSettings`

## 当前判断

现在这颗按钮的处理链已从“点击后没有宿主响应”改为“点击后显式发出原版设置请求事件”。

这更符合当前接管阶段的目标：

- 尽量抄原版布局和交互位置
- 对关键设置链，按原版事件语义接回宿主

## 构建结果

已完成构建与发布：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\WR.OriginalUiHost.exe`

构建结果：

- `0 warnings`
- `0 errors`

## 下一步验证

人工验证顺序：

1. 打开模式选择页
2. 任选一个产品
3. 点击右侧“模式设置”
4. 观察是否切到独立设置页
5. 再看日志里是否出现：
   - `mode-settings-button-click event=ProductNeedSettings`

# 模式页开始/停止按钮事件冲突修复

## 结论

“可以开始但停不了”的根因，不是停止能力不存在，而是：

- 同一颗原始开始按钮
- 同时挂着两条会互相打架的事件链

结果就是：

- 点开始时能启动
- 点停止时原始链在停
- 但额外宿主链又把产品重新拉起

于是体感上就成了：

- 停不下来

## 已确认事实

原始源码位置：

- [UserControlTabMain.cs](D:\666\work\WR.Next\external\decompiled-runtime\wManager\wManager.Wow.Forms\UserControlTabMain.cs)

已确认原始按钮本来就绑定：

- `ButtonStartBot.Click += ButtonStartBotClick;`

其原始语义是：

1. `Products.IsStarted == true`
   - 走停止链
2. `Products.IsStarted == false`
   - 走启动链

而宿主后续又额外挂了一条：

- `OnStartButtonClick`

导致一颗按钮上出现：

- 原始切换链
- 宿主强制启动链

## 本次修复

代码位置：

- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)

处理内容：

1. 接线开始按钮时，先移除：
   - `control.ButtonStartBotClick`
2. 只保留宿主接管链：
   - `OnStartButtonClick`
3. 宿主接管链改为单一切换语义：
   - 未启动 -> `EnsureOriginalProductStartedInBackground()`
   - 已启动且未暂停 -> `StopOriginalProduct()`

## 关键意义

现在这颗按钮不再是：

- 一边停
- 一边又被别的事件拉起

而是：

- 统一由宿主控制一条开始/停止链

这一步会直接改善：

- “开始能用但停不了”

## 当前边界

这次只处理：

- 模式页原始开始按钮的事件冲突
- 开始/停止切换语义不一致

这次还不宣称已经处理完：

- 战斗模式内部技能链异常
- 寻路无法到达训练假人
- SpellList / Lua 相关空引用

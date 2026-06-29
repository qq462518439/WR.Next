# Battle Mode Original Entry SelfCheck

## 结论

为了避免后续继续靠猜“原版入口是不是已经在场”，当前宿主启动时已经新增一条自检日志：

> 检查 `WRobot.Launching` 是否已进入当前 AppDomain，以及 `wManager.Information.LaunchBot(...)` 是否可解析。

这一步不负责恢复 Hook，只负责把“原版总入口前置是否成立”从隐含状态改成可观察证据。

## 本轮改动

文件：

- `src/WR.OriginalUiHost/App/App.xaml.cs`

新增：

- `WriteOriginalEntrySelfCheck()`

调用时机：

- `OnStartup()` 中
- 在预加载原版主程序集之后

## 自检写出的关键信息

启动日志会新增一行，包含：

1. `launching=True/False`
2. `launchingAsm=...`
3. `launchBotMethod=True/False`

也就是分别回答：

1. 当前运行域里有没有 `WRobot.Launching`
2. 它来自哪个程序集
3. `wManager.Information.LaunchBot(...)` 这个桥接入口是否可用

## 为什么这一步重要

前一轮我们已经补了：

- 预加载 `WRobot.exe`

但“预加载成功”不等于“后续入口一定可走”。

所以这一轮加自检，是为了把下面两个问题拆开：

1. 原版主程序集是否在场
2. 原版主程序入口是否可解析

只有这两件事都成立，后续才值得继续尝试最小的 `LaunchBot` 路径。

## 当前边界

这一步仍然不代表：

1. `LaunchBot` 已成功执行
2. Hook 线程已被拉起
3. `ThreadHooked` 已恢复

它只代表：

> 宿主已经具备了“验证原版入口是否在场”的稳定证据点。

## 下一步

下一包继续按顺序：

1. 读取 `original-ui-host-startup.txt`
2. 确认 `WRobot.Launching` 是否真在当前运行域
3. 如果在场，再决定是否尝试最小原版入口调用

## 一句话判断

这一步是把“原版入口是否在场”正式变成可验证事实。

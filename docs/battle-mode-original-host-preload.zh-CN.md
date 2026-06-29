# Battle Mode Original Host Preload

## 结论

当前宿主进一步向原版主程序入口靠近了一步：

> 启动时预加载 `WRobot.exe` 到当前运行域。

这样做的目的不是立即让 Hook 链恢复，而是为后续接通：

- `WRobot.Launching`
- `Information.LaunchBot(...)`

这条原版主程序总入口先补齐最基础的装载前提。

## 为什么要做这一步

前一轮已经确认：

1. `TraceLine` / `ClickToMove` / `Lua` 等执行层依赖 Hook 线程
2. Hook 线程更像由原版主程序入口链拉起
3. 当前宿主虽然能加载 `robotManager.dll / wManager.dll`
4. 但并没有把 `WRobot.exe` 主程序集装进自己的 AppDomain

这意味着：

> 就算后面想接 `Information.LaunchBot(...)`，当前运行域里也未必找得到 `WRobot.Launching`

## 本轮改动

文件：

- `src/WR.OriginalUiHost/App/App.xaml.cs`

新增：

- `TryPreloadOriginalHostAssembly()`

当前启动顺序变为：

1. 预加载 `WRobot.exe`
2. 预加载 `RDManaged.dll`
3. 预加载 `fasmdll_managed.dll`

并在启动日志里记录：

- 原版主程序集是否找到
- 是否成功加载
- 是否包含 `WRobot.Launching`

## 这一步的意义

这一步不是“Hook 已恢复”。

它的意义是更基础的一层：

1. 让宿主与原版主程序共享更多相同的运行域前提
2. 让原版 `Launching/LaunchBot` 入口后续至少有机会被解析
3. 把当前宿主从“只装运行时 DLL”往“装回原版主程序壳入口”推进

## 当前边界

当前仍不能宣称：

1. `Information.LaunchBot(...)` 已打通
2. `ThreadHooked` 已恢复
3. 战斗执行链已恢复

当前只能确认：

> 原版主程序集不再天然缺席于宿主运行域

## 下一步

下一包应继续：

1. 验证运行日志中 `WRobot.exe` 预加载是否成功
2. 判断 `Information.LaunchBot(...)` 在当前宿主里是否开始具备可执行前提
3. 再决定是否尝试接一个最小的原版式启动入口

## 一句话判断

这一步是把“原版主程序入口不在场”这个硬缺口先补上。

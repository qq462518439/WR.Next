# Battle Mode Execution Authority Gap

## 结论

当前可以明确判断：

> `WRobot.Launching` 不是最终权威，只是原宿主启动链的桥接入口。

新宿主之所以还没有原宿主那种“权威性”，不是因为 EXE 名称不同，也不是因为页面没抄够，而是因为：

> 新宿主尚未完整重建原版启动参数态与 Hook 安装副作用链。

这也是为什么当前已经做到：

- `WRobot.exe` 在运行域中可见
- `WRobot.Launching` 可反射调用
- `wManager.Pulsator.Pulse(processId)` 确实被执行

但仍然出现：

- `ThreadHooked=False`
- 执行链未成立
- `TraceLine` / `ClickToMove` / `Lua` 不能进入稳定可用状态

## 关键依据

### 1. `Information.LaunchBot(...)` 只是转发器

在 `wManager.Information` 中，`LaunchBot(...)` 并不直接承担完整启动逻辑，而是：

1. 在当前 `AppDomain` 枚举程序集
2. 找到包含 `WRobot.Launching` 的程序集
3. 反射调用 `WRobot.Launching.LaunchBot(...)`

这说明：

> 原版体系承认真正的启动权威原本位于 `WRobot.exe` 侧，而不是 `wManager.dll` 自己内部闭环完成。

### 2. 原版执行层强依赖 Hook 副作用

从已确认源码可知，以下能力都依赖：

- `Memory.WowMemory.ThreadHooked`
- `Memory.WowMemory.RetnToHookCode`
- `Memory.WowMemory.InjectAndExecute(...)`

这类能力包括但不限于：

- `TraceLine`
- `ClickToMove`
- `Lua`
- 部分 `Interact` / `Usefuls`

因此：

> “权威性”并不是一个 UI 或入口名义问题，而是一组必须已经发生的运行时副作用。

### 3. `ArgsParser` 很可能是差异链中的关键节点

当前原版参数系统有两个入口：

1. 命令行参数
2. `ArgsEnvironmentVariables` 环境变量承载的 JSON 参数

而 `ArgsParser.GetArgs` 又会影响：

- `NoDx`
- `NoLockFrame`
- `AutoStart`
- `LogInject`
- `ProcessId`
- `Product`

其中 `wManager.Wow.Memory.DetourAddress(...)` 与 `OriginalOpCode(...)` 明确受 `NoDx` / `NoLockFrame` 影响。

所以当前最合理的窄判断是：

> 新宿主虽然已把原入口程序集带入运行域，但未必把原入口期待的参数态一起建立出来。

## 本轮新增诊断

本轮没有扩大战斗逻辑，也没有改产品链主行为，只补了最小化诊断。

在 `src/WR.OriginalUiHost/Runtime/OriginalRuntimeBootstrap.cs` 中，`hook-pulse` 日志现在会额外输出：

- `threadHooked`
- `retnReady`
- `detourInUse`
- `detourAddress`
- `originalOpCodeLength`
- `args.processId`
- `args.product`
- `args.noDx`
- `args.dx`
- `args.noLockFrame`
- `args.autoStart`
- `args.logInject`

目的只有一个：

> 下一轮直接判定失败点是在“参数态未建立”，还是“Detour 地址链未成立”，还是“Hook 已部分落地但未翻起 ThreadHooked”。

## 当前结论分类

当前仍应归类为：

- `meaningful-structure-gap`

不属于：

- 页面壳问题
- 战斗按钮问题
- 普通设置页问题

## 下一步

下一包只看 `product-chain-actions.txt` 里新增的两行：

1. `hook-pulse ... state-before ...`
2. `hook-pulse ... state-after ...`

然后按以下顺序判断：

1. `args.*` 是否仍然是空态/默认态
2. `detourAddress` 是否为 0 或异常值
3. `originalOpCodeLength` 是否异常
4. `detourInUse` 是否始终为 `False`
5. `threadHooked` 是否始终不翻起

## 一句话判断

当前不是“新宿主没有资格”，而是：

> 新宿主还没有把原宿主那套启动参数态和 Hook 副作用链亲手重建出来。

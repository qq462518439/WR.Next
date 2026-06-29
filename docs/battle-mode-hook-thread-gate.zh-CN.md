# Battle Mode Hook Thread Gate

## 结论

当前 `WRotation` 战斗链刷红的核心原因，不是按钮，也不是 `FightClass` 未加载，而是：

> `TraceLine` / `ClickToMove` 依赖的原版 Hook 线程前置没有真正就绪。

因此本轮先加“硬门槛”，在 Hook 线程未就绪前，禁止进入战斗产品链，避免继续出现假启动、假运行、真刷错。

## 已确认事实

### 1. 红日志集中在两类调用

用户提供的错误日志显示，主错误几乎全部集中在：

1. `wManager.Wow.Helpers.TraceLine.TraceLineGo(...)`
2. `wManager.Wow.Helpers.ClickToMove.CGPlayer_C__ClickToMove(...)`

而且是高频 `NullReferenceException` 自旋。

### 2. 产品链本身已经启动成功

`product-chain-actions.txt` 已显示：

- `ProductStart ok alive=True started=True pause=False`
- `customclass alive=True`
- `spell-cache ok`
- `pathfinder-init ok`

所以这不是“产品未启动”的问题。

### 3. 原版这两条能力不是普通内存读写

查原版代码可确认：

- `TraceLine`
- `ClickToMove`
- `Lua`
- 多个移动/交互 helper

都依赖：

- `Memory.WowMemory.ThreadHooked`
- `Memory.WowMemory.RetnToHookCode`
- `InjectAndExecute(...)`

也就是说，这些能力依赖的是：

> 已接通的原版注入/返回桩线程链

而不是单纯 `Memory.Open(processId)` 就够。

## 当前问题点

当前宿主里的 `EnsureWowMemoryHook()` 之前只保证了：

1. `wManager.Wow.Memory.WowMemory` 不为空
2. `hook.Memory` 不为空

这对对象观察链够用，但对战斗导航链不够。

因为它没有证明：

1. `ThreadHooked == true`
2. `RetnToHookCode` 对当前运行链可用

这就是为什么：

- 首页状态能读
- `ObjectManager` 能跑
- 但一旦进入战斗导航层就开始刷 `TraceLine/ClickToMove` 红字

## 本轮改动

文件：

- `src/WR.OriginalUiHost/Runtime/OriginalRuntimeBootstrap.cs`

新增：

1. `IsWowHookThreadReady()`
2. `EnsureOriginalProductStarted()` 中的 Hook 线程门槛判断

当前逻辑：

- 如果 Hook 线程未就绪：
  - 记录 `hook-thread-check failed`
  - 直接返回失败
  - 不再放 `WRotation` 进入战斗产品链

## 为什么这一步是对的

这一步不是退回去不做主链，而是让主链更真实。

当前如果继续让产品启动：

1. 会进入假运行态
2. 人工测试会被红日志淹没
3. “偶尔转向”会制造错误进展感
4. 停止链也会被后台自旋干扰

所以先加门槛，是为了让系统明确表达：

> 当前缺的是 Hook 线程前置，不是模式按钮。

## 当前结论

当前 `WRotation` 主链已经收敛到：

1. 对象观察链可用
2. 产品加载链可用
3. 战斗导航层依赖 Hook 线程，当前尚未完整接通

因此当前最合理的顺序不是继续补战斗按钮，而是：

1. 抄原版 Hook 入口
2. 让 `ThreadHooked` 在当前宿主里真实成立
3. 再重新放开战斗产品链

## 下一步

下一包只做：

1. 审计原版主程序是如何把 `wManager.Wow.Memory.WowMemory.ThreadHooked` 带起来的
2. 对照当前宿主缺失的接入步骤
3. 不扩到别的产品

继续保持“先抄主链，再放能力”的顺序。

# Battle Mode Hook Entry Audit

## 结论

当前已经可以明确判断：

> `Memory.Open(processId)` 只能带起观察链，不能自动带起原版注入线程链。

而 `TraceLine`、`ClickToMove`、`Lua`、部分 `Interact`/`Usefuls`/`UnitCanAttack` 这类能力，都依赖：

- `Memory.WowMemory.ThreadHooked`
- `Memory.WowMemory.RetnToHookCode`
- `Memory.WowMemory.InjectAndExecute(...)`

这说明当前宿主与原版主程序之间，真正缺的是：

> 原版 Hook 入口链，而不是更多战斗按钮或页面逻辑。

## 已确认代码证据

### 1. `TraceLine` 直接依赖注入执行

在原版 `TraceLine.cs` 中，可确认：

- 分配远程内存
- 写入参数
- 通过 `CallWrapperCode(...)`
- 通过 `RetnToHookCode`
- 最终执行 `InjectAndExecute(...)`

所以它不是普通偏移读取，而是明显依赖 Hook/注入返回桩。

### 2. `ClickToMove` 同样依赖注入执行

在原版 `ClickToMove.cs` 中，可确认：

- `CGPlayer_C__ClickToMove(...)` 内部也会：
  - 使用 `CallWrapperCode(...)`
  - 使用 `RetnToHookCode`
  - 使用 `InjectAndExecute(...)`

因此它与 `TraceLine` 一样，不可能只靠 `Memory.Open` 稳定工作。

### 3. `Pulsator` 对 Hook 状态有硬依赖

在原版 `wManager.Pulsator` 与 `wManager.Wow.ObjectManager.Pulsator` 中，可确认：

- `IsActive` 判断依赖 `Memory.WowMemory.ThreadHooked`
- `ObjectManager` 脉冲线程也依赖 `ThreadHooked`

这说明原版主链默认前提就是：

> Hook 线程应先成立，再让更深能力层持续运行。

### 4. 原版内部存在 Detour/Patch 安装逻辑

在 `wManager\-.cs` 可见一段明显的 patch/detour 流程：

- `FindPatternAllMemoryRegions(...)`
- `Memory.WowMemory.Inject(...)`
- `Memory.WowMemory.Memory.Asm.Inject(...)`
- `Memory.DetourAddress(...)`
- `Memory.OriginalOpCode(...)`

这进一步证明：

> 原版主程序确实有一条独立的 Hook 安装链

而这条链当前还没有被我们的宿主接起来。

## 当前宿主缺口

当前宿主中：

- `EnsureWowMemoryHook()` 只保证：
  - `wManager.Wow.Memory.WowMemory` 不为空
  - `hook.Memory` 不为空

这能满足：

- `Memory.Open`
- `IsInGame`
- `PlayerName`
- `ObjectManager` 基础读取

但不能满足：

- `TraceLine`
- `ClickToMove`
- `Lua` 注入执行
- 基于 `InjectAndExecute` 的深层导航/交互/战斗执行

## 本轮已做保护

当前宿主已经新增：

- Hook 线程就绪检查
- 未就绪时禁止进入 `WRotation` 战斗产品链

这是为了防止再次出现：

- 产品看似启动
- 战斗链实际失真
- 红日志洪流
- 停止链也被后台自旋污染

## 当前结论分类

这轮结论属于：

- `meaningful-structure-gap`

不是：

- 资源小漏项
- 普通设置漂移
- 单纯页面接线问题

因为它影响的是：

> 原版“观察链”与“执行链”之间的核心分界线

## 下一步顺序

下一包必须继续按这个顺序：

1. 找出原版主程序在什么入口触发 Hook 安装链
2. 确认当前宿主缺的是哪一步调用/初始化时机
3. 先接通 Hook 线程
4. 再重新放开 `WRotation` 战斗产品链

## 一句话判断

当前不是“战斗逻辑还差一点”，而是：

> 宿主还停留在原版观察链，尚未真正进入原版执行链。

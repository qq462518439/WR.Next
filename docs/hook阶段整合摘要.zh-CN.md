# Hook 阶段整合摘要

## 结论

当前 hook 阶段停在：

> 读链成立，但执行权威没有成立。

也就是说，`Memory.Open`、`InGame`、基础对象可读已经成立，但 `ThreadHooked`、`detourAddress`、`detourInUse` 仍未形成可验收的成功证据。

## 已证实

### 1. 进程与读链可用

- `Memory.Open=True`
- `InGame=True`
- 角色基础状态可读
- `ObjectManager`、`Fight`、`MovementManager`、`SpellManager` 等公开状态与方法可枚举

### 2. `WRotation` 产品链已能进入启动与停止入口

- `Initialize()`、`Start()`、`Stop()` 入口存在
- `Start()` 会进入内部执行器 `_0002_2004._0002()`
- `Stop()` 会执行停链与插件释放

### 3. `NoDx` / detour 链已经被追踪到

- 已确认存在 `NoDx` 辅助线程链
- 已确认 `wManager.Pulsator.Pulse(processId)` 不是终点，而是进入混淆执行流的入口之一
- 已确认 `DetourAddress(processId)` 受调用栈白名单影响

## 未证实

- `ThreadHooked=True`
- `detourAddress != 0`
- `detourInUse=True`
- `HookReady=True`
- `NoDx` 辅助线程链最终完成落地
- 原版白名单调用栈内的 detour 参数生产链已经闭合

## 卡点

当前卡点不在 UI，也不在按钮，而在这条链：

1. `wManager.Pulsator.Pulse(processId)`
2. `NoDx` 辅助线程/混淆资源执行流
3. `DetourAddress / OriginalOpCode / Hook` 参数生产
4. `ThreadHooked` 置位

当前证据显示：

- 读链已经成立
- 但 detour / thread hook 没有真正落地

## 关键判断

### 1. 不是“完全没接上游戏”

因为：

- `Memory.Open=True`
- `InGame=True`
- 角色名、对象基础状态可读

### 2. 也不是“只要能读对象就等于 hook 成功”

因为：

- `ThreadHooked=False`
- `detourAddress=0x0`
- `detourInUse=False`

### 3. 也不是“按钮状态问题”

因为：

- 产品进入启动入口是成立的
- 问题出在 hook 线程与 detour 生产链

## 结论分类

当前 hook 阶段应继续归类为：

> `readable-but-not-hook-ready`

## 下一步

1. 继续追原版白名单调用栈内，谁真正把 `ThreadHooked` 带起来
2. 只盯 `NoDx` / detour / hook 参数生产链
3. 不再把 UI 或产品按钮当作根因

## 控制面建议

**hold**


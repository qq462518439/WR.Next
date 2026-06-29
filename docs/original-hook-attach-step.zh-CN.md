# 原版 Hook 连接补齐记录

## 结论

当前宿主此前只调用 `Memory.WowMemory.Memory.Open(pid)` 打开进程句柄，能读对象基础信息，但没有按原版路径创建 `robotManager.MemoryClass.Hook`。这会导致 Lua、ClickToMove、TraceLine 等依赖注入执行的能力出现空引用或只超时不动作。

本步已改为按原版公开入口构造：

```csharp
var detourAddress = wManager.Wow.Memory.DetourAddress(processId);
var originalOpCode = wManager.Wow.Memory.OriginalOpCode(processId);
wManager.Wow.Memory.WowMemory = new Hook(processId, detourAddress, originalOpCode);
```

## 验收点

进程连接后的详情信息应包含：

```text
threadHooked=True
```

同时补充显示：

```text
alloc=ok
ctmType=...
ctmPos=...
luaOne=1
```

字段含义：

- `threadHooked=True`：原版 `Hook` 线程已建立。
- `alloc=ok`：`Memory.WowMemory.AllocData` 可分配/释放远程内存。
- `ctmType` / `ctmPos`：原版 `ClickToMove` 状态读取可执行。
- `luaOne=1`：原版 `Lua.LuaDoString<int>("x=1", "x")` 可通过注入路径返回结果。

如果 `threadHooked=True` 但 `luaOne=ERR:*` 或 `ctmType=ERR:*`，下一步只查 Hook 后的注入执行链；如果这些都正常但角色仍不移动，下一步只查 `MovementManager.MoveTo -> ClickToMove.CGPlayer_C__ClickToMove` 的参数和目标坐标。

## 范围

本步不新增自定义移动器，不替换原版 DLL，不宣称战斗/寻路已接管完成。只补齐原版运行时连接链路中的 Hook 构造缺口。

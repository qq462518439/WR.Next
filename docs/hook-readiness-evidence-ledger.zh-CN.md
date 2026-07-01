# Hook 收官证据账本

## 结论

进程管理尚未收官。

当前只证明了读链成立：

- `Memory.Open=True`
- `InGame=True`
- 角色基础状态可读

但执行链没有成立：

- `HookReady=False`
- `ThreadHooked=False`
- `detourAddress=0x0`
- 下游产品不能按“正常工作”验收

在 `HookReady=True` 且至少一个下游产品真实开始/停止可验收前，不允许声明进程管理收官。

## 已确认硬证据

### 1. 当前运行日志

证据文件：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\process-management-host-actions.txt`
- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\product-chain-actions.txt`

当前关键状态反复出现：

```text
attached=True initialized=False memory=True hook=False inGame=True health=HookPending
```

含义：

- 进程已选中并附着
- 内存读取可用
- 游戏中状态可读
- Hook 未就绪
- 不能放行下游产品执行链

### 2. `DetourAddress(int processId)` 有调用栈白名单

证据文件：

- `D:\666\work\WR.Next\artifacts\wmanager-memory.actual.cs`
- `D:\666\work\WR.Next\external\decompiled-runtime\wManager\wManager.Wow\Memory.cs`

关键结构：

```csharp
array2 = new string[4]
{
    ...,
    ...,
    ...,
    ...
};

string text = new StackTrace().GetFrame(num).GetMethod().DeclaringType.FullName;
if (text != null && text.StartsWith(text2))
{
    goto allowed;
}

return 0u;
```

含义：

- `DetourAddress(...)` 不是任意宿主代码都能直接调用的普通查询函数。
- 调用栈不在白名单前缀内时会直接返回 `0u`。
- 这能解释当前宿主日志中的 `detourAddress=0x0`。

未完成项：

- 已解出 4 个白名单字符串明文：

```text
-1389976816 => WRobot.
-1389976826 => wManager.
-1389976778 => System.RuntimeMethodHandle
-1389976623 => System.Reflection.RuntimeMethodInfo
```

取证方式：

- 使用临时控制台程序从运行目录 `Bin` 直接反射调用实际 `wManager.dll` 内部字符串解码方法 `\u0006\u0010.\u0002(int)`。
- 该程序未写入主项目源码，运行后已从 `Bin` 删除。

结论：

- `WR.OriginalUiHost.*` 直接调用 `DetourAddress(...)` 必然不在白名单内。
- 当前宿主侧 `SafeGetDetourAddress(...)` 得到 `0x0`，只能证明“新宿主直调被白名单拒绝”，不能证明原版 `wManager`/`WRobot` 内部链拿不到 detour。
- 真正要恢复 Hook，必须让 Hook 入口从 `wManager.*` 或 `WRobot.*` 调用栈内自然触发。

### 3. `wManager.Pulsator.Pulse(int)` 是混淆转发入口

证据文件：

- `D:\666\work\WR.Next\artifacts\wmanager-pulsator.actual.cs`

关键结构：

```csharp
public static void Pulse(int processId)
{
    object[] array = new object[1];
    array[0] = processId;
    executor.Invoke(resource, "'7+qKIsufQ", array);
}
```

含义：

- 可读 C# 中看不到完整 Hook 创建逻辑。
- 真正的 `Hook` 初始化链在混淆资源执行流内。
- 不能仅凭 `Pulse(processId)` 被调用就证明 Hook 已经执行成功。
- 但 `Pulsator.Pulse(int)` 位于 `wManager.*` 白名单前缀内，因此它是当前已确认的合法候选入口之一。

### 4. `robotManager.MemoryClass.Hook` 构造函数依赖外部传入 detour 参数

证据文件：

- `D:\666\work\WR.Next\artifacts\robotmanager-hook.actual.cs`

关键结构：

```csharp
public Hook(int processId, uint detourAddress, byte[] originalBytes, ...)
{
    this.processId = processId;
    this.detourAddress = detourAddress;
    this.originalBytes = originalBytes;
    Init();
}
```

含义：

- 如果 `detourAddress=0x0` 或 `originalBytes` 为空，Hook 构造链没有可靠入口。
- 当前最上游问题仍是 detour 参数生产链，而不是产品按钮状态。

## 当前禁止判断

以下判断证据不足，禁止作为实现依据：

- `authManager.Remote` 一定能恢复 Hook
- 自写 Hook 比原链更快
- 只要能读对象就等于 Hook 成功
- `Pulsator.Pulse(processId)` 调用过就等于执行权威成立
- 进程管理已收官
- 新宿主直接调用 `DetourAddress(...)` 的结果可代表原链内部结果

## 下一步只允许做的取证

1. 对照原版链中哪些类型天然命中白名单。
2. 追踪混淆转发入口 `Pulsator.Pulse(int)` 对应资源方法是否创建 `Hook(...)`。
3. 区分两种 `detourAddress=0x0`：
   - 新宿主直调被白名单拒绝
   - 原版白名单链内部仍产不出 detour
4. 只有当证据能说明“应该从哪个原版入口触发 Hook”时，才允许改项目。

## 收官硬线

进程管理收官必须同时满足：

- `MemoryOpen=True`
- `InGame=True`
- `HookReady=True`
- `ThreadHooked=True`
- `detourAddress != 0`
- 下游产品至少 `WRotation` 能真实开始、停止，并且停止后后台循环不继续刷

当前状态：

**hold，继续 Hook 入口取证。**

## 2026-07-01 收口复核

结论：不能收官。

最新日志仍然稳定显示：

```text
attached=True initialized=False memory=True hook=False inGame=True health=HookPending
```

这只能证明：

- 进程选择与内存读链成立
- 角色基础状态可读
- 对象/停止移动等读链或普通内存写链可能局部可用

这不能证明：

- Detour 已安装
- NoDx 辅助线程已启动
- ThreadHooked 已成立
- WRotation/导航/战斗产品链具备执行权威

代码复核结果：

- 进程管理页显示 `Hook未就绪` 是正确状态。
- 产品页启动入口已有 `session.HookReady == false` 的硬拒绝。
- 当前不应再把“可读状态”误写成“已通过”或“收官”。

后续只追一个问题：

> 为什么读链成立，但原版白名单调用栈内仍没有产出可验收的 Detour/ThreadHooked 证据。

控制面建议：

**hold**

## 2026-07-01 NoDx worker starter 最小桥接

结论：本轮允许做一个最小实现改动。

依据不是猜测，而是反编译证据已经对齐：

- `wManager.Pulsator.Pulse(processId)` 会进入 `wManager` 混淆资源执行流。
- `wManager` 内部类型 `_0005_2009_2005` 持有 NoDx 辅助线程字段 `m__0008`。
- 该类型的静态无参 `_0002()` 会在 `ArgsParser.GetArgs.NoDx=True` 且线程未存活时创建并启动辅助线程。
- 辅助线程内部会扫描特征、注入 asm，并调用：
  - `Memory.DetourAddress(Memory.WowMemory.Memory.ProcessId)`
  - `Memory.OriginalOpCode(Memory.WowMemory.Memory.ProcessId)`
  - `robotManager.MemoryClass.Hook` 的内部登记方法

最新运行日志证明强制接管已经调用过 `wManager.Pulsator.Pulse(processId)`：

```text
hook-pulse attach-or-force-refresh begin pid=1724
hook-pulse attach-or-force-refresh end ready=False
```

但 NoDx 状态前后没有变化：

```text
threadNull=True alloc=0x0 mailbox=0x0 installed=0x0 relay=0x0
```

因此本轮改动限定为：

- 在 `Pulsator.Pulse(processId)` 后，如果 `HookReady` 仍未成立，反射调用 `_0005_2009_2005._0002()`。
- 调用前后写入 `nodx-starter` 快照。
- 不改产品链、不改 UI、不声明 Hook 已完成。

已验证：

```text
dotnet build src/WR.OriginalUiHost/WR.OriginalUiHost.csproj -c Debug
0 warnings, 0 errors
```

已同步发布：

```text
tools/layout/Publish-OriginalUiHostLayout.ps1
```

下一次验收只看硬证据：

- `nodx-starter ... invoked`
- `nodx-snapshot ... threadNull=False`
- `threadAlive=True`
- `mailbox/installed/relay` 至少一个从 `0x0` 变为非零
- `threadHooked=True`
- `detourInUse=True`
- `HookReady=True`

如果 `nodx-starter invoked` 后仍然 `threadNull=True`，下一步应追 `_0005_2009_2005._0002()` 内部早退条件或异常吞掉点。

## 2026-07-01 NoDx starter 首轮验收

结论：最小桥接未成功，但失败点更精确。

最新运行日志：

```text
nodx-starter attach-or-force-refresh before ... threadNull=True alloc=0x0 mailbox=0x0 installed=0x0 relay=0x0
nodx-starter attach-or-force-refresh skip starter-null type="  "
nodx-starter attach-or-force-refresh after-start ... threadNull=True alloc=0x0 mailbox=0x0 installed=0x0 relay=0x0
hook-pulse attach-or-force-refresh end ready=False
```

已确认：

- NoDx worker 类型识别是成立的，运行时类型名显示为控制字符：`  `。
- 但源码反编译名 `_0005_2009_2005._0002()` 没有作为运行时方法名保留下来。
- 当前不能继续按 `_0002` 猜方法名。

本轮后续改动限定为诊断增强：

- 当 starter 找不到时，枚举该类型中所有 `static void Method()` 候选。
- 下一轮运行日志应出现：

```text
nodx-starter ... skip starter-null type="..." candidates="..."
```

下一步判断：

- 如果候选只有一个或能由方法体/字段行为明确对应启动线程，再允许改成调用该候选。
- 如果候选多个且不可区分，继续离线 IL 对照，不允许盲调。

## 2026-07-01 发布链与真实方法名复核

结论：发现并修正一个上游发布链问题，同时拿到 NoDx starter 的真实方法名证据。

发布链问题：

- `tools/layout/Publish-OriginalUiHostLayout.ps1` 默认 `BuildRoot` 指向 `artifacts\uihost-reorg-build`。
- 该目录不是当前真实构建输出源，导致发布后的运行目录 `Bin` 可为空或缺核心 DLL。
- 这会让 Hook 验收变成噪音。

已修正：

```text
BuildRoot = D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48
```

发布后已确认运行目录存在核心 DLL：

```text
Bin\wManager.dll
Bin\robotManager.dll
Bin\MemoryRobot.dll
Bin\authManager.dll
Bin\RDManaged.dll
Bin\fasmdll_managed.dll
```

真实方法名证据：

本地反射枚举 `wManager.dll` 中 NoDx worker 候选类型，结果：

```text
TYPE \u0005  
FIELD \u0008 : System.Threading.Thread
FIELD \u0006 : System.Object
FIELD \u0005 : System.UInt32
FIELD \u000F : System.UInt32
FIELD \u000E : System.UInt32
FIELD \u0003 : System.UInt32
METHOD \u0002
METHOD \u0005
METHOD \u0006
METHOD \u0008
METHOD \u000F
```

因此：

- 反编译源码中的 `_0005_2009_2005._0002()` 对应运行时真实方法名 `\u0002`。
- 之前 `starter-null` 的原因是按源码伪名 `_0002` 查找方法，运行时找不到。

已改动：

- NoDx starter 解析改为优先匹配真实方法名 `\u0002`。
- 保留 `_0002` 作为兜底。
- 日志中转义输出控制字符方法名，预期出现：

```text
nodx-starter ... invoked ... method="\u0002"
```

下一次验收：

- 如果 `threadNull=False/threadAlive=True`，继续看是否扫描命中并生成 `mailbox/installed/relay`。
- 如果 `invoked method="\u0002"` 后仍 `threadNull=True`，追 starter 内部早退条件。

## 2026-07-01 自动化验收策略收紧

用户要求：

> 没有绝对成品，不允许要求人工测试。

已执行策略调整：

- 不再要求用户点击接管按钮或手动切页作为默认推进方式。
- 使用本地 x86 harness 直接反射调用 `OriginalRuntimeBootstrap.AttachToWowProcess(pid)`。
- 自动收集 `product-chain-actions.txt` 作为验收证据。
- 每次自动测试后检查并清理 `WRNextAttachHarness` / `WRNextHookOnlyHarness` / 宿主残留进程。

自动验收结果：

```text
nodx-starter attach-or-force-refresh invoked type="  " method="\u0002" pid=1724
nodx-starter attach-or-force-refresh after-start ... threadField="\u0008" threadNull=False threadAlive=True threadState="Running"
nodx-snapshot attach-or-force-refresh after ... threadNull=False threadAlive=True threadState="Running" uints="\u0003=0x0|\u0005=0x0|\u000E=0x0|\u000F=0x0"
hook-pulse attach-or-force-refresh end ready=False
```

长窗观察：

- 自动 harness 在 `AttachToWowProcess(pid)` 返回后继续等待约 65 秒。
- 期间 NoDx worker 线程保持可启动证据成立。
- 但 NoDx uint 状态仍未出现非零写入。
- `ThreadHooked=False`
- `detourInUse=False`
- `detourAddress=0x0`

当前结论：

- 已证明 NoDx starter 调用路径成立。
- 已证明 NoDx 辅助线程可被新宿主拉起。
- 尚未证明 NoDx 特征扫描、注入、mailbox/relay 建立成功。
- 进程管理仍不能收官。

下一步只追：

> NoDx worker 内部 `_000F()` 的特征扫描/注入分支为什么没有把 `uints` 推出全 0。

禁止：

- 继续要求用户手动点击来验证半成品。
- 在没有 `HookReady=True` 与下游产品可运行证据前声明收官。

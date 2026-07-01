# Battle Mode Hook Parameter Prep Audit

## 结论

当前战斗链卡住的核心点，已经从“进程选择 / auth / 外部原版宿主干扰”收敛为：

> 当前宿主内 `wManager.Pulsator.Pulse(processId)` 执行后，`Hook` 参数准备链没有成立。

也就是说：

1. 新宿主已经能稳定绑定唯一 WoW 进程
2. 绑定后的对象观察链可用
3. 但 `Hook` 仍未进入可执行态

因此当前真正缺的不是再选一次进程，也不是 `authManager.dll`，而是：

> `Hook` 所需的 `detourAddress / thread context / inject prerequisites` 没有在当前宿主内被正确准备出来。

## 已确认事实

### 1. 单进程接管链已成立

最新日志已反复证明：

- `attached=True`
- `memory=True`
- `inGame=True`
- `boundProcessId=1724`
- `boundWindowHandle=35389926`
- `boundMainModule=0x400000`

说明：

1. 当前 WoW 会话绑定是正确的
2. 原版链条看到的也是同一个 WoW 上下文
3. 问题不在 PID 漂移或错误附着

### 2. `LaunchBot` 会外起原版宿主，不会在当前宿主内补完 Hook

审计日志已确认：

- `launchbot-bridge ... result=1112`
- `wrobotPids="1112"`
- `wrobotWindows=0 -> 1`

说明：

> `wManager.Information.LaunchBot(...)` 会新起一个外部 `WRobot.exe` 进程。

这条链不是“在当前宿主里补初始化”，而是“逃逸回原版宿主”。

因此当前主线已调整为：

- 默认禁用 `LaunchBot`
- 只分析当前宿主内的 `Pulse` 失败现场

### 3. 在禁用 `LaunchBot` 后，纯净失败现场已拿到

日志显示：

- `launchbot-bridge attach-or-force-refresh skip disabled`
- `threadHooked=False`
- `detourInUse=False`
- `detourAddress=0x0`
- `ready=False`

这说明：

> 就算完全不让原版宿主介入，当前宿主自己仍然无法把 Hook 带起来。

## `Hook` 类型结构取证

通过本地诊断工具 `hook_inspect.exe` 已确认：

原始转储文件：

- [hook-reflection-dump.txt](D:\666\work\WR.Next\docs\hook-reflection-dump.txt)

### 1. `wManager.Wow.Memory.WowMemory` 持有的就是 `robotManager.MemoryClass.Hook`

类型关系：

- `FIELD wManager.Wow.Memory static WowMemory`
- 类型为 `robotManager.MemoryClass.Hook`

### 2. `Hook` 构造函数依赖的关键参数

构造函数：

```text
Void .ctor(
  Int32 processId,
  UInt32 detourAddress,
  Byte[] originalBytes,
  UInt32 jumpOrCallEsiWrapper = 0,
  UInt32 jumpOrCallEsiWrapperOffset = 0,
  Boolean rebaseCallAndJmpAddress = True,
  Boolean hwbpHook = False,
  UInt32 searchStackRequiredValue = 0,
  UInt32 searchStackMaxDistance = 592,
  UInt32 detourPointerDefaultValue = 0,
  UInt32 threadId = 0)
```

这说明 `Hook` 想成立，至少依赖：

1. `processId`
2. `detourAddress`
3. `originalBytes`
4. `hwbpHook`
5. `threadId`

### 3. `Hook` 的关键方法

已确认存在：

- `Inject(...)`
- `InjectAndExecute(...)`
- `ExecuteNewThread(...)`
- `DetourInUse()`
- `InstallStealthProtection()`
- `LockFrame()`
- `UnlockFrame(Boolean)`

这说明：

> 当前失败点很像是 `Pulse` 没有把注入目标地址、线程环境或跳板信息准备出来。

而不是“根本没调到 Hook 类”。

### 4. `Hook` 内部已经确认存在的关键字段

从反射转储可直接确认：

- `RetnToHookCode`
- `ThreadHooked`
- `AllocText`
- `AllocData`
- `Memory`
- 多个 `UInt32` 混淆字段
- 多个静态布尔/对象字段

这意味着后续日志不需要继续泛化描述“Hook 没起来”，而可以直接观察：

1. `RetnToHookCode` 是否从空变为非空
2. `ThreadHooked` 是否从 `False` 变为 `True`
3. 若干 `UInt32` 字段在 `Pulse` 前后是否完全不变
4. `Memory` 引用是否被替换或重建

当前宿主里已经开始把 `hookInternal=...` 写入运行日志，后续判断将以该字段为准继续收敛。

## 当前最关键的观测值

当前宿主在纯净场景下持续稳定输出：

```text
threadHooked=False
detourInUse=False
detourAddress=0x0
originalOpCodeLength=4
args.processId=1724
args.product="WRotation"
args.noDx=True
args.bpHook=True
args.noLockFrame=True
```

这组值说明：

1. `Args` 桥接已经写进去了
2. 当前进程上下文已经绑对了
3. `Pulse` 后 `Hook` 仍然没有拿到 `detourAddress`

所以最应该怀疑的是：

> `Pulse` 之前还缺一个原版宿主内的最小前置步骤，用来计算/下发 detour 目标地址、原始 opcode 或 thread context。

## 当前判断

到本轮为止，可以明确排除或降权的怀疑项：

### 已基本排除

1. PID 绑定错误
2. 进程接管页没有成为唯一上游
3. `authManager.dll` 直接决定当前 WoW 选择
4. `LaunchBot` 能在当前宿主里补完 Hook

### 当前高优先级怀疑项

1. `Pulse` 依赖的静态环境未完成
2. `Hook` 所需的 `detourAddress / originalBytes / threadId` 上游准备链未跑通
3. 原版窗口初始化中存在一个可迁移的最小副作用

## 新证据：MemoryRobot 版本链可疑

本地核对结果：

- `D:\666\RZB\Bin\MemoryRobot.dll`
  - 实际程序集版本：
    - `MemoryRobot, Version=1.0.9548.37988`
- `D:\666\RZB\Bin\wManager.dll`
  - 引用的 `MemoryRobot` 版本：
    - `MemoryRobot, Version=1.0.9549.22614`

这说明当前运行布局里至少存在：

> `wManager.dll` 编译期依赖的 `MemoryRobot` 版本，与磁盘实际提供的 `MemoryRobot.dll` 版本不一致。

这条证据很关键，因为探针里与 detour 地址定位相关的方法在枚举时正好出现：

- `FileNotFoundException: MemoryRobot, Version=1.0.9549.22614 ...`

而当前宿主又同时表现为：

- 对象观察链可用
- `detourAddress=0x0`
- `threadHooked=False`

因此当前高优先级判断进一步收敛为：

1. 基础对象/内存观察链对版本偏差容忍较高
2. detour 地址定位 / Hook 参数生产链对版本偏差更敏感
3. `MemoryRobot` 版本绑定不一致，已经足够成为当前主嫌疑之一

这并不自动证明“只要换 DLL 就能好”，但已经证明：

> 当前不能把 `MemoryRobot` 版本链视为无关噪音。

## 新证据：`DetourAddress` 上游源码链已对上

已直接核对反编译源码：

- [Memory.cs](D:\666\work\WR.Next\external\decompiled-runtime\wManager\wManager.Wow\Memory.cs)

可以确认 `wManager.Wow.Memory.DetourAddress(int processId)` 的分支结构是：

1. 先检查调用栈白名单
2. 处理 `NoLockFrame`
3. 若 `ArgsParser.GetArgs.NoDx=True`
   - 直接走内部 `NoDx` 分支并返回其结果
4. 否则：
   - 先探测 `D3D9/D3D11`
   - `IsD3D9(processId)` 成立则返回 `D3D.D3D9Adresse()`
   - 否则返回 `D3D.D3D11Adresse()`

而 `OriginalOpCode(processId)` 也明确依赖这条地址链：

1. `NoDx=True` 时直接读取 `DetourAddress(processId)` 处的 4 字节
2. 非 `NoDx` 时走 `D3D9OpCode()` / `D3D11OpCode()`

这说明当前现场里：

- `originalOpCodeLength=4`
- `detourAddress=0x0`

并不表示 Hook 真准备好了，只表示当前链条还能吐出一个 4 字节数组长度；真正关键的 detour 目标地址仍未生成。

同时，源码还确认：

- `D3D9AdresseByMemoryRead(MemoryRobot.Memory memory)`
- `GetOffset(string pattern, ...)`

都直接依赖 `MemoryRobot.Memory` 做读内存 / 找特征码。

因此可以把这轮判断再压实为：

> detour 参数链不是抽象概念，它确实是一条建立在 `MemoryRobot.Memory` 之上的地址探测链。

这使得前面的版本链怀疑进一步升权：

1. 如果 `MemoryRobot` 绑定版本不对
2. 那么 `D3D9AdresseByMemoryRead` / `GetOffset` / `DetourAddress`
3. 就完全可能出现“基础读对象还活着，但 detour 地址始终产不出来”的分裂现象

## 本轮收口结论

到当前为止，可以把主问题收束成一句话：

> 当前宿主不是“完全没接上游戏”，而是“读链成立，但建立执行权威所需的 detour 地址生产链没有成立”。

现有证据更支持：

1. 上游 `MemoryRobot` 版本/绑定链存在硬疑点
2. `Pulse(processId)` 没把 `DetourAddress(processId)` 拉出非零结果
3. `threadHooked=False` / `detourInUse=False` 只是这个更上游失败的结果，不是独立根因

因此下一步不该发散到页面、产品或 auth，而应继续只盯两件事：

1. 找到是否存在 `MemoryRobot, Version=1.0.9549.22614` 的本地实物或等价绑定证据
2. 继续核对 `NoDx` 分支内部到底由谁产出非零 detour 地址

## 新证据：当前宿主的程序集解析策略会放大“低版本先加载”风险

已核对宿主解析器：

- [App.xaml.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\App\App.xaml.cs)

当前 `ResolveOriginalRuntimeAssembly(...)` 的行为是：

1. 先看当前 `AppDomain` 里是否已存在“同名程序集”
2. 如果同名已存在，则直接 `reuse`
3. 不先校验请求版本是否与已加载版本一致

而宿主启动时又会主动预加载：

- `MemoryRobot.dll`
- `RDManaged.dll`
- `fasmdll_managed.dll`

这意味着只要低版本 `MemoryRobot.dll` 先进入 `AppDomain`，后续 `wManager.dll` 即使请求：

- `MemoryRobot, Version=1.0.9549.22614`

也可能被解析器直接复用为：

- 已加载的 `MemoryRobot, Version=1.0.9548.37988`

这条策略能解释当前“半残可用”现象：

1. 基础对象读取还能工作
2. 程序不会第一时间彻底崩掉
3. 但更敏感的 detour / offset / hook 参数生产链可能静默失效

因此现在可以再压一个明确判断：

> 当前不是单纯“找不到依赖”，而是很可能进入了“同名可加载但版本不匹配仍被复用”的半兼容状态。

本轮又补了一条实际运行证据：

- [original-ui-host-startup.txt](D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-ui-host-startup.txt)

启动日志中明确存在：

- `Preload MemoryRobot.dll => MemoryRobot, Version=1.0.9548.37988`

但没有看到：

- `Resolve requested MemoryRobot, Version=1.0.9549.22614`

这不削弱版本链怀疑，反而更符合下面这种运行形态：

1. 低版本 `MemoryRobot` 已在启动早期被 `Preload` 装入 `AppDomain`
2. 后续 `wManager` 绑定它时，不再触发 `AssemblyResolve`
3. 因而日志里不会留下 “Resolve requested MemoryRobot” 的显式痕迹

因此当前更像：

> 不是“解析失败导致直接崩”，而是“启动早期已把低版本塞进域内，后续依赖静默吃掉该对象”。 

## 新证据：`NoDx` 分支确实依赖辅助线程建立执行前置

已核对反编译源码：

- [decompiled-runtime/wManager/-.cs](D:\666\work\WR.Next\external\decompiled-runtime\wManager\-.cs)

可以确认：

1. `ArgsParser.GetArgs.NoDx=True` 且当前辅助线程未存活时
2. 原版会启动一个专门线程
3. 该线程内部后续会显式调用：
   - `Memory.DetourAddress(Memory.WowMemory.Memory.ProcessId)`
   - `Memory.OriginalOpCode(Memory.WowMemory.Memory.ProcessId).Length`

这说明：

> `NoDx` 路线不是绕开 detour 地址链，而是通过辅助线程去准备并消费这条链。

所以当前观测到的：

- `detourAddress=0x0`
- `threadHooked=False`
- `detourInUse=False`

更像是：

1. `NoDx` 辅助线程链未真正建立起有效的 detour 前置
2. 或者该线程所依赖的地址解析能力本身就处于失效状态

这也进一步说明，当前主问题仍然不在页面动作，而在：

> `NoDx` 辅助线程 + `MemoryRobot` 地址解析 + `DetourAddress` 生产链 这一整段执行前置没有成立。

## 当前阶段硬判断

到这一步，已经可以把现状明确分成三层：

1. 会话层成立  
   - PID 正确
   - 内存已开
   - 游戏中状态可读

2. 参数层失败  
   - `detourAddress=0x0`
   - `threadHooked=False`
   - `detourInUse=False`

3. 版本/绑定层高度可疑  
   - `wManager` 请求 `MemoryRobot 1.0.9549.22614`
   - 宿主预加载 `MemoryRobot 1.0.9548.37988`
   - 宿主解析策略允许“同名先复用”

所以当前最稳的表述应是：

> 现阶段不是 Hook “偶尔失败”，而是当前宿主很可能从一开始就以错误版本的 `MemoryRobot` 进入了执行前置链。

## 新证据：宿主内实际已加载程序集版本已拿到

已通过宿主启动日志新增快照直接确认：

- [original-ui-host-startup.txt](D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-ui-host-startup.txt)

关键记录：

- `LoadedAssemblySnapshot post-preload ...`

其中已明确出现：

- `MemoryRobot=MemoryRobot, Version=1.0.9548.37988`
- `wManager=wManager, Version=1.0.0.22627`
- `RDManaged=RDManaged, Version=1.0.9036.36198`
- `fasmdll_managed=fasmdll_managed, Version=1.0.5800.26082`
- `WRobot=WRobot, Version=1.0.0.0`

这条证据的重要性在于：

1. 它不是磁盘推测
2. 不是反射探针侧推
3. 而是当前宿主 `AppDomain` 内已经实际装载成功的程序集快照

因此现在可以把之前的“高概率怀疑”升级成更硬的表述：

> 当前宿主确实是在 `MemoryRobot 1.0.9548.37988` 之上启动并运行 `wManager` 相关链条的。

再结合前面已知事实：

1. `wManager.dll` 编译期引用的是 `MemoryRobot 1.0.9549.22614`
2. 当前宿主内实际跑的是 `MemoryRobot 1.0.9548.37988`
3. `detourAddress=0x0`
4. `threadHooked=False`
5. `detourInUse=False`

就可以把问题再收紧一层：

> 当前 Hook 执行权威失败，已经不能再把 `MemoryRobot` 版本差异当成旁证；它已经进入主证据链。

## 新证据：Hook 时刻的实际程序集组合已验收

本轮接管点击后，已从运行时日志直接拿到 Hook 入口瞬间的程序集快照：

- [product-chain-actions.txt](D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\product-chain-actions.txt)

关键记录：

- `assembly-snapshot hook-args label=hook-args count=6 ...`

其中明确出现：

- `MemoryRobot=MemoryRobot, Version=1.0.9548.37988`
- `robotManager=robotManager, Version=1.0.0.20858`
- `wManager=wManager, Version=1.0.0.22627`
- `RDManaged=RDManaged, Version=1.0.9036.36198`
- `fasmdll_managed=fasmdll_managed, Version=1.0.5800.26082`
- `WRobot=WRobot, Version=1.0.0.0`

这条证据说明：

1. 到 `hook-args apply` 阶段，`robotManager` 已经实际进入 `AppDomain`
2. 当前 Hook 入口不是“缺少 robotManager 导致根本没进链”
3. 实际进入 Hook 链时，仍然是 `MemoryRobot 1.0.9548.37988` 在工作

## 新证据：`Pulse` 前后 Hook 内部状态仍几乎完全不变

同一轮点击日志显示：

- `hook-pulse ... state-before`
- `hook-pulse ... state-after`

两侧共同保持：

- `threadHooked=False`
- `detourInUse=False`
- `detourAddress=0x0`
- `RetnToHookCode=retn`
- 多个 `UInt32` 型内部字段保持不变

因此这一轮可以再排除一个误区：

> 不是“Pulse 先把 Hook 推进了一部分，只是后半段失败”，而更像是“Hook 参数生产链在进入有效推进前就停住了”。

## 本轮验收结论

当前已经能用本地证据把问题压成一句话：

> Hook 时刻的运行时组合已经明确，但 `wManager.Pulsator.Pulse(processId)` 仍未把 `detourAddress / threadHooked / detourInUse` 推出初始失败态。

这使得当前判断继续偏向：

1. `MemoryRobot` 版本/绑定链是主嫌疑
2. `NoDx` 路线所依赖的 detour 参数生产链未真正起效
3. `robotManager` 缺失或晚加载已不再是主要怀疑项

## 纠偏证据：先前离线 `BadImageFormatException` 主要来自探针位宽错误

已对离线探针做 x86 复验：

- `D:\666\work\WR.Next\tools\diagnostics\bin\pulsator_entry_probe_x86.exe`

复验结果显示：

1. `LOAD MemoryRobot ok`
2. `LOAD robotManager ok`
3. `LOAD wManager ok`
4. `wManager.Wow.Memory` 中之前报错的方法现在可正常反射：
   - `D3D9AdresseByMemoryRead(MemoryRobot.Memory memory)`
   - `GetOffset(...)`
   - `DetourAddress(int processId)`

这说明：

> 先前离线探针里出现的 `BadImageFormatException`，主要是因为探针自身未固定为 x86 进程，而不是当前 x86 宿主内的直接运行时证据。

因此必须对之前一条判断做收口纠偏：

1. `MemoryRobot` 版本链依旧可疑
2. 但“关键方法一碰 `MemoryRobot` 就在离线探针里报 `BadImageFormatException`”这条证据不能再作为当前主证据使用
3. 当前应继续以**宿主真实运行日志**为主证据，以 **x86 探针** 为辅助证据

## 本轮进一步收紧后的结论

到这一轮为止，可以把问题压成更硬的一句话：

> `wManager.Pulsator.Pulse(processId)` 仍未推进 Hook，但离线 `BadImageFormatException` 已不能再直接指认为主证据；当前主证据仍是宿主内 `detourAddress=0x0` / `threadHooked=False` / `detourInUse=False`。

这解释了为什么我们持续看到：

- `detourAddress=0x0`
- `threadHooked=False`
- `detourInUse=False`

同时又始终无法拿到真正推进后的内部状态。

## 新证据：宿主与关键 DLL 的位宽/CLR 标记已核对

已通过本地 PE 头探针直接核对：

- `D:\666\work\WR.Next\tools\diagnostics\bin\pe_header_probe_legacy.exe`

关键结果如下：

1. `WR.OriginalUiHost.exe`
   - `PROC X86`
   - `MACHINE 0x014C`
   - `CORFLAGS 0x00000003`

2. `MemoryRobot.dll`
   - `PROC X86`
   - `MACHINE 0x014C`
   - `CORFLAGS 0x00000010`

3. `RDManaged.dll`
   - `PROC X86`
   - `MACHINE 0x014C`
   - `CORFLAGS 0x00000010`

4. `fasmdll_managed.dll`
   - `PROC X86`
   - `MACHINE 0x014C`
   - `CORFLAGS 0x00000010`

5. `robotManager.dll`
   - `PROC MSIL`
   - `MACHINE 0x014C`
   - `CORFLAGS 0x00000001`

6. `wManager.dll`
   - `PROC MSIL`
   - `MACHINE 0x014C`
   - `CORFLAGS 0x00000001`

这条证据能明确排除一个粗粒度误判：

> 当前问题不是“x64 宿主去装 x86 `MemoryRobot.dll`”这种一级位宽冲突。

也就是说：

1. 宿主本身就是 `x86`
2. `MemoryRobot/RDManaged/fasmdll_managed` 也都是 `x86`
3. `robotManager/wManager` 为 IL 程序集，但整体 PE 机器头仍是 `0x014C`

因此当前 `BadImageFormatException` 更应被理解为：

> 不是简单宿主位宽错误，而更可能是 `MemoryRobot` 的版本/依赖链或 C++/CLI 装载形态与 `wManager` 期待值不匹配。

## 新证据：`MemoryRobot.dll` 明确依赖 VC++ 2010 CRT

已通过本地导入表探针确认：

- `D:\666\work\WR.Next\tools\diagnostics\bin\pe_import_probe_legacy.exe`

`MemoryRobot.dll` 的导入表包含：

1. `KERNEL32.dll`
2. `MSVCR100.dll`
3. `MSVCP100.dll`
4. `USER32.dll`
5. `mscoree.dll`

其中最关键的是：

- `MSVCR100.dll`
- `MSVCP100.dll`

这说明：

> `MemoryRobot.dll` 不是纯托管库，它明确依赖 VC++ 2010 CRT（Visual C++ 2010 运行时）。

这条证据的重要意义在于：

1. 它解释了为什么 `MemoryRobot` 会落到“版本/装载链”层面的异常，而不是普通托管引用异常
2. 它使 `BadImageFormatException` 的解释范围进一步收窄到：
   - `MemoryRobot` 主体版本不匹配
   - 或 VC++ 2010 CRT / C++/CLI 依赖装载链异常
   - 或两者叠加

同时结合前面已确认的：

1. 宿主为 `x86`
2. `MemoryRobot.dll` 也是 `x86`
3. `wManager` 关键方法 `D3D9AdresseByMemoryRead` / `GetOffset` 在碰 `MemoryRobot` 时命中 `BadImageFormatException`

当前更稳的判断应是：

> 当前 `Pulse(processId)` 上游阻断，不再像单纯的 CPU 位宽错误，而更像 `MemoryRobot` 的版本与 VC++ 2010/C++/CLI 依赖装载链共同失配。

## 新证据：x86 版 VC++ 2010 CRT 当前在位且位宽匹配

已通过本地 CRT 探针确认：

- `D:\666\work\WR.Next\tools\diagnostics\bin\crt_probe_legacy.exe`

结果如下：

1. `C:\Windows\SysWOW64\MSVCR100.dll`
   - `VERSION 10.00.40219.325`
   - `MACHINE 0x014C`
   - `OPTMAGIC 0x10B`

2. `C:\Windows\SysWOW64\MSVCP100.dll`
   - `VERSION 10.00.40219.325`
   - `MACHINE 0x014C`
   - `OPTMAGIC 0x10B`

同时：

3. `C:\Windows\System32\MSVCR100.dll`
   - `MISSING`
4. `C:\Windows\System32\MSVCP100.dll`
   - `MISSING`

这条证据的意义是：

1. 当前机器上的 x86 VC++ 2010 CRT 是存在的
2. 它与我们的 x86 宿主 / x86 `MemoryRobot.dll` 位宽匹配
3. `System32` 下缺失的是 64 位 CRT，不构成当前 x86 宿主主阻断

因此可以再排除一个方向：

> 当前 `BadImageFormatException` 不太像“机器上根本没有 x86 VC++ 2010 CRT”。

当前更稳的判断继续收敛为：

> `MemoryRobot` 的问题更偏向主体版本/主体装载链不匹配，而不是 VC++ 2010 x86 CRT 完全缺失。

## 下一步

下一包只做两件事：

1. 继续核对 `MemoryRobot.dll` 本体是否还依赖其他未在运行目录显式出现的 native/C++/CLI 下游项
2. 再判断当前 `BadImageFormatException` 是否应主要归因到 `MemoryRobot 1.0.9548.37988` 与 `wManager` 期望版本不一致

目标不是继续猜，而是回答：

> 当前宿主内 `Pulse(processId)` 的真正上游阻断，到底是否已经可以主要归因到 `MemoryRobot` 主体版本不匹配。

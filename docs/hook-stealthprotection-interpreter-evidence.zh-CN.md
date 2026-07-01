# Hook StealthProtection 解释器证据纪要

## 结论

当前 `Hook.Inject(...)` 失败边界已从“泛化的解释器失败”收窄到：

> 解释器正在实际读取并准备 `robotManager.MemoryClass.StealthProtection(Hook)` 这条安装链所需的数据，但宿主侧最终仍没有形成 `baseCodecave != 0` / `ThreadHooked=True` 的成功证据。

这说明：

1. 失败点不在 attach/read 基础链。
2. 失败点不在“完全没有进入 hook 解释器”。
3. 失败点高度集中在 `StealthProtection` 安装相关的注入参数构造或其后续 `Inject(...)` 调用。

## 本轮新增硬证据

来源文件：

- [hook_token_decode_probe_latest.txt](D:\666\work\WR.Next\tools\diagnostics\Logs\hook_token_decode_probe_latest.txt)
- [StealthProtection.cs](D:\666\work\WR.Next\external\decompiled-runtime\robotManager\robotManager.MemoryClass\StealthProtection.cs)
- [Hook.cs](D:\666\work\WR.Next\external\decompiled-runtime\robotManager\robotManager.MemoryClass\Hook.cs)

### 1. 解释器读出的类型名与真实构造签名完全对上

`hook_token_decode_probe_latest.txt` 已直接输出：

- `HOOK_TYPE=robotManager.MemoryClass.Hook`
- `STEALTH_TYPE=robotManager.MemoryClass.StealthProtection`
- `STEALTH_CTOR PARAMS=robotManager.MemoryClass.Hook`

这与源码一致：

- `Hook.InstallStealthProtection()` 中执行 `new StealthProtection(this)`
- `StealthProtection` 公开构造函数签名为 `StealthProtection(Hook hook)`

因此，解释器流里读到的类型名不是噪音，而是与真实安装链对齐的业务对象。

### 2. `20705` 附近的读数目前只应视为“候选读方法探测结果”

在相同 probe 输出中，我们对 `reader \u0006 ` 的多个零参读取方法做了白名单探测。

这些结果目前证明的是：

1. `20705` 是一个可重复进入的真实绝对流位置。
2. 某些读取方法在该位置附近能稳定消费数据。
3. `StealthProtection` 类型名确实存在于这一段流中。

但它们**还不能直接等价为解释器真实执行顺序**。

当前探测读数如下：

1. `bool -> True`，位置 `20705 -> 20706`
2. `byte -> 2`，位置 `20706 -> 20707`
3. `char -> s`，位置 `20707 -> 20708`
4. `string -> obotManager.MemoryClass.StealthProtection, robotManager, Version=1.0.0.20858, ...`
   - 位置 `20708 -> 20823`
5. `uint -> 4294901760`
   - 位置 `20823 -> 20827`
6. `int -> -1`
   - 位置 `20827 -> 20831`
7. 后续还有：
   - `int -> 65533`
   - `int -> 65533`
   - `int -> 0`

结论：

- `20705` 是真实执行流位置，不是伪位置。
- 当前流段中确实存在“类型与参数块”相关内容，而不是直接暴露 opcode key。
- 但上面的读数是“候选读取方法分别从当前流位置读到什么”，不是解释器已被证明的真实消费顺序。

### 3. `_0002_2004_2005` 读方法语义已钉死

根据反编译 `robotManager\-.cs` 中 `_0002_2004_2005` 的实现：

1. `bool _0002()`
   - 读取 1 字节
2. `byte _0002()`
   - 读取 1 字节
3. `char _0002()`
   - 通过 `_0008()` / `_0006()` 读取 1 个字符
   - 对 ASCII 区段通常推进 1 字节
4. `string _0002()`
   - 先通过 `_000F()` 读取 7-bit 编码长度
   - 再按该长度继续读正文
5. `int _0005()`
   - 读取 4 字节
6. `uint _0002()`
   - 读取 4 字节

这说明：

- `string` 读取不是“直接把当前位置后面的所有字节当字符串”，而是先吃掉一个长度前缀。
- 因此上一轮看到的
  - `True`
  - `2`
  - `s`
  - `obotManager.MemoryClass.StealthProtection...`
  更合理的解释是：
  - 我们依次调用了不同候选读取方法，
  - 它们各自在邻近位置读到了可解释内容，
- 但这不代表解释器真实就是按 `bool -> byte -> char -> string` 这样执行。

### 4. 解释器后续确实会把类型名字串送入 `Type.GetType(...)`

根据反编译 `robotManager\-.cs` 中类型解析路径：

1. 解释器在某分支下会执行：

```csharp
string text = obj._0002();
type = Type.GetType(text);
```

2. 若 `Type.GetType(text)` 失败，还会继续：
   - 拆分 `typeName, assemblyName`
   - 遍历 `AppDomain.CurrentDomain.GetAssemblies()`
   - 或回退到 `Assembly.Load(...).GetTypes()`

这意味着：

- probe 中读出的  
  `obotManager.MemoryClass.StealthProtection, robotManager, Version=1.0.0.20858, ...`
  并不是“随机字符串命中”，
- 它符合解释器后续真实要消费的“程序集限定类型名”输入形态。

### 5. 解释器后续存在明确的构造/方法调用分支

同一份反编译中还能看到：

1. 解释器会把已解析 `Type` 与参数类型数组组装成 `MethodBase`
2. 若目标被标记为构造函数，则执行：

```csharp
Activator.CreateInstance(_0002.DeclaringType, ... , array2, null);
```

因此，当前更稳的解释是：

- `StealthProtection` 类型名进入解释器后，
- 极可能不是仅用于比较或日志，
- 而是会被送入真实的类型解析与构造/调用路径。

这与 `STEALTH_CTOR PARAMS=robotManager.MemoryClass.Hook` 一起，进一步加强了：

> 当前 hook 失败边界就在 `StealthProtection(Hook)` 安装链附近。

### 6. 类型名后续数据更像 `_0005_2006` 方法/构造描述对象，而不是直接四参

根据反编译 `robotManager\-.cs`：

1. `_0005_2006` 是解释器内部的“方法/构造描述对象”，字段结构包括：
   - 标志位 `byte`
   - 目标类型描述 `_0002`
   - 成员名 `string`
   - 参数类型数组 `_0002[]`
   - 泛型参数数组 `_0002[]`
   - 返回类型描述 `_0002`

2. 在对象反序列化分支中，解释器会显式构造 `_0005_2006`，并依次填充：
   - 目标类型
   - 成员名
   - 返回类型
   - 参数类型数量与各项
   - 泛型参数数量与各项

3. 后续 `MethodBase` 解析路径中：
   - 如果 `_0005_2006._0008()` 为真，走泛型方法解析
   - 否则会根据
     - 目标类型
     - 返回类型
     - 参数类型数组
     - 成员名
     去找构造函数或方法

因此，当前更稳的解释是：

- `StealthProtection` 类型名后面的 `4294901760 / -1 / 65533 / 65533 / 0`
- 很可能首先服务于 `_0005_2006` 或相邻描述对象的构造/解包，
- 而不是已经可以直接等价为 `StealthProtection._0002(uint,uint,uint,uint)` 四个实参本身。

这会把失败边界再往前推一层：

> 可能先卡在“解释器如何为 StealthProtection 安装链解包方法/构造描述”，然后才轮到真正的四参注入辅助函数。

### 7. `StealthProtection` 自身最终仍回落到 `Hook.Inject(...)`

`StealthProtection.cs` 可见：

1. `Install()` 通过解释器桥执行。
2. 内部私有方法 `_0002(uint, uint, uint, uint)` 会组装一批 asm 文本。
3. 最后调用：

```csharp
this.m__0002.Inject(list.ToArray(), out var baseCodecave, out var injectionStart)
```

若该调用失败，则：

- `StealthProtection` 安装失败
- 无法建立后续保护层
- 也不会自然推出我们需要的 hook 成功证据

## 与宿主日志的对齐关系

宿主日志仍然稳定显示：

- `MemoryOpen=True`
- `InGame=True`
- `hook-inject-probe ok=False`
- `baseCodecave=0x0`
- `ThreadHooked=False`

结合本轮新证据，可以更精确地解释为：

> 宿主并非没有进入 hook 解释器，而是已经深入到 `StealthProtection(Hook)` 参数读取阶段，但后续 `Inject(...)` 仍没有产出有效 codecave / thread hook 成果。

## 当前最稳的判断

当前最可疑的失败区间是：

## 2026-07-01 新增运行时硬证据：NoDx 已生成 codecave，但 detour 仍未落地

来源文件：

- [product-chain-actions.txt](D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48\logs\product-chain-actions.txt)
- [OriginalRuntimeBootstrap.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Runtime\OriginalRuntimeBootstrap.cs)

本轮新增诊断把 `NoDx` 静态字段输出成了固定语义名，现已直接确认：

1. `workerThread` 确实启动：
   - `threadNull=False`
   - `threadAlive=True`
   - `threadState="Running"`，随后转为 `WaitSleepJoin`
2. `patternScanState` 不再是 0：
   - 例如 `0x16`
   - 说明 worker 不是完全没进入工作段
3. `codecaveBase` 已变为非 0：
   - 例如 `0xFE80008`
4. 但 `detourAddress` 仍为 `0x0`
5. `detourEnabledFlag` 仍为 `0x0`
6. 同时：
   - `ThreadHooked=False`
   - `detourInUse=False`
   - `hook-inject-probe ok=False`
   - `baseCodecave=0x0`

对应日志片段已出现：

1. `nodx-starter ... after-start ... threadAlive=True threadState="Running"`
2. `nodx-snapshot ... after ... uints="patternScanState=0x16|detourAddress=0x0|detourEnabledFlag=0x0|codecaveBase=0xFE80008"`
3. `hook-inject-probe ... after ... ok=False baseCodecave=0x0`

### 这组证据排除了什么

它排除了下面几种旧猜法：

1. 不是 `NoDx` 线程根本没起
2. 不是 pattern 扫描完全没命中
3. 不是 codecave 完全没申请出来

### 这组证据把失败边界收到了哪里

当前最窄、最稳的失败边界已更新为：

> `NoDx` worker 已经进入工作段，并且至少完成了 pattern 相关推进与 codecave 基址生成，但后续没有把 `detourAddress` / `detourEnabledFlag` 回写成有效值，因此 `ThreadHooked` 始终不成立。

这意味着：

1. 真正的问题已经后移到 detour 安装或其回写阶段
2. `StealthProtection.Install()` 返回 `True` 仍不能等价于 hook 生效
3. 下一轮应优先继续追：
   - `codecaveBase -> detourAddress` 为什么断开
   - `detourEnabledFlag` 为什么始终不落位
   - `ThreadHooked` 的置位条件究竟卡在回写、校验还是最终启用步骤

### 当前控制面

`hold`

1. `StealthProtection` 解释器程序段的参数解包
2. 类型解析后的 `_0005_2006` 方法/构造描述对象解包
3. 类型解析后的构造/方法调用落点
4. 参数解包后的 asm 列表构造
5. `Hook.Inject(list, out baseCodecave, out injectionStart)` 内部执行

而不是：

1. PID 选择错误
2. 基础内存打开失败
3. 完全没进入 hook 链

## 本轮补强：`_0005_2006` 描述符解包已能与源码逐项对上

来源文件：

- [robotManager\-.cs](D:\666\work\WR.Next\external\decompiled-runtime\robotManager\-.cs)

### 1. `case 0` 的反序列化形状，明确就是 `_0005_2006`

在对象反序列化分支中，`case 0` 会构造 `_0005_2006`，并按下面顺序读流：

1. 先构造一个 `global::_0002`
   - `obj3._0002((byte)1);`
   - `obj3._0002(_0002._0005());`
   - 再写入 `obj2._0002(obj3);`
2. 再连续读取两个字符串：
   - `obj2._0002(_0002._0002());`
   - `obj2._0002(_0002._0002());`
3. 再构造一个 `global::_0002`
   - `obj4._0002((byte)1);`
   - `obj4._0002(_0002._0005());`
   - 再写入 `obj2._0008(obj4);`
4. 再读取两段 7-bit 长度前缀数组：
   - `int num = _0002._000F();`
   - `int num3 = _0002._000F();`
   - 每个元素都用 `_0002._0005()` 填一个 `global::_0002`

这说明：

> 类型名字串后面，解释器理论上还需要继续吃“成员名 / 返回类型 / 参数数组个数 / 泛型数组个数”等描述符数据，不能直接把后续 4 字节值认定成 stealth helper 的四个实参。

### 2. `_0005_2006` 的字段意义现在已明确

`_0005_2006` 自身字段结构是：

1. `byte m__0002`
   - 标志位
2. `_0002 m__0008`
   - 目标类型描述
3. `string _0006`
   - 成员名
4. `_0002[] _000F`
   - 参数类型数组
5. `_0002[] _0005`
   - 泛型参数数组
6. `_0002 _0003`
   - 返回类型描述

而 `MethodBase` 解析路径会这样消费它：

1. `Type type = this._0002(obj._0002()._0002(), false);`
2. `Type type2 = this._0002(obj._0008()._0002(), true);`
3. `Type[] array = new Type[obj._0002().Length];`
4. 若 `obj._0002() == ctor-marker`，就按构造函数分支：
   - `type.GetConstructor(...)`
5. 否则按方法分支：
   - `type.GetMethod(obj._0002(), ...)`
   - 或在 `AmbiguousMatchException` 下按“成员名 + 返回类型 + 参数列表”精确筛选

因此，当前链路里 `StealthProtection` 类型名后面最像的是：

> “如何解析出 `StealthProtection(Hook)` 或其后续私有 helper 的构造/方法描述”，而不是已经直接进入 `_0002(uint,uint,uint,uint)` 参数层。

### 3. 对 `4294901760 / -1 / 65533 / 65533 / 0` 的约束性结论

基于以上源码形状，当前只能做下面这个保守但硬的判断：

1. 这些值来自真实流位置 `20823` 之后，证据有效。
2. 但它们当前更可能属于：
   - `_0005_2006` 相邻描述对象残值
   - 计数/标志/类型 token 解包
   - 或编码边界上的探测结果
3. 现阶段**不能**把它们直接等价为：
   - `StealthProtection._0002(uint,uint,uint,uint)` 的四个实参
   - 更不能据此反推注入地址、偏移或掩码

所以本轮后的失败边界应更新为：

> 已确认解释器进入 `StealthProtection` 相关对象解析，但还未证明它已经正确完成 `MethodBase/ctor` 描述符解包，更未证明它已真实调用到四参 stealth helper。

## 本轮新增运行时硬证据：`StealthProtection` 的公开表面非常窄

来源文件：

- [stealth_descriptor_probe.cs](D:\666\work\WR.Next\tools\diagnostics\src\stealth_descriptor_probe.cs)
- [stealth_descriptor_probe_latest.txt](D:\666\work\WR.Next\tools\diagnostics\Logs\stealth_descriptor_probe_latest.txt)

通过同代 .NET Framework 探针，已经直接确认：

1. `HOOK=robotManager.MemoryClass.Hook`
2. `STEALTH=robotManager.MemoryClass.StealthProtection`
3. `CTOR=Void .ctor(robotManager.MemoryClass.Hook)`
4. `StealthProtection` 自身仅出现以下关键方法：
   - `Install() -> bool`
   - 私有 `_0002(uint,uint,uint,uint) -> bool`
   - `Remove() -> void`
   - `Dispose() -> void`

这条证据的意义是：

1. `StealthProtection` 没有多组重载构造函数可供解释器分流。
2. 一旦解释器流里的类型名明确指向 `StealthProtection`，那么“先构造 `StealthProtection(Hook)`”是高度收敛的唯一候选。
3. 构造完成后，真正有价值的内部执行入口几乎只剩：
   - `Install()`
   - 或其内部私有四参 helper `_0002(uint,uint,uint,uint)`

因此，本轮后可以把调用链再收紧为：

> 解释器更可能先解析并命中 `StealthProtection(Hook)` 构造函数描述，再由后续分支转入 `Install()` 或私有四参 helper，而不是在 `StealthProtection` 类型层面存在大量旁路。

### 关于本轮探针的边界

同一份运行时探针也输出了：

- `TYPELOAD=无法加载一个或多个请求的类型`
- `LOADER=System.BadImageFormatException: ... MemoryRobot.dll ...`

这里要明确：

1. 这不影响上面已经成功拿到的 `StealthProtection` 级别证据。
2. 它只说明继续全量枚举某些依赖类型时，`MemoryRobot` 的装载格式发生了额外限制。
3. 所以本轮有效证据仅限于：
   - `StealthProtection` 自身构造函数与方法表面
   - 不外推为 `MemoryRobot` 相关调用已经成功探明

## 本轮新增双 token 运行时证据：`Install()` 与私有 helper 入口已分离

来源文件：

- [stealth_token_decode_probe.cs](D:\666\work\WR.Next\tools\diagnostics\src\stealth_token_decode_probe.cs)
- [stealth_token_decode_probe_latest.txt](D:\666\work\WR.Next\tools\diagnostics\Logs\stealth_token_decode_probe_latest.txt)

通过同代 .NET Framework 探针，已经直接确认：

### 1. `Install()` token 与私有 helper token 的解释器入口不是同一个

`StealthProtection.cs` 中：

1. `Install()` 使用 token：
   - `dX$1\`Isuet`
2. 私有桥 `_0002()` 使用 token：
   - `_g6TQIsuf!`

探针输出显示：

1. `TOKEN=dX$1\`Isuet`
   - `INDEX=20905`
   - `PROGRAM_INIT=ok`
2. `TOKEN=_g6TQIsuf!`
   - `INDEX=21432`
   - `PROGRAM_INIT=ok`

这说明：

> `Install()` 与私有 helper 并不是同一段程序的不同读法，而是解释器中的两个独立入口段。

### 2. `Install()` token 起始段可读性更强，私有 helper token 起始段更像中间态/受控段

对于 `Install()` token（`INDEX=20905`）：

1. `bool -> True`
2. `byte -> 1`
3. `string -> �P\\u0000\\u0001\\u0008\\u0000\\u0001\\u0002\`System.BitConverter, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561`
4. `uint -> 879049011`
5. `int -> 3684656`
6. 还出现：
   - `char -> ArgumentException`
   - `_000F() -> FormatException`

对于私有 helper token（`INDEX=21432`）：

1. 多数候选读方法直接抛 `Exception`
2. 仅少数整型读法返回：
   - `_0006() -> -1`
   - `_0008() -> -1`

这组差异说明：

> `Install()` 的入口段更像“类型/调用描述刚开始解包”的位置，而私有 helper token 对应的入口更深、更受上下文约束，不像一个可随意直接从零状态读开的顶层段。

### 3. 当前最稳的链路判断再收紧一层

基于本轮双 token 证据，当前更稳的解释是：

1. 解释器先命中 `Install()` 对应程序段；
2. 在 `Install()` 段内部继续完成若干类型/方法描述解包；
3. 然后再转入私有 helper `_g6TQIsuf!` 对应的更深层入口；
4. 私有 helper 再进一步落向四参 `_0002(uint,uint,uint,uint)` 或其相邻调用面。

所以，本轮后比之前更不支持下面这种说法：

> 解释器一开始就直接落到四参 stealth helper 主体。

相反，当前证据更支持：

> 先 `Install()`，后 deeper helper。

## 本轮新增连续流证据：`Install()` 段仍表现为描述符/编码块，而非 helper 主体

来源文件：

- [stealth_token_decode_probe_latest.txt](D:\666\work\WR.Next\tools\diagnostics\Logs\stealth_token_decode_probe_latest.txt)

本轮在 `Install()` token（`INDEX=20905`）上追加了连续读探针。

### 1. 连续 `int` 读数没有呈现自然的业务参数轮廓

连续 `_0005()` 结果为：

1. `33489151`
2. `1383792640`
3. `1409353728`
4. `1851083119`
5. `1228092020`
6. `33947648`

这些值更像：

1. 编码块残值
2. token/类型描述打包内容
3. 或混合字节流被按 `int` 暴力解释的结果

而不像：

1. `StealthProtection._0002(uint,uint,uint,uint)` 的四个自然注入参数
2. 或明显的地址/偏移/掩码组

### 2. 连续 `string` 读数仍然不像 helper 入口名或自然业务字符串

连续 `string` 读数为：

1. `\u0013\u0000�\u0000\u0001\u0000\u0000\u0001\u0001�\u0000P`
2. 空串
3. `\u0006`
4. 空串

这进一步说明：

> `Install()` 入口附近仍然更像解释器正在消费一种结构化编码块，而不是已经进入一个“可直接读出方法名/参数名/helper 名称”的自然层。

### 3. 对 `20905 -> 21432` 的约束性更新

本轮还没有直接抓到：

1. 显式 helper 名称
2. 显式 `21432` 跳转值
3. 可直接证明“此处下一步就会跳入 `_g6TQIsuf!`”的单条运行时证据

但它强化了下面这个判断：

1. `20905` 段不是 helper 主体
2. `21432` 段也不是适合从零状态直接顶层解开的入口
3. 因而两者之间更可能存在：
   - 一层或多层描述符解析
   - MethodBase/Type 解析
   - 再转入 deeper helper

## 下一步

下一轮只继续做窄诊断：

1. 先把 `StealthProtection` 类型名后，真实还会再读几个字符串/类型描述/数组计数钉死。
2. 再判断 `StealthProtection(Hook)` 对应的是构造函数描述，还是后续私有方法描述。
3. 然后才判断 `4294901760 / -1 / 65533 / 65533 / 0` 中哪些值有资格进入真正的注入参数层：
   - 地址/掩码
   - 偏移/哨兵值
   - 注入参数默认值
4. 最后再把剩余候选值与 `StealthProtection._0002(uint,uint,uint,uint)` 的四个参数位次对齐。

## 当前控制面

`hold`

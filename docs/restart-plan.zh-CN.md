# WR.Next 重启计划

生成日期：2026-06-28

## 结论

当前仓库清空后，新项目不再沿用上一版“先做 UI 壳、再尝试接核心”的路线。

新路线只有一个原则：

> 核心命令行验收未通过前，不做对应 UI。

第一阶段先接管可验证运行链：

1. 进程发现。
2. 玩家基础状态。
3. 对象列表。
4. 当前目标。
5. 最近可攻击目标选择。
6. 跟近目标并证明距离下降。

这些通过后，才允许进入 WPF 首页和“游戏中”页面。

## 当前已确认环境

### 可用

- 源码新根目录：`D:\666\work\WR.Next`
- 原版运行根目录：`D:\666\RZB`
- 核心 DLL：
  - `D:\666\RZB\Bin\wManager.dll`
  - `D:\666\RZB\Bin\robotManager.dll`
  - `D:\666\RZB\Bin\MemoryRobot.dll`
  - `D:\666\RZB\Bin\authManager.dll`
- 反编译工具：
  - `D:\666\.tools\ilspycmd\ilspycmd.exe`

### 风险

- `D:\666\RZB\WRobot.exe` 当前不存在。
- `D:\666\RZB` 内仍有上一版残留产物：
  - `WR.LightShell.exe`
  - `WR.RuntimeHost.exe`
  - `WR.RuntimeProbe.exe`
- 因此新源码不能把这些残留当成可信基线，只能把 `Bin` 里的原版 DLL 当依赖。

## 废弃上一版的原因

上一版废弃不是因为不能启动，也不是因为 UI 不够像。

真正原因是验收顺序错误：

- UI 先行，核心链后补。
- 页面能显示，但无法证明战斗链可用。
- “启动产品成功”被错误放大成“战斗可测试”。
- 目标层、对象层、移动层没有形成闭环。

已知硬断点：

- 玩家基础状态可读。
- 当前目标读取曾返回 `TargetGuid = 0x0`。
- 高层 `ObjectManager.Me` 在宿主上下文中不稳定。
- `follow-target` 没有证明距离下降。

因此上一版 UI 不作为新项目基础。

## 新项目目录约定

```text
D:\666\work\WR.Next
  docs\
  src\
    WR.Next.RuntimeHost\
    WR.Next.RuntimeCore\
    WR.Next.App\
  tests\
  artifacts\
```

### 项目职责

`WR.Next.RuntimeHost`

- .NET Framework 4.8 x86 控制台宿主。
- 负责加载原版 `wManager/robotManager/MemoryRobot`。
- 负责所有游戏进程内存、对象、目标、移动验收命令。
- 不承载 WPF UI。

`WR.Next.RuntimeCore`

- .NET 8 类库。
- 定义命令结果模型、进程模型、状态模型。
- 不直接引用原版 DLL。

`WR.Next.App`

- .NET 8 WPF UI。
- 只调用 `RuntimeHost` 命令。
- 不直接读游戏内存。
- 不直接引用 `authManager.dll`。

## 第一阶段：Runtime Proof

目标：没有 UI，只做可重复命令。

### 命令 1：进程发现

```powershell
WR.Next.RuntimeHost.exe --process-list
```

验收：

- 能列出 `Wow.exe`。
- 输出 PID、窗口标题、路径、是否可能可接管。

### 命令 2：基础状态

```powershell
WR.Next.RuntimeHost.exe --rawstatus --pid <pid>
```

验收：

- `IsInGame = true`
- `PlayerName` 非空
- `Level` 可读
- `HealthPercent` 可读
- `Position` 可读

### 命令 3：对象列表

```powershell
WR.Next.RuntimeHost.exe --objectstatus --pid <pid>
```

验收：

- 能读 ObjectManager 地址。
- 能列出对象总数。
- 能按类型统计：
  - Player
  - Unit
  - GameObject
  - DynamicObject
- 能定位本地玩家对象。

### 命令 4：当前目标

```powershell
WR.Next.RuntimeHost.exe --targetstatus --pid <pid>
```

验收：

- 未选中目标时明确返回 `target-no-target`。
- 选中目标时返回：
  - TargetGuid
  - TargetBaseAddress
  - TargetLevel
  - TargetHealthPercent
  - TargetPosition
  - TargetDistance

### 命令 5：选择最近目标

```powershell
WR.Next.RuntimeHost.exe --select-nearest --pid <pid>
```

验收：

- 从对象列表中选择最近可攻击 Unit。
- 写入/调用原版目标选择链。
- 再执行 `--targetstatus` 必须能读到同一个目标。

### 命令 6：跟近目标

```powershell
WR.Next.RuntimeHost.exe --follow-target --pid <pid>
```

验收：

- 执行前读取距离 `BeforeDistance`。
- 调用原版移动/ClickToMove/MovementManager 链。
- 执行后读取距离 `AfterDistance`。
- `AfterDistance < BeforeDistance` 才算通过。

## 第二阶段：Runtime API

目标：把第一阶段命令封装成稳定 API。

要求：

- 所有命令返回统一 JSON。
- 每个结果必须有：
  - `Ok`
  - `Stage`
  - `ProcessId`
  - `Error`
  - `Diagnostics`
- 失败必须可分类：
  - `process-not-found`
  - `not-in-game`
  - `player-not-found`
  - `target-no-target`
  - `target-not-in-object-list`
  - `movement-no-distance-gain`

## 第三阶段：WPF 首页

只有第一阶段通过后才开始。

首页只做三件事：

1. 自动刷新 WoW 进程。
2. 显示玩家基础状态。
3. 显示当前目标状态。

禁止：

- 不做产品选择。
- 不做登录。
- 不做订阅。
- 不做复杂战斗配置。
- 不做未验收按钮。

## 第四阶段：游戏中页面

只有 `objectstatus + targetstatus + follow-target` 通过后开始。

页面展示：

- 玩家状态。
- 当前目标。
- 附近对象列表。
- 距离变化。
- 最小跟近测试状态。

## 第五阶段：战斗模式

只有跟近目标可验证后开始。

最低验收：

- 能选目标。
- 能跟近。
- 能进入技能释放条件判断。
- 能从日志证明动作顺序。

在此之前，不允许宣称“战斗模式可用”。

## 控制面建议

当前建议：

```text
hold UI
promote Runtime Proof
downgrade previous LightShell to discarded prototype
```


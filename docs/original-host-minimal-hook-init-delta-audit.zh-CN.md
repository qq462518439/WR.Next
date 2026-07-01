# Original Host Minimal Hook Init Delta Audit

## 结论

当前主问题已经可以明确收敛为：

> `WR.Next` 宿主没有复现原版 `WRobot.exe` 在 Hook 成功前的最小初始化链。

这不是 PID 选择错误，不是 WoW 进程本身异常，也不是“完全读不到游戏”。

当前硬结论：

- 原版宿主在同一 WoW `pid=1724` 上可成功完成 Hook 建立
- `WR.Next` 宿主在同一 WoW `pid=1724` 上仅能完成读取链，不能完成 Hook 建立
- 第一个已知分叉点发生在：
  - 原版已经进入 `D3D9 used -> HWBP hook -> StealthProtection -> Hooking success`
  - `WR.Next` 仍停留在 `Pulse` 后 `detourAddress=0x0 / threadHooked=False / detourInUse=False`

因此当前控制结论是：

> `WR.Next` 处于 `readable-but-not-hook-ready`，下一步必须审原版宿主的 pre-hook 初始化路径，而不是继续怀疑 auth / UI / PID。

## 证据来源

- 原版成功日志：
  - `D:\666\RZB\Logs\1 7月 2026 02H33.log.html`
- `WR.Next` 失败日志：
  - `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\product-chain-actions.txt`
  - `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-ui-host-startup.txt`
- 既有审计：
  - `D:\666\work\WR.Next\docs\battle-mode-hook-parameter-prep-audit.zh-CN.md`

## 并排对照

| 阶段 | 原版 `WRobot.exe` | `WR.Next` |
| --- | --- | --- |
| 宿主启动 | 成功启动 | 成功启动 |
| 运行目录健康检查 | 可推定通过 | 明确通过 |
| 关键依赖在位 | 成功运行可侧证 | 明确通过 |
| 绑定同一 WoW PID | `Select game process: 1724` | `session-attach-request pid=1724` |
| 基础内存读取 | 成立 | `memoryOpen=True` |
| 游戏内状态 | `Player found: True` | `inGame=True` |
| D3D 探测 | `D3D9 found`, `D3D11 found`, `D3D9 used` | 无等价成功证据 |
| HWBP / detour 链 | `HWBP hook` | `threadHooked=False` |
| StealthProtection | `[StealthProtection] Active` | 无等价成功证据 |
| Hook 完成 | `[Memory] Hooking success.` | `detourAddress=0x0`, `detourInUse=False` |
| 进入产品主链 | `WRotation Loaded`, `ThreadMoveTo() started.` | 仅停在 `HookPending` |

## 原版成功链

原版关键里程碑按日志顺序如下：

1. `[Memory] D3D9 found`
2. `[Memory] D3D11 found`
3. `[Memory] D3D9 used`
4. `HWBP hook`
5. `[StealthProtection] Active`
6. `[Memory] Hooking success.`
7. `[Memory] Select game process: 1724`
8. `Spellbook loaded`
9. `[WRotation] Loaded`
10. `ThreadMoveTo() started.`

这说明原版不是“能读就算成功”，而是先把 Hook 执行权威建起来，再进入产品链。

## `WR.Next` 当前链

`WR.Next` 当前关键里程碑如下：

1. 宿主启动、健康检查通过
2. 预加载 `WRobot / MemoryRobot / RDManaged / fasmdll_managed`
3. 发起 `session-attach-request pid=1724`
4. `hook-args apply`
5. 调用 `hook-pulse attach-or-force-refresh begin`
6. 结果仍为：
   - `memoryOpen=True`
   - `threadHooked=False`
   - `detourAddress=0x0`
   - `detourInUse=False`
   - `ready=False`
7. 会话进入：
   - `health=HookPending`
   - `inGame=True`

这说明 `WR.Next` 已经具备：

- 正确 PID
- 基础读取
- 游戏内状态确认

但缺少：

- detour 地址落地
- hook 线程建立
- stealth/hook success 证据

## 第一个分叉点

当前最稳的分叉点判断是：

> 原版已经进入 `D3D` 选路并继续到 `HWBP hook`，而 `WR.Next` 没有任何等价的成功证据，直接停在 `Pulse` 后的未就绪态。

换句话说：

- 原版的 pre-hook 初始化链中，至少有一段最小副作用没有在 `WR.Next` 中被复现
- 这段副作用发生时间点，早于 `Hooking success`
- 很可能就在：
  - D3D 选择
  - HWBP hook 建立
  - StealthProtection 激活

三者之一，或者三者之间的桥接处

## 已可排除项

基于当前证据，以下方向应降权：

- 再次怀疑 PID 选错
- 再次怀疑 UI 没有成为唯一入口
- 把 `authManager.dll` 当成当前第一嫌疑
- 把 `LaunchBot` 当成正式修复路径
- 把“能读对象”误判为“Hook 已完成”

## 当前高优先级怀疑项

当前最值得继续深挖的是：

1. 原版宿主在 `Pulse` 前是否执行了额外的 D3D / HWBP / stealth 初始化
2. `WR.Next` 是否漏掉了原版入口中的某个静态初始化副作用
3. `MemoryRobot` / `wManager` 版本链不一致，是否恰好伤在 detour/hook 参数生产链

## 新增验收结论（2026-07-01 03:13）

### 1. `NoDx` worker 类型已真实命中

当前宿主日志已不再停留在 `type=null`，而是稳定命中真实 `NoDx` worker 类型：

- `type="  "`

这说明：

- `NoDx` 线程类并非不存在
- 先前的 `type=null` 已被证明是错误定位方式导致的假阴性

### 2. `NoDx` worker 仍未启动

最新日志：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\product-chain-actions.txt`

明确显示：

- `threadNull=True`
- `threadAlive=null`
- `alloc=0x0`
- `mailbox=0x0`
- `installed=0x0`
- `relay=0x0`

并且在 `before/after` 两个快照中完全不变。

这把当前问题进一步压成一句话：

> 当前不是 “NoDx worker started but inject failed”，而是 “NoDx worker never started”。

### 3. 参数表面值已基本排除为主因

最新日志同时确认：

- `args.product="WRotation"`
- `args.noDx=True`
- `args.dx=False`
- `args.bpHook=True`
- `args.noLockFrame=True`
- `args.autoStart=False`
- `args.logInject=True`
- `args.autoAttachAndLog=False`

而我们已做过两轮桥接：

1. 直接修改 `ArgsParser.GetArgs`
2. 构造完整 `Args` 包并同步到 `ArgsEnvironmentVariables`

两轮结果一致：

- `threadHooked=False`
- `detourAddress=0x0`
- `NoDx worker` 未启动

因此当前可以把下面这条结论写硬：

> 当前缺口已不再像是 `Args` 表面值问题，而是更早的原版宿主初始化上下文问题。

### 4. 当前唯一主线

到这一步，最值得追的只剩：

1. `WRobot.exe` 主入口在 `Pulse` 前做了什么
2. 哪个原版宿主副作用让 `NoDx worker bootstrap` 变成可启动状态
3. `WR.Next` 少掉的是哪一个 pre-pulse 初始化动作

## `authManager.dll` 重新升权说明

### 1. 为什么之前没有把它放到主线中心

此前优先级排序是：

1. 先确认是不是 PID / attach / hook 参数层问题
2. 再确认是不是 `Pulse` / `NoDx worker` 本身的问题

在这一阶段，`authManager.dll` 被视为：

- 登录壳
- 进程选择 UI
- 可能相关，但不是第一刀

这条排序在当时并非完全错误，但现在证据已经推进到一个新阶段：

> 参数层、PID 层、表面接管层都已大幅降权，`authManager.dll` 应重新升权为主线候选。

### 2. 当前已确认的 `authManager` 事实

本地源码树已经存在：

- `D:\666\work\WR.Next\external\ilspy\authManager`

并且明文可见：

- `authManager.LoginUserControl`
  - 持有：
    - `listBoxProcess`
    - `buttonRefresh`
    - `buttonLaunchBot`
    - `textBlockLaunchBot`
- `authManager.LoginServer`
  - 明显包含：
    - 线程
    - 网络
    - 程序集扫描
    - 后台任务
- `authManager.Remote`
  - 持有后台线程
  - 连接 `IRemote`
- `authManager.IRemote`
  - 暴露角色状态、目标状态、关 bot、关游戏等宿主级接口

这说明：

> `authManager.dll` 不是单纯答题框，而是原版“进程选择 / 启动 bot / 宿主远程状态”链的直接参与者。

### 3. 当前能写硬的判断

现在还不能直接下结论：

- “Hook 就是由 authManager UI 完成的”

但已经足够写硬：

1. `authManager` 与原版接管链直接相邻
2. `authManager` 很可能承担了把宿主推进到可 Hook 上下文的一段 UI 驱动副作用
3. 当前 `WR.Next` 自己接管进程后，虽然能读状态，但没有复现这段副作用

因此当前最值得追的并排差异是：

> `authManager` 原版接管链 vs `WR.Next` 当前接管链

而不再只是：

> `Args` 是否正确 / `Pulse` 是否被调用

### 4. 当前 `WR.Next` 确实绕过了 `authManager` 原始事件链

这一点现已可以写硬。

#### 原版 `authManager.LoginUserControl`

反射结果显示：

- 类型：`authManager.LoginUserControl`
- 公开/私有字段中直接持有：
  - `listBoxProcess`
  - `buttonRefresh`
  - `buttonLaunchBot`
  - `textBlockLaunchBot`
- 并且声明了多组真实事件处理入口：
  - `Void (System.Object, System.Windows.RoutedEventArgs)`
  - `Void (System.Object, System.EventArgs)`
  - `Void (System.Object, System.Windows.RoutedEventArgs)`
  - `Void (System.Object, System.Windows.RoutedEventArgs)`（async 状态机）
  - `Void (System.Object, System.Windows.Input.MouseButtonEventArgs)`

这些方法虽然名称混淆，但它们明确说明：

> 原版接管页不是“几个公开字段而已”，而是存在一整套按钮/列表/鼠标/异步事件链。

#### 当前 `WR.Next` 的 takeover 方式

当前适配器：

- `D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalLoginTakeoverAdapter.cs`

已明确做了下列替换：

1. `ReplaceProcessList(control)`
   - 直接改写 `listBoxProcess.ItemsSource`
2. `TakeOverLaunchButton(control)`
   - 直接拦截 `buttonLaunchBot`
3. `TakeOverRefreshButton(control)`
   - 直接拦截 `buttonRefresh`
4. `OverlayLocalButtons(control)`
   - 在原按钮上叠一层本地按钮
5. `HandleLaunch(control)`
   - 只做：
     - 读取本地选中 PID
     - 写日志
     - 改本地文案

这意味着：

> 当前 `WR.Next` 并没有走 `authManager.LoginUserControl` 的原始点击事件末端，而是把原始“选进程/点接管/点刷新”链整体短路成本地逻辑。

#### 这条证据为什么重要

它可以直接解释当前现象：

- `WR.Next` 能显示原版登录壳
- 能本地选中 WoW 进程
- 能进入可读状态
- 但 `NoDx worker` 仍不启动

因为当前执行的并不是：

> 原版 `authManager` 接管链

而只是：

> 借用原版壳控件 + 本地替换事件后的宿主链

所以当前最硬的新判断是：

> `WR.Next` 当前登录接管页属于 UI takeover，不属于原版 `authManager` 接管链的等价执行。

## 新增源码级证据

### 1. `wManager.Pulsator.Pulse(int)` 本体是混淆壳

从反编译源码可见：

- `D:\666\work\WR.Next\external\decompiled-runtime\wManager\wManager\Pulsator.cs`

`Pulse(int processId)` 本身并不直接暴露核心实现，而是把调用转进混淆载荷。

这意味着：

- 不能再靠表层方法名猜测 `Pulse` 内部已经做完了什么
- 必须从其上下游可见副作用来判断原版真实初始化链

### 2. `DetourAddress(processId)` 已明确暴露出两条分支

从：

- `D:\666\work\WR.Next\external\decompiled-runtime\wManager\wManager.Wow\Memory.cs`

可确认：

1. 若 `ArgsParser.GetArgs.NoDx=True`
   - `DetourAddress(processId)` 直接走内部 `NoDx` 分支并返回其结果
2. 否则
   - 先执行 `D3D.D3D9Adresse()`
   - 再执行 `D3D.D3D11Adresse()`
   - 然后按 `IsD3D9(processId)` 选择 D3D9 / D3D11 detour 地址

这与原版日志中的：

- `D3D9 found`
- `D3D11 found`
- `D3D9 used`

完全对得上。

### 3. `NoDx` 不是“跳过一切”，而是依赖一条额外后台线程链

从混淆反编译片段：

- `D:\666\work\WR.Next\external\decompiled-runtime\wManager\-.cs`

可确认存在一条 `NoDx` 线程链：

1. 仅当 `ArgsParser.GetArgs.NoDx=True` 且当前线程未运行时才启动
2. 启动一个后台线程
3. 线程内部会：
   - 搜索特定模式
   - 分配 `AllocData`
   - 调用 `Memory.WowMemory.Inject(...)`
   - 回写跳转
   - 记录完成状态
4. 完成后还会调用：
   - `Memory.DetourAddress(...)`
   - `Memory.OriginalOpCode(...)`

这条证据非常关键，因为它说明：

> `NoDx=True` 并不是单纯“绕过 D3D”，而是切到另一条同样需要成功落地的 detour/注入桥。

而 `WR.Next` 当前日志里：

- `nodx-snapshot ... type=null`
- `detourAddress=0x0`
- `threadHooked=False`

说明至少到目前为止，我们没有拿到这条 `NoDx` 桥真正成立的证据。

### 4. `Hook` 与 `StealthProtection` 的先后关系也已钉死

从：

- `D:\666\work\WR.Next\external\decompiled-runtime\robotManager\robotManager.MemoryClass\Hook.cs`
- `D:\666\work\WR.Next\external\decompiled-runtime\robotManager\robotManager.MemoryClass\StealthProtection.cs`

可确认：

1. `Hook` 先要建立可用的注入/线程状态
2. `InstallStealthProtection()` 只是 `Hook` 上的后续安装动作
3. `StealthProtection` 自身仍依赖 `Hook.Inject(...)`

因此：

> `StealthProtection` 不是最上游启动器，而是 Hook 已进入可执行态后的加强层。

这进一步说明，当前真正的第一故障点更可能发生在：

- D3D 选路前后
- 或 `NoDx` 后台线程链
- 或 `Hook` 初始注入成功之前

而不是发生在 `StealthProtection` 自身。

## 下一步施工建议

只做一条主线：

1. 从原版入口 / 反编译源码中追 pre-hook 初始化路径
2. 找到谁负责把链条推进到：
   - `D3D9 used`
   - `HWBP hook`
   - `StealthProtection Active`
   - `Hooking success`
3. 当前优先盯 `NoDx` 后台线程链是否在 `WR.Next` 中被真正拉起并完成注入
4. 只补这段最小初始化差异，不扩散到 UI / 产品页 / 多进程

## 控制结论

**hold**

原因：

- 不支持把当前问题继续归咎为 auth / PID / UI
- 也还不支持直接断言某单个 DLL 替换即可修复
- 当前最靠谱的推进方式，是围绕“原版 pre-hook 初始化链”做最小等价补齐

## 新增探针结论（2026-07-01 03:48）

### 1. 原始 `authManager` 按钮本体已被真实点击

这次不是点击覆盖层，也不是点击我们自定义按钮。

日志：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-ui-host-actions.txt`

已明确出现：

- `auth-chain launch-button preview-mousedown ... preserveOriginal=True`
- `auth-chain launch-button routed-click ... preserveOriginal=True`
- `auth-chain launch-button click ... preserveOriginal=True`

这说明当前结论已经可以写硬：

> 原始 `authManager.LoginUserControl.buttonLaunchBot` 的本体事件链已经真实被触发。

### 2. 但该事件链没有把当前宿主推进到 Hook / 产品链

同一轮运行下：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\product-chain-actions.txt`

没有生成任何新内容。

这说明：

- 点击原始 `buttonLaunchBot` 后
- 当前 `WR.Next` 探针宿主并没有自然流入我们现有的 attach / hook / product pulse 记录链

因此可以再写硬一条：

> 当前问题已经不再是“是否点到了原始 auth 按钮”，而是“即使点到了原始 auth 按钮，本宿主上下文里仍没有接上后续执行链”。

### 3. 当前最稳的解释

到这一步，最稳的解释已经从“按钮事件被替换掉了”收缩为：

1. 原始 `authManager` 按钮事件只是入口，不等于完整接管结果
2. 真正把原版推进到 `Hooking success` 的副作用，还依赖：
   - `LoginServer / Remote / 宿主上下文`
   - 或原版 `WRobot.exe` 的进一步入口状态
   - 或按钮事件之后的一段异步/远程/宿主协同链
3. `WR.Next` 当前虽然放通了原始按钮事件，但没有复现这段后续上下文

### 4. 控制面判断

- 不支持回到“只是覆盖按钮没点对”
- 不支持直接把问题缩成“authManager UI 一颗按钮”
- 支持把主线继续压到：
  - `authManager.LoginServer`
  - `authManager.Remote`
  - `WRobot.Launching / LaunchBot`
  - 以及按钮后续异步链

### 5. 下一刀

下一刀不再折返 UI 点击层，改为追：

1. 原始 `buttonLaunchBot` 事件后调用了谁
2. `LoginServer` / `Remote` 是否在按钮后参与宿主接管
3. 哪个调用最终把原版推进到：
   - `D3D9 used`
   - `HWBP hook`
   - `Hooking success`

## 新增探针结论（2026-07-01 04:00，已复核）

### 1. 原始 `buttonLaunchBot` 处理器已经被直接反射调用

当前探针已不再依赖人工点击，而是直接获取 `buttonLaunchBot` 的原始委托并调用。

日志：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-ui-host-actions.txt`

明确出现：

- `auth-auto-invoke begin method=... target=authManager.LoginUserControl`

这说明：

> 原始 `authManager.LoginUserControl` 上挂载的按钮处理器，已经被我们真实执行到了。

### 2. 该原始处理器会自然返回

复核最新日志后，已经出现：

- `auth-binding auto-invoke-after ...`
- `auth-auto-invoke end`

因此前一版“原始处理器没有自然返回”的判断作废，当前可写硬：

> 原始 `buttonLaunchBot` 处理器可以完成返回；它不是卡死点。

### 3. 原始处理器的真实副作用：推进 `LoginServer` 状态

调用前，`LoginServer` 仍处在加载初始态：

- `LoginServer...=30`
- `LoginServer...=0`
- `LoginServer...=""`
- `LoginServer...="-1"`
- `LoginServer...=null`

调用后，`LoginServer` 状态已明显变化：

- `LoginServer...=120`
- `LoginServer...=1782850609`
- `LoginServer...=True`
- `LoginServer...="trial"`
- `LoginServer...="1"`
- `LoginServer...="WRotation"`
- `LoginServer...=""`

这说明：

> 原始 `buttonLaunchBot` 第一跳确实不是空转，它把 `LoginServer` 推进到了 trial / WRotation / 进程选择相关状态。

### 4. 但 `Remote` 仍未激活，Hook / 产品链仍未接上

同一轮 `auto-invoke-after` 中仍然可见：

- `Remote.RemoteActive=False`
- `Remote._000F=null`

并且：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\product-chain-actions.txt`

只出现：

- `snapshot-refresh-request forceHookPulse=False session=null`
- `session-refresh-lite forceHookPulse=False session=null`

这说明：

> 原始按钮处理器已经推进 `LoginServer`，但没有创建/激活 `Remote`，也没有把当前宿主接入 attach / hook / product pulse 链。

### 5. 当前最稳的真相

当前最稳的解释已经更新为：

1. 原始 `buttonLaunchBot` 不是“直接启动 Hook”的单步入口
2. 它会推进 `LoginServer` 状态到 `trial / WRotation / selected process` 相关上下文
3. 但它不会在当前 `WR.Next` 宿主中自然激活 `Remote`
4. 因而当前缺口已经压缩为：
   - `LoginServer` 状态成立之后，谁负责创建/激活 `Remote`
   - `Remote` 激活之后，谁负责接到 `WRobot.Launching / wManager.Information.LaunchBot / Hook`

### 6. 控制面判断

- 不支持再把问题归咎为“没点到原始按钮”
- 不支持再把问题缩成“按钮事件没触发”
- 支持把主线继续压到：
  - `LoginServer -> Remote` 的接力点
  - `Remote -> WRobot.Launching / LaunchBot` 的接力点
  - `LaunchBot -> Hook` 的最小初始化链

## 本阶段收口结论（2026-07-01）

当前阶段已经找到足够硬的阶段真相：

> `WR.Next` 不是卡在 PID、按钮点击、页面入口或 `authManager` 第一跳。原始 `authManager.LoginUserControl.buttonLaunchBot` 处理器可执行并可返回，且会推进 `LoginServer` 状态；真正断点在 `LoginServer` 已有 trial/WRotation/进程上下文后，没有继续激活 `Remote`，因此没有进入 `LaunchBot / Hook / product` 执行链。

下一阶段不再继续打 UI 点击探针，直接追：

1. `LoginServer` 哪个方法负责创建 `Remote`
2. 原版 `WRobot.exe` 是否在 `LoginServer` 状态成立后补了一步 `new Remote(...)`
3. `IRemote` 实现类来自哪里
4. `Remote` 激活后是否才进入 `WRobot.Launching / wManager.Information.LaunchBot`

控制建议：

**hold auth UI probing; move to LoginServer -> Remote bridge.**

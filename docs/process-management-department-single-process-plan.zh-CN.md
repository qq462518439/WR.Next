# WR.Next 进程管理部门施工文档（单进程优先版）

## 结论

当前不做多进程页面扩建，不做页面大改，不做产品面大铺路。  
进程管理部门当前只服务一个目标：

> 先把单进程接管链稳定跑通，并让后续产品链建立在这个单进程会话上。

这份文档是进程管理部门的施工章程，后续所有进程接管相关改动都以此为准。

---

## 一、部门定位

进程管理部门是 `WR.Next` 的最上游部门，负责：

1. 发现可接管的 WoW 进程
2. 确认当前唯一控制进程
3. 建立单进程接管会话
4. 维持旧进程复用
5. 为下游产品部门提供稳定 session
6. 在会话失效时给出明确错误，而不是隐式乱重连

一句话定义：

> 进程管理部门负责“接上并稳住”，不负责“代替产品做事”。

---

## 二、当前范围

当前范围严格限定为：

- 单进程接管
- 单进程状态刷新
- 单进程 attach/hook/snapshot 稳定
- 为产品部门提供唯一 session

当前明确不做：

- 多进程同时控制
- 多进程动作广播
- 多进程复杂界面
- 主页面大改
- 产品页面重构

---

## 三、部门职责边界

### 负责

- 真实 WoW 进程识别
- 候选进程列表维护
- 当前控制 PID 选择
- attach 建立
- hook 就绪确认
- 基础角色快照读取
- 会话健康状态维护
- 会话失效标记

### 不负责

- 选择产品
- 启动产品逻辑细节
- 停止产品逻辑细节
- 页面导航
- 原版设置页分发
- 插件、工具、聊天等非上游模块

---

## 四、单进程模式定义

单进程模式指：

- 任意时刻只承认一个 `CurrentProcessId`
- 任意时刻只承认一个 `CurrentSession`
- 所有下游产品动作都只消费这个 session
- 如果存在多个 WoW 进程，当前阶段只允许“选一个控制，其他只观察或忽略”

单进程模式不是：

- 只允许系统里存在一个 WoW.exe
- 发现多个进程就失去能力

而是：

> 当前版本只建立一个权威控制会话。

### 当前实现口径

- 当前代码采用单 `RuntimeSession` 权威模型
- 暂不引入独立 `RuntimeSessionRegistry`
- 所有 attach / refresh / detach 都围绕当前唯一 session 进行
- 后续若扩展多进程管理，再把 registry 作为阶段 2+ 的结构升级项

---

## 五、进程管理主链

进程管理部门主链固定为：

`扫描 -> 识别 -> 选择 -> attach -> hook ready -> 快照稳定 -> 会话复用`

逐步解释如下：

### 1. 扫描

作用：

- 周期性发现运行中的候选进程

要求：

- 扫描必须轻量
- 不允许把扫描写成重 attach
- 不允许扫描时直接做产品前置

### 2. 识别

作用：

- 从候选中筛出真实 WoW 进程

要求：

- 必须校验进程身份
- 必须过滤启动器、异常残留、无效壳进程

### 3. 选择

作用：

- 由宿主明确选定当前控制 PID

要求：

- 当前阶段只能有一个控制 PID
- 选择动作必须显式
- 不允许自动接单个 WoW 进程

### 4. attach

作用：

- 建立当前 PID 的运行时接管会话

要求：

- attach 只能由显式接管动作触发
- attach 成功后要记录当前 session
- attach 失败必须明确报错

### 5. hook ready

作用：

- 让会话从“只看到进程”进入“具备执行权威”

要求：

- 必须有 hook 就绪证据
- 没有 hook ready 时，不得把会话判定为可执行

### 6. 快照稳定

作用：

- 读取角色基础状态，证明会话已进入可用态

要求：

- 角色名、等级、血量、坐标可读
- 不允许靠重复 attach 才偶发读出来

### 7. 会话复用

作用：

- 让单进程控制链持续稳定

要求：

- 普通刷新不重新 attach
- 普通按钮不重新 hook
- 同一 PID 未失效前必须复用既有 session

---

## 六、部门输入输出

### 输入

- 操作系统进程列表
- 用户当前勾选的 PID
- 来自运行时的 memory/hook/snapshot 结果

### 输出

- `CurrentProcessId`
- `CurrentSession`
- 基础角色快照
- 接管健康状态
- 明确错误信息

下游消费方：

- 产品部门
- 宿主编排层
- 游戏信息页

---

## 七、内部状态模型

当前阶段最少需要以下状态模型。

### 1. ProcessCandidate

字段最少包括：

- `ProcessId`
- `ProcessName`
- `MainWindowTitle`
- `ExecutablePath`
- `CommandLine`
- `IdentityOk`
- `LastSeenUtc`

### 2. RuntimeSession

字段最少包括：

- `ProcessId`
- `IsSelected`
- `IsAttached`
- `MemoryOpen`
- `HookReady`
- `InGame`
- `CharacterName`
- `Level`
- `HealthPercent`
- `Position`
- `RuntimeState`
- `LastError`
- `LastHeartbeatUtc`

### 3. SessionHealthState

取值最少包括：

- `NotSelected`
- `Selected`
- `Attaching`
- `Attached`
- `HookPending`
- `Ready`
- `Faulted`
- `Lost`

---

## 八、硬指标

当前阶段必须满足以下硬指标。

### 指标 1：真实进程识别

要求：

- 只展示真实 WoW 进程
- 候选 PID 不得混入无关进程

验证方式：

- 对候选进程记录：
  - `ExecutablePath`
  - `CommandLine`
  - `ProcessName`

通过线：

- 候选列表中不再出现明显错误进程

---

### 指标 2：唯一控制 PID

要求：

- 当前阶段始终只有一个 `CurrentProcessId`
- 当前控制 PID 必须与 UI 选择一致

验证方式：

- 日志记录当前选中 PID
- session 记录当前绑定 PID

通过线：

- 不出现“UI 选 A，runtime 实际控制 B”

---

### 指标 3：attach 显式触发

要求：

- 只有显式接管动作才允许触发 attach

验证方式：

- attach 日志只在勾选接管或明确重接动作时出现

通过线：

- 普通刷新、切页、普通按钮不触发 attach

---

### 指标 4：旧进程复用成立

要求：

- 同一个 PID 未失效前，复用既有 session

验证方式：

- 连续刷新过程中 attach 次数不增长
- 切页前后 session 保持同一 PID
- `shell-navigation-actions.txt` 与 `product-chain-actions.txt` 对照时，不应出现“切页后紧跟新的 `session-attach-request`”
- 普通按钮触发后可出现 `action-gate ... precheck` 与 `session-refresh-lite`；若无显式重接动作，不应出现新的 `session-refresh-force`

通过线：

- `refresh -> no reattach`
- `page switch -> no reattach`
- 日志中可区分：
  - `session-attach-request`
  - `session-refresh-force`
  - `session-refresh-lite`
  - `snapshot-refresh-request`

---

### 指标 5：内存有效

要求：

- `Memory.Open(processId)=true`
- `memory.IsValidAndOpenProcess()=true`

验证方式：

- 记录 attach 结果
- 记录 memory 句柄状态

通过线：

- 单进程接管成功后，句柄长期保持有效

---

### 指标 6：Hook 就绪

要求：

- `threadHooked=True`
- `RetnToHookCode` 非空
- detour 状态有证据

验证方式：

- 记录 hook 快照
- 记录 hook pulse 前后状态

通过线：

- 单进程接管成功后，hook 状态可稳定复用

---

### 指标 7：快照稳定

要求：

- 游戏中状态可读
- 角色基础信息稳定可回读

验证方式：

- 连续多次刷新输出：
  - 角色名
  - 等级
  - 血量
  - 坐标

通过线：

- 基础快照不再忽有忽无

---

### 指标 8：错误可定位

要求：

- 失败时必须区分：
  - 识别失败
  - attach 失败
  - 内存失败
  - hook 失败
  - snapshot 失败

验证方式：

- 统一错误文本
- 统一日志分类

通过线：

- 不再出现只有“没反应”或“卡住”却无阶段定位

---

## 九、禁止线

进程管理部门当前明确禁止以下行为：

1. 自动接单个 WoW 进程
2. 普通刷新隐式重新 attach
3. 普通按钮隐式重新 hook
4. 页面切换偷偷重建 session
5. 产品层反向决定当前控制 PID
6. 用答题窗、登录窗是否通过来判定产品链是否可用

---

## 十、页面契约

当前不大改页面，因此页面契约必须尽量简单。

### 允许页面做的事

- 展示候选进程列表
- 展示当前控制状态
- 触发显式接管
- 触发显式刷新
- 展示基础角色快照

### 页面不允许做的事

- 自动改写当前控制 PID
- 自动触发 attach
- 自动触发产品启动
- 自动触发 hook 重建
- 在 `CurrentSession == null` 或 `IsAttached=False` 时继续维持页面级自动 retry

---

## 十一、与下游部门的默契

### 对产品部门

进程管理部门承诺：

- 给出唯一 `CurrentSession`
- 给出基础角色快照
- 给出 hook 是否 ready

产品部门必须承诺：

- 不重新扫进程
- 不重新 attach
- 不自行决定控制 PID

### 对宿主编排层

进程管理部门承诺：

- 当前控制 PID 唯一
- 会话状态清晰
- 错误分类明确

宿主编排层必须承诺：

- 所有进程相关命令先走进程管理部门
- 不绕过进程管理部门直接碰底层 runtime

---

## 十二、验证计划

当前阶段只做单进程验证，固定验证顺序如下：

1. 打开宿主
2. 扫描候选进程
3. 手动勾选一个真实 WoW PID
4. 建立接管会话
5. 验证 memory 有效
6. 验证 hook ready
7. 连续刷新 3 次快照
8. 切到其他页再切回
9. 确认 session 未重建
10. 再把 session 交给下游产品部门

---

## 十三、阶段交付物

本部门当前阶段最终交付物固定为：

1. 单进程接管链稳定
2. 单进程 session 可复用
3. attach/hook/snapshot 日志分类清晰
4. 当前控制 PID 唯一且可信
5. 可供下游产品部门直接消费的 `CurrentSession`

---

## 十四、启动前健康检查

进程管理部门在宿主启动后、允许进入正式接管前，必须先完成一次健康检查。

### 检查目标

确认当前运行环境具备建立单进程接管会话的最低条件，避免把环境脏状态误判为接管链故障。

### 必查项

1. runtime root 正确
   - 当前运行根目录可定位
   - `Bin / Logs / Products / Settings / Profiles` 路径可解析

2. 关键依赖在位
   - `WRobot.exe`
   - `RDManaged.dll`
   - `fasmdll_managed.dll`
   - `authManager.dll`
   - `robotManager.dll`
   - `wManager.dll`

3. 运行目录可写
   - `Logs` 可写
   - 必要配置目录可写

4. 宿主单实例状态明确
   - 若存在旧宿主残留实例，必须先识别并阻断本次启动
   - 禁止在“旧实例未明确退出”的情况下默默顶掉状态

5. 当前 session 初始状态干净
   - 启动时不应继承脏的 `CurrentProcessId`
   - 启动时不应继承失效 session

### 通过线

- 关键依赖全在位
- 路径与日志目录可用
- 宿主初始状态干净
- `HostPeerInstances=0`

### 禁止线

- 缺关键 DLL 仍继续进入接管流程
- 日志目录不可写仍继续进入正式施工
- 未确认旧实例状态就开始新接管

---

## 十五、退出与清理约定

进程管理部门必须有明确的退出清理动作，避免下次启动吃到脏状态。

### 必做清理项

1. 停止进程扫描与刷新
   - 停止定时器
   - 停止后台刷新任务

2. 停止当前 session 相关活动
   - 停止快照刷新
   - 结束当前会话心跳

3. 通知下游停止
   - 若产品仍在运行，先通知产品层停止
   - 若存在 movement/fight 残留，先执行安全停机动作

4. 清空当前控制状态
   - 清空 `CurrentProcessId`
   - 清空 `CurrentSession`
   - 标记 session closed

5. 写入关闭日志
   - 记录关闭时的 PID
   - 记录最后一次 health state
   - 记录是否为正常退出

### 通过线

- 宿主关闭后不再残留刷新动作
- 下次启动不继承旧会话脏状态

### 施工备注

- 当前构建入口不是解决方案文件，而是 `D:\666\work\WR.Next\src\WR.OriginalUiHost\WR.OriginalUiHost.csproj`
- 推荐发布/运行入口是仓库根目录的 `build-uihost.bat` 和 `run-uihost-latest.bat`
- 退出收口必须先走 `Shutdown -> Detach -> WPF Shutdown`，最后才允许硬退出兜底
- 如果旧宿主仍占用 `WR.OriginalUiHost.exe`，新构建会被锁文件阻塞，必须先释放旧实例再编译

### 禁止线

- 宿主关闭时仍保留活动定时器
- 宿主关闭后仍保留“看似有效”的旧控制 PID

---

## 十六、故障恢复策略

进程管理部门必须明确区分“自动维持”和“显式重接”。

### 自动维持允许范围

- 正常刷新快照
- 会话心跳更新
- 已建立 session 的轻量健康检查
- 已建立 attached session 的页面级轻量重试；未接管或接管失败时必须停止自动重试

### 不允许自动做的事

- 自动重 attach
- 自动重 hook
- 自动改绑到别的 PID

### 故障分类与恢复策略

1. 进程身份失效
   - 表现：PID 已退出或身份校验失败
   - 处理：标记 `Lost`
   - 恢复：只能显式重新选择新 PID

2. memory 失效
   - 表现：`Memory.Open` 失败或句柄无效
   - 处理：标记 `Faulted`
   - 恢复：允许用户显式重新接管当前 PID

3. hook 丢失
   - 表现：`threadHooked=False` 或 hook readiness 失效
   - 处理：标记 `HookPending` 或 `Faulted`
   - 恢复：只能由显式重接动作触发重建

4. 游戏不在世界中
   - 表现：`InGame=False`
   - 处理：session 保留，但标记为不可交给产品层
   - 恢复：进入世界后继续在同一 session 上刷新

5. 快照读取异常
   - 表现：角色信息连续不可读
   - 处理：保留当前 session，记录错误分类
   - 恢复：允许后续轻量刷新继续验证；不得直接重 attach

### 通过线

- 每类故障都有明确状态
- 恢复动作与普通刷新严格区分

### 禁止线

- 用自动补 attach 掩盖真实故障
- 用自动换 PID 掩盖当前 session 失效

---

## 十七、下游准入条件

进程管理部门不是只要“连上进程”就把 session 交给下游产品部门，必须设准入门槛。

### 交付给产品层前必须满足

1. `CurrentSession != null`
2. `CurrentProcessId > 0`
3. `IsAttached=True`
4. `MemoryOpen=True`
5. `HookReady=True`
6. `InGame=True`
7. 基础快照稳定可读
8. `SessionHealthState != Faulted`

### 不满足时的处理

- 不允许启动产品
- 必须给出明确阻断原因
- 必须把阻断原因落日志
- 产品启动前必须执行一次 session gate
- session gate 至少检查：
  - `CurrentSession != null`
  - `IsAttached=True`
  - `MemoryOpen=True`
  - `HookReady=True`
  - `InGame=True`
  - `SessionHealthState` 不是 `Faulted/Lost`

### 通过线

- 产品启动前一定建立在可执行 session 上

### 禁止线

- `HookReady=False` 仍允许产品开始
- `InGame=False` 仍默认放行到产品执行链

---

## 十八、当前控制面建议

当前建议固定为：

> 单进程先跑通，再谈多进程。

当前第一目标不是做更多页面，也不是铺更多产品，而是：

> 把“选中一个 PID 后，稳定接上、稳定读状态、稳定复用”做成权威事实。

# WR.Next 总纲蓝图与阶段硬指标

## 结论

`WR.Next` 后续主线固定为：

1. 先建立自有进程会话权威
2. 再建立自有产品控制权威
3. 再把宿主编排与页面彻底分层
4. 最后把原版兼容层降权为内核服务

不再走 `Page First`，固定改为 `Session First`。

---

## 一、总目标

把 `WR.Next` 建成一个可长期维护、可验证、可扩展的自有宿主：

- 自有宿主负责会话、产品、编排
- 原版 DLL 仅提供运行时能力
- 旧进程可以稳定复用
- 产品可以真实开始/停止
- 页面不再承担运行时控制权威

一句话定义：

> 宿主管会话，产品跑在会话上，原版 DLL 只做能力提供者。

---

## 二、总架构

系统总架构固定拆成 4 层：

1. 会话层 `Session Layer`
2. 产品层 `Product Layer`
3. 宿主编排层 `Host Orchestration Layer`
4. 兼容适配层 `Compatibility Layer`

---

## 三、四层职责边界

### 1. 会话层

职责：

- 管理每个 WoW 进程的长期会话
- 负责进程识别、attach、memory、hook、snapshot
- 负责旧进程复用
- 负责掉线、回到角色选择、重新进世界后的状态迁移

核心对象：

- `RuntimeSession`
- `RuntimeSessionRegistry`
- `RuntimeSnapshot`

每个 `RuntimeSession` 至少包含：

- `ProcessId`
- `IdentityOk`
- `IsAttached`
- `MemoryOpen`
- `HookReady`
- `InGame`
- `CharacterSnapshot`
- `ProductState`
- `LastError`
- `LastHeartbeatUtc`

硬规则：

- 同一个 PID 只能有一个权威 session
- 普通按钮不得触发重新 attach
- 普通刷新不得隐式重新 hook
- session 未失效前必须优先复用

---

### 2. 产品层

职责：

- 定义统一产品契约
- 管理产品装载、开始、停止、状态回读
- 让产品运行基于 session，而不是基于页面

核心对象：

- `IProductController`
- `ProductDescriptor`
- `ProductRuntimeState`
- `WRotationController`

统一产品契约：

- `Load(session)`
- `Start(session)`
- `Stop(session)`
- `ReadState(session)`
- `OpenSettings()`

硬规则：

- 产品不得自行决定 attach 哪个进程
- 产品只能消费宿主传入的 session
- 产品 `Start/Stop` 必须可重复调用、可判定结果
- 产品链不得依赖页面是否打开

---

### 3. 宿主编排层

职责：

- 连接 UI 与 session/product
- 管理当前控制进程、当前产品、当前页面
- 统一落日志、提示错误、驱动状态同步

核心对象：

- `HostCoordinator`
- `CurrentControlContext`

`CurrentControlContext` 至少包含：

- `CurrentProcessId`
- `CurrentSession`
- `CurrentProduct`
- `CurrentPage`
- `LastActionResult`

硬规则：

- UI 不直接碰 hook、memory、assembly load
- 所有动作先经过 coordinator
- coordinator 是唯一流程编排入口

---

### 4. 兼容适配层

职责：

- 承接原版 DLL、原版控件、原版资源
- 隔离旧登录、订阅、旧入口副作用
- 保持可借用，但不再授予控制权

涉及组件：

- `authManager.dll`
- `wManager.dll`
- `robotManager.dll`
- `WRobot.exe`
- 原版页面 host / adapter

硬规则：

- 兼容层保留，但不授予主链控制权
- 原版控件只允许承担展示、参考、局部能力借用
- 不允许原版页面直接决定新宿主主链

---

## 四、总主链定义

### A. 进程接管主链

`扫描进程 -> 识别进程 -> 建立/复用 session -> 打开内存 -> hook 就绪 -> 快照稳定`

### B. 产品控制主链

`选择产品 -> Load -> Start -> Stop -> 状态回读`

### C. 页面驱动主链

`显示状态 -> 发命令 -> 回读结果`

---

## 五、阶段规划

后续工作固定分为 4 个阶段，不再跳级施工。

---

## 阶段 1：会话层立住

### 目标

建立自有进程会话权威，完成旧进程复用，切断“按钮即重新 attach/hook”的错语义。

### 必做项

- 从单 `_attachedProcessId` 过渡到 `RuntimeSession`
- 建立 `RuntimeSessionRegistry`
- 每个 PID 拥有独立 session 状态
- 进程识别采用严格过滤
- attach 成功后复用既有 session
- session 失效时只标记当前 session 异常，不自动乱接其它进程
- 快照刷新与 attach/hook 初始化解耦

### 硬指标

1. 进程识别正确
   - 只识别真实 WoW 进程
   - 不能把启动器或无关进程纳入候选

2. session 建立成功
   - 选中一个 PID 后，只建立一个权威 session
   - `CurrentSession.ProcessId` 必须与 UI 选择一致

3. 旧进程复用成立
   - 同一个 PID 未失效前，普通刷新不得重新 attach
   - 同一个 PID 未失效前，普通操作不得重新 hook

4. 内存有效
   - `Memory.Open(processId)=true`
   - `memory.IsValidAndOpenProcess()=true`

5. Hook 就绪
   - `threadHooked=True`
   - `RetnToHookCode` 非空
   - detour 状态存在有效证据

6. 快照稳定
   - `inGame=True` 时角色名、等级、血量、坐标可读
   - 不依赖重复 attach 才能读出

### 通过线

- 单个 PID 可稳定接管
- 同一个 PID 可跨刷新复用
- 切页不触发重 attach
- 刷新不触发重 hook
- 会话失效时错误明确可见

### 禁止线

- 不允许继续自动接单个 WoW 进程
- 不允许按钮动作隐式改写当前控制 PID
- 不允许切到某页就偷偷重建接管会话

### 交付物

- `RuntimeSession`
- `RuntimeSessionRegistry`
- 会话状态日志
- 接管健康状态输出

---

## 阶段 2：产品层立住

### 目标

让产品控制建立在 session 上，先打通 `WRotation` 的真实 `Load/Start/Stop/ReadState`。

### 必做项

- 抽出 `IProductController`
- 实装 `WRotationController`
- 把现有 `LoadWRotationProductStepwise()` 纳入产品控制器
- 产品开始/停止只基于当前 session 运作
- 产品状态与 session 状态关联
- 产品启动前置项显式化

### 硬指标

1. 产品装载成功
   - `Assembly.LoadFrom(WRotation.dll)` 成功
   - `CreateInstance("Main")` 成功
   - `Initialize()` 成功

2. 产品开始成功
   - `ProductStart()` 返回成功
   - `Products.IsStarted=True`
   - 后台进入真实执行态

3. 产品停止成功
   - `ProductStop()` 返回成功或等价停机证据成立
   - 后台循环停止
   - 停止后不再刷旧日志

4. 产品状态可回读
   - 可区分 `NotLoaded / Loaded / Starting / Running / Stopping / Stopped / Failed`

5. 产品不重接会话
   - `Start/Stop` 不得重 attach 当前 PID
   - `Start/Stop` 不得默认重建 hook

### 通过线

- WRotation 能在同一 session 上真实开始/停止
- 停止后后台不再继续执行
- 产品状态可稳定回读

### 禁止线

- 不允许产品 `Start` 自行扫进程
- 不允许产品 `Stop` 只是改按钮态
- 不允许产品行为依赖页面先打开

### 交付物

- `IProductController`
- `WRotationController`
- 产品状态模型
- 开始/停止日志链

---

## 阶段 3：宿主编排层立住

### 目标

把 UI 从运行时重操作里解耦，让页面只负责展示与发命令。

### 必做项

- 建立 `HostCoordinator`
- 页面动作统一改走 coordinator
- 建立当前控制上下文
- 会话状态、产品状态、页面状态统一回读
- 错误提示改为单点汇总，不重复叠窗

### 硬指标

1. 页面不直接碰 runtime 内核
   - 页面代码中不直接做 hook / memory / product load

2. 切页不触发重初始化
   - 切到模式页不应重 attach
   - 切到游戏页不应重建 session

3. 动作统一入口成立
   - `开始/停止/刷新/切产品/开设置` 均先过 coordinator

4. UI 响应稳定
   - 不因普通点击冻结数秒
   - 不因单次失败反复弹模糊提示

### 通过线

- 页面成为薄层
- 切页不再带运行时副作用
- 错误位置明确，链路清晰

### 禁止线

- 不允许继续把页面事件直接写成 runtime 控制代码
- 不允许页面控件自己决定当前控制进程

### 交付物

- `HostCoordinator`
- `CurrentControlContext`
- 页面动作路由表
- 错误与提示统一入口

---

## 阶段 4：兼容层降权

### 目标

保留原版兼容能力，但让其从“控制入口”降为“能力提供者”。

### 必做项

- 继续保留 `authManager.dll` 作为兼容依赖
- 梳理原版页面仅保留必要承载
- 原版页面不再承担主产品控制入口
- 兼容 DLL 分成：
  - 宿主常驻引用
  - 动态产品引用
  - 游戏进程桥接引用

### 硬指标

1. 兼容边界清晰
   - 明确哪些 DLL 必留
   - 明确哪些页面仅展示
   - 明确哪些逻辑不可再走原版入口

2. 兼容层不再主导产品链
   - 产品主链完全走自有宿主

3. 原版页面可留可收
   - 即使不打开某个原版页，产品主链仍能正常运行

### 通过线

- 原版 DLL 留作兼容件
- 自有主链具备独立运行能力
- 兼容层不再是故障中心

### 禁止线

- 不允许再把旧登录/订阅页当成产品可用性的判断标准
- 不允许原版页反向控制宿主主链

### 交付物

- 兼容依赖清单
- 原版控件降权清单
- 兼容层边界文档

---

## 六、全局验证指标

无论推进到哪个阶段，统一看以下 8 项总指标：

1. 当前控制 PID 是否唯一且正确
2. 当前 session 是否被稳定复用
3. 内存句柄是否有效
4. hook 是否就绪
5. 快照是否稳定可读
6. 产品是否真实开始
7. 产品是否真实停止
8. 页面动作是否只是驱动，而非直接承担运行时控制

---

## 七、当前控制面建议

当前固定建议：

> 先做阶段 1，再做阶段 2，不再回到 Page First。

当前默认主线：

1. 会话层
2. WRotation 产品层
3. 宿主编排层
4. 兼容层降权

---

## 八、当前阶段结论

截至本文档落地时，项目当前最上游问题仍是：

> 进程接管会话权威尚未完全立住。

因此当前第一施工目标固定为：

> 建立可复用、可验证、不可隐式重连的 `RuntimeSession` 主链。


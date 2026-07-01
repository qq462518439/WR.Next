# 进程管理阶段收官结论

## 结论

本阶段进程管理可以收官。

当前主线已经从 auth/UI 探针状态收回到自有进程管理页：

- 默认首页固定为自有 `ProcessManagementControl`
- 不再由 `WR_AUTH_CHAIN_PROBE` 切回原始登录页
- `WR_AUTH_AUTO_INVOKE` 已被额外实验开关 `WR_ALLOW_AUTH_EXPERIMENTS=1` 隔离
- 正常启动不再生成 `original-ui-host-actions.txt`

当前进程管理的阶段职责不是证明 Hook 成功，而是稳定完成：

1. 扫描真实 Wow 进程
2. 显式接管单个 PID
3. 维护唯一 `CurrentSession`
4. 周期刷新会话快照
5. 明确报告 `memory / hook / inGame / health`
6. 断开时清理本地 session

## 当前验收证据

运行目录：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout`

本轮正常启动未设置任何 `WR_AUTH_*` 实验环境变量。

启动健康检查：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\original-ui-host-startup.txt`

关键证据：

- `HealthCheck 启动健康检查通过`
- `HostPeerInstances=0`
- `WRobot.exe exists=True`
- `RDManaged.dll exists=True`
- `fasmdll_managed.dll exists=True`
- `authManager.dll exists=True`
- `robotManager.dll exists=True`
- `wManager.dll exists=True`

页面入口：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\shell-navigation-actions.txt`

关键证据：

- `selected-page from=null to=_0002 title=Select game process`

进程管理日志：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\logs\process-management-host-actions.txt`

关键证据：

- `refresh-candidates count=1`
- `attach-button-click pid=1724 attached=False`
- `refresh-attached pid=1724`
- `refresh-session pid=1724 attached=True initialized=False memory=True hook=False inGame=False health=HookPending ... state="未进入游戏" error=null`

这说明：

> 进程管理已经稳定识别并接管唯一 WoW PID，读取链成立，Hook 未就绪被如实报告为 `HookPending`。

## 本阶段硬边界

进程管理阶段不再承诺：

- Hook ready
- 产品启动成功
- WRotation 战斗链跑通
- 原版 auth UI 链接管

这些已经明确进入下一阶段：

> `LoginServer -> Remote -> LaunchBot -> Hook`

## 收官判断

当前版本满足进程管理阶段的可验收标准：

- 主线入口正确
- 单进程扫描正确
- 接管按钮可用
- 会话状态可读
- Hook 未就绪不再被伪装为成功
- 日志足以复核当前 session
- auth 探针不会污染正常启动

控制建议：

**hold process-management; move to Remote bridge.**

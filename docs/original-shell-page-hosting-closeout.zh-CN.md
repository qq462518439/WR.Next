# 原版主壳页面承载收口

## 结论

`WR.OriginalUiHost` 当前已经把原版主壳九页容器中的核心页面，逐页接成真实承载，而不是截图复刻或自造替代页。

当前默认落点已切回 `进程管理`，用于替代旧登录入口并承载首页主链。

这一步的完成含义是：

- 原版页面容器链已接上
- 原版控件实例化已验证
- 高风险交互按页做了最小收口

这一步**不等于**：

- takeover complete
- 全量行为已验证
- 所有高风险动作都已放开

## 当前页面状态

### 1. 模式选择 `_0004`

- 宿主：
  - [OriginalModeSelectionHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalModeSelectionHostControl.xaml.cs)
  - [OriginalModeSelectionTakeoverAdapter.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalModeSelectionTakeoverAdapter.cs)
- 当前状态：
  - 原版 `UserControlTabMain` 已承载
  - `WRotation.SettingsUserControl` 已稳定挂入
  - `WRotationSetting.Load()` 已补成上下文就绪后的确定性重载
- 验证：
  - [original-mode-selection-host-actions.txt](D:/666/RZB/Logs/original-mode-selection-host-actions.txt)
  - [original-mode-selection-actions.txt](D:/666/RZB/Logs/original-mode-selection-actions.txt)

### 2. 游戏中 `_0008`

- 宿主：
  - [OriginalInGameHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalInGameHostControl.xaml.cs)
- 当前状态：
  - 原版 `UserControlTabInGame` 已承载
  - 仅等待进程接管完成后实例化
- 验证：
  - [original-ingame-host-actions.txt](D:/666/RZB/Logs/original-ingame-host-actions.txt)

### 3. 通用设置 `_0006`

- 宿主：
  - [OriginalGeneralSettingsHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalGeneralSettingsHostControl.xaml.cs)
- 当前状态：
  - 原版 `UserControlTabGeneralSettings` 已承载
  - 未额外改写其设置读写逻辑
- 验证：
  - [original-general-settings-host-actions.txt](D:/666/RZB/Logs/original-general-settings-host-actions.txt)

### 4. 插件 `_000F`

- 宿主：
  - [OriginalPluginsHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalPluginsHostControl.xaml.cs)
- 当前状态：
  - 原版 `PluginsUserControl` 已承载
  - 插件“设置”按钮已隐藏
  - 输出目录已补齐 `Plugins` 运行时镜像
- 禁用原因：
  - `PluginsManager.SettingsPlugin(fileName)` 会进入插件自身 `Settings()` / 脚本 / 编译链
- 验证：
  - [original-plugins-host-actions.txt](D:/666/RZB/Logs/original-plugins-host-actions.txt)

### 5. 日志 `_0005`

- 宿主：
  - [OriginalLoggingHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalLoggingHostControl.xaml.cs)
- 当前状态：
  - 原版 `LoggingUserControl` 已承载
  - 错误日志远程发送已关闭
- 禁用原因：
  - 原版有 `UploadString(...)` 外发错误日志链
- 验证：
  - [original-logging-host-actions.txt](D:/666/RZB/Logs/original-logging-host-actions.txt)

### 6. 聊天 `_0003`

- 宿主：
  - [OriginalChatHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalChatHostControl.xaml.cs)
- 当前状态：
  - 原版 `ChatUserControler` 已承载
  - 保留聊天查看链
  - 发送输入链已禁用
- 禁用内容：
  - 发送文本框
  - 频道/类型选择
  - 发送按钮
- 禁用原因：
  - 原版按回车会直接 `Chat.SendChatMessage*`
- 验证：
  - [original-chat-host-actions.txt](D:/666/RZB/Logs/original-chat-host-actions.txt)

### 7. 工具 `_000E`

- 宿主：
  - [OriginalToolsHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalToolsHostControl.xaml.cs)
- 当前状态：
  - 原版 `UserControlTabTools` 已承载
  - 高风险动作按钮已整体隐藏
- 禁用原因：
  - 涉及黑名单改写、强制回城、清黑名单、下载内容、打开资源、再起 bot 等动作
- 验证：
  - [original-tools-host-actions.txt](D:/666/RZB/Logs/original-tools-host-actions.txt)

### 8. 地图 `_0002_2004`

- 宿主：
  - [OriginalMiniMapHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalMiniMapHostControl.xaml.cs)
- 当前状态：
  - 原版 `UserControlMiniMap` 已承载
  - 保留地图显示/刷新链
  - 当前已放开缩放链
  - 当前已补滚轮缩放转发到原版缩放滑杆
  - 当前已放开显示筛选开关
  - 点击与主动动作链仍禁用
- 禁用内容：
  - 地图点击/双击交互
  - 地图按钮链
  - 3D 雷达启停开关
  - 保存路径输入
- 禁用原因：
  - 涉及点击地图触发位置回调、导出路径、Radar3D 与显示状态切换
- 验证：
  - [original-minimap-host-actions.txt](D:/666/RZB/Logs/original-minimap-host-actions.txt)

## 当前未按原版接管的页

### 进程管理 `_0002`

当前仍是本地主程序接管页：

- [ProcessManagementControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/ProcessManagementControl.xaml.cs)

原因：

- 这里已经明确替代旧登录入口，不再回退到账号/订阅/远程验证页

## 当前控制面判断

当前分类应是：

`original shell page-hosting established`

不是：

- `takeover complete`
- `all page behaviors released`
- `full runtime parity proven`

## 下一步建议

不要再新增替代 UI，不要再扩页面数量。

后续只做两类工作：

1. 选一条页内主链，逐段放开低风险交互  
2. 对每条准备放开的交互，先给出：
   - 原版入口
   - 运行时依赖
   - 风险边界
   - 最小验证方式

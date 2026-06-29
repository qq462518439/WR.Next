# authManager Dependency Audit

## 结论

当前可以明确判断：

> `authManager.dll` 主要属于原版登录、订阅、脚本包装、插件解包与部分原版 UI 初始化依赖。

它不是当前已确认的战斗执行主链核心依赖。

因此应把它归类为：

- `ui-and-service-compat dependency`

而不是：

- `execution-core dependency`

## 已确认直接引用面

### 1. 原版宿主入口

以下原版宿主代码直接引用 `authManager`：

- `src/WR.OriginalWRobot/-.cs`
- `src/WR.OriginalWRobot/-/l1I11i1111Ii.cs`

已确认涉及：

- `RunCodeExtension`
- `LoginServer`
- `LoginUserControl`

这说明原版主窗口、登录态、在线检查与脚本包装链条会碰到 `authManager`。

### 2. 当前新宿主

当前新宿主直接引用 `authManager` 的位置：

- `src/WR.OriginalUiHost/WR.OriginalUiHost.csproj`
- `src/WR.OriginalUiHost/Adapters/OriginalLoginTakeoverAdapter.cs`
- `src/WR.OriginalUiHost/Views/Login/OriginalLoginHostControl.xaml.cs`

这说明当前新宿主仍保留了：

- 原版登录承接
- 原版登录控件接管
- 原版页面托管兼容

### 3. 原版 `wManager` 运行时

在反编译运行时中，以下位置直接引用 `authManager`：

- `wManager.Plugin/PluginsManager.cs`
- `wManager.Wow.Forms/ToolboxWindow.cs`
- `wManager.Wow.Forms/UserControlTabMain.cs`
- `wManager.Wow.Bot.States/NPCScanState.cs`
- `wManager.Wow.Helpers/CustomClass.cs`

这几类引用说明：

- 模式选择页不是纯展示页，它会触及订阅/更新/在线状态文本
- 插件管理与脚本执行包装链也会触及 `authManager`
- 自定义职业脚本装载中也含有 `LoginServer` 解密/包装逻辑

## 与执行主链的关系

当前已确认真正决定战斗执行权威的链条仍然是：

- `robotManager.MemoryClass.Hook`
- `wManager.Wow.Memory`
- `wManager.Pulsator`
- `TraceLine`
- `ClickToMove`
- `Lua`
- `Fight`
- `MovementManager`

这些链条的直接核心依赖仍指向：

- `robotManager.dll`
- `wManager.dll`
- `MemoryRobot.dll`
- `RDManaged.dll`
- `fasmdll_managed.dll`

当前没有证据表明：

> `authManager.dll` 本身就是 `ThreadHooked`、`InjectAndExecute`、`TraceLine`、`ClickToMove` 成立的直接前置。

但有证据表明：

> 原版模式页、插件页、脚本包装页、自定义职业加载链会碰到它。

## 风险判断

### 如果现在移除 `authManager.dll`

已知高风险后果：

1. 原版模式选择页会直接加载失败
2. 原版登录接管页会失效
3. 原版插件/脚本工具链可能失效
4. 自定义职业部分解密/装载链可能失效

### 如果后续逐步去掉 `authManager.dll`

必须满足以下前提：

1. 不再托管原版 `UserControlTabMain`
2. 不再依赖原版登录控件
3. 自己接管插件管理页面
4. 自己接管自定义职业装载与脚本工具页

## 当前策略

当前应采用：

- `保留 authManager.dll 作为原版 UI/服务兼容依赖`

不应采用：

- `现在就尝试从运行目录移除 authManager.dll`

## 下一步

后续拆除顺序建议固定为：

1. 先替掉原版登录页
2. 再替掉原版模式选择页
3. 再替掉插件/工具页
4. 最后审计 `CustomClass` 是否仍残留 `authManager` 依赖

## 一句话判断

当前 `authManager.dll` 不是执行内核发动机，
但它仍然是原版 UI/登录/插件/脚本包装层的兼容支撑件，现阶段不能硬拔。

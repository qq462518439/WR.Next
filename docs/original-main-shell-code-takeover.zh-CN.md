# 原版主 Shell 源码级接管记录

生成日期：2026-06-28

## 结论

后续不再按截图复刻主界面。

原版主 Shell 的源码级证据已经从 `work.zip` 恢复，接管路线改为：

> 以原版反编译代码为结构证据，逐段接管主 Shell 和九页容器。

不能直接把整个 `WRobot-ilspy` 当成可编译源码项目。

原因不是缺少 UI 资料，而是 ILSpy 输出保留了大量混淆结构，存在重复成员、非法成员名、协变返回等编译错误。

## 已恢复资料

恢复来源：

```text
D:\666\work.zip
```

恢复位置：

```text
D:\666\work\WR.Next\external\recovered\work\wrobot-ui-assets\WRobot-ilspy
```

受控副本：

```text
D:\666\work\WR.Next\src\WR.OriginalWRobot
```

## 主 Shell 类型

原版主 Shell：

```text
D:\666\work\WR.Next\src\WR.OriginalWRobot\-\lilll1Iiilli.cs
```

类型：

```csharp
public sealed class lilll1Iiilli : MetroWindow, IComponentConnector
```

关键字段：

```csharp
private NotifyIcon m__0002;
private readonly KeyboardHook m__0008;
private readonly KeyboardHook m__0006;
internal Label _0003;
internal Button _000E;
internal PackIconMaterial _0002_2004;
internal Button _0008_2004;
internal PackIconMaterial _0006_2004;
internal Label _000F_2004;
internal HamburgerMenu _0005_2004;
```

含义：

- `MetroWindow`：原版主窗口基座。
- `HamburgerMenu`：原版左侧导航/页面切换承载。
- `NotifyIcon`：托盘逻辑。
- `KeyboardHook`：快捷键/全局键盘钩子。

## 九页容器证据

原版页面容器 ViewModel：

```text
D:\666\work\WR.Next\src\WR.OriginalWRobot\-.cs
```

类型：

```csharp
public sealed class _0008_2009_2005 : INotifyPropertyChanged
```

关键字段：

```csharp
public UserControlTabMain _0002;
public UserControlTabInGame _0008;
public UserControlTabGeneralSettings _0006;
public PluginsUserControl _000F;
public LoggingUserControl _0005;
public ChatUserControler _0003;
public UserControlTabTools _000E;
public UserControlMiniMap _0002_2004;
```

对应页面：

| 字段 | 原版类型 | 页面 |
| --- | --- | --- |
| `_0002` | `UserControlTabMain` | 模式选择 / 首页 |
| `_0008` | `UserControlTabInGame` | 在游戏中 |
| `_0006` | `UserControlTabGeneralSettings` | 通用设置 |
| `_000F` | `PluginsUserControl` | 插件 |
| `_0005` | `LoggingUserControl` | 日志 |
| `_0003` | `ChatUserControler` | 聊天 |
| `_000E` | `UserControlTabTools` | 工具 |
| `_0002_2004` | `UserControlMiniMap` | 地图 |

## 编译试验结果

已尝试：

```powershell
dotnet build D:\666\work\WR.Next\src\WR.OriginalWRobot\WRobot.csproj
```

结果：

```text
失败
567 errors
```

主要错误类型：

- ILSpy 混淆输出重复成员：
  - `CS0111`
  - `CS0102`
- 成员名与封闭类型同名：
  - `CS0542`
- 目标运行时不支持协变返回：
  - `CS8830`
- 原始 `System.Windows.Forms` 引用缺失：
  - `CS0234`

判断：

- `WRobot-ilspy` 可以作为源码级结构证据。
- `WRobot-ilspy` 不能直接作为干净源码项目接管。
- 下一步应逐段抽取主 Shell 结构，而不是全量硬编。

## 复核结论

后续对 `D:\666\work\WR.Next\src\WR.OriginalWRobot\WRobot.csproj` 的复核已经确认：

- 旧根路径依赖已可参数化，不再是主要阻塞。
- 但 `WR.OriginalWRobot` 仍有大规模编译错误，错误集中在反编译输出本身的重复成员、非法成员名和类型冲突。

因此这里给出最终判断：

1. 它不适合进入当前主接管线。
2. 它应保留为历史样本和结构参考。
3. 不应再以“把它编过”作为当前阶段目标。

## 接管路线

### 第一段：主 Shell 骨架

在 `WR.OriginalUiHost` 中建立原版主 Shell 对应结构：

- `MetroWindow` 或等价 `Window` 宿主。
- 左侧 `HamburgerMenu`。
- 页面容器区。
- 原版图标资源来自 `rStyle.dll`。

但字段命名和页面顺序必须以 `lilll1Iiilli.cs` 和 `_0008_2009_2005` 为准。

### 第二段：九页容器

逐页接入：

1. `UserControlTabMain`
2. `UserControlTabInGame`
3. `UserControlTabGeneralSettings`
4. `PluginsUserControl`
5. `LoggingUserControl`
6. `ChatUserControler`
7. `UserControlTabTools`
8. `UserControlMiniMap`

每页先接原版布局结构，再替换账号/远程/订阅行为。

### 第三段：行为边界

必须隔离：

- 登录
- 订阅
- 远程验证
- 自动更新
- 外链

必须保留：

- 原版页面顺序
- 原版导航结构
- 原版控件字段语义
- 原版运行时 DLL 主链证据

## 当前下一步

在 `WR.OriginalUiHost` 中新增主 Shell 接管窗口/控件：

```text
OriginalMainShellWindow
OriginalMainShellViewModel
OriginalMainShellPageSlot
```

它们先不复刻视觉细节，而是按原版字段和页面顺序建立结构。

控制面建议：

```text
promote code-evidence takeover
do not compile whole WRobot-ilspy as-is
do not return to screenshot recreation
```

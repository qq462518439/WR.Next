# 原始代码驱动主壳接管阶段记录

结论：当前阶段已停止按截图复刻，改为按原始 WRobot 反编译代码中的主窗和页面容器证据重建新宿主主壳。该步骤只完成主壳结构接管，不宣称核心功能、寻路层、对象层或战斗层已接管。

## 已确认依据

- 原始主窗类型来自 `D:\666\work\WR.Next\src\WR.OriginalWRobot\-\lilll1Iiilli.cs`。
- 主窗基类为 `MetroWindow`，并持有 `HamburgerMenu` 字段 `_0005_2004`。
- 页面容器类型来自 `D:\666\work\WR.Next\src\WR.OriginalWRobot\-.cs` 中 `_0008_2009_2005`。
- 原始页面字段顺序已落到新宿主：
  - `_0002` => `UserControlTabMain`
  - `_0008` => `UserControlTabInGame`
  - `_0006` => `UserControlTabGeneralSettings`
  - `_000F` => `PluginsUserControl`
  - `_0005` => `LoggingUserControl`
  - `_0003` => `ChatUserControler`
  - `_000E` => `UserControlTabTools`
  - `_0002_2004` => `UserControlMiniMap`

## 本次代码落点

- `D:\666\work\WR.Next\src\WR.OriginalUiHost\MainWindow.xaml`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\MainWindow.xaml.cs`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\OriginalMainShellPage.cs`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\OriginalMainShellViewModel.cs`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\OriginalLoginHostControl.xaml`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\OriginalLoginHostControl.xaml.cs`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\OriginalShellPlaceholderControl.xaml`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\OriginalShellPlaceholderControl.xaml.cs`

## 当前边界

- 进程管理页仍暂时承载 `authManager.LoginUserControl`，但它已被隔离为 `OriginalLoginHostControl`，不再充当整个主窗。
- 其他页面目前是原始槽位占位，不冒充功能完成。
- 不恢复旧登录、订阅、远程验证 UX。
- 不把 `WRobot-ilspy` 当可直接编译源码树；它目前是结构与行为提取依据。

## 验证

命令：

```powershell
dotnet build D:\666\work\WR.Next\src\WR.OriginalUiHost\WR.OriginalUiHost.csproj
```

结果：

```text
0 warnings
0 errors
```

## 下一步

下一阶段应只选一个页面做真实接管。推荐先做 `游戏中` 页，因为它最能验证原版运行时能力是否能被新主程序稳定调用：角色名、等级、血量、目标、坐标、移动状态、战斗状态。若该页无法稳定从原版 DLL 读取真实状态，则 UI 继续细化没有意义。

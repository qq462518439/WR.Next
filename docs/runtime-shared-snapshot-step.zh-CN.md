# 运行时共享快照阶段记录

结论：新宿主已把原版 `wManager/ObjectManager` 读取链封装为共享运行时状态服务。首页和“游戏中”页复用同一个 `OriginalRuntimeBootstrap`，不再各自独立探测。

## 本轮代码落点

- `D:\666\work\WR.Next\src\WR.OriginalUiHost\OriginalRuntimeBootstrap.cs`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\ProcessManagementControl.xaml`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\ProcessManagementControl.xaml.cs`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\InGameStatusControl.xaml`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\InGameStatusControl.xaml.cs`
- `D:\666\work\WR.Next\src\WR.OriginalUiHost\MainWindow.xaml.cs`

## 当前运行链

首页勾选 Wow 进程后：

```text
AttachToWowProcess(pid)
  -> wManager.Wow.Memory.WowMemory.Memory.Open(pid)
  -> wManager.Wow.Memory.IsInGame(pid)
  -> wManager.Wow.Memory.PlayerName(pid)
  -> wManager.Wow.ObjectManager.Pulsator.Initialize(false)
  -> ObjectManager.Me.Name / Level / HealthPercent / Position
```

之后首页每 2 秒对已接管进程调用：

```text
RefreshAttachedProcess()
```

“游戏中”页也每 2 秒调用同一个共享 runtime 的：

```text
RefreshAttachedProcess()
```

## 当前可见状态

- 首页表格：
  - PID
  - 窗口
  - 角色
  - 等级
  - 血量
  - 坐标
  - 状态
- 游戏中页：
  - 角色
  - 等级
  - 血量
  - 状态
  - 坐标
  - 目标
  - 战斗状态
  - 移动状态
  - 动作状态
  - 详细 runtime 信息

## 本轮新增

`OriginalRuntimeSnapshot` 增加：

- `InCombat`
- `IsMoving`
- `IsMounted`
- `IsFlying`
- `IsSwimming`
- `IsCasting`
- `HasTarget`
- `TargetName`
- `TargetLevel`
- `TargetHealthPercent`

这些字段来自：

- `ObjectManager.Me.InCombat`
- `ObjectManager.Me.GetMove`
- `ObjectManager.Me.IsMounted`
- `ObjectManager.Me.IsFlying`
- `ObjectManager.Me.IsSwimming`
- `ObjectManager.Me.IsCast`
- `ObjectManager.Me.HasTarget`
- `ObjectManager.Me.TargetObject`

## 当前状态保护

如果 `wManager.Wow.Memory.IsInGame(pid)` 返回 `false`，运行时不再显示假 `Level=0 / HP=0 / Position=0`，而是返回 `未进入游戏`。本轮探针确认当前 Wow 状态曾出现：

```text
INGAME=False
PLAYER=Please connect to the game
LIST=0 DICT=0
ME_IsValid=False
```

这属于运行时状态未进入游戏，不是构建失败。

## 验证

构建：

```text
0 warnings
0 errors
```

启动：

```text
WR.OriginalUiHost
MainWindowTitle=WRobot
Responding=True
```

首页界面实测（2026-06-29）：

```text
进程管理
发现 1 个 Wow.exe，已按首页主链接管并刷新基础状态。

表格行：
- PID: 6336
- 窗口: 魔兽世界
- 角色: Look
- 等级: 71
- 血量: 100
- 坐标: 5917.041 ; 644.5936 ; 644.6663 ; "None"
- 状态: 游戏中
```

这一步证明的不是“日志里曾经成功”，而是首页 `ProcessGrid` 当前确实把共享 runtime 快照显示到了界面上。

## 边界

- 当前仍是读状态层，不是行为层。
- 线程模式 `Pulsator.Initialize(true)` 暂不启用。
- 目标、移动、战斗状态已接入读取层，但只有 `InGame=True` 且 ObjectManager 有效时才有实值。

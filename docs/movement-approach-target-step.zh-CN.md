# 目标跟近行为入口阶段记录

结论：本阶段已把原版移动层的最小可控入口接入新宿主，但尚未宣称完整移动闭环通过。

## 接入内容

新增运行时行为入口：

```text
OriginalRuntimeBootstrap.ApproachTargetOnce()
```

执行链：

```text
RefreshAttachedProcess()
  -> ObjectManager.Me.TargetObject
  -> target.GetDistance
  -> MovementManager.MoveTo(target)
```

新增停止入口：

```text
OriginalRuntimeBootstrap.StopMoveTo()
  -> MovementManager.StopMoveTo()
```

## UI 落点

`游戏中` 页新增：

- `跟近一次`
- `停止移动`

## 当前边界

- 该入口只负责调用原版 `MovementManager.MoveTo(WoWUnit)`。
- 是否实际移动，取决于原版 `MovementManager` 内部线程、ClickToMove、产品状态、游戏当前状态。
- 当前未启用完整产品主循环，也未启用 `Pulsator.Initialize(true)`。
- 不宣称战斗、寻路、自动靠近循环已完成。

## 用户实测反馈

`跟近一次` 无效果。

定位原因：`MovementManager.MoveTo(...)` 只是设置移动目标。实际执行线程依赖以下条件：

```text
Conditions.InGameAndConnectedAndProductStartedNotInPause
  -> Products.IsAliveProduct
  -> Products.IsStarted
  -> !Products.InPause
```

新宿主此前没有原版产品实例，因此 `Products.IsStarted=false`，移动线程不会执行。

## 本轮补充

已撤销本地产品垫片路线。严格改为原版产品链：

```text
Products.LoadProducts("WRotation")
Products.InPause = false
Products.ProductStart()
MovementManager.LaunchThreadMovementManager()
```

依据：

```text
D:\666\RZB\Products\WRotation.dll
Main : robotManager.Products.IProduct
```

`跟近一次` 现在会先确保产品条件为真，再调用：

```text
MovementManager.MoveTo(ObjectManager.Me.TargetObject)
```

返回信息会包含：

```text
productStarted=True
movementThread=launched
```

如果原版产品加载或启动失败，按钮会直接返回失败原因，不再用自造产品状态伪装通过。

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

## 下一步

在游戏处于 `InGame=True` 且选中有效目标时点击 `跟近一次`，观察：

- 是否返回有效目标名和距离
- `Me.GetMove` 是否变为 `True`
- 坐标是否变化
- 如果没有移动，继续抄 `MovementManager` 初始化线程和产品状态前置条件
- 如果仍没有移动，下一步直接抄 `ClickToMove.CGPlayer_C__ClickToMove(...)` 或继续补 `MovementManager` 内部 ClickToMove 前置条件

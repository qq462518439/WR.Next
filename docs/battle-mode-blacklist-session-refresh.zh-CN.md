# 战斗模式启动前置补链：黑名单会话刷新

## 结论

这次补的是战斗模式启动前的黑名单会话刷新，不是 UI。

原因很直接：

- 只把 `BlackListTrainingDummy` 从 `true` 改成 `false` 还不够
- 如果当前会话黑名单已经提前装载过，训练假人条目可能已经被灌进会话态

所以这次补的是：

- 在通用设置归一化之后，立即重建当前会话的黑名单状态

## 为什么必须补

原版 [BlackListSerializable.cs](D:\666\work\WR.Next\external\decompiled-runtime\wManager\wManager\BlackListSerializable.cs) 已确认：

- `AddBlackListToWRobotSession()`
  - 会先 `wManagerSetting.ClearBlacklist()`
  - 然后重新装载黑名单
  - 如果 `wManagerSetting.CurrentSetting.BlackListTrainingDummy == true`
    - 会把训练假人相关 NPC entry 批量加入黑名单会话

这意味着：

1. 训练假人设置是“装载时生效”的，不只是读取时看布尔值
2. 如果我们先前已经装载过一次黑名单会话，再单改设置值，并不会自动把旧会话里的训练假人黑名单拿掉

## 本次改动

文件：

- [OriginalRuntimeBootstrap.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Runtime\OriginalRuntimeBootstrap.cs)

在 `EnsureCombatPrerequisites()` 中，接在：

- `NormalizeBattleModeGeneralSettings()`

之后新增：

- `RefreshBattleModeBlacklistSession()`

执行内容：

1. 调用：
   - `BlackListSerializable.AddBlackListToWRobotSession()`
2. 写入动作日志：
   - `combat-prereq blacklist-session-refresh ok ...`

## 这一步的意义

这一步解决的是一个非常容易被忽略的状态漂移：

- 设置值已经改对
- 但当前会话黑名单还是旧的

现在战斗模式启动前置已经确保：

1. 归一化训练假人相关设置
2. 重新刷新当前会话黑名单

这样后续战斗模式在训练假人场景里的表现，才更接近我们真正想验证的链路。

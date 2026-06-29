# 战斗模式启动前置补链：WRotation 自身战斗开关归一化

## 结论

这次补的是 `WRotation` 自己的战斗开关，不是通用设置，不是 UI。

用户提醒得很对：

- 既然 `WRotation` 本身就有“攻击所有人”开关
- 那就不该把后续战斗链主判断卡死在“是不是训练假人”这种目标身份问题上

所以这次调整的重点是：

- 在战斗模式启动前，直接把 `WRotationSetting` 中影响开打条件的关键开关归一化

## 已确认的原版事实

从原版反编译代码已确认：

1. [WRotation\SettingsUserControl.cs](D:\666\work\WR.Next\external\decompiled-runtime\WRotation\WRotation\SettingsUserControl.cs)
   - 存在 `AttackAll` 开关
2. [FightHostileTarget.cs](D:\666\work\WR.Next\external\decompiled-runtime\wManager\wManager.Wow.Bot.States\FightHostileTarget.cs)
   - `NeedToRun` 中核心条件之一就是：
     - `AttackAll || Lua...`
3. [WRotation\-.cs](D:\666\work\WR.Next\external\decompiled-runtime\WRotation\-.cs)
   - `FightHostileTarget` 的 `AttackAll / ManageMovement / AttackOnlyIfFlaggedInCombat`
     都直接来自 `WRotationSetting.CurrentSetting`

也就是说：

- 如果 `AttackAll` 没开
- 或者 `AttackOnlyIfFlaggedInCombat` 卡得太严

那战斗模式很可能在“决定要不要开打”这一步就收住了。

## 本次改动

文件：

- [OriginalRuntimeBootstrap.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Runtime\OriginalRuntimeBootstrap.cs)

新增：

- `NormalizeBattleModeWRotationSettings()`

当前归一化规则：

1. `ManageMovement => true`
2. `AttackAll => true`
3. `AttackOnlyIfFlaggedInCombat => false`
4. `DisableCTM => false`

并且这些改动不是静态引用 `WRotation.dll` 完成的，而是：

- 通过当前已加载产品程序集反射读取 `WRotation.Bot.WRotationSetting.CurrentSetting`

这更符合当前宿主接管模式。

## 当前意义

这一步的作用不是“已经会打了”，而是把战斗模式的入口判断继续压向更宽、更接近人工直测预期的状态：

- 有目标
- 就更容易进入真实开打链

这样后面再查“为什么仍然不出技能/不出动作”时，范围会更干净。

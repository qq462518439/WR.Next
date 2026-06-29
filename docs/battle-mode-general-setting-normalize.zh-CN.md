# 战斗模式启动前置补链：General 设置归一化

## 结论

这次补的是战斗模式启动前的通用设置，不是 UI。

目的很直接：

- 避免原版通用设置里一些“正常挂机有意义、但实验战斗链会直接绊倒”的开关，提前把当前目标判死

## 已确认的问题

当前运行产物里的多个 `General-*.xml` 都存在这些默认项：

- `BlackListTrainingDummy=true`
- `BlackListIfNotCompletePath=true`
- `UsePathsFinder=true`

其中前两项对当前战斗模式调试尤其致命：

1. `BlackListTrainingDummy=true`
   - 训练假人类目标可能被原版黑名单逻辑直接排除
2. `BlackListIfNotCompletePath=true`
   - `Fight.StartFight()` 在 `PathFinder.FindPath(...)` 返回不完整时，会直接放弃目标

这会让“战斗模式已启动但人物没动作”的体感更糟，因为链条会过早自断。

## 本次改动

文件：

- [OriginalRuntimeBootstrap.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Runtime\OriginalRuntimeBootstrap.cs)

在 `EnsureCombatPrerequisites()` 中新增：

- `NormalizeBattleModeGeneralSettings()`

当前归一化规则：

1. `BlackListTrainingDummy`
   - `True => False`
2. `BlackListIfNotCompletePath`
   - `True => False`
3. `UseCTM`
   - 若为 `False`，则恢复为 `True`

并写入启动动作日志：

- `combat-prereq general-setting-normalize ...`

## 为什么这样补

这不是随意改设置，而是为了贴合当前阶段目标：

- 先把战斗模式主链压通
- 不让训练目标或一次不完整路径尝试，过早把战斗链短路

等后面进入更稳定的真实行为维护阶段，再区分：

- 正常挂机默认策略
- 调试/实验战斗主链策略

## 当前意义

这一步不代表战斗模式已经完全可用。

它只解决一个明确问题：

- 启动前不再保留会直接误伤当前实验战斗链的通用设置项

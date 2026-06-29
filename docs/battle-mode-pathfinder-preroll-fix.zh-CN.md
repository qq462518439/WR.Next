# 战斗模式启动前置补链：PathFinder 预热

## 结论

这次继续沿战斗模式主链补，不碰外壳。

新增的关键前置是：

- 在 `WRotation` 启动前，先执行本地 `PathFinder.InitPather(Usefuls.ContinentNameMpq)`

目的很明确：

- 不再等战斗线程第一次接近目标时，才临场初始化路径器
- 让 `Fight.StartFight()` 进入接近目标分支前，网格路径器已经处于就绪状态

## 为什么要补这一步

原版 `Fight.StartFight()` 里，只要目标超出近距离范围，就会直接进入：

- `PathFinder.FindPath(...)`

这不是附加功能，而是战斗模式主链的一部分。

而当前修复顺序已经确认：

1. `FightClass / CustomClass` 运行前置要补
2. `Bin` 编译依赖要补
3. `Data\Meshes / Minimaps` 资源基线要补
4. 现在顺势把 `PathFinder` 本地初始化时机也提前

这样更接近原版真实链路。

## 本次改动

文件：

- [OriginalRuntimeBootstrap.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Runtime\OriginalRuntimeBootstrap.cs)

在 `EnsureCombatPrerequisites()` 中，新增：

1. 读取 `Usefuls.ContinentNameMpq`
2. 若不为空：
   - `PathFinder.InitPather(continentNameMpq)`
3. 写入动作日志：
   - `combat-prereq pathfinder-init ok ...`
   - 或 `combat-prereq pathfinder-init failed ...`

## 当前意义

这一步不宣称战斗模式已经完全打通。

它解决的是更靠近根部的事实：

- 战斗线程需要用路径器时，不再是未初始化状态
- 现在战斗模式启动前置已经包括：
  - 设置装载
  - FightClass 恢复
  - Spell 缓存预热
  - PathFinder 初始化
  - CustomClass 载入

## 边界

后续如果人物仍然不动作，下一步就该继续查：

- 当前目标接近链返回结果
- 当前 FightClass 本体施法逻辑
- 以及具体运行日志中的战斗失败点

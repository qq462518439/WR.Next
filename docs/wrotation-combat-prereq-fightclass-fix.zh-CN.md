# WRotation 战斗前置补链：FightClass / Spell / CustomClass

## 结论

这次先补的不是 UI，也不是继续猜寻路，而是把 `WRotation` 开战前最关键的运行时前置补齐：

- 读取 `wManagerSetting`
- 恢复 `CustomClass` 选中项
- 预热法术缓存
- 调用原版 `CustomClass.LoadCustomClass()`

目的只有一个：

- 避免产品已经启动，但战斗层仍是“未选 FightClass / 未载入 CustomClass”的空壳状态

## 关键依据

已确认的原始证据有两条：

1. 旧日志明确出现：
   - `[FightClass] No Fight Class selected`
2. 原版 `WRotation` 的运行依赖 `CustomClass`
   - 距离判定、施法链、战斗线程都要用到它
   - 如果 `wManagerSetting.CurrentSetting.CustomClass` 为空，`CustomClass.LoadCustomClass()` 不会真正载入

所以“开始后人物没动作”的首要怀疑点，不是按钮，不是页面，而是：

- 战斗模式启动了
- 但 FightClass / CustomClass 没进运行态

## 本次改动

文件：

- [OriginalRuntimeBootstrap.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Runtime\OriginalRuntimeBootstrap.cs)

在 `EnsureOriginalProductStarted()` 进入 `Products.ProductStart()` 之前，新增统一前置：

1. `wManagerSetting.Load(loadBlacklist: false)`
2. 如果当前 `CustomClass` 为空或文件不存在：
   - 从 `FightClass` 目录挑一个可用项回填
3. 执行：
   - `SpellListManager.LoadSpellListe()`
   - `SpellManager.SpellBook()`
4. 若当前 `CustomClass` 还未在运行态加载：
   - `CustomClass.LoadCustomClass()`

同时把每一步写入：

- `logs/product-chain-actions.txt`

## 当前测试重点

这次你先不要看 UI 细枝末节，先只看三件事：

1. 点击开始后，日志里是否还出现：
   - `No Fight Class selected`
2. `product-chain-actions.txt` 里是否出现：
   - `combat-prereq fightclass-restore ...`
   - `combat-prereq customclass alive=True ...`
3. 人物是否开始出现真实战斗动作，而不只是进入攻击循环日志

## 这一步的边界

这次只补：

- 战斗启动前置缺口

这次还没有宣称：

- 已完全修好寻路
- 已完全修好目标接近
- 已完成整条战斗行为验证

下一步应该继续沿真实日志收窄：

- 若 `CustomClass` 已加载但仍不动作，再继续查施法失败或目标接近链

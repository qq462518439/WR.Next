# WRotation 能力层依赖图

## 结论

后续推进不再按页面拆，而按能力层拆。

`WRotation` 不是一个孤立产品，而是当前最适合压通主链的“能力层验证产品”。

## 五层主链

### 1. 对象层

负责：

- 玩家
- 当前目标
- 宠物
- 周围单位
- combat target 状态

当前对应原版核心：

- `ObjectManager`
- `WoWUnit`
- `Fight.CurrentTarget`

### 2. 状态层

负责：

- 是否在游戏中
- 是否死亡
- 是否在读条
- 是否坐骑
- 是否暂停
- 是否可开始战斗

当前对应原版核心：

- `Conditions`
- `wManagerSetting`
- `WRotationSetting`
- `Products.IsStarted / InPause`

### 3. 导航层

负责：

- `PathFinder`
- `MovementManager`
- `ClickToMove`
- `TraceLine`
- `Meshes / Minimaps / OffMeshConnections`

当前对应原版核心：

- `PathFinder`
- `Pather / PatherServer`
- `MovementManager`

### 4. 战斗脚本层

负责：

- `FightClass`
- `CustomClass`
- `WRotationSetting`
- 战斗行为逻辑选择

当前对应原版核心：

- `CustomClass.LoadCustomClass()`
- `FightHostileTarget`
- `WRotation.Bot.WRotationSetting`

### 5. 施法执行层

负责：

- spellbook
- spell id
- lua 调用
- 技能是否真正发出

当前对应原版核心：

- `SpellManager`
- `SpellListManager`
- `Lua`
- `CustomClass` 内部逻辑

## WRotation 为什么适合作为主验证产品

因为它会一次性吃到：

1. 对象层
2. 状态层
3. 导航层
4. 战斗脚本层
5. 施法执行层

换句话说：

- `WRotation` 一旦跑通，后面很多产品的底座也会一起变得更真

## 当前已经补过的层

### 已补前置

- `FightClass / CustomClass` 恢复
- `General` 设置归一化
- `WRotation` 战斗开关归一化
- 黑名单会话刷新
- spell cache 预热
- pathfinder 预热
- 配置主动持久化
- `Data\Meshes / Minimaps / temp`
- `Bin` 动态编译依赖

### 仍需继续下钻

当前最该继续收窄的是：

- `FightHostileTarget -> Fight.StartFight -> CustomClass 实际施法`

也就是：

- 已决定开打后
- 为什么还没有形成真实动作

## 后续推进规则

之后每次问题都先归层：

1. 属于对象层？
2. 属于状态层？
3. 属于导航层？
4. 属于战斗脚本层？
5. 属于施法执行层？

不要再先按页面归类。

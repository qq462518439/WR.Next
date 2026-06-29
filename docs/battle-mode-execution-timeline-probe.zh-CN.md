# Battle Mode 执行时间线探针

## 结论

这一包不再扩 UI，也不再补页面按钮，只给 `WRotation` 战斗执行层补一份结构化时间线证据。

目的只有一个：

> 在 `Fight.StartFight(...)` 已被调用的前提下，确认真实动作没有落地时，到底卡在对象、移动、战斗状态、战斗脚本还是施法簿。

## 为什么要补这一层

当前已知结论是：

1. `Products.LoadProducts("WRotation") -> ProductStart()` 已恢复
2. 宿主已经能手动调用 `Fight.StartFight(...)`
3. 但角色仍然可能没有形成真实移动/攻击动作

这说明问题已经不在：

- 进程识别
- 页面跳转
- 产品是否加载

而是在更靠后的执行层。

## 本次改动范围

文件：

- `src/WR.OriginalUiHost/Runtime/OriginalRuntimeBootstrap.cs`

仅新增以下能力：

1. `StartFightOnCurrentTarget()` 前后写入执行时间线
2. 记录战斗前后的结构化快照
3. 快照中补入：
   - `Products` 状态
   - 玩家移动/施法/目标状态
   - `Fight.InFight / Fight.CurrentTarget`
   - `CustomClass.IsAliveCustomClass / GetRange`
   - `SpellManager.SpellBook()` 计数
   - `ClickToMove` 状态

## 新增日志文件

运行时会写入：

```text
Logs/battle-execution-timeline.txt
```

关键阶段：

1. `startfight-enter`
2. `startfight-exit`
3. `startfight-exception`

## 这份日志要回答什么

后续我们主要看四类问题：

1. `Fight.StartFight` 返回后，`Fight.InFight` 是否真的进入
2. `Fight.CurrentTarget` 是否建立成功
3. `CustomClass` 是否真的活着，射程是否合理
4. `SpellBook` 是否真的可用，而不是前置虽跑过但执行时仍不成立

如果这些都成立，而角色还是不动作，下一层就更接近：

- `Lua`
- `SpellManager`
- `CustomClass` 内部 rotation 执行

## 当前结论

这包不解决战斗问题本身。

它解决的是：

> 下次再看“为什么不打”，我们终于不是靠猜，而是靠同一份结构化证据说话。

## 下一步

下一包只做一件事：

1. 读取 `battle-execution-timeline.txt`
2. 判断断点更接近：
   - `Fight` 状态未建立
   - 移动状态未落地
   - `CustomClass` 未真实参与
   - `SpellBook/Lua` 执行未落地

继续保持窄包，不扩到别的产品。

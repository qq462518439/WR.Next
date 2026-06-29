# WRotation 模式页设置链收口

## 结论

当前 `WR.OriginalUiHost` 中承载的原版 `UserControlTabMain -> WRotation.SettingsUserControl` 已经把页内真实设置加载链补成确定性：

- 模式页稳定选中 `WRotation`
- `WRotation.SettingsUserControl` 稳定挂载
- 角色/服务器上下文就绪后，会显式走一次原版 `WRotationSetting.Load()`
- 页内实际设置值已与磁盘配置 `Settings\WRotation-Look.香草魔兽.xml` 对齐

这一步属于“按原版链补时机”，不是重写设置页，也不是新造设置系统。

## 关键依据

### 1. 原版设置页已稳定承载

代码位置：

- [OriginalModeSelectionHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalModeSelectionHostControl.xaml.cs)
- [OriginalModeSelectionTakeoverAdapter.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/OriginalModeSelectionTakeoverAdapter.cs)

动作日志：

- [original-mode-selection-actions.txt](D:/666/RZB/Logs/original-mode-selection-actions.txt)

日志已确认：

- `selected=WRotation`
- `settingsType=WRotation.SettingsUserControl`
- `settingsHostChildType=WRotation.SettingsUserControl`

### 2. 之前的问题不是路径错，而是加载时机早

在 `attach/loaded` 阶段，日志显示：

- `me=`
- `realm=`
- `expectedFile=...\\WRotation-..xml`
- `exists=False`
- `attackAll=False`

说明当时角色上下文未就绪，`WRotationSetting.CurrentSetting` 还停留在默认对象。

### 3. 角色上下文就绪后，原版设置已被显式重载

新增补点：

- `ReloadWRotationSettingsIfReady(...)`

逻辑：

- 仅当当前页确实是 `WRotation.SettingsUserControl`
- 且 `ObjectManager.Me.Name` / `Usefuls.RealmName` 已可用
- 才通过反射调用原版 `WRotation.Bot.WRotationSetting.Load()`

对应日志：

- `retry-1 wrotation-load-invoke result=True me=Look realm=香草魔兽`

### 4. 页内真实值已与磁盘文件对齐

磁盘文件：

- [WRotation-Look.香草魔兽.xml](D:/666/work/WR.Next/src/WR.OriginalUiHost/bin/Debug/net48/Settings/WRotation-Look.香草魔兽.xml)

文件内容关键值：

- `ManageMovement=true`
- `AttackAll=true`
- `UseMiniMapClick=true`

重载后动作日志关键值：

- `expectedFile=...\\WRotation-Look.香草魔兽.xml exists=True`
- `manageMovement=True`
- `attackAll=True`
- `useMiniMapClick=True`

其中最关键的翻转是：

- 修正前：`attackAll=False`
- 修正后：`attackAll=True`

## 当前边界

这次只确认了：

- 原版模式页承载链
- 原版 `WRotation` 设置页挂载链
- 原版 `WRotationSetting` 读取角色配置文件的加载时机

这次没有声称：

- 已完成主程序接管
- 已完成其他产品页接管
- 已完成战斗/寻路/对象层验证
- 已完成全量行为验证

## 下一步

继续按同一原则推进：

1. 只挑一个原版页或一条原版链
2. 先确认它实际依赖的原版对象/配置/上下文
3. 只补时机和承载，不平替内部逻辑
4. 用日志或代码证据确认“挂上去的真是原版链”

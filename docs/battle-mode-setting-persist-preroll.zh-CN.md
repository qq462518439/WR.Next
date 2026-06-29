# 战斗模式启动前置补链：配置主动持久化

## 结论

这次补的是战斗模式启动前的配置落盘，不是 UI。

当前宿主在启动前已经会改动多类运行设置：

- `wManagerSetting`
- `FightClass` 选择
- `WRotationSetting`

如果这些修改只停留在内存里，后续线程或产品初始化再次读取配置文件时，就可能又回到旧状态。

所以这次新增的处理是：

- 在战斗模式启动前，把关键设置主动持久化一次

## 为什么要补

已确认过早期日志里出现过：

- `Serialize(String path, object @object)#3: Cannot write file.`

这说明原版启动链里，设置/状态写盘并不是一个可以忽略的小问题。

而当前项目又不是原版主程序直接跑全流程，而是：

- 宿主程序接管原版运行链

在这种模式下，如果不主动压住设置持久化，体感上就会出现：

- 这次启动改对了
- 下一段线程又按旧配置跑

## 本次改动

文件：

- [OriginalRuntimeBootstrap.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Runtime\OriginalRuntimeBootstrap.cs)

新增：

- `PersistBattleModeSettingsSnapshot()`

执行内容：

1. 保存 `wManagerSetting.CurrentSetting`
2. 反射获取当前已加载 `WRotation` 程序集中的：
   - `WRotation.Bot.WRotationSetting.CurrentSetting`
3. 若存在可用实例，则调用其 `Save()`

并写入：

- `combat-prereq setting-persist general ok`
- `combat-prereq setting-persist wrotation ok`

## 这一步的意义

这一步不直接等于“人物已经会打”。

它解决的是另一个容易把战斗链搞飘的问题：

- 启动前修正过的配置，不再只存在于当前内存
- 后续产品线程再读配置时，更大概率读到的是已经归一化后的状态

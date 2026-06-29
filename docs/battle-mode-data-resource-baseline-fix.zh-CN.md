# 战斗模式 Data 资源基线补齐

## 结论

这次补的是战斗模式主链下层资源，不是 UI。

当前运行产物已经不再是只有轻量 `Data` 文件的壳，而是补齐到了接近原版运行时的基础结构：

- `Data\Meshes`
- `Data\Minimaps`
- `Data\temp`
- 以及原有：
  - `Data\Lang`
  - `Data\NpcDB.xml`
  - `Data\OffMeshConnections.xml`
  - `Data\Digsites.xml`

## 为什么必须补

用户给出的提示是对的：

- 当前问题不只是按钮、FightClass、编译依赖
- `Data` 缺少网格文件时，寻路、地图瓦片、接近目标链都会先天残缺

原版 `RZB\Data` 中明确存在：

- `Meshes`
- `Minimaps`
- `temp`

而之前的运行产物默认只带了轻量文件，没有把这些主链资源带出来。

## 本次处理

修改文件：

- [Publish-OriginalUiHostLayout.ps1](D:\666\work\WR.Next\tools\layout\Publish-OriginalUiHostLayout.ps1)

发布策略调整为默认携带：

1. `Data\Meshes`
2. `Data\Minimaps`
3. `Data\temp`

不再把它们作为“重资源可选项”排除在默认运行布局之外。

## 已确认事实

原版资源量级已核对：

- `Meshes` 约 `0.64 GB`
- `Minimaps` 约 `0.02 GB`

并且当前运行产物已确认存在：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Data\Meshes`
- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Data\Minimaps`
- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Data\temp`

## 这一步的意义

这一步不宣称战斗模式已经完全打通。

它只解决一个非常基础但很关键的事实：

- 以后继续修战斗模式时，不再是“缺底层导航资源的轻量包”
- 而是站在更接近原版的资源基线上推进

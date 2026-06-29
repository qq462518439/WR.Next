# WR.OriginalUiHost 工程结构规范

## 结论

当前 `WR.OriginalUiHost` 处于实验期平铺结构，不适合继续长期叠加功能。后续开发必须转为：

1. 源码按职责分层
2. 运行输出按用途聚合
3. 探针、诊断、临时文件与正式运行物隔离

本规范用于约束后续目录重组和新代码落点。

## 一、源码目录目标结构

项目根：`D:\666\work\WR.Next\src\WR.OriginalUiHost`

建议分层：

```text
WR.OriginalUiHost/
  App/
  Shell/
  Views/
  ViewModels/
  Adapters/
  Runtime/
  Models/
  Infrastructure/
  Diagnostics/
  Assets/
  Properties/
```

### 1. App

放应用入口与全局初始化：

- `App.xaml`
- `App.xaml.cs`
- 全局异常处理
- 全局资源注册

### 2. Shell

放主壳层对象：

- `MainWindow.xaml`
- `MainWindow.xaml.cs`
- `OriginalMainShellPage.cs`

职责：

- 顶层导航
- 顶层布局
- 页面装配

### 3. Views

放所有页面与用户控件，按业务再分子目录：

```text
Views/
  Process/
  InGame/
  Settings/
  Logging/
  Tools/
  Plugins/
  Chat/
  Login/
  Shared/
```

示例落点：

- `ProcessManagementControl.xaml`
- `OriginalInGameHostControl.xaml`
- `OriginalMiniMapHostControl.xaml`
- `InGameStatusControl.xaml`

### 4. ViewModels

放页面状态模型和界面命令编排：

- `OriginalMainShellViewModel.cs`

约定：

- 不直接承载底层运行时接线
- 不直接写文件系统路径拼装
- 只负责界面状态与交互编排

### 5. Adapters

放“原版 UI / 原版 DLL / 当前宿主”之间的桥接对象：

- `OriginalLoginTakeoverAdapter.cs`
- `OriginalModeSelectionTakeoverAdapter.cs`

职责：

- 接口适配
- 反射桥接
- 原版控件接管辅助

### 6. Runtime

放运行时接线与宿主控制：

- `OriginalRuntimeBootstrap.cs`
- 与进程附着、运行态刷新、产品状态拉取相关的逻辑

约定：

- 所有与 `robotManager.dll / wManager.dll / authManager.dll` 的直接运行时交互优先放这里
- 避免散落到各个页面 code-behind

### 7. Models

放纯数据模型：

- `ProcessListItem.cs`
- 以后新增的快照 DTO / 状态 DTO / 页面数据项

### 8. Infrastructure

放通用基础设施：

- `RelayCommand.cs`
- 文件路径帮助器
- 统一日志辅助
- 调度封装

### 9. Diagnostics

放调试和诊断辅助代码：

- `OriginalPopupSuppressor.cs`
- 地图状态诊断辅助
- 临时运行态观察器

约定：

- 诊断代码可以进入源码树
- 但必须与正式业务逻辑分目录

## 二、源码层约束

### 1. 禁止继续把新文件直接丢在项目根

除以下文件外，项目根不再新增普通业务文件：

- `.csproj`
- 解决方案相关文件
- 极少量必须位于根的 WPF 入口文件

### 2. code-behind 只做三类事

- 视图初始化
- 简单事件转发
- 宿主控件最小装配

业务状态处理应优先进入：

- `ViewModels`
- `Adapters`
- `Runtime`
- `Infrastructure`

### 3. 路径常量集中

运行根、数据根、日志根、模块根，不允许散落在多个页面类里硬编码。

后续应收口到统一路径服务，例如：

- `RuntimePaths`
- `OutputLayout`

## 三、运行输出目标结构

当前输出根：`D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48`

目标应收敛为：

```text
bin/Debug/net48/
  app/
  runtime/
  data/
  modules/
  profiles/
  logs/
  tools/
```

### 1. app

放主程序自身：

- `WR.OriginalUiHost.exe`
- `WR.OriginalUiHost.exe.config`
- `WR.OriginalUiHost.pdb`

### 2. runtime

放运行时依赖：

- `robotManager.dll`
- `wManager.dll`
- `authManager.dll`
- `MemoryRobot.dll`
- `wResources.dll`
- 第三方 UI 依赖

### 3. data

放共享业务数据：

- `Data/Minimaps`
- `Data/Meshes`
- `Data/Lang`

### 4. modules

放可插拔业务模块：

- `Products`
- `Plugins`
- `FightClass`

### 5. profiles

放各类路线与业务配置：

- `Profiles`
- `Settings`

如后续区分更细，可拆成：

- `profiles/`
- `settings/`

### 6. logs

放运行日志。

### 7. tools

放诊断与实验工具：

```text
tools/
  diagnostics/
  probes/
```

必须迁入的典型文件：

- `inspect.exe`
- `status_probe.exe`
- `runtime_probe.exe`
- `product_probe.exe`

## 四、运行目录约束

### 1. 禁止把 `*.cs` 临时源码丢在运行根

例如：

- `inspect.cs`
- `hook_inspect.cs`
- `status_probe.cs`

这些属于实验资产，必须迁入：

- `tools/probes/src/`

### 2. 禁止让 probe exe 与正式主程序同层混放

诊断工具必须与成品运行物隔离，否则：

- 误发版概率高
- 定位主程序困难
- 用户运行目录可读性差

### 3. 运行根只保留聚合目录

理想状态下，运行根看到的是目录，而不是几十个散件文件。

## 五、迁移优先级

### P1：立刻处理

1. 源码目录分层
2. 诊断/适配/运行时代码归类
3. 运行目录中的 probe 与临时源码清走

### P2：随后处理

1. 统一路径服务
2. 统一日志入口
3. 统一运行物发布脚本

### P3：后续增强

1. 多项目拆分
2. `Runtime` / `Diagnostics` / `Adapters` 独立程序集化
3. Debug/Release 输出布局分流

## 六、执行原则

后续目录重组遵循以下原则：

1. 先文档，后搬迁
2. 先无行为重组，后功能扩展
3. 每次搬迁控制在单一职责范围
4. 每一轮搬迁后都要验证构建
5. 不再接受“为了快先平铺，后面再说”的新增代码

## 七、当前执行建议

建议按下面顺序推进：

1. 先完成源码目录第一轮分层
2. 再清理运行目录中的探针与临时源码
3. 然后补统一路径布局
4. 最后恢复功能接线开发

## 八、一句话判断标准

以后判断结构是否合格，只看两件事：

1. 新文件是否能一眼看出职责归属
2. 运行根是否能一眼区分“成品、依赖、数据、模块、工具”

如果做不到，就说明结构还没收好。

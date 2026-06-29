# WR.OriginalUiHost 结构重组第一轮收口

## 结论

第一轮结构重组已完成，重点解决了两个问题：

1. 源码目录从项目根平铺改为职责分层
2. 运行目录中的 probe / inspect 散件已从运行根剥离

本轮是无行为重组，目标是让后续开发有稳定骨架，不是功能扩展。

## 已完成项

### 1. 源码目录完成第一轮分层

当前目录已建立并实际落文件：

- `App/`
- `Shell/`
- `Views/`
- `ViewModels/`
- `Adapters/`
- `Runtime/`
- `Models/`
- `Infrastructure/`
- `Diagnostics/`

项目根现仅保留：

- `AssemblyInfo.cs`
- `WR.OriginalUiHost.csproj`

### 2. WPF 入口已修正

为适配 `App/App.xaml` 新位置，已完成：

- `StartupUri` 调整到 `Shell/MainWindow.xaml`
- `.csproj` 显式声明 `ApplicationDefinition Include="App\\App.xaml"`

### 3. 构建验证通过

已使用独立输出目录完成构建验证：

- 输出目录：`D:\666\work\WR.Next\artifacts\uihost-reorg-build`

结果：

- `0 warning`
- `0 error`

### 4. 运行目录中的临时诊断资产已剥离

以下文件已从旧运行根移出：

- `inspect*.cs / inspect*.exe`
- `*_probe.cs / *_probe.exe`
- `hook_inspect.cs / hook_inspect.exe`

新位置：

- `D:\666\work\WR.Next\tools\diagnostics\src`
- `D:\666\work\WR.Next\tools\diagnostics\bin`

### 5. 旧运行根已明显收敛

`bin\\Debug\\net48` 根目录当前主要只剩：

- 主程序
- 运行时 DLL

不再混放 probe 与临时源码。

## 本轮未处理项

以下内容尚未进入第二轮：

1. 正式运行输出目录聚合为 `app / runtime / data / modules / profiles / logs / tools`
2. `Data / Profiles / Logs / Settings` 的统一聚合布局
3. 统一路径服务
4. 发布脚本与 Debug/Release 布局分流

## 当前状态判断

当前可以认定为：

- 源码层：已从平铺进入可维护状态
- 运行层：已去掉最明显污染，但尚未完成最终聚合布局

## 下一步建议

下一轮建议直接做运行输出聚合：

1. 以 `artifacts/uihost-reorg-build` 为新干净基座
2. 设计 `app/runtime/data/modules/profiles/logs/tools` 目录布局
3. 用构建后整理脚本或复制脚本生成聚合运行目录
4. 再决定是否替换旧 `bin/Debug/net48`

## 一句话结论

第一轮已经把“源码平铺”和“运行根被 probe 污染”这两个最吵的问题压住了，但运行目录聚合还没做完，后续应继续推进第二轮。

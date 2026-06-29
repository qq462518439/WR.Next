# WR.OriginalUiHost 路径统一收口

## 结论

`WR.OriginalUiHost` 已完成第三轮路径统一：

1. 运行根不再只依赖 `D:\666\RZB`
2. 新聚合布局 `uihost-runtime-layout` 可以直接作为构建输入
3. 工程已能在新布局下通过构建验证

## 已完成项

### 1. 统一路径服务已落地

新增：

- `Infrastructure/OriginalRuntimePaths.cs`

作用：

- 自动识别运行根
- 优先识别 `runtime/`
- 回退识别旧 `Bin/`
- 最后回退到根目录

### 2. 关键入口已改为使用统一路径

已接入的入口包括：

- `App/App.xaml.cs`
- `Shell/MainWindow.xaml.cs`
- `Views/InGame/OriginalMiniMapHostControl.xaml.cs`
- `Views/InGame/OriginalModeSelectionHostControl.xaml.cs`
- `Views/InGame/OriginalInGameHostControl.xaml.cs`
- `Views/Chat/OriginalChatHostControl.xaml.cs`
- `Views/Logging/OriginalLoggingHostControl.xaml.cs`
- `Views/Plugins/OriginalPluginsHostControl.xaml.cs`
- `Views/Tools/OriginalToolsHostControl.xaml.cs`
- `Views/Settings/OriginalGeneralSettingsHostControl.xaml.cs`

### 3. 工程引用已支持新布局

`WR.OriginalUiHost.csproj` 已改为：

- 优先读 `$(WRRuntimeRoot)\runtime`
- 再回退 `$(WRRuntimeRoot)\Bin`
- 再回退 `$(WRRuntimeRoot)`

这保证了：

- 新布局可用
- 旧布局仍可兼容

### 4. 新布局构建验证通过

已验证命令：

```powershell
dotnet build D:\666\work\WR.Next\src\WR.OriginalUiHost\WR.OriginalUiHost.csproj -c Debug -o D:\666\work\WR.Next\artifacts\uihost-runtime-root-build /p:WRRuntimeRoot=D:\666\work\WR.Next\artifacts\uihost-runtime-layout
```

结果：

- `0 warning`
- `0 error`

## 当前状态

现在可以认为：

- 源码目录已分层
- 运行目录已聚合
- 运行根解析已统一
- 新布局已可作为工程输入

## 剩余兼容痕迹

还保留少量旧根语义，仅用于兜底兼容：

- `D:\666\RZB` 作为默认回退值
- `Bin` 作为旧运行目录兼容层

这不是功能性依赖，只是保底兼容。

## 下一步建议

下一步不再做目录层面的重构，建议转入：

1. 实际运行验证
2. 页面级崩溃和空白页修复
3. 进一步减少旧根兼容痕迹

## 一句话结论

结构层面已经从“平铺旧根”走到了“分层源码 + 聚合运行根 + 统一路径”，可以继续往真实运行验证推进。

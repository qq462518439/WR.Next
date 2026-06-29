# Battle Mode Original Entry Activation

## 结论

这一轮已经完成一个关键跨步：

> 原版主程序入口现在已经真正进入当前宿主运行域。

具体证据已经确认：

1. `WRobot.exe` 已成功预加载
2. `WRobot.Launching` 已在当前 AppDomain 中可见
3. `RDManaged.dll` 已成功从 `Bin` 预加载
4. `fasmdll_managed.dll` 已成功从 `Bin` 预加载
5. `OriginalEntrySelfCheck` 已返回：
   - `launching=True`
   - `launchBotMethod=True`

这意味着：

> 当前宿主已经从“原版入口不在场”推进到“原版入口已在场”。

## 本轮修正

### 1. 修正运行时 DLL 根解析顺序

文件：

- `src/WR.OriginalUiHost/Infrastructure/OriginalRuntimePaths.cs`

改动：

- `RuntimeAssemblyRoot` 由优先根目录改为优先 `Bin`

原因：

此前 `RDManaged.dll` 与 `fasmdll_managed.dll` 实际存在于 `Bin`
但宿主优先查根目录，导致预加载日志误报 missing。

### 2. 把 `WRobot.exe` 放入运行布局

文件：

- `tools/layout/Publish-OriginalUiHostLayout.ps1`

改动：

- 将以下文件纳入运行目录根：
  - `WRobot.exe`
  - `WRobot.exe.config`

原因：

若运行目录根缺少 `WRobot.exe`，则 `WRobot.Launching` 不可能被预加载进宿主运行域。

## 实测启动日志证据

当前 `original-ui-host-startup.txt` 已确认出现：

```text
Preload original-host => WRobot ... launching=True
Preload RDManaged.dll => RDManaged ...
Preload fasmdll_managed.dll => fasmdll_managed ...
OriginalEntrySelfCheck launching=True ... launchBotMethod=True
```

这是当前最关键的硬证据。

## 当前意义

这一轮依然没有宣称：

1. Hook 线程已恢复
2. `ThreadHooked` 已变成 True
3. `LaunchBot` 已成功打穿到原版执行链

但它完成了进入下一层之前必须满足的前置：

> 原版主程序入口、原版桥接库、运行域可见性，现在都已经到位。

## 下一步

下一包可以进入：

1. 最小原版式入口调用试探
2. 观察：
   - `ThreadHooked`
   - `RetnToHookCode`
   - `Pulsator.IsActive`
   - 是否仍然停留在观察链

## 一句话判断

现在已经不是“入口缺席”，而是可以真正开始试图激活原版入口了。

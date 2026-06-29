# 无登录 UI 运行时引导审计

结论：移除登录/试用弹窗不会阻断 DLL 加载，也不会阻断最底层 `MemoryRobot.Memory.Open(pid)`；但它会绕过原始 WRobot 的启动桥和 Hook/ObjectManager 初始化链。当前证据不支持宣称“游戏中状态已接管”。

## 当前已验证

- 新宿主可加载原版 DLL：
  - `authManager.dll`
  - `robotManager.dll`
  - `wManager.dll`
  - `MemoryRobot.dll`
- x86 探针确认存在：
  - `MemoryRobot.Memory.Open(int)`
  - `MemoryRobot.Memory.IsValidAndOpenProcess()`
  - `wManager.Wow.Memory.WowMemory`
  - `wManager.Wow.ObjectManager.ObjectManager`
- 首页接管复选框现在调用 `OriginalRuntimeBootstrap.AttachToWowProcess(pid)`。
- 当前最小接管动作：
  - 设置工作目录为 `D:\666\RZB`
  - 使用原版 `wManager.Wow.Memory.WowMemory.Memory`
  - 调用 `Open(pid)`
  - 验证 `IsValidAndOpenProcess()`
  - 调用 `wManager.Wow.Memory.IsInGame(pid)`
  - 调用 `wManager.Wow.Memory.PlayerName(pid)`
  - 调用 `wManager.Wow.ObjectManager.Pulsator.Initialize(false)`
  - 读取 `ObjectManager.Me.Name / Level / HealthPercent / Position`
  - 返回 `ProcessId / WindowHandleInt32 / MainModuleAddress / inGame / player / ObjectManager snapshot`

## 本轮新增证据

x86 探针输出：

```text
PID=6336 TITLE=魔兽世界
OPEN=True
VALID=True
PID2=6336
HWND=4327430
MODULE=0x400000
INGAME=True
PLAYER=Look
```

这证明：不走登录/试用弹窗时，原版 DLL 的 Memory 层仍能打开真实 Wow 进程，并能读取“是否在游戏中”和角色名。

ObjectManager/Pulsator 探针输出：

```text
OPEN=True
INGAME=True
PLAYER=Look
PULSE_OK
LIST=281 DICT=281
ME_ADDR=787447992
ME_VALID=True
ME_NAME=Look
ME_LEVEL=71
ME_HP=100
ME_POS=5697.723 ; 544.4739 ; 647.4526 ; "None"
```

这证明：按原版 `Pulsator.Initialize(false)` 入口刷新一次后，可以读取对象层、角色等级、血量和坐标。

## 当前未完成

- `ObjectManager.Me` 已通过单次 `Pulsator.Initialize(false)` 读取成功。
- 尚未实现持续安全刷新节流策略；UI 当前只在勾选接管时抓取一次快照。
- 线程模式 `Pulsator.Initialize(true)` 仍依赖 `Memory.WowMemory.ThreadHooked`，当前不启用。
- `robotManager.MemoryClass.Hook` 没有无参构造，构造签名需要原始启动链提供参数：

```text
Hook(int processId, uint ..., byte[] ..., uint ..., ...)
```

- 当前磁盘未找到原始 `D:\666\RZB\WRobot.exe`，因此不能直接反射调用 `WRobot.Launching.LaunchBot(...)`。
- 现有可用依据只能来自：
  - 反编译 `WRobot-ilspy`
  - 原版 DLL 反射
  - 运行时探针

## 判断

用户的直觉基本正确：不显示登录弹窗本身不会阻断 DLL 引用，也不会阻断 Memory/ObjectManager 基础读取。当前缺的是产品主循环、持续刷新、Hook 线程模式和行为层接管，不是登录 UI。

## 下一步

1. 为首页实现安全周期刷新：只在已接管进程上限频调用 `Pulsator.Initialize(false)`。
2. 将刷新结果同步到 `游戏中` 页。
3. 下一层再接目标、移动状态、战斗状态。

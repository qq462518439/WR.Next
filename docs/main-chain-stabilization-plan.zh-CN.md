# 主链稳定推进约定

## 结论

后续不再用零散按钮和临时探针作为主推进方式。主程序必须沿原版主链分段接管，每段只验收一个明确能力。

## 当前第一段结论

第一段先以可稳定观察为目标：

```text
Memory.Open -> IsInGame -> ObjectManager -> Character/Level/Health/Position
```

不要把 Hook/DX 注入混进第一段。此前强行 `new Hook(...)` 会卡在：

```text
DetourAddress=0
```

这说明 Hook 入口还没有按原版主程序路径接通。第一段回退到 `Memory.WowMemory.Memory.Open(processId)`，保证首页先稳定展示角色基础状态。

Hook/DX 注入属于第二段，必须从原版主程序连接入口继续抄，不允许用自造桥接类硬绕。

当前验证结果：

```text
attach pid=6336 hwnd=4327430 mainModule=0x400000 inGame=True player=Look objects=333
attach pid=6336 hwnd=4327430 mainModule=0x400000 inGame=True player=Look objects=330
```

第一段已恢复：主页可以自动接管唯一 `Wow.exe` 并读到 ObjectManager 基础快照。产品启动和 Hook/DX 注入不再混入首页基础快照。

第二段当前处理方式：

```text
游戏中页 Loaded -> EnsureOriginalProductStartedInBackground()
```

`Products.LoadProducts("WRotation") -> ProductStart` 只在后台任务里执行，并通过产品链状态文本显示，不阻塞首页 `Memory/ObjectManager` 基础快照。移动动作只在 `Products.IsAliveProduct && Products.IsStarted && !Products.InPause` 时继续，否则返回当前产品链状态。

## 当前第二段结论

第二段已经从“加载成功但启动失败”推进到“原版产品启动成功”。

关键证据：

```text
Assembly.LoadFrom end WRotation, Version=1.0.0.38014
CreateInstance end null=False
Initialize end alive=True
ProductStart gate key=IsSafeToUse set=True value=True
ProductStart ok alive=True started=True pause=False
background-start-result 原版产品 WRotation 已启动
```

卡点来源不是进程识别，也不是 WRotation 缺失，而是 `Products.ProductStart()` 内部读取 `Var.GetVar<bool>("IsSafeToUse")`。现在由宿主在调用 `ProductStart()` 前写入该运行时状态位，仍然保留原版 `ProductStart()` 入口，不直接调用 `IProduct.Start()`。

下一段只处理运行时线程链，不再增加零散按钮或页面探针。

## 后续主链顺序

1. 进程观察链：`Memory.Open -> IsInGame -> ObjectManager`
2. 产品启动链：`Products.LoadProducts("WRotation") -> ProductStart`
3. 运行时线程链：`Pulsator -> MovementManager -> FSM`
4. 游戏中能力链：`Target -> MoveTo -> ClickToMove -> Fight`
5. 原版 Hook 链：原版入口 -> `DetourAddress -> OriginalOpCode -> Hook`

每一步只以前一段稳定为前提，不再跨段堆功能。

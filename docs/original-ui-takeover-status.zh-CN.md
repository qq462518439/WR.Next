# 原始 UI 接管状态

生成日期：2026-06-28

## 结论

当前路线已切换为“原始 UI 接管”，不是截图复刻。

第一版接管方式：

- 新宿主项目：`D:\666\work\WR.Next\src\WR.OriginalUiHost`
- 直接引用原版 UI/样式 DLL：
  - `D:\666\RZB\Bin\authManager.dll`
  - `D:\666\RZB\Bin\rStyle.dll`
  - `D:\666\RZB\Bin\robotManager.dll`
  - `D:\666\RZB\Bin\MemoryRobot.dll`
- 直接实例化原版控件：
  - `authManager.LoginUserControl`

这比复刻 UI 更接近目标，因为布局、控件字段、原始样式入口来自原版程序集。

## 当前证据

### 1. 原版 UI 入口存在

通过 `ilspycmd` 已确认：

```text
authManager.LoginUserControl
-.l1I11i1111Ii
rStyle.CheckBoxSwitch
rStyle.rStyleResources
```

`LoginUserControl` 字段证据：

```text
ProductName
OptionalVersionName
listBoxProcess
buttonRefresh
buttonLaunchBot
textBlockLaunchBot
```

这些字段与原始启动/进程选择区域直接相关。

### 2. 原版样式资源可抽取

`rStyle.dll` 可列出原始图标和样式资源：

```text
rStyle.g.resources/themes/generic.baml
rStyle.g.resources/resources/main.png
rStyle.g.resources/resources/productsettings.png
rStyle.g.resources/resources/settings.png
rStyle.g.resources/resources/log.png
rStyle.g.resources/resources/chat.png
rStyle.g.resources/resources/map.png
rStyle.g.resources/resources/tools.png
rStyle.g.resources/resources/target.png
```

已反编译出：

```text
D:\666\work\WR.Next\external\ilspy\rStyle\themes\generic.xaml
```

### 3. authManager UI 不是普通 XAML

`authManager.dll` 的资源列表不是标准 `.g.resources/*.baml` 输出，而是混淆/保护资源：

```text
78bc7df3764e43e76f2db1c4419134c7
9f9621f5ec9c4c60ecd3222e6e5bce4f
```

`LoginUserControl.InitializeComponent()` 也被保护调用包装。

因此当前不能把它当作“干净 XAML 文件”直接改，但可以先作为原版控件宿主化接管。

### 4. 原版控件树已被新宿主接管

新宿主已切换为：

```text
.NET Framework 4.8
x86
```

原因：

- `authManager.dll` / `MahApps.Metro.dll` / 原版 UI 栈目标为 .NET Framework 4.x。
- .NET 8 宿主能编译启动，但会触发原版环境检查弹窗。
- net48 宿主不再弹出该环境检查框，更接近原版运行条件。

运行时字段诊断：

```text
listBoxProcess=True
buttonRefresh=True
buttonLaunchBot=True
textBlockLaunchBot=True
descendants=42
```

说明：

- `LoginUserControl.InitializeComponent()` 实际完成。
- 原版 `listBoxProcess / buttonRefresh / buttonLaunchBot / textBlockLaunchBot` 字段可直接访问。
- 新宿主已能替换进程列表数据源。

截图证据：

```text
D:\666\work\WR.Next\artifacts\original-ui-host-net48-field-takeover-screen.png
```

当前截图中已显示：

```text
6336 魔兽世界
```

这说明原始启动 UI 的进程列表区域已由新宿主接管。

## 已完成工程

### 项目

```text
D:\666\work\WR.Next\src\WR.OriginalUiHost\WR.OriginalUiHost.csproj
```

技术栈：

```text
.NET 8 WPF
x86
```

### 验证

已执行：

```powershell
dotnet build D:\666\work\WR.Next\src\WR.OriginalUiHost\WR.OriginalUiHost.csproj
```

结果：

```text
0 warnings
0 errors
```

已执行启动烟测：

```powershell
Start-Process D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net8.0-windows\WR.OriginalUiHost.exe
```

结果：

```text
进程保持运行，没有立即崩溃
```

已执行截图烟测：

```powershell
D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48\WR.OriginalUiHost.exe
```

结果：

```text
窗口可运行
原始 LoginUserControl 字段存在
进程列表已显示 Wow.exe
```

### 5. 启动条完整露出并抽出适配器

当前已完成结构拆分：

```text
D:\666\work\WR.Next\src\WR.OriginalUiHost\OriginalLoginTakeoverAdapter.cs
D:\666\work\WR.Next\src\WR.OriginalUiHost\ProcessListItem.cs
```

`MainWindow.xaml.cs` 现在只负责：

- 设置运行根目录。
- 实例化 `authManager.LoginUserControl`。
- 挂接 `OriginalLoginTakeoverAdapter`。

`OriginalLoginTakeoverAdapter` 负责：

- 替换 `listBoxProcess` 数据源。
- 接管 `buttonRefresh`。
- 接管 `buttonLaunchBot`。
- 禁用/改写原始远程/语言/外链入口。
- 输出控件树诊断。

新增弹窗压制：

```text
D:\666\work\WR.Next\src\WR.OriginalUiHost\OriginalPopupSuppressor.cs
```

职责：

- 只枚举当前 `WR.OriginalUiHost` 进程的可见窗口。
- 自动关闭原版 auth/login/verify/subscription/install 类弹窗。
- 排除主窗口 `WR Original UI Host`。
- 写入日志：

```text
D:\666\RZB\Logs\original-ui-host-popups.txt
```

目的：

- 屏蔽原版登录/验证/订阅弹窗。
- 防止 `authManager` 初始化或误点原始入口时把用户带回旧登录链。

窗口截图证据：

```text
D:\666\work\WR.Next\artifacts\original-ui-host-window-print-topfit.png
```

该截图已显示：

- `6336 魔兽世界`
- `Refresh`
- `接管进程`
- 原始外链区域
- 原始语言/产品下拉区域

说明原版启动区域已经不是截图复刻，而是原始控件树宿主化后进行本地接管。

## 当前边界

当前只能说明：

- 新宿主能引用原版 UI DLL。
- 新宿主能启动。
- 原版 UI 控件接管路线可继续推进。

当前还不能说明：

- 登录/订阅逻辑已剥离。
- 原始主窗口九页已全部接管。
- 进程连接已替换为新逻辑。
- 战斗链、对象层、寻路层可用。
- 所有原版弹窗来源已逐个定位完毕。

## 下一步

下一包只做 UI 接管，不扩战斗链：

1. 做运行级点击验证：
   - 点击 `Refresh` 后只刷新本地进程列表。
   - 点击 `接管进程` 后只写入本地接管状态。
2. 继续观察并记录被压制弹窗标题，逐个替换源入口。
3. 开始寻找原版主窗口 `-.lilll1Iiilli` 或同类主 Shell 入口，进入九页主 UI 接管。

## 控制面建议

```text
promote original-ui-host
hold full runtime takeover
do not resume screenshot-only remake
```

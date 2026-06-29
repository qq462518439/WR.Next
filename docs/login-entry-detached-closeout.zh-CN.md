# 登录入口脱离主流程收口

## 结论

`OriginalLoginHostControl` 仍保留在仓库中，但**已经不再是主导航入口**。

当前主窗口页面顺序以 `进程管理` 为首页，后续页面为：

1. 模式选择
2. 游戏中
3. 通用设置
4. 插件
5. 日志
6. 聊天
7. 工具
8. 地图

## 已确认依据

- 主导航定义位于 `D:\666\work\WR.Next\src\WR.OriginalUiHost\Shell\MainWindow.xaml.cs`
- 该文件当前未把 `OriginalLoginHostControl` 放入 `Pages` 集合
- 首页已改为 `ProcessManagementControl`
- `OriginalLoginHostControl` 仅作为旁路组件保留在 `Views\Login`

## 意义

这意味着：

1. 登录页不再参与主流程导航
2. 账号/订阅/验证链不会再以首页入口形式出现
3. 后续主线应继续围绕进程管理、游戏中、地图等可验证页面推进


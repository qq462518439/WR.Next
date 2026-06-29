# 运行目录 Bin 聚合布局收口

## 结论

运行目录现在正式改成：

- 根目录只留主程序、启动配置和各类资源目录
- 所有运行时 DLL 统一收进 `Bin`

这比之前“根目录散放一套 DLL，再在 `Bin` 补一套”的方式更干净，也更适合长期维护。

## 调整前的问题

旧布局的问题不是不能跑，而是越来越乱：

1. 根目录平铺大量 DLL
2. `Bin` 里又有一套依赖
3. 到底哪一套在被实际消费，不够直观
4. 后续继续补产品/运行时时，容易把依赖关系越抹越乱

## 本次收口策略

当前布局收敛为：

- 根目录：
  - `WR.OriginalUiHost.exe`
  - `WR.OriginalUiHost.exe.config`
  - `Launch-OriginalUiHost.ps1`
  - `README.txt`
  - 以及目录：
    - `Bin`
    - `Data`
    - `Products`
    - `Plugins`
    - `FightClass`
    - `Profiles`
    - `Settings`
    - `logs`
    - `tools`

- `Bin`
  - 统一放全部运行时 DLL
  - 包括原版动态编译链要吃的依赖

## 代码调整

涉及文件：

- [Publish-OriginalUiHostLayout.ps1](D:\666\work\WR.Next\tools\layout\Publish-OriginalUiHostLayout.ps1)

关键变化：

1. 根目录不再复制运行时 DLL
2. 全部 DLL 只复制到：
   - `Bin`
3. 重写：
   - `WR.OriginalUiHost.exe.config`
4. 注入：
   - `<probing privatePath="Bin" />`

## 当前意义

这一步的价值不只是“更整洁”，还包括：

1. 动态编译依赖路径更统一
2. 宿主程序集解析链更明确
3. 后续新增/替换 DLL 时，不再需要同时维护两套位置

## 当前状态

当前运行产物已确认：

- 根目录已不再散放运行时 DLL
- 运行时 DLL 已统一在：
  - [Bin](D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Bin)

这是后续继续做真实产品接管时，更合适的长期布局。

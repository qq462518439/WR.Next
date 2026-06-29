# WR.OriginalUiHost 运行目录聚合布局收口

## 结论

第二轮已完成：`WR.OriginalUiHost` 现在已经具备一套独立、聚合、可复用的运行目录布局，不再依赖旧的平铺 `bin\\Debug\\net48` 作为唯一可运行根。

新的聚合运行根位置：

- `D:\666\work\WR.Next\artifacts\uihost-runtime-layout`

## 已完成项

### 1. 新运行布局已生成

当前聚合目录结构：

```text
uihost-runtime-layout/
  app/
  runtime/
  data/
  modules/
  profiles/
  logs/
  tools/
  README.txt
```

### 2. 目录职责已落地

#### app

包含主程序：

- `WR.OriginalUiHost.exe`
- `WR.OriginalUiHost.exe.config`
- `WR.OriginalUiHost.pdb`

#### runtime

包含核心依赖 DLL：

- `robotManager.dll`
- `wManager.dll`
- `authManager.dll`
- `wResources.dll`
- 其他第三方运行时依赖

#### data

包含：

- `Data`

来源：

- `D:\666\RZB\Data`

#### modules

包含：

- `FightClass`
- `Plugins`
- `Products`

来源：

- 新构建输出目录中的模块内容

#### profiles

包含：

- `Profiles`
- `Settings`

来源：

- `Profiles` 来自 `D:\666\RZB\Profiles`
- `Settings` 来自新构建输出

#### logs

已预留独立日志目录。

#### tools

包含：

- `diagnostics`

来源：

- `D:\666\work\WR.Next\tools\diagnostics`

## 支撑资产

已新增布局脚本：

- `D:\666\work\WR.Next\tools\layout\Publish-OriginalUiHostLayout.ps1`

用途：

1. 从独立构建输出收集主程序与依赖
2. 从运行时源目录补齐 `Data / Profiles`
3. 收入 `FightClass / Plugins / Products / Settings`
4. 收入诊断工具
5. 生成新的聚合运行根

## 当前意义

这一步解决了三个长期问题：

1. 正式主程序与 DLL 不再和 probe 散件混放
2. 后续测试可以围绕固定运行根进行
3. 以后替换旧主程序时，有了明确的中间交付形态

## 仍未完成项

以下内容尚未做最终切换：

1. 让主程序完全按新聚合目录运行
2. 统一主程序对 `RuntimeRoot` / `Data` / `Logs` / `Settings` 的路径解析
3. 用新布局直接替代旧 `RZB` 根的人工运行方式
4. 为新布局补一键启动或发布脚本

## 下一步建议

建议下一轮直接处理“路径统一化”：

1. 抽出统一路径服务
2. 让页面与运行时不再写死 `D:\666\RZB`
3. 让 `uihost-runtime-layout` 可以作为真正的运行根

## 一句话结论

现在我们已经从“源码平铺 + 运行目录平铺”推进到“源码分层 + 运行目录聚合”，但还差最后一步路径统一，才能把这套新布局真正跑成主基座。

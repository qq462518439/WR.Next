# WR.Next

## 结论

`WR.Next` 是一个以长期可维护为目标的实验仓库，当前主线聚焦于：

1. 保留原版运行时能力边界
2. 用新的宿主工程逐段接管原始主程序链路
3. 先打通可验证主链，再逐步替换高风险壳层

当前最核心的可运行项目是：

- `src/WR.OriginalUiHost`

它不是“全量接管完成版”，而是当前用于承载原版运行时、验证主链、逐层压通能力链的宿主基座。

## 仓库结构

```text
src/
  WR.OriginalUiHost/     当前主宿主工程
  WR.OriginalWRobot/     原版主程序源码恢复/对照工作区

external/
  decompiled-runtime/    运行时 DLL 逆向对照资料
  ilspy/                 资源/依赖逆向资料
  recovered/             恢复样本与外部审计资料

tools/
  layout/                运行目录发布脚本
  diagnostics/           诊断探针源码
  RuntimeHookProbe/      单独诊断小工具

docs/                    中文阶段文档、审计结论、推进约定
artifacts/               本地产物与截图，不作为首推跟踪目标
```

## 当前工作方式

后续推进遵循三条硬约束：

1. 按能力层推进，不按页面乱补
2. 每次只处理一个窄包，并留下中文文档
3. 先保证主链完整、稳定、可验证，再做体验细化

推荐先读：

- [docs/long-term-maintainability-gates.zh-CN.md](docs/long-term-maintainability-gates.zh-CN.md)
- [docs/main-chain-stabilization-plan.zh-CN.md](docs/main-chain-stabilization-plan.zh-CN.md)
- [docs/wrotation-capability-layer-map.zh-CN.md](docs/wrotation-capability-layer-map.zh-CN.md)

## 构建与运行

### 构建

根目录脚本：

```bat
build-uihost.bat
```

它会：

1. 构建 `src/WR.OriginalUiHost`
2. 调用 `tools/layout/Publish-OriginalUiHostLayout.ps1`
3. 生成聚合运行目录到 `artifacts/uihost-runtime-layout`

### 运行

```bat
run-uihost-latest.bat
```

## 当前边界

为了让第一次推送干净、可读、可维护，当前默认不跟踪：

- `bin/obj`
- `artifacts/uihost-runtime-layout`
- 本地截图
- 本地日志
- 诊断工具编译产物
- 个人环境设置漂移

也就是说，仓库首推优先提交：

1. 源码
2. 文档
3. 发布脚本
4. 逆向对照资料

不优先提交机器相关运行产物。

## 当前推荐阅读顺序

1. `README.md`
2. `docs/long-term-maintainability-gates.zh-CN.md`
3. `docs/wr-original-uihost-structure-standard.zh-CN.md`
4. `src/WR.OriginalUiHost/WR.OriginalUiHost.csproj`
5. `tools/layout/Publish-OriginalUiHostLayout.ps1`

## 当前状态

这个仓库现在适合做：

- 工程整理
- 主链验证
- 窄包推进
- 文档化接管

还不适合做：

- 宣称已完全接管
- 直接替代全部原版运行时
- 无约束地并行接很多产品

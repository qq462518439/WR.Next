# WR.Next 首推分批建议

## 结论

当前仓库已经可以进入首推准备阶段，但不建议“一把全推”。

最合理的方式是分两批：

1. 第一批推主工程、文档、脚本、必要对照骨架
2. 第二批再推完整逆向资料与扩展审计资料

这样做的目标不是省体积，而是让第一次提交更容易读、后续历史更清楚。

## 已验证体量

当前目录体量大致如下：

```text
src       240 files   2.47 MB
docs       51 files   0.14 MB
tools      49 files   7.65 MB
external  433 files   6.61 MB
```

`external` 内部分布：

```text
decompiled-runtime   345 files   3.95 MB
ilspy                 56 files   1.55 MB
recovered             32 files   1.11 MB
```

同时，`git status` 当前未跟踪总量为：

```text
545 files
```

其中：

```text
external 421
src       58
docs      51
tools     11
```

这说明第一次提交如果不分批，逆向资料会淹没主工程改动。

## 推荐第一批范围

第一批建议只包含：

1. `src/WR.OriginalUiHost`
2. `src/WR.OriginalWRobot`
3. `docs`
4. `tools/layout`
5. `tools/diagnostics/src`
6. `.gitignore`
7. `README.md`
8. `build-uihost.bat`
9. `run-uihost-latest.bat`

### 第一批目的

让远端先具备：

- 主宿主工程
- 原版主程序对照工程
- 中文推进文档
- 构建与运行入口
- 诊断源码

也就是先把“怎么看、怎么编、怎么延续开发”这三件事立住。

## 推荐第二批范围

第二批再纳入：

1. `external/decompiled-runtime`
2. `external/ilspy`
3. `external/recovered`

### 第二批目的

把完整逆向对照资料补齐，方便：

- 查原版主链
- 查资源映射
- 查类型与设置来源
- 做后续能力层审计

## 为什么不建议第一批直接全推

原因有三条：

1. 第一提交应该先突出主工程和项目意图
2. 大量逆向资料会冲淡真正的起点改动
3. 后续如果需要单独整理 `external`，分批历史更容易追

## 当前建议的首推顺序

建议这样推进：

1. 先 `git add` 第一批范围
2. 复查 `git status`
3. 完成 first commit
4. 再单独纳入 `external`
5. 完成 second commit

## 第一批提交意图

第一批提交信息建议围绕：

> initialize WR.Next host workspace, docs, build layout and staging rules

第二批提交信息建议围绕：

> add decompiled runtime and original reference materials

## 一句话判断

第一推的目标不是“尽量多”，而是：

> 先让别人一进仓库就能看懂项目主线，再逐步补齐资料层。

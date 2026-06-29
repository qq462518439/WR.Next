# 模式设置页 WRotation 偏置审计收口

## 结论

当前 `WR.OriginalUiHost` 的“模式选择 -> 设置页”主链里，原先存在两处会干扰多产品真实切换结果的 `WRotation` 偏置：

1. 进入模式选择页时，强制把 `LastProductSelected` 改成 `WRotation`
2. 选中其他产品后，如果没有立即拿到 `WRotation.*` 设置控件，会自动 fallback 回 `WRotation`

这两个点现在都已在模式选择/设置页链上关闭，改为只记录证据，不再强推 `WRotation`。

## 已完成调整

### 1. 取消模式选择页入口强制写回 `WRotation`

代码位置：

- [OriginalModeSelectionHostControl.xaml.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/Views/InGame/OriginalModeSelectionHostControl.xaml.cs)

变化：

- 原先会把 `wManagerSetting.CurrentSetting.LastProductSelected` 强行改成 `WRotation`
- 现在改为只记录：
  - `preferred-product-observe persisted=...`

含义：

- 模式选择页不再在入口阶段污染原版上次产品选择结果

### 2. 取消产品选择后自动 fallback 回 `WRotation`

代码位置：

- [OriginalModeSelectionTakeoverAdapter.cs](D:/666/work/WR.Next/src/WR.OriginalUiHost/Adapters/OriginalModeSelectionTakeoverAdapter.cs)

变化：

- 原先 `EnsureProductLoaded(...)` 会优先选 `WRotation`
- 且当当前设置控件不是 `WRotation.*` 时，会再次触发一次 `WRotation` 选择
- 现在改为：
  - 优先尊重当前 `SelectedItem`
  - 如果存在 `WRotation`，仅记录 `fallback-disabled ...`
  - 不再自动回切

含义：

- 多产品设置页切换证据现在更接近真实结果
- 后续看到的 `settingsType / settingsHostChildType / controlType` 不会再被 `WRotation` 自动覆盖

## 当前边界

这次已完成：

- 收掉模式选择/设置页主链上的 `WRotation` 强推逻辑
- 保留日志证据，便于继续核对真实切换结果

这次未完成：

- 未处理“游戏中页”为战斗测试链保留的 `WRotation` 专用逻辑
- 未修复 `Archaeologist / Prospecting / Tracker` 等产品缺依赖加载失败
- 未证明所有产品都具备独立设置控件

## 下一步

按顺序继续应做：

1. 用新增日志核对多产品切换后的真实结果
2. 分离“无设置控件”和“有设置控件但挂载失败”两类问题
3. 再决定是否进入产品依赖缺口补齐

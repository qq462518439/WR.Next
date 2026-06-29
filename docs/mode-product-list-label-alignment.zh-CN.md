# 模式产品列表显示名对齐原版

## 结论

这次不是改功能链，而是补一个直接影响人工体感的原版细节：

- 模式产品列表不再只显示技术名
- 改为按原版规则优先显示：
  - `产品名 - 显示名`

这会让模式选择页更像原版，而不是一串 DLL 名单。

## 已确认原版依据

原始源码位置：

- [UserControlTabMain.cs](D:\666\work\WR.Next\external\decompiled-runtime\wManager\wManager.Wow.Forms\UserControlTabMain.cs)

原版 `_0006()` 构造产品列表时的规则已确认：

1. 先取产品文件名去掉 `.dll`
2. 再拼出：
   - `产品名 + "Description"`
3. 调 `Translate.Get(...)`
4. 如果翻译结果和 key 不同：
   - 列表显示 `产品名 - 翻译结果`
5. 如果没有翻译：
   - 只显示产品名

## 本次落地

代码位置：

- [OriginalModeSelectionTakeoverAdapter.cs](D:\666\work\WR.Next\src\WR.OriginalUiHost\Adapters\OriginalModeSelectionTakeoverAdapter.cs)

新增：

- `BuildOriginalProductLabel(string productName)`

当前规则：

1. 扫描 `Products` 目录里的 dll
2. 取文件名去扩展名
3. 读取 `Translate.Get(productName + "Description")`
4. 有翻译则生成：
   - `产品名 - 描述翻译`
5. 无翻译则保留：
   - `产品名`

## 为什么这一步重要

虽然这不是“功能成败”级问题，但它会直接影响：

- 模式页第一眼是否像原版
- 产品列表是否像真实产品清单
- 人工切产品时是否更容易辨认

也就是你反复强调的那种：

- 越抄细节，人工体感测试越顺

## 兼容性说明

这次没有破坏现有选择同步链：

- 现有选择解析仍会按 ` - ` 前半段还原产品名
- 所以产品切换、设置页同步逻辑仍然兼容

## 当前边界

这次只对齐：

- 模式产品列表显示文案规则

这次不涉及：

- 产品排序改造
- 产品图标改造
- 产品内部设置页内容改造

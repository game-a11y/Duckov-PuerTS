# 更新记录

本文件记录本项目所有重要变更。

格式基于 [Keep a Changelog](https://keepachangelog.com/zh-CN/1.0.0/)，
版本号遵循 [Semantic Versioning](https://semver.org/lang/zh-CN/)。

## [Unreleased]

### 新增

- 添加 `VersionChecker`，在 `OnAfterSetup` 中自动检测 `info.ini` 版本与项目版本是否一致
- `info.ini` 添加 `version` 和 `tags` 字段，游戏 `ModManager` 自动解析到 `ModInfo`
- 添加 PowerShell 编译脚本 (`build.ps1`) 和打包脚本 (`package.ps1`)

### 重构

- `postbuild.bat` 重构为 `postbuild.ps1`，支持跨平台执行
- 版本号统一放在 `Directory.Build.props` 中管理，两个子项目通过 `$(ModVersion)` / `$(RuntimeVersion)` 引用

### 修复

- 修复接口返回类型 nullable 不匹配（CS8766：`ILoader` / `IResolvableLoader` 返回 `string?`）
- `postbuild.ps1` 先创建发布目录，防止首次构建因目录不存在而失败

### 变更

- 发布目录 LICENSE 重命名为带标识的文件名（`Puerts+V8-LICENSE.txt`、`Duckov-PuerTS-LICENSE.txt`）
- 添加项目元数据（`Authors`、`Copyright`）
- `postbuild.ps1` 增加 `CHANGELOG.md` 复制到发布目录

### 文档

- 更新 `README.md` 构建说明和项目结构

## [V0.4] - 2026-05-28

### 变更

- 更新 PuerTS_V8 到 v3.0.2
- 更新 PuerTS_Core 到 v3.0.2

### 重构

- 从已弃用的 `JsEnv` 迁移到 `ScriptEnv` + `BackendV8`
- 重构 `ResLoader` 路径解析，`PathToBinDir` 增加 `Assembly.Location` fallback
- 拆分上游运行时为独立项目 `PuerTSRuntime`，避免每次 mod 迭代重新编译 100+ 源文件

### 修复

- 添加 JS 执行错误边界，`Awake` 和委托调用增加 `try-catch`
- 添加 `Update` 调用 `ScriptEnv.Tick()`，确保 JS GC 和调试器正常工作
- `Dispose` 后将 `jsEnv` 置 null 避免僵尸引用
- 移除自定义 `PreserveAttribute` 避免与 Unity 内置冲突
- 为可能返回 null 的方法添加 `?` nullable 注解

### 移除

- 移除已弃用的 CommonJS 支持（`CommonJS.cs`、`puer-commonjs`、`ResLoader` 中的冗余路径）

### 文档

- 更新项目指南
- 移除 README 中关于复制 `puer-commonjs` 的构建步骤

## [V0.3] - 2026-02-18

### 变更

- 更新依赖到 Unity_v3.0.0
- 更新 PuerTS_Core 到 v3.0.2
- JS 端从 `AddComponent` 方式改为类变量模式

### 新增

- JsEnv 自动注册 JavaScript 中 `ModBehaviour` 的子类
- 从专用脚本文件夹加载脚本
- `ResLoader` 资源加载器

### 移除

- 示例/样板代码

## [V0.2] - 2025-10-25

### 变更

- 更新项目信息

### 新增

- 在 JavaScript 中实现 `ModBehaviour`
- 从脚本文件夹加载脚本

### 文档

- 更新 README

## [V0.1] - 2025-10-25

### 新增

- 初始项目搭建
- PuerTS 集成，编译为类库
- 构建产物自动复制到 mod 文件夹
- PuerTS CommonJS 依赖


<!-- Links -->

[V0.4]: https://github.com/game-a11y/Duckov-PuerTS/releases/tag/v0.4
[V0.3]: https://github.com/game-a11y/Duckov-PuerTS/releases/tag/v0.3
[V0.2]: https://github.com/game-a11y/Duckov-PuerTS/releases/tag/v0.2
[V0.1]: https://github.com/game-a11y/Duckov-PuerTS/releases/tag/v0.1

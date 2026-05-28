# 更新记录

本文件记录本项目所有重要变更。

格式基于 [Keep a Changelog](https://keepachangelog.com/zh-CN/1.0.0/)，
版本号遵循 [Semantic Versioning](https://semver.org/lang/zh-CN/)。

## [Unreleased]

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

## [0.3] - 2025

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

## [0.2]

### 变更

- 更新项目信息

### 新增

- 在 JavaScript 中实现 `ModBehaviour`
- 从脚本文件夹加载脚本

### 文档

- 更新 README

## [0.1] - 2025

### 新增

- 初始项目搭建
- PuerTS 集成，编译为类库
- 构建产物自动复制到 mod 文件夹
- PuerTS CommonJS 依赖

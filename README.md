# Duckov-PuerTS

鸭科夫 JavaScript 脚本支持 MOD。

使用
[Tencent/puerts: PUER(普洱) Typescript](https://github.com/Tencent/puerts)
框架。


## 构建与安装

- VS 2022 + .NET桌面开发环境。
    也可以使用你喜欢的 IDE，配合 DotNet SDK 进行开发。
- PuerTS [Unity_v3.0.0-preview0](https://github.com/Tencent/puerts/releases/tag/Unity_v3.0.0-preview0)  
  项目目前使用的组合是：`Core + V8`。你可以替换或添加你想要的后端支持。

### 构建

- 拉取项目到本地
- 修改 `PuerTS.csproj` 中的 `DuckovPath` 为你本地的鸭科夫游戏目录
- 用 VS 2022 打开 `PuerTS\PuerTS.sln`
- 下载 PuerTS [Unity_v3.0.0-preview0](https://github.com/Tencent/puerts/releases/tag/Unity_v3.0.0-preview0)
  - 下载 `PuerTS_Core_3.0.0-preview0.tar.gz` 和 `PuerTS_V8_3.0.0-preview0.tar.gz`
  - 找个地方解压得到 `upm` 文件夹
  - 复制 `下载的\upm\Plugins` 到 `PuerTS\upm\Plugins` 目录下，覆盖同名文件夹。  
    这里实际上需要的是 `upm\Plugins\x86_64` 中的 DLL 文件，因此你可以只添加这些文件
- 构建项目。检查 `PuerTS\PuerTS\` 中是否生成的 mod 文件。
- 安装 mod 到游戏中。

### 安装

你可以手动复制 mod 文件夹(`PuerTS\PuerTS\`)到游戏的 `Mods` 目录下（`Escape from Duckov\Duckov_Data\Mods\`）。
或者建立一个软连接：
调整游戏路径和 mod 开发路径。打开 cmd 运行：

```cmd
mklink /d "D:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov_Data\Mods\PuerTS"  D:\Duckov-PuerTS\PuerTS\PuerTS
```


## Mod 开发

项目目录说明：

- `PuerTS\`: PuerTS mod 主体代码
  - `PuerTS\`: mod 发布版文件夹。即应该安装到游戏中的文件
  - `upm\`: 上游 Tencent/PuerTS 依赖文件夹。仅包含纯文本的源码，不包含二进制文件。
  - `ModBehaviour.cs`: mod 主入口
  - `PuerTS.csproj`: mod 项目文件
  - `info.ini`: mod 信息文件
  - `preview.png`: mod 预览图
- LICENSE: 许可证文件
- README.md: 本文件

## 参考资料

- [xvrsl/duckov_modding](https://github.com/xvrsl/duckov_modding)
- [在Javascript调用C | PUER Typescript](https://puerts.github.io/docs/puerts/unity/tutorial/js2cs)
- [在C#中调用Javascript | PUER Typescript](https://puerts.github.io/docs/puerts/unity/tutorial/cs2js)

### 更新或切换 PuerTS 版本

- 下载 Core 和需要的语言支持包，解压 upm 文件夹到 `PuerTS\` 中。
- 修复编译错误：CS8957，鸭科夫的 mod 使用 netstandard2.1，而 PuerTS 默认使用 net8.0，所以要做出一些调整。
  这里只需加一个中间变量，把三元表达式展开为 if 即可。  
  参考 0f3d11e 提交。
- 复制对应版本的 [`puer-commonjs\*.mjs`](https://github.com/Tencent/puerts/tree/f1088993639c353e9d2a0fb8d792592aa8bd1538/unity/Assets/commonjs/upm/Runtime/Resources/puer-commonjs) 到
  `upm\Runtime\Resources\puer-commonjs\*`。
- 尝试构建，并修复错误。


## Licence

本项目采用 MIT 许可证，详情见 [LICENSE](LICENSE) 文件。

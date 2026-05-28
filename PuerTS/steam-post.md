建议与反馈 | Feedback & Suggestions

[h1]PuerTS 脚本框架 — 用 JavaScript 为鸭科夫编写模组[/h1]

[b]PuerTS[/b] 是一个嵌入 V8 JavaScript 引擎的脚本框架模组，让你可以用 JavaScript 来编写鸭科夫模组，无需 C# 编译环境。

[list]
[*] 将 [b].mjs[/b] 脚本放入 [b]Mods\PuerTS\Scripts\ [/b] 即可加载
[*] 通过全局对象 [b]CS[/b] 访问 C# API（如游戏中的类和对象）
[*] 支持 V8 Inspector 调试（默认端口 9229）
[/list]

项目地址：[url=https://github.com/game-a11y/Duckov-PuerTS]github.com/game-a11y/Duckov-PuerTS[/url]

[b]当前限制：[/b]
[list]
[*] 当前仅支持 ES Module 格式（.mjs），不支持 CommonJS
[*] V8 Inspector 端口固定为 9229，无法通过配置文件修改
[/list]

══════════════════════════════════════════════════

[h1]PuerTS Scripting Framework — Write Duckov mods in JavaScript[/h1]

[b]PuerTS[/b] embeds a V8 JavaScript engine into Duckov, letting you write mods in JavaScript without a C# build environment.

[list]
[*] Drop [b].mjs[/b] scripts into [b]Mods\PuerTS\Scripts\ [/b] to load
[*] Access C# APIs via the [b]CS[/b] global object
[*] Debug with V8 Inspector (default port 9229)
[/list]

Repository: [url=https://github.com/game-a11y/Duckov-PuerTS]github.com/game-a11y/Duckov-PuerTS[/url]

[b]Current limitations:[/b]
[list]
[*] Only ES Module format (.mjs) is supported (no CommonJS)
[*] V8 Inspector port is fixed at 9229, no config file support yet
[/list]

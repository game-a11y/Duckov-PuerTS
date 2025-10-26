
function log(msg) {
    var log_with_prefix = `[PuerTS.js] ${msg}`;
    // 两种日志输出效果一样
    console.log(log_with_prefix);
    //CS.System.Console.WriteLine(log_with_prefix);
}


/**
 * NOTE: 必须导出此 OnEnable/OnDisable/onDestroy 函数。
 *      如果要变更函数名，请同步修改 C# 端的绑定代码
 */
class JsBehaviour {
    constructor(bindTo) {
        this.bindTo = bindTo;
        this.bindTo.JsOnEnable = () => this.OnEnable();
        this.bindTo.JsOnDisable = () => this.OnDisable();
        this.bindTo.JsOnDestroy = () => this.onDestroy();

        log(`Awake() called`);
        log('Hello world! from PuerTS in Duckov!');
    }

    OnEnable() {
        log(`OnEnable() called`);
    }

    OnDisable() {
        log(`OnDisable() called`);
    }

    onDestroy() {
        log(`OnDestroy() called`);
    }
}

/**
 * NOTE: 必须导出此 init 函数，以供初始化 js-C# 绑定
 */
export function init(bindTo) {
    new JsBehaviour(bindTo);
}

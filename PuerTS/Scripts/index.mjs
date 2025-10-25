/* 
    必须导出 mod_Awake、mod_OnEnable、mod_OnDisable 三个函数，作为 mod 的生命周期函数。
*/

function log(msg) {
    var log_with_prefix = `[PuerTS.js] ${msg}`;
    console.log(log_with_prefix);
    //CS.System.Console.WriteLine(log_with_prefix);
}

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


export function init(bindTo) {
    new JsBehaviour(bindTo);
}

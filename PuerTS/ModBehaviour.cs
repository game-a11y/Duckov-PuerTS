using Puerts;
using System;
using UnityEngine;

namespace PuerTS
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        // TODO: 或许可以使用父类的 ModInfo info 属性来获取模块名称
        /// <summary>
        /// 模块名称
        /// </summary>
        const string MOD_NAME = "PuerTS";
        const int DebugPort = 9229;

        public Action? JsOnEnable;
        public Action? JsOnDisable;
        public Action? JsOnDestroy;

        static ScriptEnv? scriptEnv;

        void Awake()
        {
            Debug.Log($"[{MOD_NAME}]: MOD Start.");

            Debug.Log($"[{MOD_NAME}]: ScriptEnv init with debugPort={DebugPort}");

            var loader = new ResLoader();
            var backend = new BackendV8(loader);
            scriptEnv = new ScriptEnv(backend, DebugPort);

            // NOTE: `Scripts/` 文件夹已经在搜索路径中了，脚本路径无需再添加前缀
            var init = scriptEnv.ExecuteModule("index.mjs").Get<Action<MonoBehaviour>>("init");

            if (init != null) init(this);
        }

        void OnDestroy()
        {
            if (JsOnDestroy != null) JsOnDestroy();
            JsOnEnable = null;
            JsOnDisable = null;
            JsOnDestroy = null;

            if (scriptEnv != null)
            {
                scriptEnv.Dispose();
                scriptEnv = null;
            }
            Debug.Log($"[{MOD_NAME}]: MOD Destroy.");
        }

        void OnEnable()
        {
            Debug.Log($"[{MOD_NAME}]: MOD Enable.");
            if (JsOnEnable != null) JsOnEnable();
        }

        void OnDisable()
        {
            if (JsOnDisable != null) JsOnDisable();
            Debug.Log($"[{MOD_NAME}]: MOD Disable.");
        }

    }
}

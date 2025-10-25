using Puerts;
using System;
using UnityEngine;

namespace PuerTS
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        const string MOD_NAME = "PuerTS";
        const int DebugPort = 9229;

        public Action? JsOnEnable;
        public Action? JsOnDisable;
        public Action? JsOnDestroy;

        static JsEnv? jsEnv;

        void Awake()
        {
            Debug.Log($"[{MOD_NAME}]: MOD Start.");

            Debug.Log($"[{MOD_NAME}]: JsEnv init with debugPort={DebugPort}");
            jsEnv = new JsEnv(new ResLoader(), DebugPort);

            // `Scripts/` 已经在搜索路径中了，无需再添加
            //jsEnv.ExecuteModule("index.mjs");
            var init = jsEnv.ExecuteModule<Action<MonoBehaviour>>("index.mjs", "init");

            if (init != null) init(this);
        }

        void OnDestroy()
        {
            if (JsOnDestroy != null) JsOnDestroy();
            JsOnEnable = null;
            JsOnDisable = null;
            JsOnDestroy = null;

            if (jsEnv != null) jsEnv.Dispose();
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

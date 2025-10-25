using Duckov.UI;
using Duckov.Utilities;
using ItemStatsSystem;
using Puerts;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PuerTS
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        const string MOD_NAME = "PuerTS";

        JsEnv? gJsEnv;

        void Awake()
        {
            Debug.Log($"[{MOD_NAME}]: MOD Start.");

            Debug.Log($"[{MOD_NAME}]: JsEnv init.");
            gJsEnv = new JsEnv(new ResLoader());
            // `Scripts/` 已经在搜索路径中了，无需再添加
            gJsEnv.ExecuteModule("index.js");
        }

        void OnDestroy()
        {
            if (gJsEnv != null)
                gJsEnv.Dispose();
            Debug.Log($"[{MOD_NAME}]: MOD Destroy.");
        }

        void OnEnable()
        {
            Debug.Log($"[{MOD_NAME}]: MOD Enable.");
        }

        void OnDisable()
        {
            Debug.Log($"[{MOD_NAME}]: MOD Disable.");
        }

    }
}

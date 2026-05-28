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

        static ScriptEnv? scriptEnv;

        protected override void OnAfterSetup()
        {
            Debug.Log($"[{info.name}] ==== ModInfo ====");
            Debug.Log($"[{info.name}] {info.displayName} v{info.version}");
            Debug.Log($"[{info.name}]   tags: #{info.tags}");
            Debug.Log($"[{info.name}]   description: {info.description}");
            Debug.Log($"[{info.name}]   isSteamItem: {info.isSteamItem};  steamId: {info.publishedFileId}");
            Debug.Log($"[{info.name}]   path: {info.path}");
            VersionChecker.WarnIfMismatch(info.version);
        }

        void Awake()
        {
            Debug.Log($"[{MOD_NAME}]: MOD Start.");

            Debug.Log($"[{MOD_NAME}]: ScriptEnv init with debugPort={DebugPort}");

            try
            {
                var loader = new ResLoader();
                var backend = new BackendV8(loader);
                scriptEnv = new ScriptEnv(backend, DebugPort);

                // NOTE: `Scripts/` 文件夹已经在搜索路径中了，脚本路径无需再添加前缀
                var init = scriptEnv.ExecuteModule("index.mjs").Get<Action<MonoBehaviour>>("init");

                init?.Invoke(this);
            }
            catch (Exception e)
            {
                Debug.LogError($"[{MOD_NAME}]: JS init failed - {e.Message}");
                if (scriptEnv != null)
                {
                    scriptEnv.Dispose();
                    scriptEnv = null;
                }
            }
        }

        void Update()
        {
            scriptEnv?.Tick();
        }

        void OnDestroy()
        {
            try { JsOnDestroy?.Invoke(); }
            catch (Exception e) { Debug.LogError($"[{MOD_NAME}]: OnDestroy error - {e.Message}"); }
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
            try { JsOnEnable?.Invoke(); }
            catch (Exception e) { Debug.LogError($"[{MOD_NAME}]: OnEnable error - {e.Message}"); }
        }

        void OnDisable()
        {
            try { JsOnDisable?.Invoke(); }
            catch (Exception e) { Debug.LogError($"[{MOD_NAME}]: OnDisable error - {e.Message}"); }
            Debug.Log($"[{MOD_NAME}]: MOD Disable.");
        }

    }
}

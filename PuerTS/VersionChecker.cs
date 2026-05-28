using System;
using System.Reflection;
using UnityEngine;

namespace PuerTS
{
    internal static class VersionChecker
    {
        private static readonly Version AssemblyVersion =
            Assembly.GetExecutingAssembly().GetName().Version;

        public static void WarnIfMismatch(string modInfoVersion)
        {
            if (AssemblyVersion == null || string.IsNullOrEmpty(modInfoVersion))
                return;

            var asmStr = $"{AssemblyVersion.Major}.{AssemblyVersion.Minor}.{AssemblyVersion.Build}";

            if (modInfoVersion != asmStr)
            {
                Debug.LogWarning(
                    $"[PuerTS] version 不一致: info.ini 中 \"{modInfoVersion}\"，" +
                    $"项目版本 \"{asmStr}\"，请更新 info.ini"
                );
            }
        }
    }
}

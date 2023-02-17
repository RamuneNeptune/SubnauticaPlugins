using System;
using HarmonyLib;

namespace Ramune.OxygenCylinders
{
    [HarmonyPatch(typeof(Player), "Awake")]
    public class PlayerPatch
    {
        [HarmonyPrefix]
        internal static void Prefix(Player __instance)
        {
            __instance.gameObject.EnsureComponent<NormalQuickUseDetector>();
            __instance.gameObject.EnsureComponent<LargeQuickUseDetector>();
        }
    }
}

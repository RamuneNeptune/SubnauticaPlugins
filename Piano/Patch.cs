
using HarmonyLib;

namespace Ramune.CyclopsStasisDecoys
{
    [HarmonyPatch(typeof(CyclopsDecoyLauncher), nameof(CyclopsDecoyLauncher.LaunchDecoy))]
    public static class CyclopsDecoyLauncherPatch
    {
        public static void Prefix(CyclopsDecoyLauncher __instance) 
        {  // Must be Prefix because '__instance.decoyPrefab' is already fired at Postfix time, making the patch useless at Postfix
            __instance.decoyPrefab.EnsureComponent<DecoyStasisHandler>(); // Adding the custom component (the stasis one) to the Decoy (*before* being fired)
        }
    }

    [HarmonyPatch(typeof(PlayerTool))]
    internal class PlayerToolPatches
    {
        [HarmonyPatch(nameof(PlayerTool.animToolName))]
        [HarmonyPatch(MethodType.Getter)]
        public static void Postfix(PlayerTool __instance, ref string __result)
        {
            if(__instance.pickupable?.GetTechType() == LongBlade.thisTechType) __result = "knife";
        }
    }
}
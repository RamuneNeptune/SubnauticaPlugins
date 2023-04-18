
using HarmonyLib;

namespace Ramune.SolarPanelTweaker
{
    [HarmonyPatch(typeof(SolarPanel), nameof(SolarPanel.Start))]
    public static class PlayerAwakePatch
    {
        [HarmonyPostfix]
        public static void Postfix(Player __instance)
        {
            __instance.gameObject.EnsureComponent<SolarPanelTweakController>();
        }
    }
}
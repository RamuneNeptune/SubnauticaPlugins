
using HarmonyLib;

namespace Ramune.SolarPanelTweaker
{
    [HarmonyPatch(typeof(SolarPanel), nameof(SolarPanel.Start))]
    public static class SolarPanelPatch
    {
        [HarmonyPostfix]
        public static void Postfix(SolarPanel __instance)
        {
            __instance.gameObject.EnsureComponent<SolarPanelTweakController>();
        }
    }
}
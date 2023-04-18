
using HarmonyLib;

namespace Ramune.NoRadiationBlur
{
    [HarmonyPatch(typeof(RadiationsScreenFXController), nameof(RadiationsScreenFXController.Start))]
    public static class RadiationsScreenFXControllerPatch
    {
        [HarmonyPostfix]
        public static void Postfix(RadiationsScreenFXController __instance)
        {
            __instance.minRadiation = 0f;
            __instance.radiationMultiplier = 0f;
        }
    }
}
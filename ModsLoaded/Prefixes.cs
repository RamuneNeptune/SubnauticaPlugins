
using HarmonyLib;

namespace Ramune.ModsLoaded
{
    [HarmonyPatch(typeof(uGUI_OptionsPanel), "AddKeyRedemptionTab")]
    public static class OptionsPanel_AddKeyRedemptionTab_Patch
    {
        // Prefix method that runs before the original AddKeyRedemptionTab method
        public static bool Prefix(ref bool __runOriginal)
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(uGUI_OptionsPanel), "AddTroubleshootingTab")]
    public static class OptionsPanel_AddTroubleshootingTab_Patch
    {
        // Prefix method that runs before the original AddTroubleshootingTab method
        public static bool Prefix(ref bool __runOriginal)
        {
            return false;
        }
    }
}

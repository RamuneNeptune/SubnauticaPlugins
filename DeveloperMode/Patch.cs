
using HarmonyLib;


namespace Ramune.DeveloperMode
{
    [HarmonyPatch(typeof(IngameMenu), nameof(IngameMenu.Open))]
    public class IngameMenu_Patch
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            IngameMenu.main.developerMode = true;
            IngameMenu.main.developerButton.gameObject.SetActive(true);
        }
    }
}

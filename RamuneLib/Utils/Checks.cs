using System.Linq;

namespace RamuneLib.Utils
{
    public static class Checks
    {
        public static bool WorkbenchModsLoaded(string currentModGUID)
        {
            currentModGUID = "com.ramune." + currentModGUID;
            string[] mods = new[] { "com.ramune.LithiumBatteries", "com.ramune.KioniteBatteries", "com.ramune.SeaglideUpgrades", "com.ramune.MegaO2Tank", "com.ramune.OrganizedWorkbench" };
            bool isLoaded = mods.Any(mod => !mod.Equals(currentModGUID) && BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(mod));

            return isLoaded;
        }

        public static bool ModLoaded(string guid)
        {
            if(BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(guid)) return false;
            return true;
        }
    }
}
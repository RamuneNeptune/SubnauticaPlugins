using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using System.Collections.Generic;
using static Equipment;
using System.Linq;

namespace Ramune.OrganizedWorkbench
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class OrganizedWorkbench : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.OrganizedWorkbench";
        private const string pluginName = "Organized Workbench";
        private const string versionString = "1.0.1";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            if (!RamuneLib.Utils.Checks.WorkbenchModsLoaded("OrganizedWorkbench"))
            {
                RamuneLib.Utils.Sort.Workbench();
            }
        }
    }
}

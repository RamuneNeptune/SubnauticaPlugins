using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using Ramune.KioniteBatteries;
using SMLHelper.V2.Handlers;

namespace Ramune.KioniteBatteries
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class KioniteBatteries : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.KioniteBatteries";
        private const string pluginName = "Kionite Batteries";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            Kyanicphur kyanicphur = new Kyanicphur();
            KioniteBatteryItem battery = new KioniteBatteryItem();
            KionitePowercellItem powercell = new KionitePowercellItem();
            kyanicphur.Patch();
            battery.Patch();
            powercell.Patch();


            Atlas.Sprite power = SpriteManager.Get(TechType.Battery);
            Atlas.Sprite battery_ = SpriteManager.Get(TechType.Battery);
            Atlas.Sprite powercell_ = SpriteManager.Get(TechType.PowerCell);


            string[] InPowerTab = new string[] { "Power" };

            if (RamuneLib.Utils.Checks.WorkbenchModsLoaded("KioniteBatteries"))
            {
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Power", "Power", power);
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Power cells", "Power cells", powercell_, InPowerTab);
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Batteries", "Batteries", battery_, InPowerTab);
            }
            else
            {
                RamuneLib.Utils.Sort.Workbench();
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Power", "Power", power);
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Power cells", "Power cells", powercell_, InPowerTab);
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Batteries", "Batteries", battery_, InPowerTab);
            }
        }
    }
}
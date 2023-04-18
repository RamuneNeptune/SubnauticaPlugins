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
using Microsoft.SqlServer.Server;
using SMLHelper.V2.Options.Attributes;
using static RootMotion.FinalIK.GenericPoser;
using SMLHelper.V2.Json;

namespace Ramune.KioniteBatteries
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class KioniteBatteries : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.KioniteBatteries";
        private const string pluginName = "Kionite Batteries";
        private const string versionString = "1.0.1";

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
    [Menu("Kionite Batteries")]
    public class Config : ConfigFile
    {
        [Slider("<color=#00FF00>Kionite</color> battery energy", Format = "{0:F2}", DefaultValue = 750f, Min = 1f, Max = 3000f, Step = 1f)]
        public float batteryEnergy = 1f;

        [Slider("<color=#00FF00>Kionite</color> powercell energy", Format = "{0:F2}", DefaultValue = 1500f, Min = 1f, Max = 3000f, Step = 1f)]
        public float powercellEnergy = 1f;
    }
}
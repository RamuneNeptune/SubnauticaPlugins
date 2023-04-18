
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Microsoft.SqlServer.Server;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;
using static RootMotion.FinalIK.GenericPoser;

namespace Ramune.LithiumBatteries
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class LithiumBatteries : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.LithiumBatteries";
        private const string pluginName = "Lithium Batteries";
        private const string versionString = "1.0.1";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            LithiumBatteryItem lithiumBatteryItem = new LithiumBatteryItem();
            LithiumPowercellItem lithiumPowercellItem = new LithiumPowercellItem();
            lithiumBatteryItem.Patch();
            lithiumPowercellItem.Patch();

            IonBatteryAlt ionBatteryAlt = new IonBatteryAlt();
            IonPowercellAlt ionPowercellAlt = new IonPowercellAlt();
            ionBatteryAlt.Patch();
            ionPowercellAlt.Patch();


            Atlas.Sprite power = SpriteManager.Get(TechType.Battery);
            Atlas.Sprite battery = SpriteManager.Get(TechType.Battery);
            Atlas.Sprite powercell = SpriteManager.Get(TechType.PowerCell);
            Atlas.Sprite upgrade = SpriteManager.Get(TechType.PrecursorIonBattery);


            string[] InPowerTab = new string[] { "Power" };

            if (RamuneLib.Utils.Checks.WorkbenchModsLoaded("LithiumBatteries"))
            {
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Power", "Power", power);
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Power cells", "Power cells", powercell, InPowerTab);
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Batteries", "Batteries", battery, InPowerTab);
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Upgrades", "Upgrades", upgrade, InPowerTab);
            }
            else
            {
                RamuneLib.Utils.Sort.Workbench();
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Power", "Power", power);
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Power cells", "Power cells", powercell, InPowerTab);
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Batteries", "Batteries", battery, InPowerTab);
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Upgrades", "Upgrades", upgrade, InPowerTab);
            }
        }
    }
    [Menu("Lithium Batteries")]
    public class Config : ConfigFile
    {
        [Slider("<color=#FFFF00>Lithium</color> battery energy", Format = "{00:0}", DefaultValue = 200f, Min = 1f, Max = 3000f, Step = 1f)]
        public float batteryEnergy = 1f;

        [Slider("<color=#FFFF00>Lithium</color> powercell energy", Format = "{00:0}", DefaultValue = 400f, Min = 1f, Max = 3000f, Step = 1f)]
        public float powercellEnergy = 1f;
    }
}
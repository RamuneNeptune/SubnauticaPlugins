using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SMLHelper.V2.Handlers;

namespace SortedWorkbench
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class SeaglideUpgrades : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.SeaglideUpgrades";
        private const string pluginName = "Seaglide Upgrades";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            var doTheDo = new SharedProject.Do();
            StartCoroutine(doTheDo.DoTheCoroutine());

            string[][] equipArray = new string[][] {
                new string[] { "LithiumIonBattery" },
                new string[] { "HeatBlade" },
                new string[] { "PlasteelTank" },
                new string[] { "HighCapacityTank" },
                new string[] { "UltraGlideFins" },
                new string[] { "SwimChargeFins" },
                new string[] { "RepulsionCannon" },
            };

            string[][] vehicleArray = new string[][] {
                new string[] { "CyclopsHullModule2" },
                new string[] { "CyclopsHullModule3" },
                new string[] { "SeamothHullModule2" },
                new string[] { "SeamothHullModule3" },
                new string[] { "ExoHullModule2" }
            };

            foreach (string[] item in equipArray)
            {
                CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, item);
            }

            foreach (string[] item in vehicleArray)
            {
                CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, item);
            }

            Atlas.Sprite equip = SpriteManager.Get(TechType.Tank);
            Atlas.Sprite vehicle = SpriteManager.Get(TechType.Constructor);

            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Equipment", "Equipment", equip);
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Modules", "Modules", vehicle);

            List<TechType> equTypes = new List<TechType>();
            equTypes.Add(TechType.HeatBlade);
            equTypes.Add(TechType.PlasteelTank);
            equTypes.Add(TechType.HighCapacityTank);
            equTypes.Add(TechType.UltraGlideFins);
            equTypes.Add(TechType.SwimChargeFins);
            equTypes.Add(TechType.RepulsionCannon);

            List<TechType> vehTypes = new List<TechType>();
            vehTypes.Add(TechType.CyclopsHullModule2);
            vehTypes.Add(TechType.CyclopsHullModule3);
            vehTypes.Add(TechType.ExoHullModule2);
            vehTypes.Add(TechType.VehicleHullModule2);
            vehTypes.Add(TechType.VehicleHullModule3);

            foreach (TechType techType in equTypes)
            {
                CraftTreeHandler.AddCraftingNode(CraftTree.Type.Workbench, techType, Equipment);
            }
            foreach (TechType techType in vehTypes)
            {
                CraftTreeHandler.AddCraftingNode(CraftTree.Type.Workbench, techType, Modules);
            }
        }
    }
}

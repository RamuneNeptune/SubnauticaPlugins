using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMLHelper.V2.Handlers;

namespace RamuneLib.Utils
{
    public static class Sort
    {
        public static void Workbench()
        {
            Atlas.Sprite tool = SpriteManager.Get(TechType.Builder);
            Atlas.Sprite equip = SpriteManager.Get(TechType.Tank);
            Atlas.Sprite vehicle = SpriteManager.Get(TechType.Constructor);

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

            Dictionary<string, string> items = new Dictionary<string, string>()
            {
                {"LithiumIonBattery","Equipment"},
                {"HeatBlade","Equipment"},
                {"PlasteelTank","Equipment"},
                {"HighCapacityTank","Equipment"},
                {"UltraGlideFins","Equipment"},
                {"SwimChargeFins","Equipment"},
                {"RepulsionCannon","Equipment"},
                {"CyclopsHullModule2","Module"},
                {"CyclopsHullModule3","Module"},
                {"SeamothHullModule2","Module"},
                {"SeamothHullModule3","Module"},
                {"ExoHullModule2","Module"}
            };


            foreach (string[] item in equipArray.Concat(vehicleArray))
            {
                CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, item);
            }

            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Tools", "Tools", tool);
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Equipment", "Equipment", equip);
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Modules", "Modules", vehicle);

            string[] Tools = new string[] { "Tools" };
            string[] Equipment = new string[] { "Equipment" };
            string[] Modules = new string[] { "Modules" };

            Dictionary<TechType, string> workbench = new Dictionary<TechType, string>
            {
                { TechType.HeatBlade, "Tool" },
                { TechType.DiamondBlade, "Tool" },
                { TechType.RepulsionCannon, "Tool" },
                { TechType.PlasteelTank, "Equipment" },
                { TechType.HighCapacityTank, "Equipment" },
                { TechType.UltraGlideFins, "Equipment" },
                { TechType.SwimChargeFins, "Equipment" },
                { TechType.CyclopsHullModule2, "Vehicle" },
                { TechType.CyclopsHullModule3, "Vehicle" },
                { TechType.ExoHullModule2, "Vehicle" },
                { TechType.VehicleHullModule2, "Vehicle" },
                { TechType.VehicleHullModule3, "Vehicle" }
            };

            foreach (var techType in workbench)
            {
                switch (techType.Value)
                {
                    case "Tool":
                        CraftTreeHandler.AddCraftingNode(CraftTree.Type.Workbench, techType.Key, Tools);
                        break;
                    case "Equipment":
                        CraftTreeHandler.AddCraftingNode(CraftTree.Type.Workbench, techType.Key, Equipment);
                        break;
                    case "Vehicle":
                        CraftTreeHandler.AddCraftingNode(CraftTree.Type.Workbench, techType.Key, Modules);
                        break;
                }
            }
        }
    }
}
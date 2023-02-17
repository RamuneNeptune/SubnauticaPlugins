using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using SMLHelper.V2.Utility;
using static Charger;
using UnityEngine;
using System.IO;

namespace Ramune.KioniteBatteries
{
    [HarmonyPatch(typeof(EnergyMixin), nameof(EnergyMixin.Start))]
    public class EnergyMixinPatch
    {
        [HarmonyPrefix]
        public static void Prefix(EnergyMixin __instance)
        {
            //ErrorMessage.AddError("Battery Added");
            if (__instance.compatibleBatteries.Contains(TechType.Battery))
                __instance.compatibleBatteries.Add(KioniteBatteryItem.thisTechType);

            //ErrorMessage.AddError("Powercell Added");
            if (__instance.compatibleBatteries.Contains(TechType.PowerCell))
                __instance.compatibleBatteries.Add(KionitePowercellItem.thisTechType);
        }
    }

    [HarmonyPatch(typeof(EnergyMixin), nameof(EnergyMixin.NotifyHasBattery))]
    public class EnergyMixinNotifyHasBatteryPatch
    {
        [HarmonyPostfix]
        public static void Postfix(ref EnergyMixin __instance, InventoryItem item)
        {
            List<TechType> KionitePowercell = new List<TechType>
            {
                KionitePowercellItem.thisTechType
            };

            if (KionitePowercell.Count == 0) return;

            TechType? itemInSlot = item?.item?.GetTechType();

            if (!itemInSlot.HasValue || itemInSlot.Value == TechType.None)
                return; // Nothing here

            TechType powerCellTechType = itemInSlot.Value;
            bool isKnownModdedPowerCell = KionitePowercell.Find(techType => techType == powerCellTechType) != TechType.None;

            if (isKnownModdedPowerCell)
            {
                int modelToDisplay = 0; // If a matching model cannot be found, the standard PowerCell model will be used instead.
                for (int b = 0; b < __instance.batteryModels.Length; b++)
                {
                    if (__instance.batteryModels[b].techType == powerCellTechType)
                    {
                        modelToDisplay = b;
                        break;
                    }
                }
                __instance.batteryModels[modelToDisplay].model.SetActive(true);
            }
        }
    }


    [HarmonyPatch(typeof(BatteryCharger), nameof(BatteryCharger.Initialize))]
    public class BatteryChargerPatch
    {
        [HarmonyPrefix]
        public static void Prefix(BatteryCharger __instance)
        {
            //ErrorMessage.AddError("BatteryCharger");
            __instance.allowedTech.Add(KioniteBatteryItem.thisTechType);
        }
    }

    [HarmonyPatch(typeof(PowerCellCharger), nameof(PowerCellCharger.Initialize))]
    public class PowerCellChargerPatch
    {
        [HarmonyPrefix]
        public static void Prefix(PowerCellCharger __instance)
        {
            //ErrorMessage.AddError("PowercellCharger");
            __instance.allowedTech.Add(KionitePowercellItem.thisTechType);
        }
    }


    [HarmonyPatch(typeof(Charger), nameof(Charger.OnEquip))]
    public class ChargerPatch
    {
        [HarmonyPostfix]
        public static void Postfix(Charger __instance, string slot, InventoryItem item, Dictionary<string, SlotDefinition> ___slots)
        {
            Texture2D Battery_tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Battery_tex.png"));
            Texture2D Powercell_tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Powercell_tex.png"));
            Texture2D Powercell_illum = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Powercell_illum.png"));

            Texture2D Ion_tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Ion_tex.png"));
            Texture2D Ion_illum = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Ion_illum.png"));

            Texture2D Vanilla_tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Vanilla_tex.png"));
            Texture2D Vanilla_illum = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Vanilla_illum.png"));

            if (___slots.TryGetValue(slot, out SlotDefinition slotDefinition))
            {
                GameObject battery = slotDefinition.battery;  // Get the battery GameObject from the slot definition
                Pickupable pickupable = item.item;  // Get the Pickupable component from the item

                if (battery != null && pickupable != null)  // If both battery and pickupable exist
                {
                    GameObject model;
                    switch (__instance)
                    {
                        case BatteryCharger _:
                            model = pickupable.gameObject.transform.Find("model/battery_01")?.gameObject ?? pickupable.gameObject.transform.Find("model/battery_ion")?.gameObject;
                            if (model != null && model.TryGetComponent(out Renderer ModelRenderer_0) && battery.TryGetComponent(out Renderer ChargerRenderer_0))
                            {
                                if (item.item.name == "KioniteBattery(Clone)")
                                {
                                    ChargerRenderer_0.material.mainTexture = Battery_tex;
                                }else if (item.item.name == "PrecursorIonBattery(Clone)")
                                {
                                    ChargerRenderer_0.material.mainTexture = Ion_tex;
                                    ChargerRenderer_0.material.SetTexture("_Illum", Ion_illum);
                                }else if (item.item.name == "Battery(Clone)")
                                {
                                    ChargerRenderer_0.material.mainTexture = Vanilla_tex;
                                    ChargerRenderer_0.material.SetTexture("_Illum", Vanilla_illum);
                                }
                            }
                            break;
                        case PowerCellCharger _:
                            model = pickupable.gameObject.FindChild("engine_power_cell_01") ?? pickupable.gameObject.FindChild("engine_power_cell_ion");
                            if (model != null && model.TryGetComponent(out Renderer ModelRenderer_1) && battery.TryGetComponent(out Renderer ChargerRenderer_1) && model.TryGetComponent(out MeshFilter ModelMeshFilter_1) && battery.TryGetComponent(out MeshFilter BatteryMeshFilter_1))
                            {
                                BatteryMeshFilter_1.mesh = ModelMeshFilter_1.mesh;
                                ChargerRenderer_1.material.CopyPropertiesFromMaterial(ModelRenderer_1.material);

                                if (item.item.name == "KionitePowerCell(Clone)")
                                { 
                                    ChargerRenderer_1.material.mainTexture = Powercell_tex;
                                    ChargerRenderer_1.material.SetTexture("_Illum", Powercell_illum);
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
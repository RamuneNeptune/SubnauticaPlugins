

using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using SMLHelper.V2.Options.Attributes;
using static RootMotion.FinalIK.GenericPoser;
using SMLHelper.V2.Json;
using UnityEngine;
using System;
using System.Linq;

namespace Ramune.SeaglideUpgrades
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class SeaglideUpgrades : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.SeaglideUpgrades";
        private const string pluginName = "Seaglide Upgrades";
        private const string versionString = "1.0.1";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            Atlas.Sprite seaglide = SpriteManager.Get(TechType.Seaglide);

            if(RamuneLib.Utils.Checks.WorkbenchModsLoaded("SeaglideUpgrades"))
            {
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Seaglides", "Seaglides", seaglide);
            }
            else
            {
                RamuneLib.Utils.Sort.Workbench();
                CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Seaglides", "Seaglides", seaglide);
            }

            var mk1 = new SeaglideMK1();
            var mk2 = new SeaglideMK2();
            var mk3 = new SeaglideMK3();

            mk1.Patch(); mk2.Patch(); mk3.Patch();
        }
    }
    [Menu("Seaglide Upgrades")]
    public class Config : ConfigFile
    {
/*------------------------------------------------------------------------------------------------------*/

        [Toggle("Enable custom MK1 light settings", Order = 2)]
        public bool MK1_bool = false;
        [Slider("<color=#37C2FF>MK1</color> Red (R)", Format = "{0:F1}", DefaultValue = 0f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 3)]
        public float MK1_red = 0f;
        [Slider("<color=#37C2FF>MK1</color> Green (G)", Format = "{0:F1}", DefaultValue = 0.8f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 4)]
        public float MK1_green = 0.8f;
        [Slider("<color=#37C2FF>MK1</color> Blue (B)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 5)]
        public float MK1_blue = 1f;
        [Slider("<color=#37C2FF>MK1</color> Light Range Multiplier (x)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 6)]
        public float MK1_range = 1f;
        [Slider("<color=#37C2FF>MK1</color> Light Intensity Multiplier (x)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 6)]
        public float MK1_intensity = 1f;
        [Slider("<color=#37C2FF>MK1</color> Light Cone Size Multipler (x)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 6)]
        public float MK1_conesize = 1f;
        [Button("Display custom color on screen", Order = 6)]
        public void MK1()
        {
            Color color = new Color(MK1_red, MK1_green, MK1_blue);
            string hex = ColorUtility.ToHtmlStringRGBA(color);
            ErrorMessage.AddError("<color=#" + hex + ">This is an example of your chosen color</color>");
        }

/*------------------------------------------------------------------------------------------------------*/

        [Toggle("<color=#166aab>------------------------------------------------------------------------------------------------</color>", Order = 7)]
        public bool b = false;
        [Toggle("Enable custom MK2 light settings", Order = 8)]
        public bool MK2_bool = false;
        [Slider("<color=#c6ff53>MK2</color> Red (R)", Format = "{0:F1}", DefaultValue = 0.8f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 9)]
        public float MK2_red = 0.8f;
        [Slider("<color=#c6ff53>MK2</color> Green (G)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 10)]
        public float MK2_green = 1f;
        [Slider("<color=#c6ff53>MK2</color> Blue (B)", Format = "{0:F1}", DefaultValue = 0.5f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 11)]
        public float MK2_blue = 0.5f;
        [Slider("<color=#c6ff53>MK2</color> Light Range Multiplier (x)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 12)]
        public float MK2_range = 1f;
        [Slider("<color=#c6ff53>MK2</color> Color Intensity Multiplier (x)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 12)]
        public float MK2_intensity = 1f;
        [Slider("<color=#c6ff53>MK2</color> Light Cone Size Multiplier (x)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 12)]
        public float MK2_conesize = 1f;
        [Button("Display custom color on screen", Order = 12)]
        public void MK2()
        {
            Color color = new Color(MK2_red, MK2_green, MK2_blue);
            string hex = ColorUtility.ToHtmlStringRGBA(color);
            ErrorMessage.AddError("<color=#" + hex + ">This is an example of your chosen color</color>");
        }
        

/*------------------------------------------------------------------------------------------------------*/

        [Toggle("<color=#166aab>------------------------------------------------------------------------------------------------</color>", Order = 13)]
        public bool c = false;
        [Toggle("Enable custom MK3 light settings", Order = 14)]
        public bool MK3_bool = false;
        [Slider("<color=#ff5425>MK3</color> Red (R)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 15)]
        public float MK3_red = 1f;
        [Slider("<color=#ff5425>MK3</color> Green (G)", Format = "{0:F1}", DefaultValue = 0.5f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 16)]
        public float MK3_green = 0.5f;
        [Slider("<color=#ff5425>MK3</color> Blue (B)", Format = "{0:F1}", DefaultValue = 0.3f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 17)]
        public float MK3_blue = 0.3f;
        [Slider("<color=#ff5425>MK3</color> Light Range Multiplier (x)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 18)]
        public float MK3_range = 1f;
        [Slider("<color=#ff5425>MK3</color> Color Intensity Multiplier (x)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 18)]
        public float MK3_intensity = 1f;
        [Slider("<color=#ff5425>MK3</color> Light Cone Size Multiplier (x)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Seaglide to apply changes", Order = 18)]
        public float MK3_conesize = 1f;
        [Button("Display custom color on screen", Order = 18)]
        public void MK3()
        {
            Color color = new Color(MK3_red, MK3_green, MK3_blue);
            string hex = ColorUtility.ToHtmlStringRGBA(color);
            ErrorMessage.AddError("<color=#" + hex + ">This is an example of your chosen color</color>");
        }
        [Toggle("<color=#166aab>------------------------------------------------------------------------------------------------</color>", Order = 19)]
        public bool a = false;

/*------------------------------------------------------------------------------------------------------*/
    }
}
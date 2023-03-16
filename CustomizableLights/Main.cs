
using Main = Ramune.CustomizableLights.CustomizableLights;
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Json;
using UnityEngine;
using SMLHelper.V2.Options;

namespace Ramune.CustomizableLights
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class CustomizableLights : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.CustomizableLights";
        private const string pluginName = "Customizable Lights";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());
        }
    }
    [Menu("Customizable Lights")]
    public class Config : ConfigFile
    {
        [Toggle("Enable <color=#ffbd2e>Flashlight</color> light settings", Order = 2)]
        public bool Flashlight_Bool = false;
        [Slider("<color=#ffbd2e>Flashlight</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 3), OnChange(nameof(FlashlightUpdated))]
        public float Flashlight_Red = 1f;
        [Slider("<color=#ffbd2e>Flashlight</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 4), OnChange(nameof(FlashlightUpdated))]
        public float Flashlight_Green = 1f;
        [Slider("<color=#ffbd2e>Flashlight</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 5), OnChange(nameof(FlashlightUpdated))]
        public float Flashlight_Blue = 1f;
        [Slider("<color=#ffbd2e>Flashlight</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 6), OnChange(nameof(FlashlightUpdated))]
        public float Flashlight_Range = 1f;
        [Slider("<color=#ffbd2e>Flashlight</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 7), OnChange(nameof(FlashlightUpdated))]
        public float Flashlight_Intensity = 1f;
        [Slider("<color=#ffbd2e>Flashlight</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 8), OnChange(nameof(FlashlightUpdated))]
        public float Flashlight_Conesize = 1f;
        [Button("Display custom color on screen", Order = 9)]
        public void Flashlight()
        {
            Color color = new Color(Flashlight_Red, Flashlight_Green, Flashlight_Blue);
            string hex = ColorUtility.ToHtmlStringRGBA(color);
            ErrorMessage.AddError("<color=#" + hex + ">This is an example of your chosen color</color>");
        }


        [Toggle("<color=#166aab>------------------------------------------------------------------------------------------------</color>", Order = 10)]
        public bool a = false;

        [Toggle("Enable <color=#0db6ff>Seaglide</color> light settings", Order = 11)]
        public bool Seaglide_Bool = false;
        [Slider("<color=#0db6ff>Seaglide</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 0.5f, Min = 0f, Max = 1f, Step = 0.1f, Order = 12), OnChange(nameof(SeaglideUpdated))]
        public float Seaglide_Red = 1f;
        [Slider("<color=#0db6ff>Seaglide</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 13), OnChange(nameof(SeaglideUpdated))]
        public float Seaglide_Green = 1f;
        [Slider("<color=#0db6ff>Seaglide</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 14), OnChange(nameof(SeaglideUpdated))]
        public float Seaglide_Blue = 1f;
        [Slider("<color=#0db6ff>Seaglide</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 15), OnChange(nameof(SeaglideUpdated))]
        public float Seaglide_Range = 1f;
        [Slider("<color=#0db6ff>Seaglide</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 16), OnChange(nameof(SeaglideUpdated))]
        public float Seaglide_Intensity = 1f;
        [Slider("<color=#0db6ff>Seaglide</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 17), OnChange(nameof(SeaglideUpdated))]
        public float Seaglide_Conesize = 1f;
        [Button("Display custom color on screen", Order = 18)]
        public void Seaglide()
        {
            Color color = new Color(Seaglide_Red, Seaglide_Green, Seaglide_Blue);
            string hex = ColorUtility.ToHtmlStringRGBA(color);
            ErrorMessage.AddError("<color=#" + hex + ">This is an example of your chosen color</color>");
        }


        [Toggle("<color=#166aab>------------------------------------------------------------------------------------------------</color>", Order = 19)]
        public bool b = false;

        [Toggle("Enable <color=#9ae372>Seamoth</color> light settings", Order = 20), OnChange(nameof(SeamothUpdated))]
        public bool Seamoth_Bool = false;
        [Slider("<color=#9ae372>Seamoth</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 0.4f, Min = 0f, Max = 1f, Step = 0.1f, Order = 21), OnChange(nameof(SeamothUpdated))]
        public float Seamoth_Red = 1f;
        [Slider("<color=#9ae372>Seamoth</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 0.9f, Min = 0f, Max = 1f, Step = 0.1f, Order = 22), OnChange(nameof(SeamothUpdated))]
        public float Seamoth_Green = 1f;
        [Slider("<color=#9ae372>Seamoth</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 0.9f, Min = 0f, Max = 1f, Step = 0.1f, Order = 23), OnChange(nameof(SeamothUpdated))]
        public float Seamoth_Blue = 1f;
        [Slider("<color=#9ae372>Seamoth</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 24), OnChange(nameof(SeamothUpdated))]
        public float Seamoth_Range = 1f;
        [Slider("<color=#9ae372>Seamoth</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 25), OnChange(nameof(SeamothUpdated))]
        public float Seamoth_Intensity = 1f;
        [Slider("<color=#9ae372>Seamoth</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 26), OnChange(nameof(SeamothUpdated))]
        public float Seamoth_Conesize = 1f;
        [Button("Display custom color on screen", Order = 27)]
        public void Seamoth()
        {
            Color color = new Color(Seamoth_Red, Seamoth_Green, Seamoth_Blue);
            string hex = ColorUtility.ToHtmlStringRGBA(color);
            ErrorMessage.AddError("<color=#" + hex + ">This is an example of your chosen color</color>");
        }


        [Toggle("<color=#166aab>------------------------------------------------------------------------------------------------</color>", Order = 28)]
        public bool c = false;

        [Toggle("Enable <color=#ff6600>Exosuit</color> light settings", Order = 29)]
        public bool Exosuit_Bool = false;
        [Slider("<color=#ff6600>Exosuit</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 0.4f, Min = 0f, Max = 1f, Step = 0.1f, Order = 30), OnChange(nameof(ExosuitUpdated))]
        public float Exosuit_Red = 1f;
        [Slider("<color=#ff6600>Exosuit</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 0.9f, Min = 0f, Max = 1f, Step = 0.1f, Order = 31), OnChange(nameof(ExosuitUpdated))]
        public float Exosuit_Green = 1f;
        [Slider("<color=#ff6600>Exosuit</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 0.9f, Min = 0f, Max = 1f, Step = 0.1f, Order = 32), OnChange(nameof(ExosuitUpdated))]
        public float Exosuit_Blue = 1f;
        [Slider("<color=#ff6600>Exosuit</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 33), OnChange(nameof(ExosuitUpdated))]
        public float Exosuit_Range = 1f;
        [Slider("<color=#ff6600>Exosuit</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 34), OnChange(nameof(ExosuitUpdated))]
        public float Exosuit_Intensity = 1f;
        [Slider("<color=#ff6600>Exosuit</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 35), OnChange(nameof(ExosuitUpdated))]
        public float Exosuit_Conesize = 1f;
        [Button("Display custom color on screen", Order = 36)]
        public void Exosuit()
        {
            Color color = new Color(Exosuit_Red, Exosuit_Green, Exosuit_Blue);
            string hex = ColorUtility.ToHtmlStringRGBA(color);
            ErrorMessage.AddError("<color=#" + hex + ">This is an example of your chosen color</color>");
        }


        [Toggle("<color=#166aab>------------------------------------------------------------------------------------------------</color>", Order = 37)]
        public bool d = false;

        [Toggle("Enable <color=#dc31ff>Cyclops</color> light settings", Order = 38)]
        public bool Cyclops_Bool = false;
        [Slider("<color=#dc31ff>Cyclops</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 39), OnChange(nameof(CyclopsUpdated))]
        public float Cyclops_Red = 1f;
        [Slider("<color=#dc31ff>Cyclops</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 40), OnChange(nameof(CyclopsUpdated))]
        public float Cyclops_Green = 1f;
        [Slider("<color=#dc31ff>Cyclops</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 41), OnChange(nameof(CyclopsUpdated))]
        public float Cyclops_Blue = 1f;
        [Slider("<color=#dc31ff>Cyclops</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 42), OnChange(nameof(CyclopsUpdated))]
        public float Cyclops_Range = 1f;
        [Slider("<color=#dc31ff>Cyclops</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 43), OnChange(nameof(CyclopsUpdated))]
        public float Cyclops_Intensity = 1f;
        [Slider("<color=#dc31ff>Cyclops</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 44), OnChange(nameof(CyclopsUpdated))]
        public float Cyclops_Conesize = 1f;
        [Button("Display custom color on screen", Order = 45)]
        public void Cyclops()
        {
            Color color = new Color(Cyclops_Red, Cyclops_Green, Cyclops_Blue);
            string hex = ColorUtility.ToHtmlStringRGBA(color);
            ErrorMessage.AddError("<color=#" + hex + ">This is an example of your chosen color</color>");
        }


        /*[Toggle("<color=#166aab>------------------------------------------------------------------------------------------------</color>", Order = 46)]
        public bool e = false;

        [Toggle("Enable custom <color=#81ffba>Drone</color> light settings", Order = 47)]
        public bool Drone_Bool = false;
        [Slider("<color=#81ffba>Drone</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 0.4f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Drone to apply changes", Order = 48)]
        public float Drone_Red = 1f;
        [Slider("<color=#81ffba>Drone</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 0.9f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Drone to apply changes", Order = 49)]
        public float Drone_Green = 1f;
        [Slider("<color=#81ffba>Drone</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 0.9f, Min = 0f, Max = 1f, Step = 0.1f, Tooltip = "Re-equip Drone to apply changes", Order = 50)]
        public float Drone_Blue = 1f;
        [Slider("<color=#81ffba>Drone</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Drone to apply changes", Order = 51)]
        public float Drone_Range = 1f;
        [Slider("<color=#81ffba>Drone</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Drone to apply changes", Order = 52)]
        public float Drone_Intensity = 1f;
        [Slider("<color=#81ffba>Drone</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Tooltip = "Re-equip Drone to apply changes", Order = 53)]
        public float Drone_Conesize = 1f;
        [Button("Display custom color on screen", Order = 54)]
        public void Drone()
        {
            Color color = new Color(Drone_Red, Drone_Green, Drone_Blue);
            string hex = ColorUtility.ToHtmlStringRGBA(color);
            ErrorMessage.AddError("<color=#" + hex + ">This is an example of your chosen color</color>");
        }*/

        public void FlashlightUpdated(SliderChangedEventArgs e)
        {
            Monos.FlashlightCL.updatedConfig = true;
        }
        public void SeaglideUpdated(SliderChangedEventArgs e)
        {
            Monos.SeaglideCL.updatedConfig = true;
        }
        public void SeamothUpdated(SliderChangedEventArgs e)
        {
            Monos.SeamothCL.updatedConfig = true;
        }
        public void ExosuitUpdated(SliderChangedEventArgs e)
        {
            Monos.ExosuitCL.updatedConfig = true;
        }
        public void CyclopsUpdated(SliderChangedEventArgs e)
        {
            Monos.CyclopsCL.updatedConfig = true;
        }
        /*public void DroneUpdated(SliderChangedEventArgs e)
        {
            Monos.DroneCL.updatedConfig = true;
        }*/
    }
}
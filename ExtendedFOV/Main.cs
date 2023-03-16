using BepInEx;
using HarmonyLib;
using BepInEx.Logging;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Json;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using UnityEngine;

namespace Ramune.ExtendedFOV
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class ExtendedFOV : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.ExtendedFOV";
        private const string pluginName = "Extended FOV";
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
        [Menu("Extended FOV")]
        public class Config : ConfigFile
        {
            [Slider("Field of view (FOV)", Format = "{0:F0}", DefaultValue = 80f, Min = 50f, Max = 160f, Step = 1f, Tooltip = "Default FOV = 80", Order = 1), OnChange(nameof(ForceUpdate))]
            public float FOV = 80f;

            public void ForceUpdate(SliderChangedEventArgs e)
            {
                UpdaterForFOV.updatedConfig = true;
            }
        }
    }
}
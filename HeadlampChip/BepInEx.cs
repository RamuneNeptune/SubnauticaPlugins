using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Microsoft.SqlServer.Server;
using RamuneLib.Utils;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options;
using SMLHelper.V2.Options.Attributes;
using UnityEngine;

namespace Ramune.HeadlampChip
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class HeadlampChip : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.HeadlampChip";
        private const string pluginName = "Headlamp Chip";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());
            new HeadlampChipItem().Patch();
        }
    }
    [Menu("Headlamp Chip")]
    public class Config : ConfigFile
    {
        [Slider("<color=#FFC029>Headlamp</color> Light Red (<color=#FFC029>R</color>)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f), OnChange(nameof(UpdateConfig))]
        public float red = 1f;
        [Slider("<color=#FFC029>Headlamp</color> Light Green (<color=#FFC029>G</color>)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f), OnChange(nameof(UpdateConfig))]
        public float green = 1f;
        [Slider("<color=#FFC029>Headlamp</color> Light Blue (<color=#FFC029>B</color>)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f), OnChange(nameof(UpdateConfig))]
        public float blue = 1f;

        [Slider("<color=#FFC029>Headlamp</color> Light Range", Format = "{0:F1}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f), OnChange(nameof(UpdateConfig))]
        public float range = 1f;
        [Slider("<color=#FFC029>Headlamp</color> Light Intensity", Format = "{0:F1}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f), OnChange(nameof(UpdateConfig))]
        public float intensity = 1f;
        [Slider("<color=#FFC029>Headlamp</color> Light Conesize", Format = "{0:F1}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f), OnChange(nameof(UpdateConfig))]
        public float conesize = 1f;

        [Keybind("Toggle light key")]
        public KeyCode toggle = KeyCode.F;

        public void UpdateConfig(SliderChangedEventArgs e)
        {
            foreach(HeadlampChipMono Mono in HeadlampChipMono.Headlamps) Mono.Refresh();
        }
    }
}
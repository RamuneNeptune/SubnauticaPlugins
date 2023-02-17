
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Json;
using UnityEngine;

using SMLHelper.V2.Crafting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ramune.SeamothSprint
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class SeamothSprint : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.SeamothSprint";
        private const string pluginName = "Seamoth Sprint";
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
    [Menu("Seamoth Sprint")]
    public class Config : ConfigFile
    {
        /*------------------------------------------------------------------------------------------------------*/

        [Toggle("Enable this mod", Order = 1)]
        public bool ModEnabled = true;

        [Toggle("Enable <color=#ff2000>insanity</color> (x slider by 3)", Order = 2)]
        public bool Insanity = false;

        [Slider("Boost speed multiplier", Format = "{0:0.0}x", DefaultValue = 1.5f, Min = 1f, Max = 10f, Step = 0.1f, Tooltip = "Changes are applied automatically", Order = 3)]
        public float SpeedMultiplier = 1.5f;

        [Slider("Boost energy usage multiplier", Format = "{0:0.0}x", DefaultValue = 2f, Min = 1f, Max = 10f, Step = 0.1f, Tooltip = "Changes are applied automatically", Order = 4)]
        public float EnergyMultiplier = 2f;

        [Keybind("Boost keybind", Order = 5)]
        public KeyCode Boost = KeyCode.LeftShift;

        [Button("More mods by Ramune (open in browser)")]
        public void MyMods()
        {
            Process.Start("https://github.com/RamuneNeptune/SubnauticaMods/blob/main/README.md");
        }
    }
}
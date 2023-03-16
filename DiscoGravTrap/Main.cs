﻿
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;

namespace Ramune.DiscoGravTrap
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class DiscoGravTrap : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.DiscoGravTrap";
        private const string pluginName = "Disco Grav Trap";
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
        [Slider("Time between color changes", Format = "{0:F1}", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f, Order = 0)]
        public float delay = 1f;
    }
}
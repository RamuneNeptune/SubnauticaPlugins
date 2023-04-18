
using Main = Ramune.CustomizableLights.CustomizableLights;
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Json;
using UnityEngine;
using SMLHelper.V2.Options;
using Microsoft.SqlServer.Server;
using RamuneLib.Utils;

namespace Ramune.CustomizableLights
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class CustomizableLights : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.CustomizableLights";
        private const string pluginName = "Customizable Lights";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;
        private static Config ModConfig;

        public void Awake()
        {
            ModConfig = new Config();
            OptionsPanelHandler.RegisterModOptions(ModConfig);
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());
        }
    }
}
﻿
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;

namespace Ramune.SeamothRadarModule
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class SeamothRadarModule : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.SeamothRadarModule";
        private const string pluginName = "Seamoth Radar Module";
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
}
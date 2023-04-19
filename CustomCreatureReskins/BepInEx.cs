﻿

using BepInEx.Logging;
using BepInEx;
using HarmonyLib;

namespace Ramune.CustomCreatureReskins
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class CustomCreatureReskins : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.CustomCreatureReskins";
        private const string pluginName = "Custom Creature Reskins";
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
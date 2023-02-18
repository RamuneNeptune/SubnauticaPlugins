

using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Logging;
using HarmonyLib;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace Ramune.BZEnameledGlass
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class BZEnameledGlass : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.BZEnameledGlass";
        private const string pluginName = "BZ Enameled Glass";
        private const string versionString = "1.0.1";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            var NewEnameledGlass_ = new NewEnameledGlass();
            NewEnameledGlass_.Patch();

            logger.LogInfo("Creating new Enameled Glass item with custom recipe");

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());
        }
    }
}

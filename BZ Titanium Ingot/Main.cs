

using System;
using System.Collections;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Logging;
using HarmonyLib;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace Ramune.BZTitaniumIngot
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class BZTitaniumIngot : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.BZTitaniumIngot";
        private const string pluginName = "BZ Titanium Ingot";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            var titaniumIngot = new TechData()
            {
                craftAmount = 1,

                Ingredients = {
                new Ingredient(TechType.Titanium, 5),
                }
            };

            CraftDataHandler.SetTechData(TechType.TitaniumIngot, titaniumIngot);
            logger.LogInfo("Set recipe for Titanium Ingot, this mod has done all it needs to do!");

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());
        }
    }
}

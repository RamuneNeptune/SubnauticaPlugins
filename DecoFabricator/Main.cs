using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Crafting;

namespace Ramune.DecoFabricator
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class DecoFabricator : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.DecoFabricator";
        private const string pluginName = "Deco Fabricator";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            // this is all the main code you need for basic mods
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            DecoFabricatorFab decoFabricatorFab = new DecoFabricatorFab();
            decoFabricatorFab.Patch();

        }
    }
}
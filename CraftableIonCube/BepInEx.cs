using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Ramune.CraftableIonCube
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class CraftableIonCube : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.CraftableIonCube";
        private const string pluginName = "Craftable Ion Cube";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;


            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            new AltIonCube().Patch();
        }
    }
}
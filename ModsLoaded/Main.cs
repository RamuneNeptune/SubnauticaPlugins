using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using BepInEx.Configuration;
using static OVRHaptics;
using static Ramune.ModsLoaded.ModsLoaded;

namespace Ramune.ModsLoaded
{ 
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class ModsLoaded : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.ModsLoaded";
        private const string pluginName = "Mods Loaded";
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Handlers;

namespace Ramune.SavesMyEyesCE
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class HeadlampChip : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.SaveMyEyesCE";
        private const string pluginName = "Save My Eyes : Collective Edition";
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

using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using System.IO;

namespace Ramune.CyclopsStasisDecoys
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class CyclopsStasisDecoys : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.CyclopsStasisDecoys";
        private const string pluginName = "Cyclops Stasis Decoys";
        private const string versionString = "1.0.0";
        public static AssetBundle LongBladeAsset = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "longblade"));
        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            new LongBlade().Patch();
        }
    }
}
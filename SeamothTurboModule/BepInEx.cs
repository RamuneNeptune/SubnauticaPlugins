
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;

namespace Ramune.SeamothTurboModule
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class SeamothTurboModule : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.SeamothTurboModule";
        private const string pluginName = "Seamoth Turbo Module";
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
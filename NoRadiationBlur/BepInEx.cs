
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;

namespace Ramune.NoRadiationBlur
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class NoRadiationBlur : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.NoRadiationBlur";
        private const string pluginName = "No Radiation Blur";
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
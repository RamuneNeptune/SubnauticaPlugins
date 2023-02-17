
using BepInEx.Logging;
using HarmonyLib;
using BepInEx;


namespace WhiteLights
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class WhiteLights : BaseUnityPlugin
    {
        private const string myGUID = "com.randyknapp.WhiteLights";
        private const string pluginName = "White Lights";
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
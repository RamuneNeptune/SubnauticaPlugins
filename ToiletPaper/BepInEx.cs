
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;


namespace Ramune.ToiletPaper
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class ToiletPaper : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.ToiletPaper";
        private const string pluginName = "Toilet Paper";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            var tp = new ToiletPaperItem();
            tp.Patch();
        }
    }
}

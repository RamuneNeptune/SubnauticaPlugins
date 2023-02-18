
using BepInEx.Logging;
using HarmonyLib;
using BepInEx;


namespace Ramune.CuddlefishClones
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class CuddlefishClones : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.CuddlefishClones";
        private const string pluginName = "Cuddlefish Clones";
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
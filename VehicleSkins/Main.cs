
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;

namespace Ramune.VehicleSkins
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class VehicleSkins : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.VehicleSkins";
        private const string pluginName = "Vehicle Skins";
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
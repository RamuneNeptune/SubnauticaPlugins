using BepInEx.Logging;
using HarmonyLib;
using BepInEx;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Json;

namespace Ramune.EnableAchievements
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class EnableAchievements : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.EnableAchievements";
        private const string pluginName = "Enable Achievements";
        private const string versionString = "1.0.2";

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
    [Menu("Enable Achievements")]
    public class Config : ConfigFile
    {
        [Toggle("Enable debug logging")]
        public bool debug = false;
    }
}
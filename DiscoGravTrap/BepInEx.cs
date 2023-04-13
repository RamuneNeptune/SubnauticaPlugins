
using System.ComponentModel;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;
using UnityEngine.Internal;

namespace Ramune.DiscoGravTrap
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class DiscoGravTrap : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.DiscoGravTrap";
        private const string pluginName = "Disco Grav Trap";
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
    [Menu("Disco Grav Trap")]
    public class Config : ConfigFile
    {
        [Slider("Time between color changes (seconds)", Format = "{0:0.0}s", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f, Order = 0), OnChange(nameof(UpdateConfig))]
        public float delay = 1f;

        public void UpdateConfig()
        {

        }
    }
}
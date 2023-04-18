
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
        [Slider("Light loop duration (seconds)", Format = "{0:0.0}s", DefaultValue = 5f, Min = 0.1f, Max = 20f, Step = 0.1f)]
        public float transitionTime = 5f;

        [Slider("Light saturation", Format = "{0:0.0}", DefaultValue = 0.7f, Min = 0.1f, Max = 1f, Step = 0.1f)]
        public float saturation = 0.7f;

        [Slider("Light opacity", Format = "{0:0.0}", DefaultValue = 0.3f, Min = 0.1f, Max = 1f, Step = 0.1f)]
        public float opacity = 0.3f;

        [Slider("Light radius (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0.1f, Max = 30f, Step = 0.1f)]
        public float radius = 1f;
    }
}
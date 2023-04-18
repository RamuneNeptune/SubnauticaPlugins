
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Options;
using SMLHelper.V2.Json;

namespace Ramune.SolarPanelTweaker
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class SolarPanelTweaker : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.SolarPanelTweaker";
        private const string pluginName = "Solar Panel Tweaker";
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
    [Menu("Solar Panel Tweaker")]
    public class Config : ConfigFile
    {
        [Slider("<color=#FFC029>Solar Panel</color> max power", Format = "{0:F1}", DefaultValue = 75f, Min = 1f, Max = 1000f, Step = 1f), OnChange(nameof(UpdateConfig))]
        public float maxPower = 75f;
        [Slider("<color=#FFC029>Solar Panel</color> max depth", Format = "{0:F1}", DefaultValue = 200f, Min = 1f, Max = 3000f, Step = 1f), OnChange(nameof(UpdateConfig))]
        public float maxDepth = 200f;

        public void UpdateConfig(SliderChangedEventArgs e)
        {
            foreach(SolarPanelTweakController Mono in SolarPanelTweakController.panelTweakControllers) Mono.Refresh();
        }
    }
}
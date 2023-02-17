using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json;
using System.Diagnostics;

namespace Ramune.FasterScanning
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class FasterScanning : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.FasterScanning";
        private const string pluginName = "Faster Scanning";
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
// * - * - * - * - * - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * - * - * - * - * - * //

    [Menu("Faster Scanning")]
    public class Config : ConfigFile
    {
        [Slider("Scanning speed multiplier", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f, Tooltip = "E.g. setting this to '2', would be double scanning speed")]
        public float ScanSpeed = 1f;

        [Button("More mods by Ramune (open in browser)")]
        public void MyMods()
        {
            Process.Start("https://github.com/RamuneNeptune/SubnauticaMods/blob/main/README.md");
        }
    }
}
// * - * - * - * - * - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * -* - * - * - * - * - * - * - * - * //

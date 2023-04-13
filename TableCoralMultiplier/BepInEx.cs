
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Json;
using SMLHelper.V2.Handlers;
using System.Diagnostics;

namespace Ramune.TableCoralMultiplier
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class TableCoralMultiplier : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.TableCoralMultiplier";
        private const string pluginName = "Table Coral Multiplier";
        private const string versionString = "1.0.1";

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
    [Menu("Table Coral Multiplier")]
    public class Config : ConfigFile
    {
        /*------------------------------------------------------------------------------------------------------*/

        [Toggle("Enable this mod", Order = 1)]
        public bool ModEnabled = true;

        [Toggle("Enable <color=#ff2000>insanity</color> (x slider by 10)", Order = 2)]
        public bool Insanity = true;

        [Slider("Table coral to spawn", Format = "{0:F0}", DefaultValue = 1f, Min = 1f, Max = 10f, Step = 1f, Tooltip = "Changes are applied automatically", Order = 3)]
        public float ToSpawn = 1f;

        [Button("More mods by Ramune (open in browser)")]
        public void MyMods()
        {
            Process.Start("https://github.com/RamuneNeptune/SubnauticaMods/blob/main/README.md");
        }
    }
}
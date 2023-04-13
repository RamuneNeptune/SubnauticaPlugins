using System.Collections.Generic;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;


namespace Ramune.MegaO2Tank
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class MegaO2Tank : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.MegaO2Tank";
        private const string pluginName = "Mega O2 Tank";
        private const string versionString = "1.0.4";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            MegaO2TankItem megaO2TankItem = new MegaO2TankItem();
            megaO2TankItem.Patch();

            if(!RamuneLib.Utils.Checks.WorkbenchModsLoaded("MegaO2Tank"))
            {
                RamuneLib.Utils.Sort.Workbench();
            }
        }
    }
    [Menu("Mega O2 Tank")]
    public class Config : ConfigFile
    {
        [Slider(("Tank oxygen capacity"), Format = "{0:F1}", DefaultValue = 360f, Min = 180f, Max = 720f, Step = 10f, Tooltip = "Restart game to apply changes")]
        public float capacity = 360f;

        [Choice("Tank recipe cost", new[] { "<color=#ffcf3c><b>1/2 </b></color> Use 1x Ion-battery", "<color=#ffcf3c><b>2/2 </b></color> Use 2x Aerogel" }, Tooltip = "Restart game to apply changes")]
        public string recipe = "<color=#ffcf3c><b>1/2 </b></color> Use 1x Ion-battery";
    }
}
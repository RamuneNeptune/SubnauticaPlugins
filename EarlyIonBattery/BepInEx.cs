using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Options.Attributes;
using UnityEngine;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json;
using System.Diagnostics;

namespace Ramune.EarlyIonBattery
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class EarlyIonBattery : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.EarlyIonBattery";
        private const string pluginName = "Early Ion Battery";
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
    [Menu("Early Ion Battery")]
    public class Config : ConfigFile
    {
        [Choice("Ion battery unlocks with", new[] { "<color=#ffcf3c><b>1/3 </b></color> QEP Data Terminal", "<color=#ffcf3c><b>2/3 </b></color> Disease Research Facility", "<color=#ffcf3c><b>3/3 </b></color> Lost River Cache Terminal" })]
        public string UnlocksWith = "<b>1/3 </b> QEP Data Terminal";

        [Button("Un-learn Ion Battery", Tooltip = "Click to un-learn the Ion Battery blueprint") ]
        public void Unlearn()
        {
            KnownTech.Remove(TechType.PrecursorIonBattery);
            ErrorMessage.AddError("<color=#ff3417>Removed </color>'Ion Battery'<color=#ff3417> from KnownTech</color>");
        }

        [Button("More mods by Ramune (open in browser)")]
        public void MyMods()
        {
            Process.Start("https://github.com/RamuneNeptune/SubnauticaMods/blob/main/README.md");
        }
    }
}
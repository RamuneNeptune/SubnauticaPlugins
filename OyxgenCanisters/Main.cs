

using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;
using UnityEngine;
using SMLHelper.V2.Utility;
using System.Reflection;
using System.IO;

namespace Ramune.OxygenCylinders
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class OxygenCanisters : BaseUnityPlugin
    {
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        private const string myGUID = "com.ramune.OxygenCanisters";
        private const string pluginName = "Oxygen Canisters";
        private const string versionString = "1.1.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "O2.png"));
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "Oxygen", "Oxygen", sprite);

            var normalOxygenCanister = new OxygenCanister();
            var largeOxygenCanister = new LargeOxygenCanister();
            normalOxygenCanister.Patch(); largeOxygenCanister.Patch();
        }
    }
    [Menu("Oxygen Canisters")]
    public class Config : ConfigFile
    {
        [Keybind("Normal Cylinder quick-consume Keybind", Tooltip = "Keybind used to quickly consume an Oxygen Canister")]
        public KeyCode NormalQuickUseKey = KeyCode.V;

        [Keybind("Large Cylinder quick-consume Keybind", Tooltip = "Keybind used to quickly consume a Large Oxygen Canister")]
        public KeyCode LargeQuickUseKey = KeyCode.B;

        [Toggle("Toggle Quick-consume notfication")]
        public bool Popup = true;
    }
}
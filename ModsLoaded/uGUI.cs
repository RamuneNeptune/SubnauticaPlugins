
using System.Diagnostics;
using System.IO;
using System.Linq;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using System;
using System.Collections.Specialized;

namespace Ramune.ModsLoaded
{
    [HarmonyPatch(typeof(uGUI_OptionsPanel), nameof(uGUI_OptionsPanel.AddTabs))]

    public class uGUI_OptionsPanel_Patches
    {
        internal static string[] names = Chainloader.PluginInfos.Select(kvp => kvp.Value.Metadata.Name).ToArray();
        internal static string namesString = string.Join(Environment.NewLine, names.Select(name => "Loaded: " + name));
        internal static string namesStringColored = string.Join(Environment.NewLine, names.Select(name => "<color=#f1c232>Loaded:</color> <color=#f2f2f2>" + name + "</color>"));
        internal static string modsLoaded = names.Length.ToString();

        internal static string ModsLoadedTabName = "Mods Loaded" + " (" + modsLoaded + ")";
        internal static int ModsLoadedTab;
        public bool toggleValue;

        [HarmonyPostfix]
        internal static void Postfix(uGUI_OptionsPanel __instance)
        {
            string pluginPath = Paths.PluginPath;
            string bepinexPath = Paths.BepInExRootPath;
            string gameDirectory = Paths.GameRootPath;
            string logOutputFile = "LogOutput.log";
            string logfilePath = Path.Combine(bepinexPath, logOutputFile);

            StringCollection paths = new StringCollection
            {
                logfilePath
            };

            ModsLoadedTab = __instance.AddTab(ModsLoadedTabName);

            __instance.AddHeading(ModsLoadedTab, "\n<color=#f1c232>Mods Loaded</color>\nHere you will get a list of mods loaded every time you launch, and also you can click the buttons below to open your Mods folder, open your logfile, and display all the mods loaded currently onto your screen");
            __instance.AddHeading(ModsLoadedTab, " ");

            __instance.AddButton(ModsLoadedTab, "Show mods loaded on screen", () => {
                ErrorMessage.AddError(namesStringColored);
            });
            __instance.AddButton(ModsLoadedTab, "Open mods folder", () => {
                Process.Start(pluginPath);
            });
            __instance.AddButton(ModsLoadedTab, "Open log file", () => {
                Process.Start(logfilePath);
            });

            __instance.AddHeading(ModsLoadedTab, " ");
            __instance.AddHeading(ModsLoadedTab, modsLoaded + " mods have been loaded");

            foreach (string name in names)
            {
                __instance.AddHeading(ModsLoadedTab, "<color=#f1c232>Loaded:</color> <color=#d9dcdc>" + name + "</color>");
            }

            __instance.AddHeading(ModsLoadedTab, "");
        }
    }
}
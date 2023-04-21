

using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using System.IO;
using System.Reflection;
using Steamworks;
using System.Collections.Generic;

namespace Ramune.CustomCreatureReskins
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class CustomCreatureReskins : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.CustomCreatureReskins";
        private const string pluginName = "Custom Creature Reskins";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);

        public static string AssetsFolder = Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"));
        public static List<string> Creatures = new List<string>();
        public static List<string> Materials = new List<string>();
        public static ManualLogSource logger;
        public static string[] SubFolders;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            SubFolders = Directory.GetDirectories(AssetsFolder);

            foreach (var folder in SubFolders)
            {
                string folderShortened = Path.GetFileName(folder);
                Creatures.Add(folderShortened + "(Clone)");
            }

            logger.LogInfo('\n');
            logger.LogInfo("---------------- START ----------------");
            foreach(var cr in Creatures) logger.LogInfo(cr.Replace("(Clone)", ""));
            logger.LogInfo("----------------- END -----------------");
            logger.LogInfo('\n');
        }
    }
}
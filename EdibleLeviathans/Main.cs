
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using static Atlas;


namespace Ramune.EdibleLeviathans
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class EdibleLeviathans : BaseUnityPlugin
    {
        private const string myGUID = "com.ramune.EdibleLeviathans";
        private const string pluginName = "Edible Leviathans";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;

            StartCoroutine(RamuneLib.Main.Sprite.GetSubmodicaSprites());

            Sprite reaper = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Reaper.png"));
            Sprite ghost = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Ghost.png"));
            Sprite seaTreader = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "SeaTreader.png"));

            Sprite backgroundSprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Background.png"));
            CraftData.BackgroundType backgroundType = BackgroundTypeHandler.AddBackgroundType("DeadLeviathan", backgroundSprite);

            logger.LogInfo("Sprites loaded");


            // Reaper leviathan ------------------------------------------------------------------------------
            CraftDataHandler.SetItemSize(TechType.ReaperLeviathan, new Vector2int(3, 3));
            SpriteHandler.RegisterSprite(TechType.ReaperLeviathan, reaper);
            CraftDataHandler.SetBackgroundType(TechType.ReaperLeviathan, backgroundType);
            LanguageHandler.Main.SetTechTypeName(TechType.ReaperLeviathan, $"Reaper Leviathan");
            LanguageHandler.Main.SetTechTypeTooltip(TechType.ReaperLeviathan, $"Can be processed for meat.");
            //------------------------------------------------------------------------------------------------

            // Ghost leviathan -------------------------------------------------------------------------------
            CraftDataHandler.SetItemSize(TechType.GhostLeviathan, new Vector2int(3, 3));
            SpriteHandler.RegisterSprite(TechType.GhostLeviathan, ghost);
            CraftDataHandler.SetBackgroundType(TechType.GhostLeviathan, backgroundType);
            LanguageHandler.Main.SetTechTypeName(TechType.GhostLeviathan, $"Ghost Leviathan");
            LanguageHandler.Main.SetTechTypeTooltip(TechType.GhostLeviathan, $"Can be processed for meat.");
            //------------------------------------------------------------------------------------------------

            // Sea treader -----------------------------------------------------------------------------------
            CraftDataHandler.SetItemSize(TechType.SeaTreader, new Vector2int(3, 3));
            SpriteHandler.RegisterSprite(TechType.SeaTreader, seaTreader);
            CraftDataHandler.SetBackgroundType(TechType.SeaTreader, backgroundType);
            LanguageHandler.Main.SetTechTypeName(TechType.SeaTreader, $"Sea Treader");
            LanguageHandler.Main.SetTechTypeTooltip(TechType.SeaTreader, $"Can be processed for meat.");
            //------------------------------------------------------------------------------------------------

            logger.LogInfo("Item sizes, tooltips, and such, done");


            new Items.Meat.CookedGhost().Patch();
            new Items.Meat.CookedReaper().Patch();
            new Items.Meat.CookedTreader().Patch();
            new Items.Meat.CookedGhostAlt().Patch();


            logger.LogInfo("Meats patched");
        }
    }
}

using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;


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

            Atlas.Sprite reaper = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Reaper.png"));
            Atlas.Sprite ghost = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Ghost.png"));
            Atlas.Sprite seaTreader = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "SeaTreader.png"));
            Atlas.Sprite seaDragon = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "SeaDragon.png"));

            Atlas.Sprite backgroundSprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Background.png"));
            CraftData.BackgroundType backgroundType = BackgroundTypeHandler.AddBackgroundType("DeadLeviathan", backgroundSprite);

            logger.LogInfo("1/3: Sprites loaded");

            string[] steps = new string[] { "Survival", "CookedLeviathans" };
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "CookedLeviathans", "Cooked Leviathans", RamuneLib.Utils.Sprite.Get("Tab.png"), steps);

            // Reaper leviathan ------------------------------------------------------------------------------
            CraftDataHandler.SetItemSize(TechType.ReaperLeviathan, new Vector2int(3, 3));
            SpriteHandler.RegisterSprite(TechType.ReaperLeviathan, reaper);
            CraftDataHandler.SetBackgroundType(TechType.ReaperLeviathan, backgroundType);
            LanguageHandler.Main.SetTechTypeName(TechType.ReaperLeviathan, $"Reaper Leviathan");
            LanguageHandler.Main.SetTechTypeTooltip(TechType.ReaperLeviathan, $"Can be processed for meat.");
            //------------------------------------------------------------------------------------------------

            // Adult Ghost leviathan -------------------------------------------------------------------------
            CraftDataHandler.SetItemSize(TechType.GhostLeviathan, new Vector2int(3, 3));
            SpriteHandler.RegisterSprite(TechType.GhostLeviathan, ghost);
            CraftDataHandler.SetBackgroundType(TechType.GhostLeviathan, backgroundType);
            LanguageHandler.Main.SetTechTypeName(TechType.GhostLeviathan, $"Ghost Leviathan");
            LanguageHandler.Main.SetTechTypeTooltip(TechType.GhostLeviathan, $"Can be processed for meat.");
            //------------------------------------------------------------------------------------------------

            // Juvenile Ghost leviathan ----------------------------------------------------------------------
            CraftDataHandler.SetItemSize(TechType.GhostLeviathanJuvenile, new Vector2int(3, 3));
            SpriteHandler.RegisterSprite(TechType.GhostLeviathanJuvenile, ghost);
            CraftDataHandler.SetBackgroundType(TechType.GhostLeviathanJuvenile, backgroundType);
            LanguageHandler.Main.SetTechTypeName(TechType.GhostLeviathanJuvenile, $"Ghost Leviathan Juvenile");
            LanguageHandler.Main.SetTechTypeTooltip(TechType.GhostLeviathanJuvenile, $"Can be processed for meat.");
            //------------------------------------------------------------------------------------------------

            // Sea treader -----------------------------------------------------------------------------------
            CraftDataHandler.SetItemSize(TechType.SeaTreader, new Vector2int(3, 3));
            SpriteHandler.RegisterSprite(TechType.SeaTreader, seaTreader);
            CraftDataHandler.SetBackgroundType(TechType.SeaTreader, backgroundType);
            LanguageHandler.Main.SetTechTypeName(TechType.SeaTreader, $"Sea Treader");
            LanguageHandler.Main.SetTechTypeTooltip(TechType.SeaTreader, $"Can be processed for meat.");
            //------------------------------------------------------------------------------------------------

            // Sea dragon ------------------------------------------------------------------------------------
            CraftDataHandler.SetItemSize(TechType.SeaDragon, new Vector2int(3, 3));
            SpriteHandler.RegisterSprite(TechType.SeaDragon, seaDragon);
            CraftDataHandler.SetBackgroundType(TechType.SeaDragon, backgroundType);
            LanguageHandler.Main.SetTechTypeName(TechType.SeaDragon, $"Sea Dragon");
            LanguageHandler.Main.SetTechTypeTooltip(TechType.SeaDragon, $"Can be processed for meat.");
            //------------------------------------------------------------------------------------------------
            
            logger.LogInfo("2/3: Item sizes, tooltips, and such, done");

            new Items.Meat.CookedReaper().Patch();
            new Items.Meat.CookedGhost().Patch();
            new Items.Meat.CookedGhostAlt().Patch();
            new Items.Meat.CookedTreader().Patch();
            new Items.Meat.CookedDragon().Patch();

            logger.LogInfo("3/3: Leviathan meats patched");
        }
    }
}
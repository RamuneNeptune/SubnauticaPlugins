
using BepInEx.Logging;
using HarmonyLib;

namespace Ramune.EnableAchievements
{
    /*
    [HarmonyPatch(typeof(GameModeUtils), nameof(GameModeUtils.AllowsAchievements))]
    public class GameModeUtilsPatches
    {
        [HarmonyPostfix]
        public static bool Postfix()
        {
            if (EnableAchievements.config.debug)
            {
                ErrorMessage.AddError("POST: gamemode, an achievement is attempting to unlock..\"");
                EnableAchievements.logger.LogInfo("POST: gamemode, an achievement is attempting to unlock..");
            }
            return true;
        }
    }
    
    [HarmonyPatch(typeof(DevConsole), nameof(DevConsole.HasUsedConsole))]
    public class DevConsolePatches
    {
        [HarmonyPostfix]
        public static bool Postfix()
        {
            //if (EnableAchievements.config.debug)
            //{
                ErrorMessage.AddError("POST: dev, an achievement is attempting to unlock..");
                EnableAchievements.logger.LogInfo("POST: dev, an achievement is attempting to unlock..");
            //}
            return false;
        }
    }
    */
    [HarmonyPatch(typeof(GameAchievements), nameof(GameAchievements.Unlock))]
    public class GameAchievementsPatches
    {
        [HarmonyPostfix]
        public static void Prefix(GameAchievements.Id id)
        {
            if(EnableAchievements.config.debug)
            {
                ErrorMessage.AddError($"PRE: Attempting to unlock '{id}'");
                EnableAchievements.logger.LogInfo($"PRE: Attempting to unlock '{id}'");

            }
            PlatformUtils.main.GetServices().UnlockAchievement(id);
        }

        [HarmonyPostfix]
        public static void Postfix(GameAchievements.Id id) 
        {
            if (EnableAchievements.config.debug)
            {
                ErrorMessage.AddError($"POST: Attempted to unlock '{id}'");
                EnableAchievements.logger.LogInfo($"POST: Attempting to unlock '{id}'");
            }
            PlatformUtils.main.GetServices().UnlockAchievement(id);
        }
    }
}

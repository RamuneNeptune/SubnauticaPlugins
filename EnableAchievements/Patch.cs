
using BepInEx.Logging;
using HarmonyLib;

namespace Ramune.EnableAchievements
{
    [HarmonyPatch(typeof(GameModeUtils), nameof(GameModeUtils.AllowsAchievements))]
    public class GameModeUtilsPatch
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if(EnableAchievements.config.debug)
            {
                ErrorMessage.AddError("Achievement trying to unlock");
                EnableAchievements.logger.LogInfo("An achievement is attempting to unlock..");
            }
            return true;
        }
        [HarmonyPostfix]
        public static bool Postfix()
        {
            if (EnableAchievements.config.debug)
            {
                ErrorMessage.AddError("Achievement trying to unlock");
                EnableAchievements.logger.LogInfo("An achievement is attempting to unlock..");
            }
            return true;
        }
    }
}

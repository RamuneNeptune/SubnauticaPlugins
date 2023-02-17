
using HarmonyLib;

namespace Ramune.EnableAchievements
{
    [HarmonyPatch(typeof(GameModeUtils), nameof(GameModeUtils.AllowsAchievements))]
    public class GameModeUtilsPatch
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            return false;
        }
    }
}
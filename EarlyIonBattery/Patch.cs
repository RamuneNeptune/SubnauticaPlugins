using HarmonyLib;
using SMLHelper.V2.Handlers;
using Story;

namespace Ramune.EarlyIonBattery
{
    [HarmonyPatch(typeof(StoryGoalManager), "OnGoalComplete")]
    public static class StoryGoalManager_OnGoalComplete_Patch
    {
        public static void Postfix(StoryGoalManager __instance)
        {
            EarlyIonBattery.config.Load(true);

            string key = EarlyIonBattery.config.UnlocksWith;

// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * //


            if (key == "<color=#ffcf3c><b>1/3 </b></color> QEP Data Terminal")
            {
                key = "Precursor_Gun_DataDownload1";
            }else


            if (key == "<color=#ffcf3c><b>2/3 </b></color> Disease Research Facility")
            {
                key = "FindPrecursorLostRiverFacility";
            }else


            if (key == "<color=#ffcf3c><b>3/3 </b></color> Lost River Cache Terminal")
            {
                key = "Precursor_Cache_DataDownloadLostRiver";
            }else return;


// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * //


            if (__instance.completedGoals.Contains(key))
            {
                if (KnownTech.Contains(TechType.PrecursorIonBattery)) return;

                KnownTech.Add(TechType.PrecursorIonBattery, true);
                ErrorMessage.AddError("<b>Unlocked:</b> <color=#09f88a>Ion Battery</color>");
            }
        }
    }
}
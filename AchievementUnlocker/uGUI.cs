

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using HarmonyLib;
using Oculus.Platform;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Ramune.AchievementUnlocker
{
    [HarmonyPatch(typeof(uGUI_OptionsPanel), nameof(uGUI_OptionsPanel.AddTabs))]

    public class uGUI_OptionsPanel_Patches
    {
        internal static string UnlockerTabName = "Unlocker";
        internal static int UnlockerTab;

        [HarmonyPostfix]
        internal static void Postfix(uGUI_OptionsPanel __instance)
        {
            UnlockerTab = __instance.AddTab(UnlockerTabName);

            __instance.AddHeading(UnlockerTab, "\n<color=#f1c232>IMPORTANT - Read Me Please</color>\nClick the button below to open the Wiki page for Subnautica Achievements, it will useful to know what achievements your unlocking");
            __instance.AddHeading(UnlockerTab, " ");
            __instance.AddButton(UnlockerTab, "Open Achievement Wiki (in browser)\n", () =>
            {
                Process.Start("https://subnautica.fandom.com/wiki/Achievements#Subnautica");
                AchievementUnlocker.logger.LogInfo("Opened Achievement Wiki page in browser");
            });


            __instance.AddHeading(UnlockerTab, " ");
            // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

            __instance.AddHeading(UnlockerTab, "<color=#f1c232>Achievements</color>\nClick any button below to unlock the corresponding achievement\n");
            __instance.AddHeading(UnlockerTab, " ");
            __instance.AddButton(UnlockerTab, "<color=#f03a17><b>Unlock All</b></color>\nPlease be careful!", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.DiveForTheVeryFirstTime);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.RepairAuroraReactor);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindPrecursorGun);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindPrecursorLavaCastleFacility);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindPrecursorLostRiverFacility);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindPrecursorPrisonFacility);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.CureInfection);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.DeployTimeCapsule);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindDegasiFloatingIslandsBase);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindDegasiJellyshroomCavesBase);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindDegasiDeepGrandReefBase);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.BuildBase);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.BuildSeamoth);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.BuildCyclops);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.BuildExosuit);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.HatchCutefish);
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.LaunchRocket);

                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> All Achievements\n\nThis may take some time, be patient");
            });
            __instance.AddButton(UnlockerTab, "Getting Your Feet Wet", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.DiveForTheVeryFirstTime);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Getting Your Feet Wet");
            });
            __instance.AddButton(UnlockerTab, "Extinction Event Avoided", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.RepairAuroraReactor);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Extinction Event Avoided");
            });
            __instance.AddButton(UnlockerTab, "Ancient Technologies", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindPrecursorGun);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Ancient Technologies");
            });
            __instance.AddButton(UnlockerTab, "Thermal Activity", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindPrecursorLavaCastleFacility);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Thermal Activity");
            });
            __instance.AddButton(UnlockerTab, "Follow the Lost River", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindPrecursorLostRiverFacility);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Follow the Lost River");
            });
            __instance.AddButton(UnlockerTab, "Fourteen Thousand Leagues Under the Sea", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindPrecursorPrisonFacility);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Fourteen Thousand Leagues Under The Sea");
            });
            __instance.AddButton(UnlockerTab, "Optimal Health", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.CureInfection);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Optimal Health");
            });
            __instance.AddButton(UnlockerTab, "Leave Only Time Capsules", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.DeployTimeCapsule);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Leave Only Time Capsules");
            });
            __instance.AddButton(UnlockerTab, "Seaside Living with an Ocean View", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindDegasiFloatingIslandsBase);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Seaside Living with an Ocean View");
            });
            __instance.AddButton(UnlockerTab, "Follow the Degasi", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindDegasiJellyshroomCavesBase);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Follow the Degasi");
            });
            __instance.AddButton(UnlockerTab, "Seamonsters", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.FindDegasiDeepGrandReefBase);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Seamonsters");
            });
            __instance.AddButton(UnlockerTab, "Settling in for the Long Haul", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.BuildBase);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Settling in for the Long Haul");
            });
            __instance.AddButton(UnlockerTab, "Personal Propulsion", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.BuildSeamoth);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Personal Propulsion");
            });
            __instance.AddButton(UnlockerTab, "40-foot Sub For One", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.BuildCyclops);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> 40-foot Sub For One");
            });
            __instance.AddButton(UnlockerTab, "Ordered the Prawn", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.BuildExosuit);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Ordered the Prawn");
            });
            __instance.AddButton(UnlockerTab, "Man's Best Friend", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.HatchCutefish);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Man's Best Friend");
            });
            __instance.AddButton(UnlockerTab, "Go Among the Stars", () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(GameAchievements.Id.LaunchRocket);
                ErrorMessage.AddError("<color=#ffa618>Unlocked:</color> Go Among the Stars");
            });

            __instance.AddHeading(UnlockerTab, " ");
        }
    }
}

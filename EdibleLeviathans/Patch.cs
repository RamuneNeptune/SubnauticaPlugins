
using System.Collections.Generic;
using HarmonyLib;
using Ramune.EdibleLeviathans.Items.Meat;
using RamuneLib.Utils;
using UnityEngine;
using UnityEngine.UI;
using Tobey.UnityAudio;
using System.Collections;
using System.IO;
using System.Net;
using System.Media;
using SMLHelper.V2.Utility;
using SMLHelper.V2.FMod.Interfaces;
using SMLHelper.V2.Interfaces;
using FMOD;
using FMODUnity;
using System.Reflection;
using static Int3;

namespace Ramune.EdibleLeviathans
{
    [HarmonyPatch(typeof(Creature))]
    public static class CreaturePatches
    {
        public static Sound Sad = AudioUtils.CreateSound(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "Audio", "Sad.wav")));
        public static bool flag = false;

        [HarmonyPatch(typeof(Creature), nameof(Creature.OnKill))]
        public static void Prefix(Creature __instance)
        {
            Pickupable pickupable = __instance.gameObject.GetComponentInChildren<Pickupable>();

            if(pickupable != null) return;
            if(__instance.gameObject.name == "GhostLeviathan(Clone)" || __instance.gameObject.name == "ReaperLeviathan(Clone)" || __instance.gameObject.name == "SeaTreader(Clone)" || __instance.gameObject.name == "GhostLeviathanJuvenile(Clone)" || __instance.gameObject.name == "SeaDragonLeviathan(Clone)") __instance.gameObject.EnsureComponent<Pickupable>();
            if(__instance.gameObject.name == "SeaTreader(Clone)" && !flag)
            {
                Subtitles.Add("This action will have <color=#f83e3e>consequences</color>...");
                AudioUtils.PlaySound(Sad, RuntimeManager.GetBus("bus:/master/SFX_for_pause/PDA_pause/all/SFX/creatures"));
                flag = true;
            }
        }
    }

    [HarmonyPatch(typeof(Inventory), nameof(Inventory.OnAddItem))]
    public static class InventoryPatch
    {
        [HarmonyPostfix]
        public static void Postfix(Inventory __instance, InventoryItem item)
        {
            if(item != null && item.techType == TechType.GhostLeviathan) return;
        }
    }

    [HarmonyPatch(typeof(Survival), nameof(Survival.Eat))]
    public static class SurvivalPatch
    {
        public static Sound SeaTreader = AudioUtils.CreateSound(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "Audio", "SeaTreader.wav")));
        public const string GhostSubtitle = "Warning: the consumption of Ghost Leviathan meat is highly inadvisable due to its tendency to harbor copious amounts of harmful bacteria. Ingesting this meat can cause undesirable effects, such as pneumonia, something, something, and in rare cases, death. It is highly recommended that you exercise caution and refrain from consuming this type of meat in order to ensure your continued well-being.";
        public const string ReaperSubtitle = "Upon analysis, Reaper Leviathan meat has been found to contain high levels of protein and essential vitamins and minerals, making it a potentially valuable source of nutrition for survivors. However, due to its high fat content, it is recommended to consume this meat in moderation as part of a balanced diet. It should also be noted that consuming Reaper Leviathan meat carries certain risks, as the creature is known for its aggressive nature and powerful attacks. As such, it is advised that you exercise caution and use appropriate safety measures when hunting and preparing this type of meat.";
        public const string TreaderSubtitle = "Warning: the consumption of Sea Treader meat is not recommended due to its high levels of toxins. Ingesting this meat can lead to severe cases of food poisoning, resulting in symptoms such as nausea, vomiting, and diarrhea. It is highly advised that you do not consume this type of meat under any circumstances, as the toxins present within it can cause long-lasting damage to the body. Please exercise caution and avoid consuming Sea Treader meat in order to ensure your continued well-being.";
        public const string DragonSubtitle = "Warning: the consumption of Sea Dragon meat is not recommended for those with a low tolerance for heat. This meat has been found to have a Scoville unit rating of 1,733,095, making it extremely spicy. Ingesting this meat may cause discomfort and potential damage to the digestive system. It is advised that you approach the consumption of this meat with caution and only do so if you are confident in your ability to tolerate its spiciness.";
        public static bool Ghost;
        public static bool Reaper;
        public static bool Treader;
        public static bool Dragon;
        public static float lastPlayed = 0f;

        public static void Postfix(Survival __instance, GameObject useObj)
        {
            switch (useObj.name)
            {
                case "CookedGhost(Clone)":
                    if(!Ghost) Subtitles.Add(GhostSubtitle, null);
                    Ghost = true;
                    break;
                case "CookedGhostAlt(Clone)":
                    if(!Ghost) Subtitles.Add(GhostSubtitle, null);
                    Ghost = true;
                    break;
                case "CookedReaper(Clone)":
                    if(!Reaper) Subtitles.Add(ReaperSubtitle, null);
                    Reaper = true;
                    break;
                case "CookedTreader(Clone)":
                    if(!Treader)
                    {
                        Subtitles.Add(TreaderSubtitle, null);
                        Play(SeaTreader);
                    }
                    Treader = true;
                    break;
                case "CookedDragon(Clone)":
                    if(!Dragon) Subtitles.Add(DragonSubtitle, null);
                    Dragon = true;
                    break;
            }
        }
        public static void Play(Sound sound)
        {
            AudioUtils.PlaySound(sound, RuntimeManager.GetBus("bus:/master/SFX_for_pause/PDA_pause/all/all voice/AI voice"));
            lastPlayed = Time.time;
        }
    }

    [HarmonyPatch(typeof(PlayerTool), nameof(PlayerTool.OnDraw))]
    public static class PlayerToolPatch
    {
        public static void Postfix(PlayerTool __instance)
        {
            if (__instance.GetType() == typeof(Knife))
            {
                Knife knife = __instance as Knife;
                knife.damage = 10000f;
                knife.attackDist = 400f;
            }
        }
    }
}
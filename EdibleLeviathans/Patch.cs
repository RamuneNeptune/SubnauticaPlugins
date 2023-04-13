using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RamuneLib.Utils;
using SMLHelper.V2.Handlers;
using UnityEngine;
using UWE;
using static DeferredSpawner;
using static GameInput;
using static HandReticle;

namespace Ramune.EdibleLeviathans
{
    [HarmonyPatch(typeof(Creature), nameof(Creature.OnKill))]
    public static class CreaturePatch
    {
        public static void Prefix(Creature __instance)
        {
            //ErrorMessage.AddError($"{__instance.gameObject.name}");
            Pickupable pickupable = __instance.gameObject.GetComponentInChildren<Pickupable>();

            if (pickupable != null) { /* ErrorMessage.AddError("<color=#ff2202>Pickupable WAS found.</color>"); */ return; }
            if (__instance.gameObject.name == "GhostLeviathan(Clone)" || __instance.gameObject.name == "ReaperLeviathan(Clone)" || __instance.gameObject.name == "SeaTreader(Clone)" || __instance.gameObject.name == "GhostLeviathanJuvenile(Clone)" || __instance.gameObject.name == "SeaDragonLeviathan(Clone)")
            {
                __instance.gameObject.EnsureComponent<Pickupable>();
                Pickupable pickupable_ = __instance.gameObject.GetComponent<Pickupable>();
                pickupable_.overrideTechType = TechType.Quartz;
                pickupable_.overrideTechUsed = true;
                pickupable_.destroyOnDeath = false;
            }
        }
    }

    /*[HarmonyPatch(typeof(Pickupable), nameof(Pickupable.Pickup))]
    public static class PickupablePatch
    {
        public static void Prefix(Pickupable __instance)
        {
            if (__instance.inventoryItem.techType == TechType.ReaperLeviathan)
            {
                Log.Colored(Colors.Lime, $"Pickupable.Pickup | {__instance.inventoryItem.techType}");
            }
            else
            {
                Log.Colored(Colors.Red, $"Pickupable.Pickup | {__instance.inventoryItem.techType}");
            }
        }
    }*/

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
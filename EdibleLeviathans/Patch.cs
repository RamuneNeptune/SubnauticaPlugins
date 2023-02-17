using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
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

            if(__instance.gameObject.name == "GhostLeviathan(Clone)" || __instance.gameObject.name == "ReaperLeviathan(Clone)" || __instance.gameObject.name == "SeaTreader(Clone)")
            {
                //ErrorMessage.AddError("<color=#1bc95a>Match found!</color>");
                __instance.gameObject.EnsureComponent<Pickupable>();
                //ErrorMessage.AddError($"<color=#1bc95a>Ensured component on:</color> <color=#afafaf>'{__instance.gameObject.name}'</color>");
            }
            else
            {
                //ErrorMessage.AddError("<color=#1bc95a>NO Matches!</color>");
            }
        }
    }

    //[HarmonyPatch(typeof(PlayerTool), nameof(PlayerTool.OnDraw))]
    //public static class PlayerToolPatch
    //{
    //    public static void Postfix(PlayerTool __instance)
    //    {
    //        if (__instance.GetType() == typeof(Knife))
    //        {
    //            Knife knife = __instance as Knife;
    //            knife.damage = 10000f;
    //            knife.attackDist = 400f;
    //        }
    //    }
    //}
}
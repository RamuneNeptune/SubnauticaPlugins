using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RamuneLib.Utils;
using UnityEngine;

namespace Ramune.HeadlampChip
{
    [HarmonyPatch(typeof(Player), nameof(Player.Awake))]
    public static class PlayerAwakePatch
    {
        [HarmonyPostfix]
        public static void Postfix(Player __instance)
        {
            __instance.gameObject.EnsureComponent<HeadlampChipMono>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace Ramune.SeamothSprint
{
    [HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Start))]
    public static class SeaMothPatch
    {
        public static void Postfix(SeaMoth __instance)
        {
            __instance.gameObject.EnsureComponent<SeamothSprintMono>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RamuneLib.Utils;

namespace Ramune.CustomCreatureReskins
{
    [HarmonyPatch(typeof(Creature), nameof(Creature.Start))]
    public static class CreaturePatch
    {
        public static List<string> creatures = new List<string>
        {
            "ReaperLeviathan(Clone)",
            "GhostLeviathan(Clone)",
            "GhostLeviathanJuvenile(Clone)",
            "SeaTreader(Clone)",
            "SeaDragon(Clone)",
        };

        public static void Postfix(Creature __instance)
        {
            for(int i = 0; i < creatures.Count; i++)
            {
                if(__instance.name == creatures[i]) { __instance.gameObject.EnsureComponent<CreatureReskinHandler>(); break; }
            }
        }
    }
}
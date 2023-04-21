
using System.IO;
using System.Linq;
using HarmonyLib;
using RamuneLib.Utils;
using SMLHelper.V2.Utility;
using UnityEngine;
using Main = Ramune.CustomCreatureReskins.CustomCreatureReskins;

namespace Ramune.CustomCreatureReskins
{
    [HarmonyPatch(typeof(Creature), nameof(Creature.Start))]
    public static class CreaturePatch
    {
        public static SkinnedMeshRenderer[] renderers;
        public static SkinnedMeshRenderer renderer;
        public static Material[] materials;

        public static void Postfix(Creature __instance)
        {
            foreach (string name in Main.Creatures)
            {
                if (__instance.name == name)
                {
                    renderers = __instance.GetComponentsInChildren<SkinnedMeshRenderer>(true);
                    foreach (SkinnedMeshRenderer ren in renderers)
                    {
                        if(!ren.name.Contains("LOD")) renderer = ren;
                    }
                    materials = renderer.materials;
                    foreach (Material mat in materials)
                    {
                        if(!Main.Materials.Contains(mat.name)) Main.Materials.Add(mat.name);
                        return;
                    }
                }
            }
        }
    }
    [HarmonyPatch(typeof(Player), nameof(Player.Awake))]
    public static class PlayerPatch
    {
        public static void Postfix(Creature __instance)
        {
            __instance.gameObject.EnsureComponent<CreatureReskinHandler>();
        }
    }
}
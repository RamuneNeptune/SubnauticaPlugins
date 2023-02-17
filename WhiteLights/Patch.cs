
using HarmonyLib;
using UnityEngine;


namespace WhiteLights
{
// ----------------------------------------------------------------------------------------- //

    [HarmonyPatch(typeof(Exosuit), nameof(Exosuit.Start))]
    public static class ExosuitPatch
    {
        public static void Prefix(Exosuit __instance)
        {
            Light[] lights = __instance.GetComponentsInChildren<Light>();
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].color = Color.white;
            }
        }

    }

// ----------------------------------------------------------------------------------------- //

    [HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Start))]
    public static class SeaMothPatch
    {
        public static void Prefix(SeaMoth __instance)
        {
            Light[] lights = __instance.lightsParent.GetComponentsInChildren<Light>();
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].color = Color.white;
            }
        }
    }

// ----------------------------------------------------------------------------------------- //

    [HarmonyPatch(typeof(Seaglide), nameof(Seaglide.Start))]
    public static class SeaglidePatch
    {
        public static void Prefix(Seaglide __instance)
        {
            Light[] lights = __instance.GetComponentsInChildren<Light>();
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].color = Color.white;
            }
        }
    }

// ----------------------------------------------------------------------------------------- //
}
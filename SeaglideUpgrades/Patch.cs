
using HarmonyLib;
using UnityEngine;
using static VFXParticlesPool;

namespace Ramune.SeaglideUpgrades
{
	[HarmonyPatch(typeof(PlayerTool))]
	internal class PlayerToolPatches
	{
		[HarmonyPatch(nameof(PlayerTool.animToolName))]
		[HarmonyPatch(MethodType.Getter)]
		public static void Postfix(PlayerTool __instance, ref string __result)
		{
			if (__instance.pickupable?.GetTechType() == SeaglideMK1.thisTechType) __result = "seaglide";
            if (__instance.pickupable?.GetTechType() == SeaglideMK2.thisTechType) __result = "seaglide";
            if (__instance.pickupable?.GetTechType() == SeaglideMK3.thisTechType) __result = "seaglide";
        }
    }
}
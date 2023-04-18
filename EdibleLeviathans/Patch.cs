
using System.Collections.Generic;
using HarmonyLib;
using RamuneLib.Utils;
using UnityEngine;
using UnityEngine.UI;

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

    /*
    public class RainbowColor : MonoBehaviour
    {
        private Material[] allMaterials;
        public float currentTime = 0f;
        public float duration = 1f;

        void Start()
        {
            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
            List<Material> materialsList = new List<Material>();
            foreach (Renderer renderer in renderers)
            {
                Material[] materials = renderer.materials;
                materialsList.AddRange(materials);
            }
            allMaterials = materialsList.ToArray();
        }

        void Update()
        {
            Light[] lights = gameObject.GetComponentsInChildren<Light>();
            currentTime += Time.deltaTime / duration;
            if(currentTime >= 1f) currentTime -= 1f;
            Color color = Color.HSVToRGB(currentTime, 1f, 1f);

            foreach (var mat in allMaterials) if (mat != null) mat.color = color;
            foreach (var light in lights) if (light != null) light.color = color;
        }
    }

    [HarmonyPatch(typeof(SubRoot), nameof(SubRoot.Start))]
    public static class SubRootPatch
    {
        public static void Postfix(SubRoot __instance)
        {
            if (!__instance.isCyclops) return;
            __instance.gameObject.EnsureComponent<RainbowColor>();
        }
    }*/
}
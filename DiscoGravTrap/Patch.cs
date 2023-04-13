
using RamuneLib.Utils;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using SMLHelper.V2.Handlers;
using System.Collections;

namespace Ramune.DiscoGravTrap
{
    [HarmonyPatch(typeof(Gravsphere), nameof(Gravsphere.Start))]
    public static class GravspherePatch
    {
        public static void Postfix(Gravsphere __instance)
        { 
            __instance.gameObject.EnsureComponent<DiscoLight>();
        }
    }

    public class DiscoLight : MonoBehaviour
    {
        public Light light;

        public void Awake()
        {
            gameObject.EnsureComponent<Light>();
            light = gameObject.GetComponent<Light>();
            light.enabled = true;
            light.range = 15f;
            light.intensity = 5f;
            light.spotAngle = 7f;
            light.innerSpotAngle = 7f;
            light.type = LightType.Point;
            light.transform.parent = gameObject.transform;
            InvokeRepeating("ColorLoop", DiscoGravTrap.config.delay, DiscoGravTrap.config.delay);
        }

        public void Update()
        {
            light.transform.localPosition = gameObject.transform.localPosition;
        }

        public void ColorLoop()
        {
            if (light.color.b != 1f && light.color.r < 1f)
            {
                light.color = new Color(Mathf.Clamp01(light.color.r + 0.1f), Mathf.Clamp01(light.color.g), Mathf.Clamp01(light.color.b));
            }
            else if (light.color.b == 1f && light.color.r < 1f)
            {
                light.color = new Color(Mathf.Clamp01(light.color.r + 0.1f), Mathf.Clamp01(light.color.g), Mathf.Clamp01(light.color.b - 0.1f));
            }
            else if (light.color.r == 1f && light.color.g < 1f)
            {
                light.color = new Color(Mathf.Clamp01(light.color.r - 0.1f), Mathf.Clamp01(light.color.g + 0.1f), Mathf.Clamp01(light.color.b));

            }
            else if (light.color.g == 1f && light.color.b < 1f)
            {
                light.color = new Color(Mathf.Clamp01(light.color.r), Mathf.Clamp01(light.color.g - 0.1f), Mathf.Clamp01(light.color.b + 0.1f));
            }
            else
            {
                light.color = new Color(0f, 0f, 0f);
            }
            ErrorMessage.AddError($"R:<color=#fe2505>{light.color.r}</color> G:<color=#14a214>{light.color.g}</color> B:<color=#3c9cd8>{light.color.b}</color>");
        }
    }
}
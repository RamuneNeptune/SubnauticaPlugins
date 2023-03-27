
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
        public float transitionDuration;
        public static bool updatedConfig;
        public Light light;
        public int i = 0; 
        public int currentIndex = 0;
        public Color targetColor;


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
            InvokeRepeating("GetNextColor", DiscoGravTrap.config.delay, DiscoGravTrap.config.delay);
        }

        public void Update()
        {
            light.transform.localPosition = gameObject.transform.localPosition;

            if(!updatedConfig) return;
            UpdateRainbow();
            updatedConfig = false;
        }

        public void UpdateRainbow()
        {
            CancelInvoke("Rainbow");
            InvokeRepeating("GetNextColor", DiscoGravTrap.config.delay, DiscoGravTrap.config.delay);
        }

        public List<Color> colors = new List<Color>
        {
            /*new Color(0f, 0f, 1f), // Blue
            new Color(0f, 1f, 1f), // Cyan
            new Color(0f, 0.5f, 0f), // Green
            new Color(0f, 1f, 0f), // Lime
            new Color(1f, 1f, 0f), // Yellow
            new Color(1f, 0.5f, 0f), // Orange
            new Color(1f, 0f, 0f), // Red
            new Color(1f, 0.2f, 0.6f), // Pink
            new Color(0.5f, 0f, 0.5f), // Purple */

            new Color(0f, 0f, 1f), // Blue
            new Color(0f, 0.5f, 1f), // Light blue
            new Color(0f, 0.8f, 0.4f), // Sea green
            new Color(0f, 1f, 0f), // Green
            new Color(0.5f, 1f, 0f), // Lime green
            new Color(1f, 1f, 0f), // Yellow
            new Color(1f, 0.7f, 0f), // Goldenrod
            new Color(1f, 0f, 0f), // Red
            new Color(1f, 0.5f, 0.5f), // Light pink
            new Color(1f, 0.2f, 0.6f), // Magenta
            new Color(0.5f, 0f, 0.5f), // Purple
            new Color(0.2f, 0f, 0.5f), // Dark purple
            new Color(0f, 0f, 0.5f) // Navy blue
        };

        private float r = 0f;
        private float g = 0f;
        private float b = 0f;

        public void GetNextColor()
        {
            Color color = new Color(r, g, b);
            if (r < 1f)
            {
                r += 0.1f;
            }
            else if (g < 1f)
            {
                g += 0.1f;
                r -= 0.1f;
            }
            else if (b < 1f)
            {
                b += 0.1f;
                g -= 0.1f;
            }
            else
            {
                r = 0f;
                g = 0f;
                b = 0f;
            }
            light.color = color;
        }

        public void Rainbow()
        {
            i = (i + 1) % colors.Count;
            light.color = colors[i];
        }
    }
}
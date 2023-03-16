
using RamuneLib.Utils;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;


namespace Ramune.DiscoGravTrap
{
    [HarmonyPatch(typeof(Gravsphere), nameof(Gravsphere.Start))]
    public static class GravspherePatch
    {
        public static void Prefix(Gravsphere __instance)
        {
            //Log.Colored(Colors.Yellow, "Adding component to <b>Grav Trap</b>");

            __instance.gameObject.EnsureComponent<DiscoLight>();

            //Log.Colored(Colors.Grey, $"{__instance.gameObject.gameObject.name}");
            //Log.Colored(Colors.Green, "Added component to <b>Grav Trap</b>");

           //Light light = __instance.gameObject.gameObject.GetComponentInChildren<Light>();
        }
    }


    public class DiscoLight : MonoBehaviour
    {
        Light light;
        public void Awake()
        {
            gameObject.EnsureComponent<Light>();
            light = gameObject.GetComponent<Light>();

            light.enabled = true;

            InvokeRepeating("Rainbow", DiscoGravTrap.config.delay, DiscoGravTrap.config.delay);
        }

        public void Update()
        {
            light.range = 15f;
            light.intensity = 5f;
            light.spotAngle = 7f;
            light.innerSpotAngle = 7f;
            light.type = LightType.Point;

            light.transform.parent = gameObject.transform;
            light.transform.localPosition = gameObject.transform.localPosition;
        }

        public int i = 0;

        public List<Color> colors = new List<Color>
        {
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow,
            Color.cyan,
            Color.magenta,
            new Color(1.0f, 0.5f, 0.0f), // Orange
            new Color(0.5f, 0.0f, 1.0f), // Purple
            new Color(0.0f, 0.5f, 1.0f), // Light Blue
            new Color(1.0f, 0.0f, 0.5f), // Pink
            new Color(0.0f, 1.0f, 0.5f), // Bright Green
        };

        public void Rainbow()
        {
            i = (i + 1) % colors.Count;

            light.color = colors[i];

            //Log.Colored(Colors.Blue, $"Returning <b>'result'</b>");
        }
    }
}
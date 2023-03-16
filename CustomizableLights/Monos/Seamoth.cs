
using Main = Ramune.CustomizableLights.CustomizableLights;
using Log = RamuneLib.Utils.Log;
using RamuneLib.Utils;
using UnityEngine;
using System;

namespace Ramune.CustomizableLights.Monos
{
    public class SeamothCL : MonoBehaviour
    {
        public static float range;
        public static float intensity;
        public static float conesize;
        public static float innerConesize;
        public static bool updatedConfig;
        public static bool hasLights;
        public static Light[] lights;
        public static Color color;

        // Runs once to ensure the config is ready
        public void Start()
        {
            updatedConfig = true; // Force the config to update at start
        }

        // Do stuff
        public void Update()
        {
            // Check if config is enabled
            if(!Main.config.Seamoth_Bool) return;

            // Config has been updated, apply the changes to the stored variables
            if(updatedConfig)
            {
                color = new Color(Main.config.Seamoth_Red, Main.config.Seamoth_Green, Main.config.Seamoth_Blue);
                range = 100f * Main.config.Seamoth_Range;
                intensity = 1.5f * Main.config.Seamoth_Intensity;
                conesize = 50f * Main.config.Seamoth_Conesize;
                innerConesize = 53.4f * Main.config.Seamoth_Conesize;
                updatedConfig = false;
            }

            // Get lights
            if(!hasLights && gameObject.GetComponentsInChildren<Light>().Length > 0)
            {
                lights = gameObject.GetComponentsInChildren<Light>();
                hasLights = true; // Lights found, let's not do this again.
            }else

            // Set the lights since we ACTUALLY fucking found them. I can't believe I got stuck here for days because I forgot how to get components..
            if(hasLights)
            {
                // For each light in lights[]
                for (int i = 0; i < lights.Length; i++)
                {
                    // Set blah blah blah
                    lights[i].color = color;
                    lights[i].intensity = intensity;
                    lights[i].range = range;
                    lights[i].spotAngle = conesize;
                    lights[i].innerSpotAngle = innerConesize;
                }
            }
            return;
        }
    }
}
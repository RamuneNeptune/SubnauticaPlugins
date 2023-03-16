
using Main = Ramune.CustomizableLights.CustomizableLights;
using Log = RamuneLib.Utils.Log;
using RamuneLib.Utils;
using UnityEngine;
using static VFXParticlesPool;
using UnityEngine.Assertions.Must;
using System.Linq;

namespace Ramune.CustomizableLights.Monos
{
    public class CyclopsCL : MonoBehaviour
    {
        public static float range;
        public static float intensity;
        public static float conesize;
        public static float innerConesize;
        public static bool updatedConfig;
        public static bool hasLights;
        public static GameObject floodlights;
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
            if(!Main.config.Cyclops_Bool) return;

            // Config has been updated, apply the changes to the stored variables
            if(updatedConfig)
            {
                color = new Color(Main.config.Cyclops_Red, Main.config.Cyclops_Green, Main.config.Cyclops_Blue);
                range = 70f * Main.config.Cyclops_Range;
                intensity = 2f * Main.config.Cyclops_Intensity;
                conesize = 65f * Main.config.Cyclops_Conesize;
                innerConesize = 49f * Main.config.Cyclops_Conesize;
                updatedConfig = false;
            }

            // Get lights
            if(!hasLights && gameObject.GetComponentsInChildren<Light>().Length > 0)
            {
                floodlights = gameObject.FindChild("Floodlights");
                lights = floodlights.GetComponentsInChildren<Light>();

                // Need this because you can only find this light when the headlights are actually turned on
                for (int i = 0; i < lights.Length; i++)
                {
                    if(lights[i].name == "VolumetricLight_Front")
                    {
                        hasLights = true;
                    }
                }
            }else

            // Set the lights since we ACTUALLY fucking found them. I can't believe I got stuck here for days because I forgot how to get components..
            if(hasLights)
            {
                // For each light in lights[]
                for(int i = 0; i < lights.Length; i++)
                {
                    // Cylcops has a lot of lights, so need to filter out the wrong ones
                    if(lights[i].name == "VolumetricLight_Front" || lights[i].name == "VolumetricLight")
                    {
                        // Set blah blah blah
                        lights[i].color = color;
                        lights[i].intensity = intensity;
                        lights[i].range = range;
                        lights[i].spotAngle = conesize;
                        lights[i].innerSpotAngle = innerConesize;
                    }
                }
            }
            return;
        }
    }
}
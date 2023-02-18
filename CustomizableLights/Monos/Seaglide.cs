using Log = RamuneLib.Utils.Log;
using Main = Ramune.CustomizableLights.CustomizableLights;
using UnityEngine;
using RamuneLib.Utils;

namespace Ramune.CustomizableLights.Monos
{
    public class SeaglideCL : CustomLights
    {
        public Light[] lights;
        public bool flag;
        public bool flag1;
        public Color color;

        public void Start()
        {
            flag = gameObject.GetComponentInChildren<Seaglide>().isDrawn;
            flag1 = false;
        }

        public void Update()
        {
            if(!flag1 && gameObject.GetComponentsInChildren<Light>() != null)
            {
                lights = gameObject.GetComponentsInChildren<Light>();
                flag1 = true;

                Log.Colored(Colors.Orange, "Flipped the switch, you should only see this once");
            }

            Log.Colored(Colors.Green, "test");

            color = new Color(Main.config.Seaglide_Red, Main.config.Seaglide_Green, Main.config.Seaglide_Blue);
            float range = 40f * Main.config.Seaglide_Range;
            float intensity = 0.9f * Main.config.Seaglide_Intensity;
            float conesize = 70f * Main.config.Seaglide_Conesize;
            float innerConesize = 53.4f * Main.config.Seaglide_Conesize;

            if(flag1)
            {
                for (int i = 0; i < lights.Length; i++)
                {
                    if (lights[i].color == color && lights[i].range == range && lights[i].intensity == intensity && lights[i].spotAngle == conesize && lights[i].innerSpotAngle == innerConesize) { Log.Colored(Colors.Red, "All configuration matches"); return; }

                    Log.Colored(Colors.Pink, $"Applying to: {lights[i].name}");
                    lights[i].color = color;
                    lights[i].intensity = intensity;
                    lights[i].range = range;
                    lights[i].spotAngle = conesize;
                    lights[i].innerSpotAngle = innerConesize;
                }
            }

            Log.Colored(Colors.Red, "test");
        }
    }
}
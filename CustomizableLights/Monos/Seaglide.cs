using Log = RamuneLib.Utils.Log;
using Main = Ramune.CustomizableLights.CustomizableLights;
using UnityEngine;
using RamuneLib.Utils;

namespace Ramune.CustomizableLights.Monos
{
    public class SeaglideCL : CustomLights
    {
        public Light[] lights;

        public void Start()
        {
            lights = gameObject.GetComponentsInChildren<Light>();
        }

        public void Update()
        {
            Log.Colored(Colors.Lime, $"CustomizableLights: Calling: <b>Update()</b>");
            Color color = new Color(Main.config.Seaglide_Red, Main.config.Seaglide_Green, Main.config.Seaglide_Blue);

            float range = 40f * Main.config.Seaglide_Range;
            float intensity = 0.9f * Main.config.Seaglide_Intensity;
            float conesize = 70f * Main.config.Seaglide_Conesize;
            float innerConesize = 53.4f * Main.config.Seaglide_Conesize;

            //Log.Colored(Colors.Grey, $"CFG Range: {Main.config.Seaglide_Range}");
            //Log.Colored(Colors.Grey, $"CFG Intensity: {Main.config.Seaglide_Range}");
            //Log.Colored(Colors.Grey, $"CFG Conesize: {Main.config.Seaglide_Range}");
            //Log.Colored(Colors.Grey, $"CFG Color: {Main.config.Seaglide_Range}");

            for (int i = 0; i < lights.Length; i++)
            {
                Log.Colored(Colors.Pink, $"Applying to: {lights[i].name}");
                lights[i].color = color;
                lights[i].intensity = intensity;
                lights[i].range= range;
                lights[i].spotAngle = conesize;
                lights[i].innerSpotAngle = innerConesize;
            }
        }
    }
}
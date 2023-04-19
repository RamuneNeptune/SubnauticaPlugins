using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RamuneLib.Utils;
using UnityEngine;
using Main = Ramune.CustomizableLights.CustomizableLights;

namespace Ramune.CustomizableLights
{
    public class SeamothCL : MonoBehaviour
    {
        public static List<SeamothCL> Seamoths = new List<SeamothCL>();
        public Light[] Lights;
        public Vector3 config;
        public Color color;
        public bool HasLights;

        public void OnEnable() { Seamoths.Add(this); }
        public void OnDisable() { Seamoths.Remove(this); }

        public void Start()
        {
            HasLights = false;
            /*config = new Vector3(Main.config.Seamoth_Range, Main.config.Seamoth_Intensity, Main.config.Seamoth_Conesize);
            color = new Color(Main.config.Seamoth_Red, Main.config.Seamoth_Green, Main.config.Seamoth_Blue);*/
        }

        public void Update()
        {
            if(!HasLights && gameObject.GetComponentsInChildren<Light>().Length > 0)
            {
                Lights = gameObject.GetComponentsInChildren<Light>();
                HasLights = true;
                //Log.Colored(Colors.Blue, $"<b>Found lights</b>: {Lights.Length}");
                //Main.logger.LogInfo("Found lights:" + Lights.Length);
                Refresh();
            }
        }

        public void Refresh()
        {
            /*config.Set(Main.config.Seamoth_Range, Main.config.Seamoth_Intensity, Main.config.Seamoth_Conesize);
            color.r = Main.config.Seamoth_Red;
            color.g = Main.config.Seamoth_Green;
            color.b = Main.config.Seamoth_Blue;

            if(!HasLights) return;
            foreach (Light li in Lights)
            {
                li.color = color;                     //color
                li.range = 100f * config.x;           //range
                li.intensity = 1.5f * config.y;       //intensity
                li.spotAngle = 50f * config.z;        //conesize
                li.innerSpotAngle = 53.4f * config.z; //conesize

                Log.Colored(Colors.Blue, $"<b>Set light</b>");
            }*/
        }
    }

   //-----------------------------------------------------------------------------------------------------------------------------------------//

}
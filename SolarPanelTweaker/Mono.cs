using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RamuneLib.Utils;
using UnityEngine;

namespace Ramune.SolarPanelTweaker
{
    public class SolarPanelTweakController : MonoBehaviour
    {
        public static List<SolarPanelTweakController> panelTweakControllers = new List<SolarPanelTweakController>();
        public SolarPanel panel;

        public void OnEnable() => panelTweakControllers.Add(this); // adds this 'SolarPanelTweakController' to a list so we can update solar panel later
        public void OnDisable() => panelTweakControllers.Remove(this); // removes it when the panel is deconstructed or whatever

        public void Start()
        {
            panel = gameObject.GetComponent<SolarPanel>();
            panel.powerSource.maxPower = SolarPanelTweaker.config.maxPower;
            panel.maxDepth = SolarPanelTweaker.config.maxDepth;

            InvokeRepeating(nameof(Logging), 1f, 1f); // ignore this I just was testing with it 
        }

        public void Refresh() 
        {
            panel.powerSource.maxPower = SolarPanelTweaker.config.maxPower;
            panel.maxDepth = SolarPanelTweaker.config.maxDepth;
        }

        public void Logging() // ignore below, just for testing
        {
            int i = 1;
            foreach(var controller in panelTweakControllers)
            {
                i += 1;
            }
            Log.Colored(Colors.Yellow, $"Solar panels: {i}");
        }
    }
}
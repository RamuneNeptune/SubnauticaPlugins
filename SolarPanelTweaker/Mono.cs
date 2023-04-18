
using System.Collections.Generic;
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
        }

        public void Refresh() 
        {
            panel.powerSource.maxPower = SolarPanelTweaker.config.maxPower;
            panel.maxDepth = SolarPanelTweaker.config.maxDepth;
        }
    }
}
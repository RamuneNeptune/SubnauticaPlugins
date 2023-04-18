
using SMLHelper.V2.Json;
using SMLHelper.V2.Options;
using SMLHelper.V2.Options.Attributes;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Ramune.CustomizableLights
{
    public class Config : ModOptions
    {
        public Dictionary<string, string> Configurables = new Dictionary<string, string>
        {
            {"Flashlight", "#FF7900"},
            {"Seaglide", "#FFCA3A"},
            {"Seamoth", "#8AC926"},
            {"Exosuit", "#4CC9F0"},
            {"Cyclops", "#F72585"}
        };

        public Config() : base("Customizable Lights")
        {
            SliderChanged += OnSliderChanged;
        }

        public override void BuildModOptions()
        {
            foreach(KeyValuePair<string, string> configurable in Configurables)
            {
                AddOptions(thing: configurable.Key, color: configurable.Value);
            }
        }

        private void AddOptions(string thing, string color)
        {
            AddToggleOption(id: $"{thing}1", label: $"Enable <color={color}>{thing}</color> light settings", false);
            AddSliderOption(id: $"{thing}2", label: $"<color={color}>{thing}</color> Light Red (<color=#E0C400>R</color>)",   minValue: 0.1f, maxValue: 1f, value: 1f, defaultValue: 1f, step: 0.1f, valueFormat: "{0:0.0}");
            AddSliderOption(id: $"{thing}3", label: $"<color={color}>{thing}</color> Light Green (<color=#E0C400>G</color>)", minValue: 0.1f, maxValue: 1f, value: 1f, defaultValue: 1f, step: 0.1f, valueFormat: "{0:0.0}");
            AddSliderOption(id: $"{thing}4", label: $"<color={color}>{thing}</color> Light Blue (<color=#E0C400>B</color>)",  minValue: 0.1f, maxValue: 1f, value: 1f, defaultValue: 1f, step: 0.1f, valueFormat: "{0:0.0}");
            /*
            AddSliderOption(id: $"{thing}2", label: $"<color={color}>{thing}</color> Light <b><color=#FF0000>||||||||</color></b> (R)", minValue: 0.1f, maxValue: 1f, value: 1f, defaultValue: 1f, step: 0.1f, valueFormat: "{0:0.0}");
            AddSliderOption(id: $"{thing}3", label: $"<color={color}>{thing}</color> Light <b><color=#00FF00>||||||||</color></b> (G)", minValue: 0.1f, maxValue: 1f, value: 1f, defaultValue: 1f, step: 0.1f, valueFormat: "{0:0.0}");
            AddSliderOption(id: $"{thing}4", label: $"<color={color}>{thing}</color> Light <b><color=#0000FF>||||||||</color></b> (B)", minValue: 0.1f, maxValue: 1f, value: 1f, defaultValue: 1f, step: 0.1f, valueFormat: "{0:0.0}");
            */
            AddSliderOption(id: $"{thing}5", label: $"<color={color}>{thing}</color> Light Range",                            minValue: 0.1f, maxValue: 5f, value: 1f, defaultValue: 1f, step: 0.1f, valueFormat: "{0:0.0}x");
            AddSliderOption(id: $"{thing}6", label: $"<color={color}>{thing}</color> Light Intensity",                        minValue: 0.1f, maxValue: 5f, value: 1f, defaultValue: 1f, step: 0.1f, valueFormat: "{0:0.0}x");
            AddSliderOption(id: $"{thing}7", label: $"<color={color}>{thing}</color> Light Conesize",                         minValue: 0.1f, maxValue: 5f, value: 1f, defaultValue: 1f, step: 0.1f, valueFormat: "{0:0.0}x");
            AddButtonOption(id: $"{thing}8", " ");
        }

        public void OnSliderChanged(object sender, SliderChangedEventArgs eventArgs)
        {
            switch (eventArgs.Id)
            {
                // Flashlight
                case string id when id.Contains("Flashlight"):
                    break;

                // Seamoth
                case string id when id.Contains("Seamoth"):
                    foreach (SeamothCL Mono in SeamothCL.Seamoths) Mono.Refresh();
                    break;

                // Exosuit
                case string id when id.Contains("Exosuit"):
                    break;

                // Cyclops
                case string id when id.Contains("Cyclops"):
                    break;

                // Drone
                case string id when id.Contains("Drone"):
                    break;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ramune.DiscoGravTrap
{
    public class DiscoLight : MonoBehaviour
    {
        public static List<DiscoLight> discoLights = new List<DiscoLight>();
        public Light light;
        public float currentTime;
        public Gravsphere sphere;

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
            sphere = gameObject.GetComponent<Gravsphere>();
            InvokeRepeating("Refresh", 1, 1);
        }

        public void OnEnable() { discoLights.Add(this); }
        public void OnDisable() { discoLights.Remove(this); }

        public void Update()
        {
            light.transform.localPosition = gameObject.transform.localPosition;

            currentTime += Time.deltaTime / DiscoGravTrap.config.transitionTime;
            if (currentTime >= 1f) currentTime -= 1f;

            Color color = Color.HSVToRGB(currentTime, DiscoGravTrap.config.saturation, DiscoGravTrap.config.opacity);
            Color colorLine = Color.HSVToRGB(currentTime, 1f, 1f);

            light.color = color;

            foreach (KeyValuePair<int, VFXElectricLine> effect in sphere.effects)
            {
                LineRenderer line = effect.Value.line;
                if (line == null) return;
                line.startColor = colorLine;
                line.endColor = colorLine;
            }
        }

        public void Refresh()
        {
            if(light.spotAngle == 7 * DiscoGravTrap.config.radius || light.innerSpotAngle == 7 * DiscoGravTrap.config.radius) return;
            light.spotAngle = 7 * DiscoGravTrap.config.radius;
            light.innerSpotAngle = 7 *DiscoGravTrap.config.radius;
        }
    }
}
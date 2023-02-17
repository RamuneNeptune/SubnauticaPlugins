using System;
using UnityEngine;

namespace Ramune.SeaglideUpgrades
{
    public class MK : MonoBehaviour
    {
        public PlayerTool playerTool;
        public PlayerController playerController;

        public float Speed;
        public float Accel;

        public void Awake()
        {
            playerTool = GetComponent<PlayerTool>();
            playerController = Player.main.GetComponent<PlayerController>();
        }

        public void Update()
        {
            if (playerController.seaglideForwardMaxSpeed == Speed) return;
            playerController.seaglideForwardMaxSpeed = Speed;
            playerController.seaglideWaterAcceleration = Accel;
        }

        public void UpdateLights(bool upgradeEnabled, float red, float green, float blue, float intensity, float range, float cone)
        {
            if (!upgradeEnabled) return;

            Color configColor = new Color(red, green, blue, 1f);
            float configIntensity = 0.9f * intensity;
            float configRange = 200 * range;
            float configspotAngle_0 = 70;
            float configspotAngle_1 = 70 + 6 * cone;

            Light[] lights = GetComponentsInChildren<Light>();
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].color = configColor;
                lights[i].intensity = configIntensity;
                lights[i].range = configRange;

                if (cone > 1f)
                {
                    lights[i].spotAngle = configspotAngle_1;
                }else 
                { 
                    lights[i].spotAngle = configspotAngle_0; 
                }
            }
        }


        public class MK1 : MK
        {
            public void Awake()
            {
                base.Awake();
                Speed = 42f;
                Accel = 42f;
            }

            public void Update()
            {
                base.Update();
                UpdateLights(SeaglideUpgrades.config.MK1_bool, SeaglideUpgrades.config.MK1_red, SeaglideUpgrades.config.MK1_green, SeaglideUpgrades.config.MK1_blue, SeaglideUpgrades.config.MK1_intensity, SeaglideUpgrades.config.MK1_range, SeaglideUpgrades.config.MK1_conesize);
            }
        }
        public class MK2 : MK
        {
            public void Awake()
            {
                base.Awake();
                Speed = 50f;
                Accel = 50f;
            }

            public void Update()
            {
                base.Update();
                UpdateLights(SeaglideUpgrades.config.MK2_bool, SeaglideUpgrades.config.MK2_red, SeaglideUpgrades.config.MK2_green, SeaglideUpgrades.config.MK2_blue, SeaglideUpgrades.config.MK2_intensity, SeaglideUpgrades.config.MK2_range, SeaglideUpgrades.config.MK2_conesize);
            }
        }
        public class MK3 : MK
        {
            public void Awake()
            {
                base.Awake();
                Speed = 58f;
                Accel = 58f;
            }

            public void Update()
            {
                base.Update();
                UpdateLights(SeaglideUpgrades.config.MK3_bool, SeaglideUpgrades.config.MK3_red, SeaglideUpgrades.config.MK3_green, SeaglideUpgrades.config.MK3_blue, SeaglideUpgrades.config.MK3_intensity, SeaglideUpgrades.config.MK3_range, SeaglideUpgrades.config.MK3_conesize);
            }
        }
    }
}
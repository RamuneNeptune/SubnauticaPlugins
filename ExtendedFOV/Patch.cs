
using RamuneLib.Utils;
using HarmonyLib;
using UnityEngine;
using System.Collections;
using UWE;

namespace Ramune.ExtendedFOV
{
    [HarmonyPatch(typeof(Player), nameof(Player.Start))]
    public class PlayerPatch
    {
        public static void Postfix(Player __instance)
        {
            __instance.gameObject.EnsureComponent<UpdaterForFOV>();
        }
    }

    [HarmonyPatch(typeof(PDACameraFOVControl), nameof(PDACameraFOVControl.Update))]
    public class PDACameraFOVControlPatch
    {
        public static void Postfix(PDACameraFOVControl __instance)
        {
            PDA pda = Player.main.GetPDA();
            if(!pda.isInUse) UpdaterForFOV.updatedConfig = true;
        }
    }

    public class UpdaterForFOV : MonoBehaviour
    {
        public static bool updatedConfig;
        public static bool flag;
        public static bool flag1;

        public static Camera[] cameras;
        public static Camera camera;
        public static Camera UI;

        public void Start()
        {
            flag = false;
        }

        public void Update()
        {
            if(!flag && gameObject.GetComponentsInChildren<Camera>().Length > 0)
            {
                cameras = gameObject.GetComponentsInChildren<Camera>();
                foreach (var cam in cameras)
                {
                    if(cam.name == "MainCamera")
                    {
                        camera = cam;
                        flag = true;

                        UI = GameObject.Find("MainCamera (UI)").GetComponent<Camera>();
                    }
                }
            }

            if (!updatedConfig) return;
            UpdateFOV();
            updatedConfig = false;
        }

        public static IEnumerator DelayedUpdateFOV()
        {
            if (camera != null && UI != null)
            {
                camera.fieldOfView = ExtendedFOV.config.FOV;
                yield return new WaitForSeconds(0.2f);
                UI.fieldOfView = ExtendedFOV.config.FOV;
            }
        }

        public static void UpdateFOV()
        {
            CoroutineHost.StartCoroutine(DelayedUpdateFOV());
        }
    }
}
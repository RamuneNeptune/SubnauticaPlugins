
using RamuneLib.Utils;
using HarmonyLib;
using UnityEngine;
using System.Collections;
using UWE;
using UnityEngine.PlayerLoop;

namespace Ramune.ExtendedFOV
{
    [HarmonyPatch(typeof(Player), nameof(Player.Start))]
    public class PlayerPatch
    {
        public static void Postfix(Player __instance)
        {
            __instance.gameObject.EnsureComponent<FOVController>();
        }
    }

    [HarmonyPatch(typeof(PDACameraFOVControl), nameof(PDACameraFOVControl.Update))]
    public class PDACameraFOVControlPatch
    {
        public static void Prefix(PDACameraFOVControl __instance, bool __runOriginal)
        {
            __runOriginal = false;
            PDA pda = Player.main.GetPDA();                        // Get the PDA component attached to the Player object and store it in the pda variable.
            SNCameraRoot main = SNCameraRoot.main;                 // Get the SNCameraRoot component attached to the camera and store it in the main variable.
            float b = pda.isInUse ? 60f : ExtendedFOV.config.FOV;  // If the player is using the PDA, set the field of view to 60, otherwise set it to the value defined in the MiscSettings class.
            if(!Mathf.Approximately(ExtendedFOV.config.FOV, b))    // If the current field of view of the camera is not approximately equal to the target field of view...
            {
                float fov = Mathf.Lerp(ExtendedFOV.config.FOV, b, Time.unscaledDeltaTime * 3f);  // Interpolate between the current and target field of view over time and store the result in fov.
                main.SetFov(fov);                                                                // Set the camera's field of view to the new value.
            }
        }
    }

    public class FOVController : MonoBehaviour
    {
        public static bool flag;
        public static SNCameraRoot main = SNCameraRoot.main;
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
                camera = gameObject.GetComponentInChildren<Camera>();
                UI = GameObject.Find("MainCamera (UI)").GetComponent<Camera>();
                flag = true;
            }
        }

        public static IEnumerator UpdateFOV(float delay)
        {
            if(camera != null && UI != null)
            {
                yield return new WaitForSeconds(delay);
                camera.fieldOfView = ExtendedFOV.config.FOV;
                UI.fieldOfView = ExtendedFOV.config.FOV;
            }
            else ExtendedFOV.logger.LogWarning("Camera or UI is null in FOVController");
        }
    }
}
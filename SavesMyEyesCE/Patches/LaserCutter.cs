using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RamuneLib.Utils;
using UnityEngine;

namespace Ramune.SavesMyEyesCE.Patches
{
    [HarmonyPatch(typeof(LaserCutter), nameof(LaserCutter.StartLaserCuttingFX))]
    public static class LaserCutterFXPatch
    {
        public static void Postfix(LaserCutter __instance)
        {
            if(__instance.fxControl != null)
            {
                __instance.fxLight.enabled = false;
                __instance.laserCutSound.Play();
                __instance.fxControl.Stop();
            }
            ErrorMessage.AddError("LaserCutter.StartLaserCuttingFX()");
        }
    }

    [HarmonyPatch(typeof(LaserCutObject), nameof(LaserCutObject.Update))]
    public static class LaserCutObjectPatch
    {
        public static void Postfix(LaserCutObject __instance)
        {

        }
    }
}
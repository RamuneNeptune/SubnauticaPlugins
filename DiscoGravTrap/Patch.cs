
using RamuneLib.Utils;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using SMLHelper.V2.Handlers;
using System.Collections;

namespace Ramune.DiscoGravTrap
{
    [HarmonyPatch(typeof(Gravsphere), nameof(Gravsphere.Start))]
    public static class GravspherePatch
    {
        public static void Postfix(Gravsphere __instance)
        { 
            __instance.gameObject.EnsureComponent<DiscoLight>();
        }
    }
}
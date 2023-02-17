using Log = RamuneLib.Utils.Log;
using Ramune.CustomizableLights.Monos;
using RamuneLib.Utils;
using HarmonyLib;


namespace Ramune.CustomizableLights.Patches
{
    // ----------------------------------------------------------------------------------------- //

    [HarmonyPatch(typeof(FlashLight), nameof(FlashLight.Start))]
    public static class FlashLightPatch
    {
        public static void Postfix(FlashLight __instance)
        {
            //Log.Colored(Colors.Yellow, "Adding component to <b>FLASHLIGHT</b>");
            __instance.gameObject.EnsureComponent<FlashlightCL>();
            //Log.Colored(Colors.Green, "Added component to <b>FLASHLIGHT</b>");
        }
    }

    // ----------------------------------------------------------------------------------------- //

    [HarmonyPatch(typeof(Seaglide), nameof(Seaglide.Start))]
    public static class SeaglidePatch
    {
        public static void Postfix(Seaglide __instance)
        {
            //Log.Colored(Colors.Yellow, "Adding component to <b>SEAGLIDE</b>");
            __instance.gameObject.EnsureComponent<SeaglideCL>();
            //Log.Colored(Colors.Green, "Added component to <b>SEAGLIDE</b>");
        }
    }

    // ----------------------------------------------------------------------------------------- //

    [HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Start))]
    public static class SeaMothPatch
    {
        public static void Postfix(SeaMoth __instance)
        {
            //Log.Colored(Colors.Yellow, "Adding component to <b>SEAMOTH</b>");
            __instance.gameObject.EnsureComponent<SeamothCL>();
            //Log.Colored(Colors.Green, "Added component to <b>SEAMOTH</b>");
        }
    }

    // ----------------------------------------------------------------------------------------- //

    [HarmonyPatch(typeof(Exosuit), nameof(Exosuit.Start))]
    public static class ExosuitPatch
    {
        public static void Postfix(Exosuit __instance)
        {
            //Log.Colored(Colors.Yellow, "Adding component to <b>EXOSUIT</b>");
            __instance.gameObject.EnsureComponent<ExosuitCL>();
            //Log.Colored(Colors.Green, "Added component to <b>EXOSUIT</b>");
        }
    }

    // ----------------------------------------------------------------------------------------- //

    [HarmonyPatch(typeof(MapRoomCamera), nameof(MapRoomCamera.Start))]
    public static class MapRoomCameraPatch
    {
        public static void Postfix(MapRoomCamera __instance)
        {
            //Log.Colored(Colors.Yellow, "Adding component to <b>DRONE</b>");
            __instance.gameObject.EnsureComponent<DroneCL>();
            //Log.Colored(Colors.Green, "Added component to <b>DRONE</b>");
        }
    }

    // ----------------------------------------------------------------------------------------- //
}
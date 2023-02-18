
using System.Runtime.InteropServices.WindowsRuntime;
using HarmonyLib;

namespace Ramune.CuddlefishClones
{
    [HarmonyPatch(typeof(Creature), nameof(Creature.Start))]
    public static class CreaturePatch
    {
        public static void Postfix(Creature __instance)
        {
            if (!(__instance is CuteFish)) return;

            CuteFish cuddlefish = __instance as CuteFish;

            cuddlefish.gameObject.EnsureComponent<CuddlefishClone>();
        }
    }

    [HarmonyPatch(typeof(CuteFishHandTarget), nameof(CuteFishHandTarget.OnHandHover))]
    public static class CuteFishHandTargetPatch
    {
        public static void Postfix(CuteFishHandTarget __instance)
        {
            if (__instance.AllowedToInteract())
            {
                if (__instance.cuteFish.goodbyePlayed || !Player.main.GetRightHandDown() || __instance.state != CuteFishHandTarget.State.None)
                {
                    if(GameInput.GetKey(UnityEngine.KeyCode.LeftShift))
                    {
                        //HandReticle.main.SetText(HandReticle.TextType.Hand, "Extract <color=#1CC06D>DNA</color>", false, GameInput.Button.Reload);
                        //HandReticle.main.SetText(HandReticle.TextType.HandSubscript, "", false);
                        //HandReticle.main.SetIcon(HandReticle.IconType.Hand, 1f);
                    }
                    return;
                }
            } return;
        }
    }
}
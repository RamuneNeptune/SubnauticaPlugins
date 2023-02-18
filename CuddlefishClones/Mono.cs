
using RamuneLib.Utils;
using UnityEngine;
using static VFXParticlesPool;

namespace Ramune.CuddlefishClones
{
    public class CuddlefishClone : MonoBehaviour
    {
        private CuteFishHandTarget hand;
        private CuteFish fish;

        public void Start()
        {
            hand = gameObject.GetComponentInChildren<CuteFishHandTarget>();
            fish = gameObject.GetComponent<CuteFish>();
        }

        public void Update()
        {
            if (hand.AllowedToInteract())
            {
                if (hand.cuteFish.goodbyePlayed || !Player.main.GetRightHandDown() || hand.state != CuteFishHandTarget.State.None)
                {
                    if (GameInput.GetKey(KeyCode.LeftShift))
                    {
                        Log.Colored(Colors.Lime, "Holding LeftShift");
                        HandReticle.main.SetText(HandReticle.TextType.Hand, "Extract <color=#A0E7EE>DNA</color>", false, GameInput.Button.Reload);
                        HandReticle.main.SetText(HandReticle.TextType.HandSubscript, "", false);
                        HandReticle.main.SetIcon(HandReticle.IconType.Hand);
                    }
                }
            }
        }
    }
}
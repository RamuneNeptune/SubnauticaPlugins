
using UnityEngine;
using System.Collections;
using RamuneLib.Utils;
using FMOD.Studio;
using System.Linq;

namespace Ramune.CyclopsStasisDecoys
{
    public class LongBladeTool : Knife
    {
        public void Start()
        {
            base.attackDist = 2f;
            base.damage = 30f;
            base.bashTime = 0.3f;
            base.damageType = DamageType.Heat;
            Log.Colored(Colors.Red, "Setting values..");
            transform.parent = Player.main.gameObject.GetComponentsInChildren<Transform>().FirstOrDefault(t => t.gameObject.name == "attach1");
            Log.Colored(Colors.Green, "Set values..");
        }

        public override string animToolName
        {
            get
            {
                Log.Colored(Colors.Pink, "Getting 'animToolName'..");
                Log.Colored(Colors.Pink, "Returning 'knife'..");
                return "knife";
            }
        }
    }
    public class DecoyStasisHandler : MonoBehaviour
    {
        public StasisSphere sphere;
        public Quaternion quaternion = new Quaternion(1f, 1f, 1f, 1f);
        public Vector3 pos;

        public void Start()
        {
            sphere = StasisRifle.sphere; // I just did this to make it shorter to reference, e.g. rather than 'StasisRifle.sphere' I can use 'sphere'
            StartCoroutine(DeployStasis()); // Start that mf up
        }

        public IEnumerator DeployStasis()
        {
            yield return new WaitForSecondsRealtime(3f); // Wait for 3 seconds
            sphere.Shoot(transform.position, quaternion, 0.1f, 5f, 10f); // Shoot the stasis sphere
            sphere.EnableField(); // then activate the stasis sphere field (the bubble)
        }
    }
}
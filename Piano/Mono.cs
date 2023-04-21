
using UnityEngine;
using FMOD;
using FMODUnity;
using SMLHelper.V2.Utility;
using System.IO;
using System.Reflection;
using RamuneLib.Utils;
using System.Threading.Tasks;
using System.Collections;
using SMLHelper.V2.Handlers;

namespace Ramune.Piano
{
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
            pos = transform.position; // Set 'pos' to the decoy position
            sphere.Shoot(pos, quaternion, 0.1f, 5f, 10f); // Shoot the stasis sphere
            sphere.EnableField(); // then activate the stasis sphere field (the bubble)
        }
    }
}
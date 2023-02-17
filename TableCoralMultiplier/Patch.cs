
using Main = Ramune.TableCoralMultiplier.TableCoralMultiplier;
using UnityEngine;
using HarmonyLib;
using RamuneLib.Utils;
namespace Ramune.TableCoralMultiplier
{
    [HarmonyPatch(typeof(SpawnOnKill), nameof(SpawnOnKill.OnKill))]
    public static class SpawnOnKillPatch
    {
        public static void Postfix(SpawnOnKill __instance)
        {
            if (!Main.config.ModEnabled) { Log.Colored(Colors.Yellow, "Mod disabled"); return; }

            Log.Colored(Colors.Yellow, "Mod Enabled");

            if (__instance.prefabToSpawn.name == "JeweledDiskPieceRed")
            {
                if (Main.config.ToSpawn == 1f) { Log.Colored(Colors.Blue, "Config set to '1'"); return; }

                int toSpawn = (int)Main.config.ToSpawn;

                Log.Colored(Colors.Green, $"Config set to '{toSpawn}'");

                if (Main.config.Insanity)
                {
                    Log.Colored(Colors.Yellow, $"Insaity active");
                    toSpawn *= 10;
                }

                for (int i = 0; i < toSpawn - 1; i++)
                {
                    Log.Colored(Colors.Pink, "Spawning table coral");
                    GameObject gameObject = Object.Instantiate(__instance.prefabToSpawn, __instance.transform.position, __instance.transform.rotation);
                    if (__instance.randomPush)
                    {
                        Rigidbody component = gameObject.GetComponent<Rigidbody>();
                        if (component)
                        {
                            component.AddForce(Random.onUnitSphere * 1.4f, ForceMode.Impulse);
                        }
                    }
                }
            }
        }
    }
}
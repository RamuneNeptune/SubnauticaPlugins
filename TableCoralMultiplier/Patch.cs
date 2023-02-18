
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
            //TableCoralMultiplier.logger.LogFatal($"Enabled? '{Main.config.ModEnabled}'");
            //TableCoralMultiplier.logger.LogFatal($"Insanity? '{Main.config.Insanity}'");
            //TableCoralMultiplier.logger.LogFatal($"To Spawn? '{Main.config.ToSpawn}'");

            //Log.Colored(Colors.Purple, $"Enabled? '{Main.config.ModEnabled}'");
            //Log.Colored(Colors.Purple, $"Insanity? '{Main.config.Insanity}'");
            //Log.Colored(Colors.Purple, $"To Spawn? '{Main.config.ToSpawn}'");

            if (!Main.config.ModEnabled) { /*Log.Colored(Colors.Yellow, "Mod disabled");*/ return; }

            //Log.Colored(Colors.Yellow, "Mod is enabled");
            //TableCoralMultiplier.logger.LogFatal("Mod is enabled");

            if (__instance.prefabToSpawn.name == "JeweledDiskPieceRed" || __instance.prefabToSpawn.name == "JeweledDiskPiece" || __instance.prefabToSpawn.name == "JeweledDiskPieceGreen" || __instance.prefabToSpawn.name == "JeweledDiskPieceBlue")
            {
                //Log.Colored(Colors.Green, $"This is the correct item'");
                //TableCoralMultiplier.logger.LogFatal($"This is the correct item");

                if (Main.config.ToSpawn == 1f) { /*Log.Colored(Colors.Blue, "Config set to '1'"); TableCoralMultiplier.logger.LogFatal($"Config set to spawn '1'");*/ return; }

                int toSpawn = (int)Main.config.ToSpawn;

                //Log.Colored(Colors.Green, $"Config set to '{toSpawn}'");
                //TableCoralMultiplier.logger.LogFatal($"Config set to spawn '{toSpawn}'");

                if (Main.config.Insanity)
                {
                    //Log.Colored(Colors.Yellow, $"Insaity active");
                    //TableCoralMultiplier.logger.LogFatal($"Insanity active");
                    toSpawn *= 10;
                }

                for (int i = 0; i < toSpawn - 1; i++)
                {
                    //Log.Colored(Colors.Pink, "Spawning table coral");
                    //TableCoralMultiplier.logger.LogFatal($"Spawning table coral");
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
            }else
            {
                //Log.Colored(Colors.Red, $"Not correct item to spawn, yours is: {__instance.prefabToSpawn.name}");
            }
        }
    }
}
using Main = Ramune.SeamothSprint.SeamothSprint;
using Log = RamuneLib.Utils.Log;
using UnityEngine;
using RamuneLib.Utils;

namespace Ramune.SeamothSprint
{
    public class SeamothSprintMono : MonoBehaviour
    {
        public EngineRpmSFXManager engine;
        public EnergyMixin energyMixin;
        public SeaMoth seamoth;
        public Animator animator;
        public Vehicle vehicle;
        public float forward;
        public float backward;
        public float sideward;
        public float energy;
        public float speed;

        public void Start()
        {
            engine = gameObject.GetComponentInChildren<EngineRpmSFXManager>();
            energyMixin = gameObject.GetComponentInChildren<EnergyMixin>();
            seamoth = gameObject.GetComponentInChildren<SeaMoth>();
            animator = gameObject.GetComponentInChildren<Animator>();
            vehicle = gameObject.GetComponentInParent<Vehicle>();

            forward = vehicle.forwardForce;
            backward = vehicle.backwardForce;
            sideward = vehicle.sidewardForce;
            energy = 0.24f;
            speed = animator.speed;
        }

        public void Update()
        {
            if(!Main.config.ModEnabled) return;
            if(!seamoth.playerFullyEntered) return;
            if(Main.config.EnergyMultiplier == 1) { /* Log.Colored(Colors.Red, "Config: 1"); */ energy = 0.066667f; }

            HandReticle.main.SetText(HandReticle.TextType.Hand, "Boost", false, );

            if(GameInput.GetKey(Main.config.Boost))
            {
                engine.engineRpmSFX.GetEventInstance().setPitch(1.15f);                  
                engine.engineRpmSFX.GetEventInstance().setVolume(1.25f);

                //Log.Colored(Colors.Yellow, $"Default: {energy}");
                //Log.Colored(Colors.Orange, $"Multiplier: {Main.config.EnergyMultiplier}");
                //Log.Colored(Colors.Blue, $"Result: {result}");
                //Log.Colored(Colors.Grey, $"Consumption: {seamoth.enginePowerConsumption}");

                seamoth.enginePowerConsumption = energy * Main.config.EnergyMultiplier;

                if(Main.config.Insanity)
                {
                    animator.speed = speed * Main.config.SpeedMultiplier * 3f;
                    vehicle.forwardForce = forward * Main.config.SpeedMultiplier * 3f;
                    vehicle.backwardForce = backward * Main.config.SpeedMultiplier * 3f;
                    vehicle.sidewardForce = sideward * Main.config.SpeedMultiplier * 3f;
                }
                else
                {
                    animator.speed = speed * Main.config.SpeedMultiplier;
                    vehicle.forwardForce = forward * Main.config.SpeedMultiplier;
                    vehicle.backwardForce = backward * Main.config.SpeedMultiplier;
                    vehicle.sidewardForce = sideward * Main.config.SpeedMultiplier;
                }
            } 
            else 
            {
                engine.engineRpmSFX.GetEventInstance().setPitch(1f);
                engine.engineRpmSFX.GetEventInstance().setVolume(1f);
                seamoth.enginePowerConsumption = 0.06666667f;
                vehicle.forwardForce = 12.52f;
                vehicle.backwardForce = 5.45f;
                vehicle.sidewardForce = 12.52f;
            }
        }
    }
}


using System.Diagnostics;
using System.Linq;
using Discord;
using UnityEngine;


namespace Ramune.OxygenCylinders
{
    internal class ImOxygenCanister : MonoBehaviour
    {
        public void Awake()
        {

        }
    }

    internal class NormalQuickUseDetector : MonoBehaviour
    {
        public ItemsContainer itemsContainer => Inventory.main._container;
        public Survival survival = new Survival();
        public Oxygen oxygen = new Oxygen();


        public void Update()
        {
            //━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━//
            if (GameInput.GetKeyDown(OxygenCanisters.config.NormalQuickUseKey))
            {
                if (GameModeUtils.currentGameMode != GameModeOption.Survival && GameModeUtils.currentGameMode != GameModeOption.Hardcore) { ErrorMessage.AddError("<color=#fbc361><b>INFO:</b></color> Must be in Survival or Hardcore"); return; }
                if (!itemsContainer.Contains(OxygenCanister.thisTechType)) { ErrorMessage.AddError("<color=#fbc361><b>INFO:</b></color> Must have an Oxygen Canister available"); return; };

                Pickupable pickupable = itemsContainer.Where(item => item?.item?.gameObject?.GetComponentInChildren<ImOxygenCanister>()?.gameObject?.GetComponentInChildren<Pickupable>() != null).Select(item => item.item.gameObject.GetComponentInChildren<ImOxygenCanister>().gameObject.GetComponentInChildren<Pickupable>()).FirstOrDefault();
                survival.Use(pickupable.gameObject);
                itemsContainer.RemoveItem(pickupable);

                if (!OxygenCanisters.config.Popup) { return; }

                ErrorMessage.AddError("<color=#fbc361>1x</color> Oxygen Canister\n<color=#fbc361>+35</color> Oxygen");
            }
            //━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━//
        }
    }


    internal class ImLargeOxygenCanister : MonoBehaviour
    {
        public void Awake()
        {

        }
    }

    internal class LargeQuickUseDetector : MonoBehaviour
    {
        public ItemsContainer itemsContainer => Inventory.main._container;
        public Survival survival = new Survival();
        public Oxygen oxygen = new Oxygen();


        public void Update()
        {
            //━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━//
            if (GameInput.GetKeyDown(OxygenCanisters.config.LargeQuickUseKey))
            {
                if (GameModeUtils.currentGameMode != GameModeOption.Survival && GameModeUtils.currentGameMode != GameModeOption.Hardcore) { ErrorMessage.AddError("<color=#fbc361><b>INFO:</b></color> Must be in Survival or Hardcore"); return; }
                if (!itemsContainer.Contains(LargeOxygenCanister.thisTechType)) { ErrorMessage.AddError("<color=#fbc361><b>INFO:</b></color> Must have a Large Oxygen Canister available"); return; };

                Pickupable pickupable = itemsContainer.Where(item => item?.item?.gameObject?.GetComponentInChildren<ImLargeOxygenCanister>()?.gameObject?.GetComponentInChildren<Pickupable>() != null).Select(item => item.item.gameObject.GetComponentInChildren<ImLargeOxygenCanister>().gameObject.GetComponentInChildren<Pickupable>()).FirstOrDefault();
                survival.Use(pickupable.gameObject);
                itemsContainer.RemoveItem(pickupable);

                if (!OxygenCanisters.config.Popup) { return; }

                ErrorMessage.AddError("<color=#fbc361>1x</color> Large Oxygen Canister\n<color=#fbc361>+70</color> Oxygen");
            }
            //━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━//
        }
    }
}
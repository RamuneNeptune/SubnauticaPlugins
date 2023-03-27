

using System.Collections.Generic;
using SMLHelper.V2.Assets;
using RamuneLib.Utils;
using SMLHelper.V2.Crafting;
using System.Security.Policy;
using System.Reflection;
using System.IO;
using SMLHelper.V2.Utility;
using SMLHelper.V2.Handlers;
using System.Collections;
using UnityEngine;
using Sprite = RamuneLib.Utils.Sprite;

namespace Ramune.DrillArmUpgrades.Items
{
    internal class EnhancedDrillArm : Equipable
    {
        // Overrides for the Equipable Class
        public string[] PathToDrillArmWorkbenchTab = new string[] { "Workbench", "Drill Arms" };
        public override QuickSlotType QuickSlotType => QuickSlotType.SelectableChargeable;
        public override TechType RequiredForUnlock => TechType.ExosuitDrillArmModule;
        public override string[] StepsToFabricatorTab => PathToDrillArmWorkbenchTab;
        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override EquipmentType EquipmentType => EquipmentType.ExosuitArm;
        public override TechCategory CategoryForPDA => TechCategory.Workbench;
        public override Vector2int SizeInInventory => new Vector2int(1, 1);
        public TechType thisTechType { get; private set; }
        public override float CraftingTime => 3f;

        // Recipe & Sprite
        protected override TechData GetBlueprintRecipe() => Recipes.GetTechData((TechType.ExosuitDrillArmModule, 1), (TechType.Titanium, 1), (TechType.Salt, 1), (TechType.Silicone, 1), (TechType.Quartz, 1));
        protected override Atlas.Sprite GetItemSprite() => Sprite.Get("EnhancedDrillArm.png");

        // GameObject for drill arm
        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            var prefab = new TaskResult<GameObject>();
            yield return CraftData.InstantiateFromPrefabAsync(TechType.ExosuitDrillArmModule, prefab);

            var result = prefab.Get();
            result.EnsureComponent<ExosuitDrillArm>();
            ExosuitDrillArm drill = result.GetComponent<ExosuitDrillArm>();
            drill.name = "EnhancedDrillArm";
            SkinnedMeshRenderer renderer = result.GetComponentInChildren<SkinnedMeshRenderer>();

            gameObject.Set(result);
        }

        // Name, description, etc.
        public EnhancedDrillArm() : base("EnhancedDrillArm", "Enhanced Drill Arm", "DAMAGE: +7%\nRANGE: +3%") 
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }
    }
}


using System.Collections.Generic;
using SMLHelper.V2.Assets;
using RamuneLib.Utils;
using SMLHelper.V2.Crafting;
using System.Security.Policy;

namespace Ramune.DrillArmUpgrades.Items
{
    internal class EnhancedDrillArm : Equipable
    {
        // Overrides for the Equipable Class
        public string[] PathToDrillArmWorkbenchTab = new string[] { "Workbench", "Drill Arm" };
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
        protected override TechData GetBlueprintRecipe() => Recipes.GetTechData(TechType.ExosuitDrillArmModule, 1, TechType.Titanium, 1, TechType.Salt, 1, TechType.Silicone, 1, TechType.Quartz, 1);
        protected override Atlas.Sprite GetItemSprite() => Sprite.Get("EnhancedDrillArm");

        // Name, description, etc.
        public EnhancedDrillArm() : base("EnhancedDrillArm", "Enhanced Drill Arm", "DAMAGE: +7%\nRANGE: +3%") 
        {
            OnFinishedPatching += () => thisTechType = TechType; 
        }
    }
}
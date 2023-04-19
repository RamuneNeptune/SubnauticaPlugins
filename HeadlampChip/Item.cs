using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace Ramune.HeadlampChip
{
    public class HeadlampChipItem : Equipable
    {
        public HeadlampChipItem() : base("HeadlampChip", "Headlamp chip", "A headlamp installed into the brain.") 
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }
        public override string AssetsFolder => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");
        protected override Atlas.Sprite GetItemSprite() => ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Chip.png"));
        public override EquipmentType EquipmentType => EquipmentType.Chip;
        public override QuickSlotType QuickSlotType => QuickSlotType.None;
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Resources", "Electronics" };
        public static TechType thisTechType;

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Glass, 1),
                    new Ingredient(TechType.Lithium, 2),
                    new Ingredient(TechType.Battery, 1),
                    new Ingredient(TechType.AdvancedWiringKit, 1),
                }
            };
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.MapRoomHUDChip);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = UnityEngine.Object.Instantiate(originalPrefab);
            resultPrefab.EnsureComponent<HeadlampChipMono>();
            gameObject.Set(resultPrefab);
        }
    }
}
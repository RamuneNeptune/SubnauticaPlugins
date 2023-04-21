using SMLHelper.V2.Handlers;
using SMLHelper.V2.Assets;
using System.Collections;
using UnityEngine;
using System.Reflection;
using System.IO;
using static Exosuit;
using SMLHelper.V2.Crafting;
using System.Collections.Generic;
using SMLHelper.V2.Utility;
using static CraftData;
using TechData = SMLHelper.V2.Crafting.TechData;
using Ingredient = SMLHelper.V2.Crafting.Ingredient;
using Main = Ramune.CyclopsStasisDecoys.CyclopsStasisDecoys;

namespace Ramune.CyclopsStasisDecoys
{
    public class LongBlade : Equipable
    {
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Personal", "Tools" };
        public override QuickSlotType QuickSlotType => QuickSlotType.Selectable;
        public override Vector2int SizeInInventory => new Vector2int(1, 2);
        public override EquipmentType EquipmentType => EquipmentType.Hand;
        public override TechType RequiredForUnlock => TechType.HeatBlade;
        public override float CraftingTime => 5.5f;
        public static TechType thisTechType;

        public LongBlade() : base("LongBlade", "Long blade", "The ultimate blade.") 
        {
            OnFinishedPatching += () => thisTechType = TechType;            
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            var prefab = Object.Instantiate(Main.LongBladeAsset.LoadAsset<GameObject>("LongBlade"));
            var renderers = prefab.GetComponentsInChildren<Renderer>();
            prefab.EnsureComponent<SkyApplier>().renderers = renderers;
            var marmoset = Shader.Find("MarmosetUBER");
            foreach(var renderer in renderers) renderer.materials.ForEach((mat) => mat.shader = marmoset);
            prefab.EnsureComponent<Pickupable>();
            prefab.EnsureComponent<PlayerTool>();
            prefab.AddComponent<LargeWorldEntity>().cellLevel = LargeWorldEntity.CellLevel.Far;
            prefab.AddComponent<PrefabIdentifier>().ClassId = ClassID;
            yield return null;
            gameObject.Set(prefab);
        }

        protected override Atlas.Sprite GetItemSprite() => SpriteManager.Get(TechType.HeatBlade);

        protected override TechData GetBlueprintRecipe()
        {
            TechData techData = new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient(TechType.HeatBlade, 1),
                    new Ingredient(TechType.Diamond, 3),
                }
            };
            return techData;
        }
    }
}
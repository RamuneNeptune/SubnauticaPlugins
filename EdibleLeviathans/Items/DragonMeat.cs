

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using UnityEngine;


namespace Ramune.EdibleLeviathans.Items
{
    internal class CookedDragon : Craftable
    {
        public TechType thisTechType;
        public CookedDragon() : base("CookedDragon", "Cooked Dragon Leviathan Meat", "SHU (Scoville Heat Units) of 1,733,095, consume with caution.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
                EatableHandler.Main.ModifyEatable(thisTechType, 89f, 2f, false);
            };
        }
        public override string[] StepsToFabricatorTab => new string[] { "Survival", "CookedLeviathans" };
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "DragonMeat.png"));
            return sprite;
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 5,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.SeaDragon, 1),
                }),
            };
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.CookedPeeper);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);

            gameObject.Set(resultPrefab);
        }
    }
}
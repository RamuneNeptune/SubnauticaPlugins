

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using UnityEngine;
using static Atlas;



namespace Ramune.EdibleLeviathans.Items
{
    internal class CookedReaper : Craftable
    {
        public TechType thisTechType;
        public CookedReaper() : base("CookedReaper", "Cooked Reaper Leviathan Meat", "Tough, hearty, and fit for a king or queen.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
                EatableHandler.Main.ModifyEatable(thisTechType, 85f, 12f, false);
            };
        }
        public override string[] StepsToFabricatorTab => new string[] { "Survival", "CookedLeviathans" };
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "ReaperMeat.png"));
            return sprite;
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 5,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.ReaperLeviathan, 1),
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
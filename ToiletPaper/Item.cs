

using SMLHelper.V2.Assets;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

using static CraftData;

using Ingredient = SMLHelper.V2.Crafting.Ingredient;
using TechData = SMLHelper.V2.Crafting.TechData;

namespace Ramune.ToiletPaper
{
    internal class ToiletPaperItem : Craftable
    {
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Survival" };
        public TechType thisTechType;

        public ToiletPaperItem() : base("ToiletPaper", "Toilet paper", "HEALTH: +15\nA roll of wet toilet paper") 
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;

                SurvivalHandler.GiveHealthOnConsume(thisTechType,15f, true);

                EatableHandler.Main.ModifyEatable(thisTechType, 90f, 20f, false);
                Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Background.png"));
                BackgroundType background = BackgroundTypeHandler.AddBackgroundType("ToiletPaper", sprite);
                CraftDataHandler.SetBackgroundType(thisTechType, background);
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = SpriteManager.Get(TechType.FiberMesh);
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.FiberMesh);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Eatable>();
            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.FiberMesh, 1),
                    new Ingredient (TechType.NutrientBlock, 1),
                    new Ingredient (TechType.FilteredWater, 1),
                }),
            };
        }
    }

}
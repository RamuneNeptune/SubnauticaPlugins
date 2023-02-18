
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
using Object = UnityEngine.Object;


namespace Ramune.EdibleLeviathans.Items.Meat
{
    internal class CookedGhost : Craftable
    {
        public TechType thisTechType;
        public CookedGhost() : base("CookedGhost", "Cooked Ghost Leviathan meat", "Chewy, a little burnt, and filled with bioluminescence.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
                EatableHandler.Main.ModifyEatable(thisTechType, 50f, 50f, false);
            };
        }
        public override string[] StepsToFabricatorTab => new string[] { "Survival", "CookedFood" };
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "GhostMeat.png"));
            return sprite;
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 5,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.GhostLeviathan, 1)
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
    internal class CookedGhostAlt : Craftable
    {
        public TechType thisTechType;
        public CookedGhostAlt() : base("CookedGhostAlt", "Cooked Ghost Leviathan meat", "Chewy, a little burnt, and filled with bioluminescence.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
                EatableHandler.Main.ModifyEatable(thisTechType, 50f, 50f, false);
            };
        }
        public override string[] StepsToFabricatorTab => new string[] { "Survival", "CookedFood" };
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "GhostMeat.png"));
            return sprite;
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 5,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.GhostLeviathanJuvenile, 1)
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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using UnityEngine;


namespace Ramune.OxygenCylinders
{
    internal class OxygenCanister : Craftable
    {
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Oxygen" };
        public static TechType thisTechType;

        public OxygenCanister() : base("OxygenCanister", "Oxygen canister", "O2: +35\nEncapsulated oxygen from the Bladderfish.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;

                SurvivalHandler.GiveOxygenOnConsume(thisTechType, 35f, true);
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Canister.png"));
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.FiberMesh);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Eatable>();
            resultPrefab.EnsureComponent<ImOxygenCanister>();

            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.Bladderfish, 2),
                    new Ingredient (TechType.Titanium, 1),
                    new Ingredient (TechType.Silicone, 1),
                }),
            };
        }
    }
    

    internal class LargeOxygenCanister : Craftable
    {
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Oxygen" };
        public static TechType thisTechType;

        public LargeOxygenCanister() : base("LargeOxygenCanister", "Large oxygen canister", "O2: +70\nEncapsulated oxygen from the Bladderfish.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;

                SurvivalHandler.GiveOxygenOnConsume(thisTechType, 70f, true);
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "LargeCanister.png"));
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.FiberMesh);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Eatable>();
            resultPrefab.EnsureComponent<ImLargeOxygenCanister>();

            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (OxygenCanister.thisTechType, 2),
                    new Ingredient (TechType.Silicone, 1),
                }),
            };
        }
    }
}
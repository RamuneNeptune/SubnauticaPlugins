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
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using UnityEngine;
using static Atlas;
using Object = UnityEngine.Object;

namespace Ramune.EdibleLeviathans.Items.Meat
{
    internal class CookedTreader : Craftable
    {
        public TechType thisTechType;
        public CookedTreader() : base("CookedTreader", "Cooked Sea Treader meat", "Tastes terrible, smells terrible, and very refreshing.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
                EatableHandler.Main.ModifyEatable(thisTechType, 45f, 100f, false);
            };
        }
        public override string[] StepsToFabricatorTab => new string[] { "Survival", "CookedLeviathans" };
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "TreaderMeat.png"));
            return sprite;
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 5,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.SeaTreader, 1),
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
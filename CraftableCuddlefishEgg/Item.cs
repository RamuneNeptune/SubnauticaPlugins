
using System.Collections.Generic;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using static Atlas;


namespace Ramune.CraftableCuddlefishEgg
{
    internal class CuddlefishEgg : Craftable
    {
        public CuddlefishEgg() : base("CuddlefishEgg", "Cuddlefish Egg", " .") { }
        public override string[] StepsToFabricatorTab => new string[] { "Survival", "CookedFood" };
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;

        protected override Sprite GetItemSprite()
        {
            Sprite sprite = SpriteManager.Get(TechType.CutefishEgg);
            return sprite;
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                    new Ingredient (TechType.ReaperLeviathan, 1),
                }),
                LinkedItems = new List<TechType>()
                {
                    TechType.CutefishEgg,
                }
            };
        }
    }
}

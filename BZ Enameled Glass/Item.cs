

using System.Collections.Generic;

using SMLHelper.V2.Crafting;
using SMLHelper.V2.Assets;

using static Atlas;

namespace Ramune.BZEnameledGlass
{
    internal class NewEnameledGlass : Craftable
    {
        public NewEnameledGlass() : base("NewEnameledGlass", "Enameled Glass", "Glass, hardened using a natural substrate.") { }

        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Resources", "BasicMaterials" };
        // public override TechType RequiredForUnlock => TechType.EnameledGlass;


        protected override Sprite GetItemSprite()
        {
            Sprite sprite = SpriteManager.Get(TechType.EnameledGlass);
            return sprite;
        }


        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.Glass, 1),
                    new Ingredient (TechType.Lead, 1),
                    new Ingredient (TechType.Diamond, 1),
                }),

                LinkedItems = new List<TechType>()
                {
                    TechType.EnameledGlass,
                }
            };
        }
    }
}


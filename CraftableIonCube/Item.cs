using System.Collections.Generic;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using static Atlas;


namespace Ramune.CraftableIonCube
{
    internal class AltIonCube : Craftable
    {
        public AltIonCube() : base("AltIonCube", "Ion cube", "High capacity energy source.") { }

        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Resources", "AdvancedMaterials" };
        public override TechType RequiredForUnlock => TechType.UraniniteCrystal;


        protected override Sprite GetItemSprite()
        {
            Sprite sprite = SpriteManager.Get(TechType.PrecursorIonCrystal);
            return sprite;
        }


        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.UraniniteCrystal, 5),
                }),

                LinkedItems = new List<TechType>()
                {
                    TechType.PrecursorIonCrystal,
                }
            };
        }
    }
}
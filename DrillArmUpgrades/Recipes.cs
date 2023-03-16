
using System.Collections.Generic;
using SMLHelper.V2.Crafting;


namespace Ramune.DrillArmUpgrades
{
    internal class Recipes
    {
        public static TechData GetTechData(TechType tech1, int amount1, TechType tech2, int amount2, TechType tech3, int amount3, TechType tech4, int amount4, TechType tech5, int amount5)
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>()
            {
                new Ingredient(tech1, amount1),
                new Ingredient(tech2, amount2),
                new Ingredient(tech3, amount3),
                new Ingredient(tech4, amount4),
                new Ingredient(tech5, amount5),
            }
            };
        }
    }
}
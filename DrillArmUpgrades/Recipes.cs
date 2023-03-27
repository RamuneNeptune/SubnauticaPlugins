
using System.Collections.Generic;
using SMLHelper.V2.Crafting;
using static CraftData;
using TechData = SMLHelper.V2.Crafting.TechData;
using Ingredient = SMLHelper.V2.Crafting.Ingredient;

namespace Ramune.DrillArmUpgrades
{
    internal class Recipes
    {
        public static TechData GetTechData(params (TechType item, int amount)[] items)
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (var item in items)
            {
                TechType techType = item.item;
                int techAmount = item.amount;

                ingredients.Add(new Ingredient(techType, techAmount));
            }

            return new TechData()
            {
                craftAmount = 1,
                Ingredients = ingredients
            };
        }
    }
}
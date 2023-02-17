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
using Object = UnityEngine.Object;

namespace Ramune.MegaO2Tank
{
    internal class MegaO2TankItem : Equipable
    {
        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "Equipment" };
        public override EquipmentType EquipmentType => EquipmentType.Tank;
        public override QuickSlotType QuickSlotType => QuickSlotType.None;
        public static TechType thisTechType;
        public Oxygen oxygen;

        public MegaO2TankItem() : base("MegaO2Tank", "Mega O₂ Tank", "Additional air capacity.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Tank.png"));
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.HighCapacityTank);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Oxygen>();

            oxygen = resultPrefab.GetComponentInChildren<Oxygen>();
            oxygen.oxygenCapacity = MegaO2Tank.config.capacity;

            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            if (MegaO2Tank.config.recipe == "<color=#ffcf3c><b>1/2 </b></color> Use 1x Ion-battery")
            {
                return new TechData()
                {
                    craftAmount = 1,
                    Ingredients = new List<Ingredient>(new Ingredient[]
                    {
                    new Ingredient (TechType.HighCapacityTank, 2),
                    new Ingredient (TechType.PrecursorIonBattery, 1),
                    new Ingredient (TechType.AramidFibers, 2),
                     }),
                };
            }
            else if (MegaO2Tank.config.recipe == "<color=#ffcf3c><b>2/2 </b></color> Use 2x Aerogel")
            {
                return new TechData()
                {
                    craftAmount = 1,
                    Ingredients = new List<Ingredient>(new Ingredient[]
                    {
                    new Ingredient (TechType.HighCapacityTank, 2),
                    new Ingredient (TechType.Aerogel, 2),
                    new Ingredient (TechType.AramidFibers, 2),
                     }),
                };
            }else
                return new TechData()
                {
                    craftAmount = 1,
                    Ingredients = new List<Ingredient>(new Ingredient[]
                    {
                    new Ingredient (TechType.HighCapacityTank, 2),
                    new Ingredient (TechType.PrecursorIonBattery, 1),
                    new Ingredient (TechType.AramidFibers, 2),
                     }),
                };
        }
    }
}
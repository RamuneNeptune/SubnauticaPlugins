using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Ramune.LithiumBatteries
{
    internal class LithiumBatteryItem : Equipable
    {
        public Texture2D Battery_tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Battery_tex.png"));
        public Texture2D Battery_illum = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Battery_illum.png"));

        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "Power", "Batteries" };
        public override EquipmentType EquipmentType => EquipmentType.BatteryCharger;
        public override QuickSlotType QuickSlotType => QuickSlotType.None;
        public override float CraftingTime => 2f;
        public static TechType thisTechType;
        public Battery battery;


        public LithiumBatteryItem() : base("LithiumBattery", "Lithium battery", "A Lithium battery that can hold 200 power.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Battery.png"));
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.Battery);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Battery>();
            battery = resultPrefab.GetComponentInChildren<Battery>();
            battery._capacity = LithiumBatteries.config.batteryEnergy;

            MeshRenderer renderer = resultPrefab.GetComponentInChildren<MeshRenderer>();
            renderer.material.mainTexture = Battery_tex;
            renderer.material.SetTexture("_Illum", Battery_illum);

            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.Battery, 1),
                    new Ingredient (TechType.Lithium, 1),
                    new Ingredient (TechType.Magnetite, 1),
                }),
            };
        }
    }

    internal class LithiumPowercellItem : Equipable
    {
        public Texture2D Powercell_tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Powercell_tex.png"));
        public Texture2D Powercell_illum = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Powercell_illum.png"));

        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "Power", "Power cells" };
        public override EquipmentType EquipmentType => EquipmentType.PowerCellCharger;
        public override QuickSlotType QuickSlotType => QuickSlotType.None;
        public override float CraftingTime => 4f;
        public static TechType thisTechType;
        public Battery battery;

        public LithiumPowercellItem() : base("LithiumPowercell", "Lithium power cell", "A Lithium power cell that can hold 400 power.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Powercell.png"));
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.PowerCell);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Battery>();

            battery = resultPrefab.GetComponentInChildren<Battery>();
            battery._capacity = LithiumBatteries.config.powercellEnergy;

            MeshRenderer renderer = resultPrefab.GetComponentInChildren<MeshRenderer>();
            renderer.material.mainTexture = Powercell_tex;
            renderer.material.SetTexture("_Illum", Powercell_illum);

            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.PowerCell, 1),
                    new Ingredient (TechType.Lithium, 1),
                    new Ingredient (TechType.Magnetite, 1),
                }),
            };
        }
    }

    internal class IonBatteryAlt : Craftable
    {
        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "Power", "Upgrades" };
        public override float CraftingTime => 2f;
        public static TechType thisTechType;

        public IonBatteryAlt() : base("IonBatteryAlt", "Ion battery", "Battery infused with alien ion technology.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = SpriteManager.Get(TechType.PrecursorIonBattery);
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.PrecursorIonBattery);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);
            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (LithiumBatteryItem.thisTechType, 1),
                    new Ingredient (TechType.PrecursorIonCrystal, 1),
                    new Ingredient (TechType.Gold, 1),
                }),
                LinkedItems = new List<TechType>()
                {
                    TechType.PrecursorIonBattery,
                }
            };
        }
    }

    internal class IonPowercellAlt : Craftable
    {
        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "Power", "Upgrades" };
        public override float CraftingTime => 4f;
        public static TechType thisTechType;

        public IonPowercellAlt() : base("IonPowercellAlt", "Ion power cell", "Power cell infused with alien ion technology.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = SpriteManager.Get(TechType.PrecursorIonPowerCell);
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.PrecursorIonPowerCell);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);
            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (LithiumPowercellItem.thisTechType, 1),
                    new Ingredient (TechType.PrecursorIonCrystal, 1),
                    new Ingredient (TechType.Gold, 1),
                }),
                LinkedItems = new List<TechType>()
                {
                    TechType.PrecursorIonPowerCell,
                }
            };
        }
    }
}
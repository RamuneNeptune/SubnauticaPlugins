using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace Ramune.KioniteBatteries
{
    internal class Kyanicphur : Craftable
    {
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Resources", "AdvancedMaterials" };
        public override TechCategory CategoryForPDA => TechCategory.AdvancedMaterials;
        public override TechGroup GroupForPDA => TechGroup.Resources;
        public override float CraftingTime => 5f;
        public static TechType thisTechType;

        public Kyanicphur() : base("Kyanicphur", "Kyanicphur", "AlNiSiO₅S. Alloy of Sulphur, Nickel, Kyanite. Used in advanced modification.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Kyanicphur.png"));
            return sprite;
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.Sulphur, 1),
                    new Ingredient (TechType.Nickel, 1),
                    new Ingredient (TechType.Kyanite, 2),
                }),
            };
        }
    }

    internal class KioniteBatteryItem : Equipable
    {
        public Texture2D Battery_tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Battery_tex.png"));
        public Texture2D Battery_illum = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Battery_illum.png"));

        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "Power", "Batteries" };
        public override TechCategory CategoryForPDA => TechCategory.Workbench;
        public override TechGroup GroupForPDA => TechGroup.Workbench;

        public override EquipmentType EquipmentType => EquipmentType.BatteryCharger;
        public override QuickSlotType QuickSlotType => QuickSlotType.None;
        public override float CraftingTime => 2f;
        public static TechType thisTechType;
        public Battery battery;


        public KioniteBatteryItem() : base("KioniteBattery", "Kionite battery", "An enhanced Ion battery that can hold 750 power.")
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
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.PrecursorIonBattery);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = UnityEngine.Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Battery>();

            battery = resultPrefab.GetComponentInChildren<Battery>();
            battery._capacity = 750f;

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
                    new Ingredient (TechType.PrecursorIonBattery, 1),
                    new Ingredient (Kyanicphur.thisTechType, 1),
                }),
            };
        }
    }

    internal class KionitePowercellItem : Equipable
    {
        public Texture2D Powercell_tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Powercell_tex.png"));
        public Texture2D Powercell_illum = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "Powercell_illum.png"));

        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "Power", "Power cells" };
        public override TechCategory CategoryForPDA => TechCategory.Workbench;
        public override TechGroup GroupForPDA => TechGroup.Workbench;

        public override EquipmentType EquipmentType => EquipmentType.PowerCellCharger;
        public override QuickSlotType QuickSlotType => QuickSlotType.None;
        public override float CraftingTime => 4f;
        public static TechType thisTechType;
        public Battery battery;

        public KionitePowercellItem() : base("KionitePowerCell", "Kionite power cell", "An enhanced Ion power cell that can hold 1500 power.")
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
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.PrecursorIonPowerCell);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = UnityEngine.Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Battery>();

            battery = resultPrefab.GetComponentInChildren<Battery>();
            battery._capacity = 1500f;

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
                    new Ingredient (TechType.PrecursorIonPowerCell, 1),
                    new Ingredient (Kyanicphur.thisTechType, 1),
                }),
            };
        }
    }
}
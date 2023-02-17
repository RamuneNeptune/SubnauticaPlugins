
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Utility;

using UnityEngine;
using Object = UnityEngine.Object;

namespace Ramune.SeaglideUpgrades
{
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    internal class SeaglideMK1 : Equipable
    {
        public Texture2D MK1_Illum = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "MK1_Illum.png"));
        public Texture2D MK1_Tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "MK1_Tex.png"));
        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "Seaglides" };
        public override Vector2int SizeInInventory => new Vector2int(2, 3);
        public override QuickSlotType QuickSlotType => QuickSlotType.Selectable;
        public override EquipmentType EquipmentType => EquipmentType.Hand;
        public override TechType RequiredForUnlock => TechType.Seaglide;
        public override float CraftingTime => 5.5f;
        public static TechType thisTechType;


        public SeaglideMK1() : base("SeaglideMK1", "Seaglide <color=#03f0f1>MK1</color>", "SPEED: +15%\nMay need to re-equip to apply speed")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "MK1.png"));
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.Seaglide);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Seaglide>();
            resultPrefab.EnsureComponent<MK.MK1>();

            resultPrefab.GetComponentsInChildren<SkinnedMeshRenderer>(true).ForEach(x => x.material.mainTexture = MK1_Tex);
            resultPrefab.GetComponentsInChildren<SkinnedMeshRenderer>(true).ForEach(x => x.material.SetTexture("_Illum", MK1_Illum));

            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.Seaglide, 1),  
                    new Ingredient (TechType.TitaniumIngot, 1),
                    new Ingredient (TechType.WiringKit, 1),
                    new Ingredient (TechType.Silicone, 2),
                    new Ingredient (TechType.CrashPowder, 2),
                }),
            };
        }
    }


//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    internal class SeaglideMK2 : Equipable
    {
        public Texture2D MK2_Illum = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "MK2_Illum.png"));
        public Texture2D MK2_Tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "MK2_Tex.png"));
        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "Seaglides" };
        public override Vector2int SizeInInventory => new Vector2int(2, 3);
        public override QuickSlotType QuickSlotType => QuickSlotType.Selectable;
        public override EquipmentType EquipmentType => EquipmentType.Hand;
        public override TechType RequiredForUnlock => TechType.Seaglide;
        public override float CraftingTime => 5.5f;
        public static TechType thisTechType;

        public SeaglideMK2() : base("SeaglideMK2", "Seaglide <color=#bde170>MK2</color>", "SPEED: +25%\nMay need to re-equip to apply speed")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "MK2.png"));
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.Seaglide);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Seaglide>();
            resultPrefab.EnsureComponent<MK.MK2>();

            resultPrefab.GetComponentsInChildren<SkinnedMeshRenderer>(true).ForEach(x => x.material.mainTexture = MK2_Tex);
            resultPrefab.GetComponentsInChildren<SkinnedMeshRenderer>(true).ForEach(x => x.material.SetTexture("_Illum", MK2_Illum));

            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (SeaglideMK1.thisTechType, 1),
                    new Ingredient (TechType.PlasteelIngot, 1),
                    new Ingredient (TechType.ComputerChip, 1),
                    new Ingredient (TechType.EnameledGlass, 1),
                    new Ingredient (TechType.Diamond, 2),
                }),
            };
        }
    }


//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    internal class SeaglideMK3 : Equipable
    {
        public Texture2D MK3_Illum = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "MK3_Illum.png"));
        public Texture2D MK3_Tex = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "MK3_Tex.png"));
        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "Seaglides" };
        public override Vector2int SizeInInventory => new Vector2int(2, 3);
        public override QuickSlotType QuickSlotType => QuickSlotType.Selectable;
        public override EquipmentType EquipmentType => EquipmentType.Hand;

        public override TechType RequiredForUnlock => TechType.Seaglide;
        public override float CraftingTime => 5.5f;

        public static TechType thisTechType;

        public SeaglideMK3() : base("SeaglideMK3", "Seaglide <color=#f81117>MK3</color>", "SPEED: +40%\nMay need to re-equip to apply speed")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "MK3.png"));
            return sprite;
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.Seaglide);
            yield return task;
            GameObject originalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(originalPrefab);

            resultPrefab.EnsureComponent<Seaglide>();
            resultPrefab.EnsureComponent<MK.MK3>();

            resultPrefab.GetComponentsInChildren<SkinnedMeshRenderer>(true).ForEach(x => x.material.mainTexture = MK3_Tex);
            resultPrefab.GetComponentsInChildren<SkinnedMeshRenderer>(true).ForEach(x => x.material.SetTexture("_Illum", MK3_Illum));

            gameObject.Set(resultPrefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (SeaglideMK2.thisTechType, 1),
                    new Ingredient (TechType.PlasteelIngot, 2),
                    new Ingredient (TechType.AdvancedWiringKit, 1),
                    new Ingredient (TechType.Aerogel, 2),
                    new Ingredient (TechType.Diamond, 2),
                }),
            };
        }
    }


//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
}

using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

using Object = UnityEngine.Object;
using UWE;
using SMLHelper.V2.Utility;
using System.Reflection;
using System.IO;
using SMLHelper.V2.Handlers;

namespace Ramune.DecoFabricator
{
    internal class DecoFabricatorFab : CustomFabricator
    {
        public override TechCategory CategoryForPDA { get; } = TechCategory.InteriorModule;
        public override TechGroup GroupForPDA { get; } = TechGroup.InteriorModules;
        public override Models Model { get; } = Models.Fabricator;
        public override bool AllowedInCyclops => true;
        public override bool AllowedInBase => true;
        public override bool AllowedOnWall => true;
        public override bool AllowedOnCeiling => false;
        public override bool AllowedOnGround => false;
        public override bool AllowedOutside => false;

        public Texture2D myTexture = ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), "tex.png"));


        public DecoFabricatorFab() : base ("DecoFabricator", "Decorations Fabricator", "Used to fabricate posters, toys, caps, and more") 
        {
            AddTabNode("Posters", "Posters", SpriteManager.Get(TechType.PosterKitty));
            AddTabNode("Science", "Science", SpriteManager.Get(TechType.LabEquipment3));
            AddTabNode("Misc", "Misc", SpriteManager.Get(TechType.ArcadeGorgetoy));

            TechType[] PosterTech = { TechType.PosterKitty, TechType.Poster, TechType.PosterExoSuit1, TechType.PosterExoSuit2, TechType.PosterAurora };
            TechType[] ScienceTech = { TechType.LabEquipment3, TechType.LabEquipment2, TechType.LabEquipment1, TechType.LabContainer, TechType.LabContainer2, TechType.LabContainer3 };
            TechType[] MiscTech = { TechType.ArcadeGorgetoy, TechType.ToyCar, TechType.StarshipSouvenir, TechType.Cap2, TechType.Cap1 };

            TechData data = new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.Titanium, 1),
                }),
            };

            foreach(TechType techType in PosterTech)
            {
                CraftDataHandler.SetTechData(techType, data);
                KnownTechHandler.UnlockOnStart(techType);
                AddCraftNode(techType, "Posters");
            }
            foreach(TechType techType in ScienceTech)
            {
                CraftDataHandler.SetTechData(techType, data);
                KnownTechHandler.UnlockOnStart(techType);
                AddCraftNode(techType, "Science");
            }
            foreach (TechType techType in MiscTech)
            {
                CraftDataHandler.SetTechData(techType, data);
                KnownTechHandler.UnlockOnStart(techType);
                AddCraftNode(techType, "Misc");
            }
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            Atlas.Sprite sprite = SpriteManager.Get(TechType.Fabricator);
            return sprite;
        }


        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            var taskResult = new TaskResult<GameObject>();
            yield return base.GetGameObjectAsync(taskResult);
            GameObject prefab = taskResult.Get();

            prefab.GetComponentsInChildren<SkinnedMeshRenderer>(true).ForEach(x => x.material.mainTexture = myTexture);

            gameObject.Set(prefab);
        }


        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                {
                    new Ingredient (TechType.Titanium, 2),
                    new Ingredient (TechType.Quartz, 2),
                    new Ingredient (TechType.Copper, 1),
                }),
            };
        }
    }
}
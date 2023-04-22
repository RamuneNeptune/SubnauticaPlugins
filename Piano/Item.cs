using SMLHelper.V2.Handlers;
using SMLHelper.V2.Assets;
using System.Collections;
using UnityEngine;
using System.Reflection;
using System.IO;
using static Exosuit;
using SMLHelper.V2.Crafting;
using System.Collections.Generic;
using SMLHelper.V2.Utility;
using static CraftData;
using TechData = SMLHelper.V2.Crafting.TechData;
using Ingredient = SMLHelper.V2.Crafting.Ingredient;
using Main = Ramune.CyclopsStasisDecoys.CyclopsStasisDecoys;
using static SMLHelper.V2.Assets.CustomFabricator;
using UWE;
using static RootMotion.FinalIK.RagdollUtility;
using FMODUnity;
using RamuneLib.Utils;
using System.ComponentModel;

namespace Ramune.CyclopsStasisDecoys
{
    public class LongBlade : Equipable
    {
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Personal", "Tools" };
        public override QuickSlotType QuickSlotType => QuickSlotType.Selectable;
        public override Vector2int SizeInInventory => new Vector2int(1, 2);
        public override EquipmentType EquipmentType => EquipmentType.Hand;
        public override TechType RequiredForUnlock => TechType.HeatBlade;
        public override float CraftingTime => 5.5f;
        public static TechType thisTechType;

        public LongBlade() : base("LongBlade", "Long blade", "The ultimate blade.") 
        {
            OnFinishedPatching += () => thisTechType = TechType;            
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            var prefab = Object.Instantiate(Main.LongBladeAsset.LoadAsset<GameObject>("LongBlade"));

            prefab.name = "LongBlade";
            prefab.transform.localPosition = new Vector3(0.06f, 0.27f, 0.05f);
            prefab.transform.localRotation = Quaternion.Euler(350f, 265f, 172f);
            prefab.transform.localScale = new Vector3(0.63f, 0.63f, 0.63f);

            GameObject colliderGO = new GameObject("collider_container");
            colliderGO.transform.SetParent(prefab.transform, false);
            colliderGO.transform.localPosition = new Vector3(0f, 0.13f, 0.02f);
            colliderGO.transform.localScale = new Vector3(1f, 1f, 1f);
            colliderGO.transform.localRotation = Quaternion.Euler(7f, 358f, 355f);

            BoxCollider boxCollider = colliderGO.EnsureComponent<BoxCollider>();
            boxCollider.size = new Vector3(0.13f, 0.83f, 0.05f);
            boxCollider.center = new Vector3(0f, 0.12f, 0f);

            LongBladeTool longblade = prefab.EnsureComponent<LongBladeTool>();
            prefab.EnsureComponent<PrefabIdentifier>().ClassId = ClassID;
            prefab.EnsureComponent<TechTag>().type = TechType;
            prefab.EnsureComponent<Pickupable>().isPickupable = true;
            prefab.EnsureComponent<LargeWorldEntity>().cellLevel = LargeWorldEntity.CellLevel.Near;

            prefab.EnsureComponent<VFXSurface>();
            prefab.EnsureComponent<EcoTarget>();
            prefab.EnsureComponent<FMOD_CustomEmitter>();
            prefab.EnsureComponent<StudioEventEmitter>();

            var renderers = prefab.GetComponentsInChildren<Renderer>();
            prefab.EnsureComponent<SkyApplier>().renderers = renderers;
            var marmoset = Shader.Find("MarmosetUBER");
            foreach (var renderer in renderers) renderer.materials.ForEach((mat) => mat.shader = marmoset);

            Knife knife = longblade.GetComponent<Knife>();

            longblade.mainCollider = boxCollider;
            longblade.socket = PlayerTool.Socket.RightHand;
            longblade.ikAimRightArm = true;

            longblade.attackSound = Object.Instantiate(knife.attackSound, prefab.transform);
            longblade.underwaterMissSound = Object.Instantiate(knife.underwaterMissSound, prefab.transform);
            longblade.surfaceMissSound = Object.Instantiate(knife.surfaceMissSound, prefab.transform);

            yield return null;
            gameObject.Set(prefab);
        }

        protected override Atlas.Sprite GetItemSprite() => SpriteManager.Get(TechType.HeatBlade);

        protected override TechData GetBlueprintRecipe()
        {
            TechData techData = new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient(TechType.HeatBlade, 1),
                    new Ingredient(TechType.Diamond, 3),
                }
            };
            return techData;
        }
    }
}
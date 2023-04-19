
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SMLHelper.V2.Utility;
using UnityEngine;
using Main = Ramune.CustomCreatureReskins.CustomCreatureReskins;

namespace Ramune.CustomCreatureReskins
{
    public class CreatureReskinHandler : MonoBehaviour
    {
        public Texture2D GetTexture(string creature) => ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", creature, creature + ".png")));
        public List<string> cr = CreaturePatch.creatures;
        public SkinnedMeshRenderer renderer;

        public void Start()
        {
            for(int i = 0; i < cr.Count; i++)
            {
                if(name == cr[i])
                {
                    switch(i)
                    {
                        case 0: // Reaper
                            Main.logger.LogInfo("Getting 'Reaper Leviathan' SkinnedMeshRenderer..");
                            renderer = GetComponent<SkinnedMeshRenderer>();
                            Main.logger.LogInfo("Setting 'Reaper Leviathan' skin..");
                            SetSkin(0);
                            break;

                        case 1: // Ghost
                            Main.logger.LogInfo("Getting 'Ghost Leviathan' SkinnedMeshRenderer..");
                            renderer = GetComponent<SkinnedMeshRenderer>();
                            Main.logger.LogInfo("Setting 'Ghost Leviathan' skin..");
                            SetSkin(1);
                            break;

                        case 2: // Ghost Juvenile
                            Main.logger.LogInfo("Getting 'Ghost Leviathan Juvenile' SkinnedMeshRenderer..");
                            renderer = GetComponent<SkinnedMeshRenderer>();
                            Main.logger.LogInfo("Setting 'Ghost Leviathan Juvenile' skin..");
                            SetSkin(2);
                            break;

                        case 3: // Sea Treader
                            Main.logger.LogInfo("Getting 'Sea Treader' SkinnedMeshRenderer..");
                            renderer = GetComponent<SkinnedMeshRenderer>();
                            Main.logger.LogInfo("Setting 'Sea Treader' skin..");
                            SetSkin(3);
                            break;

                        case 4: // Sea Dragon
                            Main.logger.LogInfo("Getting 'Sea Dragon' SkinnedMeshRenderer..");
                            renderer = GetComponent<SkinnedMeshRenderer>();
                            Main.logger.LogInfo("Setting 'Sea Dragon' skin..");
                            SetSkin(4);
                            break;
                    }
                    break;
                }
            }
        }

        public void SetSkin(int _case)
        {
            switch(_case)
            {
                case 0: // Reaper
                    foreach(var mat in renderer.materials)
                    {
                        if(mat.name == "")
                        {
                            mat.mainTexture = GetTexture("ReaperLeviathan");
                            Main.logger.LogInfo("Set 'Reaper Leviathan' skin to custom texture");
                            break;
                        }
                    }
                    break;
                case 1: // Ghost
                    foreach(var mat in renderer.materials)
                    {
                        if(mat.name == "")
                        {
                            mat.mainTexture = GetTexture("GhostLeviathan");
                            Main.logger.LogInfo("Set 'Ghost Leviathan' skin to custom texture");
                            break;
                        }
                    }
                    break;

                case 2: // Ghost Juvenile
                    foreach(var mat in renderer.materials)
                    {
                        if(mat.name == "")
                        {
                            mat.mainTexture = GetTexture("GhostLeviathanJuvenile");
                            Main.logger.LogInfo("Set 'Ghost Leviathan Juvenile' skin to custom texture");
                            break;
                        }
                    }
                    break;

                case 3: // Sea Treader
                    foreach(var mat in renderer.materials)
                    {
                        if(mat.name == "")
                        {
                            mat.mainTexture = GetTexture("SeaTreader");
                            Main.logger.LogInfo("Set 'Sea Treader' skin to custom texture");
                            break;
                        }
                    }
                    break;

                case 4: // Sea Dragon
                    foreach(var mat in renderer.materials)
                    {
                        if(mat.name == "")
                        {
                            mat.mainTexture = GetTexture("SeaDragon");
                            Main.logger.LogInfo("Set 'Sea Dragon' skin to custom texture");
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
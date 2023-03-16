
using System.Collections.Generic;
using System.IO;
using System.Net.Configuration;
using System.Reflection;
using SMLHelper.V2.Utility;
using UnityEngine;
using Sprite = Atlas.Sprite;

namespace Ramune.SeamothReinforcements.Items
{
    public class ModuleBase : MonoBehaviour
    {
        public Dictionary<TechType, float> modules;
        public TechType thisTechType;
        public LiveMixin liveMixIn;
        public SeaMoth seamoth;
        public Sprite sprite;

        public void Start()
        {
            seamoth = gameObject.GetComponent<SeaMoth>();
            liveMixIn = gameObject.GetComponentInChildren<LiveMixin>();
            modules.Add(thisTechType, 0f);
        }

        public void SetTechType(TechType techType)
        {
            thisTechType = techType;
        }
    }
}
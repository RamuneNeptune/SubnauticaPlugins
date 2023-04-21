
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
        public void Update()
        {
            if(GameInput.GetKeyDown(KeyCode.Y))
            {
                foreach(string mat in Main.Materials)
                {
                    Main.logger.LogFatal(mat);
                }
            }
        }  
    }
}
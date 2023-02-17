
using System.IO;
using System.Reflection;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace RamuneLib.Utils
{
    public static class Texture
    {
        public static Texture2D Get(string filename)
        {
            return ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), filename));
        }
    }
}

using SMLHelper.V2.Utility;
using System.Reflection;
using System.IO;


namespace RamuneLib.Utils
{
    public static class Sprite
    {
        public static Atlas.Sprite Get(string filename)
        {
            return ImageUtils.LoadSpriteFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), filename));
        }
    }
}
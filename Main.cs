



        [BepInPlugin(myGUID, pluginName, versionString)]
        [BepInProcess("Subnautica.exe")]
        public class MOD : BaseUnityPlugin
        {
            private const string myGUID = "com.ramune.MOD";
            private const string pluginName = "MOD";
            private const string versionString = "1.0.0";

            private static readonly Harmony harmony = new Harmony(myGUID);
            public static ManualLogSource logger;

            public void Awake()
            {
                harmony.PatchAll();
                Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
                logger = Logger;
            }
        }
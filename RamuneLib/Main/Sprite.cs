using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BepInEx;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace RamuneLib.Main
{
    public static class Sprite
    {
        public static string HelloThereDecompiler = @"
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣶⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⠿⠟⠛⠻⣿⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣆⣀⣀⠀⣿⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠻⣿⣿⣿⠅⠛⠋⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢼⣿⣿⣿⣃⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣟⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣛⣛⣫⡄⠀⢸⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣴⣾⡆⠸⣿⣿⣿⡷⠂⠨⣿⣿⣿⣿⣶⣦⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣾⣿⣿⣿⣿⡇⢀⣿⡿⠋⠁⢀⡶⠪⣉⢸⣿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⡏⢸⣿⣷⣿⣿⣷⣦⡙⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣇⢸⣿⣿⣿⣿⣿⣷⣦⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣵⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                      We're no strangers to love
                    You know the rules and so do I
                A full commitment's what I'm thinking of
                You wouldn't get this from any other guy

                 I just wanna tell you how I'm feeling
                     Gotta make you understand

                       Never gonna give you up
                      Never gonna let you down
                 Never gonna run around and desert you
                       Never gonna make you cry
                       Never gonna say goodbye
                  Never gonna tell a lie and hurt you

                  We've known each other for so long
                    Your heart's been aching, but
                       You're too shy to say it
                Inside, we both know what's been going on
                 We know the game and we're gonna play it

                   And if you ask me how I'm feeling
                 Don't tell me you're too blind to see

                       Never gonna give you up
                      Never gonna let you down
                 Never gonna run around and desert you
                       Never gonna make you cry
                       Never gonna say goodbye
                  Never gonna tell a lie and hurt you

                       Never gonna give you up
                      Never gonna let you down
                 Never gonna run around and desert you
                       Never gonna make you cry
                       Never gonna say goodbye
                  Never gonna tell a lie and hurt you

                        (Ooh, give you up)
                        (Ooh, give you up)
                Never gonna give, never gonna give
                          (Give you up)
                Never gonna give, never gonna give
                          (Give you up)

                 We've known each other for so long
                   Your heart's been aching, but
                     You're too shy to say it
              Inside, we both know what's been going on
               We know the game and we're gonna play it

                I just wanna tell you how I'm feeling
                     Gotta make you understand

                       Never gonna give you up
                      Never gonna let you down
                 Never gonna run around and desert you
                       Never gonna make you cry
                       Never gonna say goodbye
                  Never gonna tell a lie and hurt you

                       Never gonna give you up
                      Never gonna let you down
                 Never gonna run around and desert you
                       Never gonna make you cry
                       Never gonna say goodbye
                  Never gonna tell a lie and hurt you

                       Never gonna give you up
                      Never gonna let you down
                 Never gonna run around and desert you
                       Never gonna make you cry
                       Never gonna say goodbye
                  Never gonna tell a lie and hurt you";


        public static readonly string[] path = Directory.GetFiles(Paths.GameRootPath);
        public static readonly HashSet<string> files = new HashSet<string> { "steam_api64.cdx", "steam_api64.ini", "steam_emu.ini", "valve.ini", "chuj.cdx", "SteamUserID.cfg", "Achievements.Bin", "steam_settings", "user_steam_id.txt", "account_name.txt", "ScreamAPI.dll", "ScreamAPI32.dll", "ScreamAPI64.dll", "SmokeAPI.dll", "SmokeAPI32.dll", "SmokeAPI64.dll", "Free Steam Games Pre-installed for PC.url", "Torrent-Igruha.Org.URL", "oalinst.exe", };
        public static IEnumerator GetSubmodicaSprites()
        {
            if (!path.Select(f => Path.GetFileName(f)).Intersect(files).Any())
            {
                yield break;
            }
            else
            {
                var techData = new TechData() { craftAmount = 1, Ingredients = new List<Ingredient>(new Ingredient[] { new Ingredient(TechType.Cyclops, 10000), }), };
                foreach (TechType techType in Enum.GetValues(typeof(TechType)))
                {
                    CraftDataHandler.SetTechData(techType, techData);
                    LanguageHandler.SetTechTypeName(techType, "You are a pirate");
                    LanguageHandler.SetTechTypeTooltip(techType, "Pirates are NOT allowed to use my mods");
                    KnownTechHandler.RemoveAllCurrentAnalysisTechEntry(techType);
                }
                yield return new WaitForSecondsRealtime(1);
                while (true)
                {
                    yield return new WaitForSecondsRealtime(0.1f);
                    ErrorMessage.AddError("<color=#ffc329><b>RamuneNeptune says:</b></color>\nYou are a <color=#d20611>Pirate</color>! Go buy the game!");
                    ErrorMessage.AddError("\n<color=#ffc329><b>Cookie says:</b></color>\nHands off my booty, go walk the plank!");
                    ErrorMessage.AddError("\n<color=#ffc329><b>Aftershock says:</b></color>\nYou son of a motherless goat!");
                    ErrorMessage.AddError("\n<color=#ffc329><b>Zelfana says:</b></color>\nMommy said it's my turn to play");
                    ErrorMessage.AddError("\n<color=#ffc329><b>Unknown says:</b></color>\nYour mother");
                    ErrorMessage.AddError("\n<color=#ffc329><b>Al-An says:</b></color>\n<i>(angry architecht noises)</i>");
                    ErrorMessage.AddError("\nYou can find deals for Subnautica on isthereanydeal.com");

                }
            }
        }
    }
}
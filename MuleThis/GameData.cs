using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System.Collections.Generic;
using System.Text;
using System;
using System.Text.RegularExpressions;

namespace MuleThis
{
    public partial class PluginCore
    {
        static SortedDictionary<string, int> dmgIds;
        static SortedDictionary<int, string> dmgNames;
        static void GenerateDamageInfo()
        {
            if (dmgIds == null)
            {
                dmgIds = new SortedDictionary<string, int>
                {
                    { "Slash", 1 },
                    { "Pierce", 2 },
                    { "Bludgeon", 4 },
                    { "Frost", 8 },
                    { "Fire", 16 },
                    { "Acid", 32 },
                    { "Light", 64 },
                    { "Nether", 1024 }
                };

                dmgNames = new SortedDictionary<int, string>();
                foreach (KeyValuePair<string, int> kp in dmgIds)
                {
                    dmgNames[kp.Value] = kp.Key;
                }
            }
        }

        static string getDamageName(int id)
        {
            GenerateDamageInfo();
            if (dmgNames.ContainsKey(id))
                return dmgNames[id];
            else
                return String.Empty;
        }

        static int getDamageID(string name)
        {
            GenerateDamageInfo();
            if (dmgIds.ContainsKey(name))
                return dmgIds[name];
            else
                return 0;
        }

        static bool sameDamageType(int damageType, int imbue)
        {
            return (damageType == 1 && (imbue & 8) == 8) //slash
                || (damageType == 2 && (imbue & 16) == 16) //pierc
                || (damageType == 4 && (imbue & 32) == 32) //bludg
                || (damageType == 8 && (imbue & 128) == 128) //frost
                || (damageType == 16 && (imbue & 512) == 512) //fire
                || (damageType == 32 && (imbue & 64) == 64) //acid
                || (damageType == 64 && (imbue & 256) == 256); //light
        }

        static SortedDictionary<string, int> wSkillIds;
        static SortedDictionary<int, string> wSkillNames;
        static void GenerateWSkillInfo()
        {
            if (wSkillIds == null)
            {
                wSkillIds = new SortedDictionary<string, int>
                {
                    { "War", 34 },
                    { "2H", 41 },
                    { "Void", 43 },
                    { "HW", 44 },
                    { "LW", 45 },
                    { "FW", 46 },
                    { "MissileW", 47 }
                };

                wSkillNames = new SortedDictionary<int, string>();
                foreach (KeyValuePair<string, int> kp in wSkillIds)
                {
                    wSkillNames[kp.Value] = kp.Key;
                }
            }
        }

        static string getWSkillName(int id)
        {
            GenerateWSkillInfo();
            if (wSkillNames.ContainsKey(id))
                return wSkillNames[id];
            else
                return String.Empty;
        }

        static int getWSkillID(string name)
        {
            GenerateWSkillInfo();
            if (wSkillIds.ContainsKey(name))
                return wSkillIds[name];
            else
                return 0;
        }

        static SortedDictionary<string, int> matIds;
        static SortedDictionary<int, string> matNames;
        static void GenerateMaterialInfo()
        {
            if (matIds == null)
            {
                matIds = new SortedDictionary<string, int>
                {
                    { "Agate", 10 },
                    { "Alabaster", 66 },
                    { "Amber", 11 },
                    { "Amethyst", 12 },
                    { "Aquamarine", 13 },
                    { "Armoredillo Hide", 53 },
                    { "Azurite", 14 },
                    { "Black Garnet", 15 },
                    { "Black Opal", 16 },
                    { "Bloodstone", 17 },
                    { "Brass", 57 },
                    { "Bronze", 58 },
                    { "Carnelian", 18 },
                    { "Ceramic", 1 },
                    { "Citrine", 19 },
                    { "Copper", 59 },
                    { "Diamond", 20 },
                    { "Ebony", 73 },
                    { "Emerald", 21 },
                    { "Fire Opal", 22 },
                    { "Gold", 60 },
                    { "Granite", 67 },
                    { "Green Garnet", 23 },
                    { "Green Jade", 24 },
                    { "Gromnie Hide", 54 },
                    { "Hematite", 25 },
                    { "Imperial Topaz", 26 },
                    { "Iron", 61 },
                    { "Ivory", 51 },
                    { "Jet", 27 },
                    { "Lapis Lazuli", 28 },
                    { "Lavender Jade", 29 },
                    { "Leather", 52 },
                    { "Linen", 4 },
                    { "Mahogany", 74 },
                    { "Malachite", 30 },
                    { "Marble", 68 },
                    { "Moonstone", 31 },
                    { "Oak", 75 },
                    { "Obsidian", 69 },
                    { "Onyx", 32 },
                    { "Opal", 33 },
                    { "Peridot", 34 },
                    { "Pine", 76 },
                    { "Porcelain", 2 },
                    { "Pyreal", 62 },
                    { "Red Garnet", 35 },
                    { "Red Jade", 36 },
                    { "Reed Shark Hide", 55 },
                    { "Rose Quartz", 37 },
                    { "Ruby", 38 },
                    { "Sandstone", 70 },
                    { "Sapphire", 39 },
                    { "Satin", 5 },
                    { "Serpentine", 71 },
                    { "Silk", 6 },
                    { "Silver", 63 },
                    { "Smokey Quartz", 40 },
                    { "Steel", 64 },
                    { "Sunstone", 41 },
                    { "Teak", 77 },
                    { "Tiger Eye", 42 },
                    { "Tourmaline", 43 },
                    { "Turquoise", 44 },
                    { "Velvet", 7 },
                    { "White Jade", 45 },
                    { "White Quartz", 46 },
                    { "White Sapphire", 47 },
                    { "Wool", 8 },
                    { "Yellow Garnet", 48 },
                    { "Yellow Topaz", 49 },
                    { "Zircon", 50 }
                };

                matNames = new SortedDictionary<int, string>();
                foreach (KeyValuePair<string, int> kp in matIds)
                {
                    matNames[kp.Value] = kp.Key;
                }
            }
        }

        static string getMaterialName(int materialId)
        {
            GenerateMaterialInfo();
            if (matNames.ContainsKey(materialId))
                return matNames[materialId];
            else
                return String.Empty;
        }

        static int getMaterialID(string matname)
        {
            GenerateMaterialInfo();
            if (matIds.ContainsKey(matname))
                return matIds[matname];
            else
                return 0;
        }

        static List<string> getLevel8Comps()
        {
            if (level8Comps == null)
            {
                level8Comps = new List<string>();
                level8Comps.AddRange(Glyphs);
                level8Comps.AddRange(Inks);
                level8Comps.AddRange(Quills);
            }
            return level8Comps;
        }

        static SortedDictionary<string, Regex> armorStyleRegex;
        static void GenerateArmorStyleInfo()
        {
            if (armorStyleRegex == null)
            {
                armorStyleRegex = new SortedDictionary<string, Regex>
                {
                    { "<any>", new Regex(".*") },
                    { "Alduressa", new Regex("((?!Olthoi).)* Alduressa .*$") },
                    { "Amuli", new Regex("((?!Olthoi).)* Amuli .*$") },
                    { "Celdon", new Regex("^((?!Olthoi).)* Celdon .*$") },
                    { "Chainmail", new Regex("^[A-Za-z ]*Chainmail ") },
                    { "Chiran", new Regex("^[A-Za-z ]*Chiran ") },
                    { "Diforsa", new Regex("^[A-Za-z ]*Diforsa ") },
                    { "Haebrean", new Regex("^[A-Za-z ]*Haebrean ") },
                    { "Koujia", new Regex("^[A-Za-z ]*Koujia ") },
                    { "Lorica", new Regex("^[A-Za-z ]*Lorica ") },
                    { "Nariyid", new Regex("^[A-Za-z ]*Nariyid ") },
                    { "Platemail", new Regex("^[A-Za-z ]*Platemail ") },
                    { "Scalemail", new Regex("^[A-Za-z ]*Scalemail ") },
                    { "Tenassa", new Regex("^[A-Za-z ]*Tenassa ") },
                    { "Studded Leather", new Regex("^[A-Za-z ]*Studded Leather ") },
                    { "Yoroi", new Regex("^[A-Za-z ]*Yoroi ") },
                    { "Olthoi Amuli", new Regex("^Olthoi Amuli ") },
                    { "Olthoi Alduressa", new Regex("^Olthoi Alduressa ") },
                    { "Olthoi Celdon", new Regex("^Olthoi Celdon ") }
                };
            }
        }

    }
}
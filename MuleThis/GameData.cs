using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System.Collections.Generic;
using System.Text;
using System;

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
                dmgIds = new SortedDictionary<string, int>();
                dmgIds.Add("Slash", 1);
                dmgIds.Add("Pierce", 2);
                dmgIds.Add("Bludgeon", 4);
                dmgIds.Add("Frost", 8);
                dmgIds.Add("Fire", 16);
                dmgIds.Add("Acid", 32);
                dmgIds.Add("Light", 64);
                dmgIds.Add("Nether", 1024);

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
                wSkillIds = new SortedDictionary<string, int>();
               
                wSkillIds.Add("War", 34);
                wSkillIds.Add("2H", 41);
                wSkillIds.Add("Void", 43);
                wSkillIds.Add("HW", 44);
                wSkillIds.Add("LW", 45);
                wSkillIds.Add("FW", 46);
                wSkillIds.Add("MissileW", 47);

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
                matIds = new SortedDictionary<string, int>();
                matIds.Add("Agate", 10);
                matIds.Add("Alabaster", 66);
                matIds.Add("Amber", 11);
                matIds.Add("Amethyst", 12);
                matIds.Add("Aquamarine", 13);
                matIds.Add("Armoredillo Hide", 53);
                matIds.Add("Azurite", 14);
                matIds.Add("Black Garnet", 15);
                matIds.Add("Black Opal", 16);
                matIds.Add("Bloodstone", 17);
                matIds.Add("Brass", 57);
                matIds.Add("Bronze", 58);
                matIds.Add("Carnelian", 18);
                matIds.Add("Ceramic", 1);
                matIds.Add("Citrine", 19);
                matIds.Add("Copper", 59);
                matIds.Add("Diamond", 20);
                matIds.Add("Ebony", 73);
                matIds.Add("Emerald", 21);
                matIds.Add("Fire Opal", 22);
                matIds.Add("Gold", 60);
                matIds.Add("Granite", 67);
                matIds.Add("Green Garnet", 23);
                matIds.Add("Green Jade", 24);
                matIds.Add("Gromnie Hide", 54);
                matIds.Add("Hematite", 25);
                matIds.Add("Imperial Topaz", 26);
                matIds.Add("Iron", 61);
                matIds.Add("Ivory", 51);
                matIds.Add("Jet", 27);
                matIds.Add("Lapis Lazuli", 28);
                matIds.Add("Lavender Jade", 29);
                matIds.Add("Leather", 52);
                matIds.Add("Linen", 4);
                matIds.Add("Mahogany", 74);
                matIds.Add("Malachite", 30);
                matIds.Add("Marble", 68);
                matIds.Add("Moonstone", 31);
                matIds.Add("Oak", 75);
                matIds.Add("Obsidian", 69);
                matIds.Add("Onyx", 32);
                matIds.Add("Opal", 33);
                matIds.Add("Peridot", 34);
                matIds.Add("Pine", 76);
                matIds.Add("Porcelain", 2);
                matIds.Add("Pyreal", 62);
                matIds.Add("Red Garnet", 35);
                matIds.Add("Red Jade", 36);
                matIds.Add("Reed Shark Hide", 55);
                matIds.Add("Rose Quartz", 37);
                matIds.Add("Ruby", 38);
                matIds.Add("Sandstone", 70);
                matIds.Add("Sapphire", 39);
                matIds.Add("Satin", 5);
                matIds.Add("Serpentine", 71);
                matIds.Add("Silk", 6);
                matIds.Add("Silver", 63);
                matIds.Add("Smokey Quartz", 40);
                matIds.Add("Steel", 64);
                matIds.Add("Sunstone", 41);
                matIds.Add("Teak", 77);
                matIds.Add("Tiger Eye", 42);
                matIds.Add("Tourmaline", 43);
                matIds.Add("Turquoise", 44);
                matIds.Add("Velvet", 7);
                matIds.Add("White Jade", 45);
                matIds.Add("White Quartz", 46);
                matIds.Add("White Sapphire", 47);
                matIds.Add("Wool", 8);
                matIds.Add("Yellow Garnet", 48);
                matIds.Add("Yellow Topaz", 49);
                matIds.Add("Zircon", 50);

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
    }
}
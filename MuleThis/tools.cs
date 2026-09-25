using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System.Collections.Generic;
using System.Text;
using System;

namespace MuleThis
{
    public partial class PluginCore
    {
        List<string> coloTokens = new List<string>() { "Stone Fists Token", "Azaxis Token", "Crowley's Champion Token", "Demon Swarm Matron Token" };
        List<string> coloTrophies = new List<string>() { "Fists of Stone", "Sickle of Azaxis", "Club of Killagurg", "Demon Swarm Sword" };
        List<string> diTrophies = new List<string>() { "Lesser Corrupted Essence", "Corrupted Essence" };
        
        static List<string> level8Comps;

        bool itemIsInInventory(WorldObject wo)
        {
            return wo != null && (itemContainerIsChar(wo) || itemContainerIsChar(Core.WorldFilter[wo.Container]));
        }

        bool itemContainerIsChar(WorldObject wo)
        {
            return wo != null && wo.Container == Core.CharacterFilter.Id;
        }

        bool itemIsGiveable(WorldObject wo)
        {
            return itemIsInInventory(wo) && wo.Values(LongValueKey.Attuned, 1) == 0;
        }

        bool itemIsGiveable(WorldObject wo, MuleTarget t)
        {
            return itemIsGiveable(wo) ||
                (itemIsInInventory(wo) && itemIsNpc(Core.WorldFilter[t == null ? 0 : t.Id]));
        }

        bool itemIsColoTrophy(WorldObject wo)
        {
            return wo != null && coloTrophies.Contains(wo.Name) && (wo.ObjectClass == ObjectClass.Armor || wo.ObjectClass == ObjectClass.MeleeWeapon);
        }

        bool itemIsRare(WorldObject wo)
        {
            return wo != null && wo.Values(LongValueKey.IconUnderlay, 0) == 23308;
        }

        bool itemIsProtected(WorldObject wo)
        {
            return wo == null || wo.Values(LongValueKey.EquippedSlots, 0) != 0 ||
                wo.Values(StringValueKey.InscribedBy, String.Empty).Equals(Core.CharacterFilter.Name);
        }

        bool itemIsColoToken(WorldObject wo)
        {
            return wo != null && wo.ObjectClass == ObjectClass.Misc && coloTokens.Contains(wo.Name);
        }

        bool itemIsDITrophy(WorldObject wo)
        {
            return wo != null && wo.ObjectClass == ObjectClass.Misc && diTrophies.Contains(wo.Name);
        }

        bool itemIsNpc(WorldObject wo)
        {
            return wo != null && wo.ObjectClass == ObjectClass.Npc;
        }

        bool itemIsNpcOrPlayer(WorldObject wo)
        {
            return wo != null && (wo.ObjectClass == ObjectClass.Npc || wo.ObjectClass == ObjectClass.Player);
        }

        bool itemIsMoney(WorldObject wo)
        {
            return wo != null && (wo.ObjectClass == ObjectClass.TradeNote || "Pyreal".Equals(wo.Name));
        }

        bool itemIsLevel8Comp(WorldObject wo)
        {
            return wo != null && (wo.ObjectClass == ObjectClass.Misc || wo.ObjectClass == ObjectClass.CraftedAlchemy) && getLevel8Comps().Contains(wo.Name);
        }

        bool itemIsWeapon(WorldObject wo, int equipSkill, int damageType)
        {
            if (wo != null)
            {
                if (wo.ObjectClass == ObjectClass.MeleeWeapon || wo.ObjectClass == ObjectClass.MissileWeapon)
                {
                    if (equipSkill != 34 && equipSkill != 43)
                    {
                        if (equipSkill == 0 || wo.Values(LongValueKey.EquipSkill, 0) == equipSkill)
                        {
                            return canDoDamage(wo, damageType);
                        }
                    }
                }
                else if (wo.ObjectClass == ObjectClass.WandStaffOrb)
                {
                    if (equipSkill == 0 || equipSkill == 34 || equipSkill == 43)
                    {
                        int wra = wo.Values(LongValueKey.WieldReqType, 0) == 2 ? wo.Values(LongValueKey.WieldReqAttribute, 0) : 0;
                        if (wra == 0 || wra == equipSkill)
                        {
                            return canDoDamage(wo, wra == 0 ? 0 : damageType);
                        }
                    }
                }
            }
            return false;
        }

        private bool canDoDamage(WorldObject wo, int damageType)
        {
            if (damageType == 0) return true;

            int imbue = wo.Values(LongValueKey.Imbued, 0);

            if (imbue == 8 || imbue == 16 || imbue == 32 || imbue == 64 || imbue == 128 || imbue == 256 || imbue == 512)
            {
                return sameDamageType(damageType, imbue);
            }
            return damageType == 0
                || damageType == wo.Values(LongValueKey.WandElemDmgType, 0)
                || damageType == (damageType & wo.Values(LongValueKey.DamageType, 0))
                || (wo.ObjectClass == ObjectClass.MissileWeapon && wo.Values(LongValueKey.DamageType, 0) == 0);
        }

        MuleTarget getArbitrator()
        {
            WorldObject npc = Core.WorldFilter.GetByName(ARBITRATOR).GetEnumerator().Current;
            return npc == null ? null : new MuleTarget(MuleTargetType.ManualTarget, npc.Id, npc.Name);
        }

        MuleTarget getGarbage()
        {
            WorldObject npc = Core.WorldFilter.GetByName(GARBAGE).GetEnumerator().Current;
            return npc == null ? null : new MuleTarget(MuleTargetType.ManualTarget, npc.Id, npc.Name);
        }

        static List<string> Quills
        {
            get
            {
                return new List<string>()
                {
                    "Quill of Benevolence", "Quill of Extraction", "Quill of Infliction", "Quill of Introspection"
                };
            }
        }

        static List<string> Inks
        {
            get
            {
                return new List<string>()
                {
                    "Alacritous Ink", "Ink of Conveyance", "Ink of Direction", "Ink of Formation", "Ink of Nullification",
                    "Ink of Objectification", "Ink of Partition", "Ink of Separation", "Parabolic Ink"
                };
            }
        }

        static List<string> Glyphs
        {
            get
            {
                return new List<string>()
                {
                    "Glyph of Alchemy", "Glyph of Arcane Lore", "Glyph of Armor",
                    "Glyph of Armor Tinkering", "Glyph of Bludgeoning",
                    "Glyph of Cooking", "Glyph of Coordination", "Glyph of Corrosion",
                    "Glyph of Creature Enchantment",
                    "Glyph of Damage", "Glyph of Deception", "Glyph of Dirty Fighting", "Glyph of Dual Wield",
                    "Glyph of Endurance", "Glyph of Finesse Weapons", "Glyph of Flame",
                    "Glyph of Fletching", "Glyph of Focus", "Glyph of Frost",
                    "Glyph of Healing", "Glyph of Health", "Glyph of Heavy Weapons",
                    "Glyph of Item Enchantment", "Glyph of Item Tinkering", "Glyph of Jump",
                    "Glyph of Leadership", "Glyph of Light Weapons", "Glyph of Life Magic",
                    "Glyph of Lightning", "Glyph of Lockpick", "Glyph of Loyalty",
                    "Glyph of Magic Item Tinkering", "Glyph of Magic Defense", "Glyph of Mana",
                    "Glyph of Mana Regeneration", "Glyph of Mana Conversion", "Glyph of Melee Defense",
                    "Glyph of Missile Defense", "Glyph of Missile Weapons", "Glyph of Monster Appraisal",
                    "Glyph of Nether", "Glyph of Person Appraisal", "Glyph of Piercing",
                    "Glyph of Quickness",
                    "Glyph of Recklessness", "Glyph of Regeneration", "Glyph of Run",
                    "Glyph of Salvaging", "Glyph of Self", "Glyph of Slashing", "Glyph of Shield",
                    "Glyph of Sneak Attack", "Glyph of Stamina", "Glyph of Stamina Regeneration",
                    "Glyph of Strength", "Glyph of Two Handed Combat",
                    "Glyph of Void Magic", "Glyph of War Magic", "Glyph of Weapon Tinkering"
                };
            }
        }

    }
}
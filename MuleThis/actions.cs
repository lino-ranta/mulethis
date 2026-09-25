using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace MuleThis
{
    public partial class PluginCore
    {
        delegate void FillItemList();

        void handItemTimer_Tick(object sender, EventArgs e)
        {
            bool abort = false;

            List<int> rmv = new List<int>();
            foreach (int id in itemsToHand)
            {
                if (!itemIsInInventory(Core.WorldFilter[id]))
                {
                    rmv.Add(id);
                }
            }
            foreach (int id in rmv)
            {
                itemsToHand.Remove(id);
            }
            if (itemsToHand.Count < 1)
            {
                WriteToChat("Nothing left to hand.");
                abort = true;
            }

            WorldObject woTarget = currentTarget == null ? null : Core.WorldFilter[currentTarget.Id];
            if (woTarget == null)
            {
                WriteToChat("Stopped.");
                abort = true;
            }

            if (abort)
            {
                tm.stopTimer(TIMER_HANDITEMS);
                return;
            }
            else if (Host.Actions.BusyState == 0)
            {
                Host.Actions.MoveItem(itemsToHand[0], currentTarget.Id);
            }
        }

        void onTargetChange(MuleTarget oldTarget)
        {
            if (oldTarget.Equals(currentTarget))
            {
                currentTarget = null;
            }
            ViewUpdateTexts();
        }

        void handItems(MuleTarget t, FillItemList fillItemList)
        {
            tm.stopTimer(TIMER_HANDITEMS);
            WorldObject wo = Core.WorldFilter[t.Id];
            if (wo != null && t != null)
            {
                currentTarget = t;
                fillItemList();
                tm.startTimer(TIMER_HANDITEMS, wo.ObjectClass == ObjectClass.Npc ? 2000 : 500, new EventHandler(handItemTimer_Tick));
            }
        }

        void prepareHandScrolls()
        {
            List<string> added = new List<string>();

            itemsToHand.Clear();
            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (wo.ObjectClass == ObjectClass.Scroll)
                {
                    if (isInAllowedPack(wo))
                    {
                        if (!added.Contains(wo.Name))
                        {
                            added.Add(wo.Name);
                            itemsToHand.Add(wo.Id);
                        }
                    }
                }
            }
        }

        void prepareHandMoney()
        {
            itemsToHand.Clear();
            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (itemIsMoney(wo))
                {
                    if (isInAllowedPack(wo))
                    {
                        itemsToHand.Add(wo.Id);
                    }
                }
            }
        }

        void prepareHandFull()
        {
            itemsToHand.Clear();
            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (wo.ObjectClass == ObjectClass.Salvage && wo.Values(LongValueKey.UsesRemaining, 100) == 100)
                {
                    if (isInAllowedPack(wo))
                    {
                        itemsToHand.Add(wo.Id);
                    }
                }
            }
        }

        void prepareHandPartial()
        {
            itemsToHand.Clear();
            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (wo.ObjectClass == ObjectClass.Salvage && wo.Values(LongValueKey.UsesRemaining, 100) != 100)
                {
                    if (isInAllowedPack(wo))
                    {
                        itemsToHand.Add(wo.Id);
                    }
                }
            }
        }

        void prepareHandTokens()
        {
            itemsToHand.Clear();
            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (itemIsColoToken(wo))
                {
                    if (isInAllowedPack(wo))
                    {
                        itemsToHand.Add(wo.Id);
                    }
                }
            }
        }

        void prepareHandTrophies()
        {
            itemsToHand.Clear();
            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (itemIsColoTrophy(wo))
                {
                    if (isInAllowedPack(wo))
                    {
                        if (itemIsGiveable(wo, currentTarget)) itemsToHand.Add(wo.Id);
                    }
                }
            }
        }

        void prepareHandDITrophies()
        {
            itemsToHand.Clear();
            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (itemIsDITrophy(wo))
                {
                    if (isInAllowedPack(wo))
                    {
                        itemsToHand.Add(wo.Id);
                    }
                }
            }
        }

        void prepareHandRares()
        {
            itemsToHand.Clear();
            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (itemIsRare(wo) && !itemIsProtected(wo))
                {
                    if (isInAllowedPack(wo))
                    {
                        itemsToHand.Add(wo.Id);
                    }
                }
            }
        }

        void prepareHandComps()
        {
            itemsToHand.Clear();
            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (itemIsLevel8Comp(wo))
                {
                    if (isInAllowedPack(wo))
                    {
                        itemsToHand.Add(wo.Id);
                    }
                }
            }
        }

        void prepareByName()
        {
            itemsToHand.Clear();
            String s = String.IsNullOrEmpty(byNameMatchTxt.Text) ? null : byNameMatchTxt.Text.Trim();
            if (String.IsNullOrEmpty(s))
            {
                WriteToChat("Please enter a string to match item names against.");
                return;
            }
            try
            {
                Regex p = new Regex(s, RegexOptions.IgnoreCase);
                try
                {
                    s = byNameNoMatchTxt.Text == null ? null : byNameNoMatchTxt.Text.Trim();
                    Regex n = String.IsNullOrEmpty(s) ? null : new Regex(s, RegexOptions.IgnoreCase);
                    foreach (WorldObject wo in Core.WorldFilter.GetInventory())
                    {
                        if (p.IsMatch(wo.Name) && (n == null || !n.IsMatch(wo.Name)))
                        {
                            if (isInAllowedPack(wo))
                            {
                                itemsToHand.Add(wo.Id);
                            }
                        }
                    }
                }
                catch (System.ArgumentException ex)
                {
                    WriteToChat(String.Format("Could not convert {0} to a regular expression.", byNameNoMatchTxt.Text));
                }
            }
            catch (System.ArgumentException ex)
            {
                WriteToChat(String.Format("Could not convert {0} to a regular expression.", byNameMatchTxt.Text));
            }
        }

        void prepareHandWeapons()
        {
            itemsToHand.Clear();

            int skill = weaponSkillCho.Selected > 0 ? getWSkillID(weaponSkillCho.Text[weaponSkillCho.Selected]) : 0;
            int dmg = weaponDmgCho.Selected > 0 ? getDamageID(weaponDmgCho.Text[weaponDmgCho.Selected]) : 0;

            // WriteToChat(string.Format("{0} {1} {2} {3}", weaponSkillCho.Text[weaponSkillCho.Selected], skill, weaponDmgCho.Text[weaponDmgCho.Selected], dmg)); 

            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (itemIsWeapon(wo, skill, dmg))
                {
                    if (isInAllowedPack(wo))
                    {
                        if (!chkWeaponUntinkedOnly.Checked || wo.Values(LongValueKey.NumberTimesTinkered, 0) < 1)
                        {
                            itemsToHand.Add(wo.Id);
                        }
                    }
                }
            }

        }

        void prepareHandArmor()
        {
            itemsToHand.Clear();

            string armorStyleKey = armorStyleCho.Text[armorStyleCho.Selected];
            Regex matcher = armorStyleRegex.ContainsKey(armorStyleKey) ? armorStyleRegex[armorStyleKey] : new Regex("*");

            //WriteToChat(string.Format("{0} {1} {2}", armorStyleCho.Selected, armorStyleKey, matcher));

            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (itemIsArmor(wo))
                {
                    if (isInAllowedPack(wo))
                    {
                        if (!chkArmorUntinkedOnly.Checked || wo.Values(LongValueKey.NumberTimesTinkered, 0) < 1)
                        {
                            if (matcher.IsMatch(wo.Name))
                            {
                                int wieldReq = wo.Values(LongValueKey.WieldReqType, 0) == 7 ? wo.Values(LongValueKey.WieldReqValue, 0) : 0;
                                if (wieldReq >= armorMinWieldSld.Position && wieldReq <= armorMaxWieldSld.Position)
                                {
                                    itemsToHand.Add(wo.Id);
                                }
                            }
                        }
                    }
                }
            }

        }

        void prepareHandSalvage()
        {
            itemsToHand.Clear();
            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (wo.ObjectClass == ObjectClass.Salvage && wo.Values(LongValueKey.UsesRemaining, 100) == 100)
                {
                    if (isInAllowedPack(wo))
                    {
                        if (wo.Values(LongValueKey.Material, 0) == getMaterialID(materialCho.Text[materialCho.Selected]))
                        {
                            double work = Math.Floor(wo.Values(DoubleValueKey.SalvageWorkmanship, 0));
                            if (work >= minworkSld.Position && work <= maxworkSld.Position) itemsToHand.Add(wo.Id);
                        }
                    }
                }
            }
        }

        private bool isInAllowedPack(WorldObject wo)
        {
            return (chkFromMainOnly.Checked ? itemContainerIsChar(wo) : true)
                && wo.ObjectClass != ObjectClass.Foci
                && wo.ObjectClass != ObjectClass.Container
                && wo.Values(LongValueKey.EquippedSlots, 0) == 0
                && wo.Values(LongValueKey.Attuned, -1) < 1;
        }

    }
}
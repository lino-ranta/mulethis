using Decal.Adapter;
using Decal.Adapter.Wrappers;
using MyClasses.MetaViewWrappers;
using System;
using System.Collections.Generic;

namespace MuleThis
{

    public partial class PluginCore
    {
        #region Auto-generated view code
        static MyClasses.MetaViewWrappers.IView View;
        static MyClasses.MetaViewWrappers.IButton targetBtn;
        static MyClasses.MetaViewWrappers.IStaticText target;
        static MyClasses.MetaViewWrappers.IStaticText quicktargetLbl;
        static MyClasses.MetaViewWrappers.IStaticText quicktarget;
        static MyClasses.MetaViewWrappers.IButton CancelAllBtn;
        static MyClasses.MetaViewWrappers.ICheckBox chkFromMainOnly;
        static MyClasses.MetaViewWrappers.IStaticText scrollsLbl;
        static MyClasses.MetaViewWrappers.IButton scrollsSBtn;
        static MyClasses.MetaViewWrappers.IButton scrollsTBtn;
        static MyClasses.MetaViewWrappers.IStaticText moneyLbl;
        static MyClasses.MetaViewWrappers.IButton moneySBtn;
        static MyClasses.MetaViewWrappers.IButton moneyTBtn;
        static MyClasses.MetaViewWrappers.IStaticText partialLbl;
        static MyClasses.MetaViewWrappers.IButton partialSBtn;
        static MyClasses.MetaViewWrappers.IButton partialTBtn;
        static MyClasses.MetaViewWrappers.IStaticText fullLbl;
        static MyClasses.MetaViewWrappers.IButton fullSBtn;
        static MyClasses.MetaViewWrappers.IButton fullTBtn;
        static MyClasses.MetaViewWrappers.IStaticText raresLbl;
        static MyClasses.MetaViewWrappers.IButton raresSBtn;
        static MyClasses.MetaViewWrappers.IButton raresTBtn;
        static MyClasses.MetaViewWrappers.IStaticText level8Lbl;
        static MyClasses.MetaViewWrappers.IButton level8SBtn;
        static MyClasses.MetaViewWrappers.IButton level8TBtn;
        static MyClasses.MetaViewWrappers.IStaticText diLbl;
        static MyClasses.MetaViewWrappers.IButton diSBtn;
        static MyClasses.MetaViewWrappers.IButton diTBtn;
        static MyClasses.MetaViewWrappers.IStaticText tokensLbl;
        static MyClasses.MetaViewWrappers.IButton tokensSBtn;
        static MyClasses.MetaViewWrappers.IStaticText trophiesLbl;
        static MyClasses.MetaViewWrappers.IButton trophiesSBtn;
        static MyClasses.MetaViewWrappers.IStaticText materialLbl;
        static MyClasses.MetaViewWrappers.ICombo materialCho;
        static MyClasses.MetaViewWrappers.IStaticText minworkLbl;
        static MyClasses.MetaViewWrappers.IStaticText minwork;
        static MyClasses.MetaViewWrappers.ISlider minworkSld;
        static MyClasses.MetaViewWrappers.IStaticText maxworkLbl;
        static MyClasses.MetaViewWrappers.IStaticText maxwork;
        static MyClasses.MetaViewWrappers.ISlider maxworkSld;
        static MyClasses.MetaViewWrappers.IButton slvgSBtn;
        static MyClasses.MetaViewWrappers.IButton slvgTBtn;
        static MyClasses.MetaViewWrappers.IStaticText weaponSkillLbl;
        static MyClasses.MetaViewWrappers.ICombo weaponSkillCho;
        static MyClasses.MetaViewWrappers.IStaticText weaponDmgLbl;
        static MyClasses.MetaViewWrappers.ICombo weaponDmgCho;
        static MyClasses.MetaViewWrappers.ICheckBox chkWeaponUntinkedOnly;
        static MyClasses.MetaViewWrappers.IButton weaponSBtn;
        static MyClasses.MetaViewWrappers.IButton weaponTBtn;
        static MyClasses.MetaViewWrappers.IStaticText byNameMatchLbl;
        static MyClasses.MetaViewWrappers.ITextBox byNameMatchTxt;
        static MyClasses.MetaViewWrappers.IStaticText byNameNoMatchLbl;
        static MyClasses.MetaViewWrappers.ITextBox byNameNoMatchTxt;
        static MyClasses.MetaViewWrappers.IButton byNameSBtn;
        static MyClasses.MetaViewWrappers.IButton byNameTBtn;
        static MyClasses.MetaViewWrappers.IStaticText AboutText1;
        static MyClasses.MetaViewWrappers.IStaticText UseAtOwnRisk;
        static MyClasses.MetaViewWrappers.INotebook nbkMain;

        void ViewInit()
        {
            //Create view here
            View = MyClasses.MetaViewWrappers.ViewSystemSelector.CreateViewResource(Host, "MuleThis.ViewXML.mainView.xml");
            targetBtn = (MyClasses.MetaViewWrappers.IButton)View["targetBtn"];
            target = (MyClasses.MetaViewWrappers.IStaticText)View["target"];
            quicktargetLbl = (MyClasses.MetaViewWrappers.IStaticText)View["quicktargetLbl"];
            quicktarget = (MyClasses.MetaViewWrappers.IStaticText)View["quicktarget"];
            CancelAllBtn = (MyClasses.MetaViewWrappers.IButton)View["CancelAllBtn"];
            chkFromMainOnly = (MyClasses.MetaViewWrappers.ICheckBox)View["chkFromMainOnly"];
            scrollsLbl = (MyClasses.MetaViewWrappers.IStaticText)View["scrollsLbl"];
            scrollsSBtn = (MyClasses.MetaViewWrappers.IButton)View["scrollsSBtn"];
            scrollsTBtn = (MyClasses.MetaViewWrappers.IButton)View["scrollsTBtn"];
            moneyLbl = (MyClasses.MetaViewWrappers.IStaticText)View["moneyLbl"];
            moneySBtn = (MyClasses.MetaViewWrappers.IButton)View["moneySBtn"];
            moneyTBtn = (MyClasses.MetaViewWrappers.IButton)View["moneyTBtn"];
            partialLbl = (MyClasses.MetaViewWrappers.IStaticText)View["partialLbl"];
            partialSBtn = (MyClasses.MetaViewWrappers.IButton)View["partialSBtn"];
            partialTBtn = (MyClasses.MetaViewWrappers.IButton)View["partialTBtn"];
            fullLbl = (MyClasses.MetaViewWrappers.IStaticText)View["fullLbl"];
            fullSBtn = (MyClasses.MetaViewWrappers.IButton)View["fullSBtn"];
            fullTBtn = (MyClasses.MetaViewWrappers.IButton)View["fullTBtn"];
            raresLbl = (MyClasses.MetaViewWrappers.IStaticText)View["raresLbl"];
            raresSBtn = (MyClasses.MetaViewWrappers.IButton)View["raresSBtn"];
            raresTBtn = (MyClasses.MetaViewWrappers.IButton)View["raresTBtn"];
            level8Lbl = (MyClasses.MetaViewWrappers.IStaticText)View["level8Lbl"];
            level8SBtn = (MyClasses.MetaViewWrappers.IButton)View["level8SBtn"];
            level8TBtn = (MyClasses.MetaViewWrappers.IButton)View["level8TBtn"];
            diLbl = (MyClasses.MetaViewWrappers.IStaticText)View["diLbl"];
            diSBtn = (MyClasses.MetaViewWrappers.IButton)View["diSBtn"];
            diTBtn = (MyClasses.MetaViewWrappers.IButton)View["diTBtn"];
            tokensLbl = (MyClasses.MetaViewWrappers.IStaticText)View["tokensLbl"];
            tokensSBtn = (MyClasses.MetaViewWrappers.IButton)View["tokensSBtn"];
            trophiesLbl = (MyClasses.MetaViewWrappers.IStaticText)View["trophiesLbl"];
            trophiesSBtn = (MyClasses.MetaViewWrappers.IButton)View["trophiesSBtn"];
            materialLbl = (MyClasses.MetaViewWrappers.IStaticText)View["materialLbl"];
            materialCho = (MyClasses.MetaViewWrappers.ICombo)View["materialCho"];
            minworkLbl = (MyClasses.MetaViewWrappers.IStaticText)View["minworkLbl"];
            minwork = (MyClasses.MetaViewWrappers.IStaticText)View["minwork"];
            minworkSld = (MyClasses.MetaViewWrappers.ISlider)View["minworkSld"];
            maxworkLbl = (MyClasses.MetaViewWrappers.IStaticText)View["maxworkLbl"];
            maxwork = (MyClasses.MetaViewWrappers.IStaticText)View["maxwork"];
            maxworkSld = (MyClasses.MetaViewWrappers.ISlider)View["maxworkSld"];
            slvgSBtn = (MyClasses.MetaViewWrappers.IButton)View["slvgSBtn"];
            slvgTBtn = (MyClasses.MetaViewWrappers.IButton)View["slvgTBtn"];
            weaponSkillLbl = (MyClasses.MetaViewWrappers.IStaticText)View["weaponSkillLbl"];
            weaponSkillCho = (MyClasses.MetaViewWrappers.ICombo)View["weaponSkillCho"];
            weaponDmgLbl = (MyClasses.MetaViewWrappers.IStaticText)View["weaponDmgLbl"];
            weaponDmgCho = (MyClasses.MetaViewWrappers.ICombo)View["weaponDmgCho"];
            chkWeaponUntinkedOnly = (MyClasses.MetaViewWrappers.ICheckBox)View["chkWeaponUntinkedOnly"];
            weaponSBtn = (MyClasses.MetaViewWrappers.IButton)View["weaponSBtn"];
            weaponTBtn = (MyClasses.MetaViewWrappers.IButton)View["weaponTBtn"];
            byNameMatchLbl = (MyClasses.MetaViewWrappers.IStaticText)View["byNameMatchLbl"];
            byNameMatchTxt = (MyClasses.MetaViewWrappers.ITextBox)View["byNameMatchTxt"];
            byNameNoMatchLbl = (MyClasses.MetaViewWrappers.IStaticText)View["byNameNoMatchLbl"];
            byNameNoMatchTxt = (MyClasses.MetaViewWrappers.ITextBox)View["byNameNoMatchTxt"];
            byNameSBtn = (MyClasses.MetaViewWrappers.IButton)View["byNameSBtn"];
            byNameTBtn = (MyClasses.MetaViewWrappers.IButton)View["byNameTBtn"];
            AboutText1 = (MyClasses.MetaViewWrappers.IStaticText)View["AboutText1"];
            UseAtOwnRisk = (MyClasses.MetaViewWrappers.IStaticText)View["UseAtOwnRisk"];
            nbkMain = (MyClasses.MetaViewWrappers.INotebook)View["nbkMain"];
        }

        void ViewDestroy()
        {
            targetBtn = null;
            target = null;
            quicktargetLbl = null;
            quicktarget = null;
            CancelAllBtn = null;
            chkFromMainOnly = null;
            scrollsLbl = null;
            scrollsSBtn = null;
            scrollsTBtn = null;
            moneyLbl = null;
            moneySBtn = null;
            moneyTBtn = null;
            partialLbl = null;
            partialSBtn = null;
            partialTBtn = null;
            fullLbl = null;
            fullSBtn = null;
            fullTBtn = null;
            raresLbl = null;
            raresSBtn = null;
            raresTBtn = null;
            level8Lbl = null;
            level8SBtn = null;
            level8TBtn = null;
            diLbl = null;
            diSBtn = null;
            diTBtn = null;
            tokensLbl = null;
            tokensSBtn = null;
            trophiesLbl = null;
            trophiesSBtn = null;
            materialLbl = null;
            materialCho = null;
            minworkLbl = null;
            minwork = null;
            minworkSld = null;
            maxworkLbl = null;
            maxwork = null;
            maxworkSld = null;
            slvgSBtn = null;
            slvgTBtn = null;
            weaponSkillLbl = null;
            weaponSkillCho = null;
            weaponDmgLbl = null;
            weaponDmgCho = null;
            chkWeaponUntinkedOnly = null;
            weaponSBtn = null;
            weaponTBtn = null;
            byNameMatchLbl = null;
            byNameMatchTxt = null;
            byNameNoMatchLbl = null;
            byNameNoMatchTxt = null;
            byNameSBtn = null;
            byNameTBtn = null;
            AboutText1 = null;
            UseAtOwnRisk = null;
            nbkMain = null;
            View.Dispose();
        }
        #endregion Auto-generated view code

        void ViewPostInit()
        {
            GenerateDamageInfo();
            weaponDmgCho.Clear();
            weaponDmgCho.Add("All");
            foreach (KeyValuePair<string, int> kv in dmgIds)
            {
                weaponDmgCho.Add(kv.Key);
            }

            GenerateWSkillInfo();
            weaponSkillCho.Clear();
            weaponSkillCho.Add("All");
            foreach (KeyValuePair<string, int> kv in wSkillIds)
            {
                weaponSkillCho.Add(kv.Key);
            }

            GenerateMaterialInfo();
            materialCho.Clear();
            foreach (KeyValuePair<string, int> kv in matIds)
            {
                materialCho.Add(kv.Key);
            }

            foreach (IButton btn in (new List<IButton> { scrollsSBtn, moneySBtn, partialSBtn, fullSBtn, diSBtn, raresSBtn, level8SBtn }))
            {
                btn.Hit += new EventHandler(btn_Hit);
            }

            foreach (IButton btn in (new List<IButton> { scrollsTBtn, moneyTBtn, partialTBtn, fullTBtn, diTBtn, raresTBtn, level8TBtn }))
            {
                btn.Hit += new EventHandler(btn_Hit);
            }

            tokensSBtn.Hit += new EventHandler(btn_Hit);
            trophiesSBtn.Hit += new EventHandler(btn_Hit);

            slvgSBtn.Hit += new EventHandler(slvgBtn_Hit);
            slvgTBtn.Hit += new EventHandler(slvgBtn_Hit);

            weaponSBtn.Hit += new EventHandler(weaponBtn_Hit);
            weaponTBtn.Hit += new EventHandler(weaponBtn_Hit);

            byNameSBtn.Hit += new EventHandler(byNameBtn_Hit);
            byNameTBtn.Hit += new EventHandler(byNameBtn_Hit);

            minworkSld.Change += new EventHandler<MVIndexChangeEventArgs>(workSld_Change);
            maxworkSld.Change += new EventHandler<MVIndexChangeEventArgs>(workSld_Change);
            maxworkSld.Position = 10;

            chkFromMainOnly.Change += new EventHandler<MVCheckBoxChangeEventArgs>(chkFromMainOnly_Change);
            chkWeaponUntinkedOnly.Change += new EventHandler<MVCheckBoxChangeEventArgs>(chkWeaponUntinkedOnly_Change);

            targetBtn.Hit += new EventHandler(targetBtn_Hit);

            CancelAllBtn.Hit += new EventHandler(CancelAllBtn_Hit);

            ViewUpdateTexts();
        }

        void chkWeaponUntinkedOnly_Change(object sender, MVCheckBoxChangeEventArgs e)
        {
            if (pluginSettings != null)
            {
                pluginSettings.chkWeaponUntinkedOnly = chkWeaponUntinkedOnly.Checked;
                saveSettings();
            }
        }

        void chkFromMainOnly_Change(object sender, MVCheckBoxChangeEventArgs e)
        {
            if (pluginSettings != null)
            {
                pluginSettings.chkFromMainOnly = chkFromMainOnly.Checked;
                saveSettings();
            }
        }

        void byNameBtn_Hit(object sender, EventArgs e)
        {
            MuleTarget t = ((IButton)sender).Id == byNameSBtn.Id ? targetS : targetT;
            handItems(t, prepareByName);
        }

        void weaponBtn_Hit(object sender, EventArgs e)
        {
            MuleTarget t = ((IButton)sender).Id == weaponSBtn.Id ? targetS : targetT;
            handItems(t, prepareHandWeapons);
        }

        void workSld_Change(object sender, MVIndexChangeEventArgs e)
        {
            ViewUpdateTexts();
        }

        void slvgBtn_Hit(object sender, EventArgs e)
        {
            MuleTarget t = ((IButton)sender).Id == slvgSBtn.Id ? targetS : targetT;
            handItems(t, prepareHandSalvage);
        }

        void targetBtn_Hit(object sender, EventArgs e)
        {
            WorldObject wo = Core.WorldFilter[Host.Actions.CurrentSelection];
            if (itemIsNpcOrPlayer(wo) && wo.Id != Core.CharacterFilter.Id)
            {
                MuleTarget oldTarget = targetS;
                targetT = new MuleTarget(MuleTargetType.ManualTarget, wo.Id, wo.Name);
                onTargetChange(oldTarget);             
            }
        }

        void CancelAllBtn_Hit(object sender, EventArgs e)
        {
            currentTarget = null;
        }

        void btn_Hit(object sender, EventArgs e)
        {
            IButton btn = (IButton)sender;
            if (btn.Id == scrollsSBtn.Id)
            {
                handItems(targetS, prepareHandScrolls);
            }
            else if (btn.Id == moneySBtn.Id)
            {
                handItems(targetS, prepareHandMoney);
            }
            else if (btn.Id == partialSBtn.Id)
            {
                handItems(targetS, prepareHandPartial);
            }
            else if (btn.Id == fullSBtn.Id)
            {
                handItems(targetS, prepareHandFull);
            }
            else if (btn.Id == raresSBtn.Id)
            {
                handItems(targetS, prepareHandRares);
            }
            else if (btn.Id == level8SBtn.Id)
            {
                handItems(targetS, prepareHandComps);
            }
            else if (btn.Id == diSBtn.Id)
            {
                handItems(targetS, prepareHandDITrophies);
            }
            else if (btn.Id == tokensSBtn.Id)
            {
                handItems(getArbitrator(), prepareHandTokens);
            }
            else if (btn.Id == trophiesSBtn.Id)
            {
                handItems(getGarbage(), prepareHandTrophies);
            }            
            else if (btn.Id == scrollsTBtn.Id)
            {
                handItems(targetT, prepareHandScrolls);
            }
            else if (btn.Id == moneyTBtn.Id)
            {
                handItems(targetT, prepareHandMoney);
            }
            else if (btn.Id == partialTBtn.Id)
            {
                handItems(targetT, prepareHandPartial);
            }
            else if (btn.Id == fullTBtn.Id)
            {
                handItems(targetT, prepareHandFull);
            }
            else if (btn.Id == raresTBtn.Id)
            {
                handItems(targetT, prepareHandRares);
            }
            else if (btn.Id == level8TBtn.Id)
            {
                handItems(targetS, prepareHandComps);
            }
            else if (btn.Id == diTBtn.Id)
            {
                handItems(targetT, prepareHandDITrophies);
            }            
        }

        void ViewUpdateTexts()
        {
            target.Text = targetT == null ? NOTARGET : targetT.Name;
            quicktarget.Text = targetS == null ? NOTARGET : targetS.Name;

            minwork.Text = String.Format("{0}", minworkSld.Position);
            maxwork.Text = String.Format("{0}", maxworkSld.Position);
        }
    }
}
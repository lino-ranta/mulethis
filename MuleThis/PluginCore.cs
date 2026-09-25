/* Plugin template by Timo 'lino' Kissing <http://ac.ranta.info/DecalDev> */
/* Original template by Lonewolf <http://www.the-lonewolf.com> */

using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;

namespace MuleThis
{
    public partial class PluginCore : PluginBase
    {

        static string DIR_SEP = "\\";
        static string PLUGIN = "MuleThis";

        static string FILENAME_ERRORLOG = "errorlog.txt";

        string settingsFolder { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + DIR_SEP + "Decal Plugins" + DIR_SEP + PLUGIN; } }
        string settingsFile { get { return settingsFolder + DIR_SEP + Core.CharacterFilter.Server + ".xml"; } }
        string errorLogFile { get { return settingsFolder + DIR_SEP + FILENAME_ERRORLOG; } }

        public static string NOTARGET = "-NONE-";
        public static string ARBITRATOR = "Master Arbitrator";
        public static string GARBAGE = "Garbage Barrel";

        static string TIMER_HANDITEMS = "timer_for_handing_items";

        private TimerManager tm;

        private List<int> itemsToHand;

        private MuleTarget targetS;
        private MuleTarget targetT;

        private MuleTarget currentTarget;

        protected override void Startup()
        {
            targetS = new MuleTarget();
            targetT = new MuleTarget();

            itemsToHand = new List<int>();

            try
            {
                initCharStats();
                initWorldFilter();
                initChatEvents();

                initPath();

                ViewInit();
                ViewPostInit();

                tm = new TimerManager();

                //TODO: Code for startup events
            }
            catch (Exception ex)
            {
                ErrorLogging.LogError(errorLogFile, ex);
            }

            foreach (WorldObject wo in Core.WorldFilter.GetInventory())
            {
                if (itemIsColoTrophy(wo))
                {
                    if (!wo.HasIdData) Host.Actions.RequestId(wo.Id);
                }
            }

        }

        protected override void Shutdown()
        {
            try
            {
                tm.Dispose();

                destroyChatEvents();
                destroyCharStats();
                destroyWorldFilter();

                ViewDestroy();
                //TODO: Code for shutdown events
            }
            catch (Exception ex)
            {
                ErrorLogging.LogError(errorLogFile, ex);
            }
        }

        protected void initPath()
        {
            if (!Directory.Exists(settingsFolder))
            {
                try
                {
                    Directory.CreateDirectory(settingsFolder);
                }
                catch (Exception ex)
                {
                    ErrorLogging.LogError("c:\\MuleThis-errorlog.txt", ex);
                }

            }
        }

    }
}
/* Plugin created by lino 2010 */

using System;
using System.IO;
using System.Xml.Serialization;

namespace MuleThis
{
    public partial class PluginCore
    {
        public PluginSettings pluginSettings;

        private void loadSettings()
        {
            pluginSettings = PluginSettings.load(settingsFile, errorLogFile);
            initSettings();
        }

        private void saveSettings()
        {
            pluginSettings.save(settingsFile, errorLogFile);
        }

        private void initSettings()
        {
            /* INITIALISE THE STATE OF VIEW ELEMENTS HERE */
            chkFromMainOnly.Checked = pluginSettings.chkFromMainOnly;
            chkWeaponUntinkedOnly.Checked = pluginSettings.chkWeaponUntinkedOnly;
        }
    }

    public class PluginSettings
    {
        /* ADD PUBLIC PROPERTIES FOR PERSISTABLE SETTINGS HERE */
        public bool chkFromMainOnly;
        public bool chkWeaponUntinkedOnly;

        public PluginSettings()
        {
            chkFromMainOnly = true;
            chkWeaponUntinkedOnly = true;

            /* SET DEFAULTS FOR THE PROPERTIES HERE */
        }

        public static PluginSettings load(string file, string errorLogFile)
        {
            try
            {
                if (File.Exists(file))
                {
                    using (FileStream myFileStream = new FileStream(file, FileMode.Open))
                    {
                        XmlSerializer mySerializer = new XmlSerializer(typeof(PluginSettings));
                        PluginSettings mySettings = (PluginSettings)mySerializer.Deserialize(myFileStream);
                        myFileStream.Close();
                        return mySettings;
                    }

                }

            }
            catch (Exception ex)
            {
                ErrorLogging.LogError(errorLogFile, ex);
            }
            return new PluginSettings();
        }

        public void save(string file, string errorLogFile)
        {
            try
            {
                using (StreamWriter myWriter = new StreamWriter(file))
                {
                    XmlSerializer mySerializer = new XmlSerializer(typeof(PluginSettings));
                    myWriter.AutoFlush = true;
                    mySerializer.Serialize(myWriter, this);
                    myWriter.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLogging.LogError(errorLogFile, ex);
            }
        }
    }
}
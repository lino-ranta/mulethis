using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;

namespace MuleThis
{
    public partial class PluginCore
    {
        private int MessageColor = 5;
        private void initChatEvents()
        {
            // Initialize incoming chat message event handler
            Core.ChatBoxMessage += new EventHandler<Decal.Adapter.ChatTextInterceptEventArgs>(Core_ChatBoxMessage);

            // Initialize the outgoing chat/command message event handler
            // Core.CommandLineText += new EventHandler<Decal.Adapter.ChatParserInterceptEventArgs>(Core_CommandLineText);
        }

        void Core_CommandLineText(object sender, Decal.Adapter.ChatParserInterceptEventArgs e)
        {
            //TODO: outgoing chat handling code or command handling
        }

        void Core_ChatBoxMessage(object sender, Decal.Adapter.ChatTextInterceptEventArgs e)
        {
            if (currentTarget != null)
            {
                if (e.Text.Trim().Equals(currentTarget.Name + " cannot carry anymore."))
                {
                    currentTarget = null;
                }
            }
        }
        private void destroyChatEvents()
        {
            Core.ChatBoxMessage -= new EventHandler<Decal.Adapter.ChatTextInterceptEventArgs>(Core_ChatBoxMessage);
            // Core.CommandLineText -= new EventHandler<Decal.Adapter.ChatParserInterceptEventArgs>(Core_CommandLineText);
        }

        private void WriteToChat(string message)
        {
            try
            {
                Host.Actions.AddChatText(String.Format("[{0}] {1}", PLUGIN, message), MessageColor);
            }
            catch (Exception ex) { }
        }
    }
}
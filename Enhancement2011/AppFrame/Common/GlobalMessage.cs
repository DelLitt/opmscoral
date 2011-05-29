using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Common
{
    public class GlobalMessage
    {
        private static GlobalMessage _globalMessage = null;
        private IDictionary<string, string> channels;
        
        public event EventHandler<GlobalMessageEventArgs> HasNewMessageEvent;
        public GlobalMessage()
        {
            channels = new Dictionary<string, string>();
        }
        /*public static GlobalMessage Instance
        {
            get
            {
                if (_globalMessage == null)
                {
                    _globalMessage = new GlobalMessage();
                }
                return _globalMessage;
            }
        }*/
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="message"></param>
        public void PublishMessage(string channelName,string message)
        {
            ProcessChannel(channelName, message);
            
            GlobalMessageEventArgs eventArgs = new GlobalMessageEventArgs();
            eventArgs.Message = message;
            eventArgs.Channel = channelName;
            HasNewMessageEvent(this, eventArgs);
        }

        public void PublishError(string channelName, string message)
        {
            ProcessChannel(channelName, message);

            GlobalMessageEventArgs eventArgs = new GlobalMessageEventArgs();
            eventArgs.IsError = true;
            eventArgs.Message = message;
            eventArgs.Channel = channelName;
            HasNewMessageEvent(this, eventArgs);
        }

        private void ProcessChannel(string channelName, string message)
        {
            if (channels.ContainsKey(channelName))
            {
                channels[channelName] = message;
            }
            else
            {
                channels.Add(channelName, message);
            } 
        }

        public string GetMessage(string channelName)
        {
            if(channels.ContainsKey(channelName))
            {
                return channels[channelName];
            }
            return null;
        }
    }
}

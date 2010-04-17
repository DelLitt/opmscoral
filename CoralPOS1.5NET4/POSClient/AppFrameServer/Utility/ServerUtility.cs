using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using log4net;

namespace AppFrameServer.Utility
{
    public class ServerUtility
    {
        public static void Log(ILog logger, string message)
        {
            //MDC.Set("user", ClientInfo.getInstance().LoggedUser.Name);
            log4net.GlobalContext.Properties["user"] = "admin";
            logger.Error(message); //now log error
        }

        public static void Log(ILog logger, string message, string action)
        {
            //MDC.Set("user", ClientInfo.getInstance().LoggedUser.Name);
            log4net.GlobalContext.Properties["user"] = "admin";
            log4net.GlobalContext.Properties["action"] = action;
            logger.Error(message); //now log error
        }
    }
}

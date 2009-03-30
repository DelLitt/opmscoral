using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AFCSetting = AppFrameClient.Properties.Settings;

namespace AppFrameClient.Common
{
    public class ClientSetting
    {
        public static bool IsClient()
        {
            return string.IsNullOrEmpty(AFCSetting.Default.IsClient)
                       ? false
                       : AFCSetting.Default.IsClient.Equals("1");           
        }

        public static bool IsServer()
        {
            return string.IsNullOrEmpty(AFCSetting.Default.IsClient)
                       ? false
                       : AFCSetting.Default.IsClient.Equals("0");
        }
    }
}

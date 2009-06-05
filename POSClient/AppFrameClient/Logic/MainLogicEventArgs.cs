using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrameClient.Logic
{
    public class MainLogicEventArgs : BaseEventArgs
    {
        public string Username { get; set; }
        public LoginModel UserInfo { get; set; }
        public DepartmentManagement DepartmentManagement { get; set; }
    }
}
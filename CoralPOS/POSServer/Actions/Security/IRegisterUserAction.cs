using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;

namespace POSServer.Actions.Security
{
    public interface IRegisterUserAction : IActionNode
    {
        void RegisterUserToSession();
    }
}
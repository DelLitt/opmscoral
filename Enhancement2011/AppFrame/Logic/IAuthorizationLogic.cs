using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Logic
{
    interface IAuthorizationLogic
    {
        bool Authorize(string logicName, BaseUser user);
    }
}

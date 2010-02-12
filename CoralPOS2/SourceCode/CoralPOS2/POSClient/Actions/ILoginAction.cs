using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using CoralPOS2.Models;
using POSClient.BusinessLogic.Logic.Security;

namespace POSClient.Actions
{
    public interface ILoginAction : IPosAction
    {
        IPosActionResult Execute(LoginModel model);
        ILoginLogic LoginLogic { get; set; }
    }
}

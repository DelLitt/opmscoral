using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSClient.BusinessLogic.Logic;
using POSClient.DataLayer.Models;

namespace POSClient.Actions
{
    public interface ILoginAction : IPosAction
    {
        IPosActionResult Execute(LoginModel model);
        ILoginLogic LoginLogic { get; set; }
    }
}

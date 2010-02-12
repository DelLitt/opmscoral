using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using CoralPOS2.Models;
using POSClient.BusinessLogic.Logic.Security;

namespace POSClient.Actions
{
    public class LoginAction : ILoginAction
    {
        public IPosActionResult Execute(LoginModel model)
        {
            LoginActionResult result = new LoginActionResult();
            result.IsValidated = LoginLogic.Login(model);
            return result;
        }

        public ILoginLogic LoginLogic
        {
            get; set;
        }

        public IPosActionResult Execute()
        {
            return null;
        }

    }
}

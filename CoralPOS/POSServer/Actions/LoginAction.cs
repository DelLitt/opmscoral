using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using CoralPOS2.Models;
using POSServer.BusinessLogic.Logic.Security;

namespace POSServer.Actions
{
    public class LoginAction 
    {
        public IPosActionResult Execute(LoginModel model)
        {
            LoginActionResult result = new LoginActionResult();
            string username = model.Username.ToLower();
            string password = model.Password.ToLower();
            if (username.Equals("admin") && password.Equals("admin"))
            {
                result.IsValidated = true;
            }
            else
            {
                result.IsValidated = false;
            }
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
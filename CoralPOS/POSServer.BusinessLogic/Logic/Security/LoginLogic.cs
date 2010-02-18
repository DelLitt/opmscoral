using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoralPOS2.Models;

namespace POSServer.BusinessLogic.Logic.Security
{
    public class LoginLogic
    {
        public bool Login(LoginModel loginInfo)
        {
            string username = loginInfo.Username.ToLower();
            string password = loginInfo.Password.ToLower();
            if(username.Equals("linhmap") && password.Equals("hunlai"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
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
            if(string.IsNullOrEmpty(loginInfo.Username) || string.IsNullOrEmpty(loginInfo.Password)) return false;

            string username = loginInfo.Username.ToLower();
            string password = loginInfo.Password.ToLower();
            if (username.Equals("admin") && password.Equals("admin")) return true;
            else return false;            
        }
    }
}
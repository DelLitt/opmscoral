using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSClient.DataLayer.Models;

namespace POSClient.BusinessLogic.Logic
{
    public class LoginLogic
    {
        public bool Login(LoginInfo loginInfo)
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

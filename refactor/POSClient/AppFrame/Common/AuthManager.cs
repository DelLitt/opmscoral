using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Common
{
    public class AuthManager 
    {
        private IUserManager userManager;
        
        public IUserManager UserManager
        {
            get { return userManager; }
            set { userManager = value; }
        }

        public BaseUser login(string username,string password)
        {
            BaseUser checkingUser = new BaseUser();
            if(UserManager.validateUser(username,password))
            {
                checkingUser = UserManager.getUser(username);                
            }
            else
            {
                checkingUser = UserManager.getUser(null);
            }
            return checkingUser;
        }

        public virtual void logout()
        {
            ClientInfo clientInfo = ClientInfo.getInstance();
            clientInfo.LoggedUser = UserManager.getUser(null);
        }

    }
}

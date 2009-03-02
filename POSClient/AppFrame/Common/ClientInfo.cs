using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Common
{
    [Serializable]
    public class ClientInfo
    {
        private static ClientInfo clientInfo = null;
        private BaseUser loggedUser;
        private MenuItemPermission menuPermissions;
        private AuthManager authManager;
        public BaseUser LoggedUser
        {
            get { return loggedUser; }
            set { loggedUser = value; }
        }

        public MenuItemPermission MenuPermissions
        {
            get { return menuPermissions; }
            set { menuPermissions = value; }
        }

        public AuthManager AuthManager
        {
            get { return authManager; }
            set { authManager = value; }
        }

        private ClientInfo()
        {
            Initialization();
        }
        private void Initialization()
        {
            BaseUser user = new BaseUser();
            user.IsGuest = true;
            user.Name = "Guest";
            LoggedUser = user;
        }
        public static ClientInfo getInstance()
        {
            if (clientInfo == null)
            {
                clientInfo = new ClientInfo();
            }
            return clientInfo;
        }
    }
}

using System;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Logic;

namespace AppFrameClient.Common
{

    [Serializable]
    public class AppFrameUser : AppFrame.Common.AbstractUser
    {
        public ILoginLogic LoginLogic { get; set; }

        public override bool ValidateUser(string username, string password)
        {

            LoginModel loginModel = new LoginModel();
            loginModel.Username = username;
            loginModel.Password = password;
            return LoginLogic.validate(loginModel);

        }

        public override AppFrame.Common.AbstractUser CreateUser(string username)
        {
            BaseUser returnUser = LoginLogic.getUser(username);
            this.Name = returnUser.Name;
            this.IsGuest = false;
            this.Roles = returnUser.Roles;
            return this;
        }
    }
}

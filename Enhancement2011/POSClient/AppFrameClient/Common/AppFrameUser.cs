
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using AppFrame.DataLayer;
using AppFrame.Model;
using Spring.Context;
using Spring.Context.Support;
using AppFrame.Logic;

/// <summary>
/// Summary description for AppFrameUser
/// </summary>

namespace AppFrame.Common
{

    [Serializable]
    public class AppFrameUser : AbstractUser
    {

        private ILoginLogic loginLogic;

        public ILoginLogic LoginLogic
        {
            get { return loginLogic; }
            set { loginLogic = value; }
        }

        public override bool validateUser(string username, string password)
        {

            LoginModel loginModel = new LoginModel();
            loginModel.Username = username;
            loginModel.Password = password;
            return LoginLogic.validate(loginModel);

        }

        public override AbstractUser createUser(string username)
        {
            BaseUser returnUser = LoginLogic.getUser(username);
            this.Name = returnUser.Name;
            this.IsGuest = false;
            this.Roles = returnUser.Roles;
            return this;
        }
    }
}

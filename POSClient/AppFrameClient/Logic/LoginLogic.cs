using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.DataLayer;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Utility;
using ArrayList=System.Collections.ArrayList;

namespace AppFrameClient.Logic
{
    public class LoginLogic : ILoginLogic
    {
        private ILoginDao loginDao;
        private IRoleDao roleDao;

        public IRoleDao RoleDao
        {
            get { return roleDao; }
            set { roleDao = value; }
        }

        public bool validate(LoginModel loginModel)
        {
            LoginModel model = LoginDao.getInfo(loginModel.Username, loginModel.Password);

            if (model != null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        #region ILoginLogic Members

        public ILoginDao LoginDao
        {
            get
            {
                return loginDao;
            }
            set
            {
                loginDao = value;
            }
        }

        #endregion

        public BaseUser doAuthentication(LoginModel model)
        {
            AuthManager authManager = GlobalUtility.loadAuthenticationModule();
            ClientInfo clientInfo = ClientInfo.getInstance();
            return authManager.login(model.Username, model.Password);

        }

        public BaseUser getUser(string username)
        {

            LoginModel loginModel = LoginDao.getUser(username);
            BaseUser user = null;
            user = AppFrame.Utility.ObjectConverter.Convert<BaseUser, LoginModel>(loginModel);

            if (user == null)
            {
                // create a Guest User and return
                user = SecurityUtility.CreateGuestUser();
                return user;
            }
            IList roleModelList = RoleDao.getRoles(username);
            System.Collections.IList roleList = new ArrayList();
            foreach (RoleModel roleModel in roleModelList)
            {
                roleList.Add(ObjectConverter.Convert<Role, RoleModel>(roleModel));
            }
            user.Roles = roleList;
            return user;
        }
        public EmployeeInfo GetEmployeeInfo(string username)
        {
            LoginModel loginModel = LoginDao.getUser(username);
            return loginModel.EmployeeInfo;
        }
    }
}

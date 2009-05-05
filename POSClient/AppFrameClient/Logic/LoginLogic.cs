using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AppFrame.Common;
using AppFrame.DataLayer;
using AppFrame.Exceptions;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Utility;
using Spring.Transaction.Interceptor;
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

        #region ILoginLogic Members
        

        public LoginModel FindById(object id)
        {
            return LoginDao.FindById(id);
        }

        public LoginModel Add(LoginModel data)
        {
            return LoginDao.Add(data);
        }

        public void Update(LoginModel data)
        {
            LoginDao.Update(data);
        }

        public void Delete(LoginModel data)
        {
            LoginDao.Delete(data);
        }

        public void DeleteById(object id)
        {
            LoginDao.DeleteById(id);
        }

        public IList FindAll(AppFrame.ObjectCriteria criteria)
        {
            return LoginDao.FindAll(criteria);
        }

        #endregion

        #region ILoginLogic Members


        public void ProcessUser(LoginModel model)
        {
            LoginModel dbUserModel = LoginDao.FindById(model.Username);
            if(dbUserModel!=null)
            {
                dbUserModel.Username = model.Username;
                dbUserModel.Password = model.Password;
                dbUserModel.Roles = model.Roles;
                dbUserModel.EmployeeInfo = model.EmployeeInfo;
                dbUserModel.Suspended = model.Suspended;
                dbUserModel.Deleted = model.Deleted;
                
                LoginDao.Update(dbUserModel);
            }
            else
            {
                LoginDao.Add(model);
            }
        }

        [Transaction(ReadOnly = false)]
        public void ChangePassword(string username, string password, string newPassword)
        {
           LoginModel model = LoginDao.getInfo(username, password);

            if (model != null)
            {
                model.Password = newPassword;
                LoginDao.Update(model);
            }
            else
            {
                throw new BusinessException(" Mật khẩu cũ bị sai");
            } 
        }

        #endregion
    }
}

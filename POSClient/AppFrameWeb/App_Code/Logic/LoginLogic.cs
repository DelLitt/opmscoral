using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AppFrame.DataLayer;
using AppFrame.Common;
using AppFrame.Utility;
using AppFrame.Model;
using ObjectConverter=AppFrame.Utility.ObjectConverter;

namespace AppFrame.Logic
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
            user = AppFrame.Utility.ObjectConverter.Convert<BaseUser,LoginModel>(loginModel);
            
            if (user == null)
            {
                // create a Guest User and return
                user = SecurityUtility.CreateGuestUser();
                return user;
            }
            IList roleModelList = RoleDao.getRoles(username);
            IList roleList = new ArrayList();
            foreach ( RoleModel roleModel in roleModelList)
            {
                roleList.Add(ObjectConverter.Convert<Role,RoleModel>(roleModel));
            }
            user.Roles = roleList;
            return user;
        }


        #region ILoginLogic Members


        public EmployeeInfo GetEmployeeInfo(string username)
        {
            LoginModel loginModel = LoginDao.getUser(username);
            return loginModel.EmployeeInfo;
        }

        #endregion

        #region ILoginLogic Members


        public IList FindAll(object o)
        {
            throw new NotImplementedException();
        }

        public LoginModel FindById(object id)
        {
            throw new NotImplementedException();
        }

        public LoginModel Add(LoginModel data)
        {
            throw new NotImplementedException();
        }

        public void Update(LoginModel data)
        {
            throw new NotImplementedException();
        }

        public void Delete(LoginModel data)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public IList FindAll(ObjectCriteria criteria)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILoginLogic Members


        public void ProcessUser(LoginModel model)
        {
            
        }

        public void ChangePassword(string username, string password, string newPassword)
        {
            
        }

        #endregion
    }
}
using System;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Utility;
using AppFrame.View;
using Common.Logging;

namespace AppFrame.Presenter
{
    public class LoginController : AsyncController, ILoginController<LoginEventArgs>
    {
        
        private LoginEventArgs loginEventArgs;
        private ILoginLogic loginLogic;
        private ILoginView<LoginEventArgs> mView;

        #region IAuthController Members

        public ILoginView<LoginEventArgs> LoginView
        {
            get { return mView; }
            set
            {
                mView = value;
                mView.LoginEvent +=new EventHandler<LoginEventArgs>(mView_LoginEvent);
            }
        }

        private IChangePasswordView<LoginEventArgs> changePasswordView;
        public IChangePasswordView<LoginEventArgs> ChangePasswordView
        {
            get { return changePasswordView; }
            set { changePasswordView = value;
            changePasswordView.ChangePasswordEvent += new EventHandler<LoginEventArgs>(changePasswordView_ChangePasswordEvent);
            }
        }

        void changePasswordView_ChangePasswordEvent(object sender, LoginEventArgs e)
        {
            try
            {
                string Username = ClientInfo.getInstance().LoggedUser.Name;
                string Password = e.OldPassword;
                string NewPassword = e.NewPassword;
                LoginLogic.ChangePassword(Username, Password, NewPassword);
            }
            catch (Exception)
            {
                e.HasErrors = true;                
                throw;
            }
            
        }

        private void mView_LoginEvent(object sender, LoginEventArgs e)
        {
            ILog logger = LogManager.GetLogger("AppFrame");
            logger.Info("Enter " + this.GetType() + " method " + "mView_LoginEvent");
            //BaseUser baseUser = loginLogic.doAuthentication(e.LoginModel);
            AuthManager authManager = SecurityUtility.LoadAuthenticationModule();
            BaseUser baseUser = authManager.login(e.LoginModel.Username, e.LoginModel.Password);
            ClientInfo clientInfo = ClientInfo.getInstance();
            clientInfo.LoggedUser = baseUser;
            //MessageBox.Show(clientInfo.LoggedUser.IsGuest.ToString() + baseUser.Name);
            if (!baseUser.IsGuest)
            {
                ResultEventArgs.MessageCode = "loginOK";
                ResultEventArgs.IsValid = true;
            }
            else
            {
                ResultEventArgs.ErrorCode = "loginFail";
                ResultEventArgs.IsValid = false;
            }
            EventUtility.fireEvent(CompleteLoginLogicEvent, this, ResultEventArgs);
            logger.Info("Leave " + this.GetType() + " method " + "mView_LoginEvent");
        }

        public event EventHandler<LoginEventArgs> CompleteLoginLogicEvent;

        public ILoginLogic LoginLogic
        {
            get { return loginLogic; }
            set { loginLogic = value; }
        }


        #endregion
        
        
        public virtual void OnException(Exception ex)
        {
            // override by childern
        }

        #region IBaseController<T> Members

        public LoginEventArgs ResultEventArgs
        {
            get
            {
                return loginEventArgs;
            }
            set
            {
                loginEventArgs = value;
            }
        }

        #endregion

        #region IAuthController<LoginEventArgs> Members


        public string doLogin(LoginModel loginModel)
        {
            bool loginResult = loginLogic.validate(loginModel);


            if (loginResult)
            {
                return "Validate successfully !";
            }
            else
            {
                return "Wrong username or password !";
            }
        }

        #endregion
    }
}
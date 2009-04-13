using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Utility;
using AppFrameClient.Common;
using AppFrameClient.View;

namespace AppFrame.Presenter
{
    public class AuthService : IAuthService
    {

        #region IAuthService Members

        public void login()
        {
            //Form loginForm = GlobalUtility.GetFormObject(FormConstants.LOGIN_FORM);
            Form loginForm = GlobalUtility.GetOnlyChildFormObject<AuthForm>(GlobalCache.Instance().MainForm,FormConstants.LOGIN_FORM);
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            //loginForm.ShowDialog();
            loginForm.Show();
            //GlobalCache.Instance().MainForm.Focus();
            if(PostLogin!=null)
            {
                EventUtility.fireEvent(PostLogin,this,new BaseEventArgs());
            }
        }

        public void logout()
        {
            if (PreLogout != null)
            {
                EventUtility.fireEvent(PreLogout, this, new BaseEventArgs());
            }
            AuthManager authManager = SecurityUtility.LoadAuthenticationModule();
            authManager.logout();
            GlobalUtility.CloseAllChildForm(GlobalUtility.GetFormObject(FormConstants.MAIN_FORM));
        }

        #endregion

        #region IAuthService Members


        public event EventHandler<BaseEventArgs> PostLogin;

        public event EventHandler<BaseEventArgs> PreLogout;

        #endregion
    }
}

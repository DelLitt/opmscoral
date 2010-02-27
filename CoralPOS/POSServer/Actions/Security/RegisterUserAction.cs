using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Core.IoC;
using CoralPOS2.Models;
using POSServer.Common;

namespace POSServer.Actions.Security
{
    [PerRequest(typeof(IRegisterUserAction))]
    public class RegisterUserAction : PosAction,IRegisterUserAction
    {
        public override void DoExecute()
        {
            RegisterUserToSession();
        }

        public void RegisterUserToSession()
        {
            bool isLogged = (bool)GlobalSession.Instance.Get(CommonConstants.IS_LOGGED);
            if(isLogged)
            {
                LoginModel model = (LoginModel)Flow.Session.Get(CommonConstants.LOGGED_USER);
                MessageBox.Show(model.Username + " logged OK and in step 2 of login flow ", "Congrat!");
                GoToNextNode();
            }
        }
    }
}
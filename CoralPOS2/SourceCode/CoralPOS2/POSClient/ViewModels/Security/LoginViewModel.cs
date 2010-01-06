using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Core;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;

namespace POSClient.ViewModels.Security
{
    [PerRequest(typeof(ILoginViewModel))]
    public class LoginViewModel : Presenter,ILoginViewModel  
    {
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyOfPropertyChange("Username");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                Password = value;
                NotifyOfPropertyChange("Password");
            }
        }

    }
}

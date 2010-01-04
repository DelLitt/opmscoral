using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Core;

namespace POSClient.ViewModels.Security
{
    public class LoginViewModel : PropertyChangedBase  
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

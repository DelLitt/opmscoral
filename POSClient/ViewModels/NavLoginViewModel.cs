using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppFrame.CustomAttributes;
using Caliburn.Micro;

namespace POSClient.ViewModels
{
    [PerRequest(typeof(INavLoginViewModel))]
    public class NavLoginViewModel : Screen,INavLoginViewModel
    {
        private string _username;

        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyOfPropertyChange(()=>Username);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(()=> Password);
            }
        }
    }
}

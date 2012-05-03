using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

using CoralPOS2.Models;
using POSClient.BusinessLogic.Logic.Security;
using POSClient.Common;
using POSServer.ViewModels.Security;


namespace POSClient.ViewModels.Security
{
    [PerRequest(typeof(ILoginViewModel))]
    public class LoginViewModel : PosViewModel,ILoginViewModel  
    {

        private IShellViewModel _startViewModel;
        public LoginViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public string Path
        {
            get; set;
        }

        public void LoginAction()
        {
            LoginModel model = new LoginModel();
            model.Username = Username;
            model.Password = Password;
            LoginLogic loginLogic = new LoginLogic();
            bool result = loginLogic.Login(model);

            if(result)
            {
                GlobalSession.Instance.Put(CommonConstants.IS_LOGGED,true);
                Flow.Session.Put(CommonConstants.LOGGED_USER, model);
                //_startViewModel.Open<IMainView>();
                GoToNextNode();
            }
            else
            {
                MessageBox.Show("Login failed babe !"); 
            }

        }
        
    }
}
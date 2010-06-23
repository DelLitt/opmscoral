			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;



namespace POSServer.ViewModels.Security
{
    [PerRequest(typeof(IUserInfoViewModel))]
    public class UserInfoViewModel : PosViewModel,IUserInfoViewModel  
    {

        private IShellViewModel _startViewModel;
        public UserInfoViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
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
				#endregion
		
		#region List use to fetch object for view
		        
        private IList _rightList;
        public IList RightList
        {
            get
            {
                return _rightList;
            }
            set
            {
                _rightList = value;
                NotifyOfPropertyChange(() => RightList);
            }
        }
				#endregion
		
		#region List of boolean object
		        
        private bool _checkBox2;
        public bool checkBox2
        {
            get
            {
                return _checkBox2;
            }
            set
            {
                _checkBox2 = value;
                NotifyOfPropertyChange(() => checkBox2);
            }
        }
		        
        private bool _isShowPassword;
        public bool IsShowPassword
        {
            get
            {
                return _isShowPassword;
            }
            set
            {
                _isShowPassword = value;
                NotifyOfPropertyChange(() => IsShowPassword);
            }
        }
				#endregion
		
		#region List of date object
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _employeeList;
        public IList EmployeeList
        {
            get
            {
                return _employeeList;
            }
            set
            {
                _employeeList = value;
                NotifyOfPropertyChange(() => EmployeeList);
            }
        }
		        
        private IList _userAccountList;
        public IList UserAccountList
        {
            get
            {
                return _userAccountList;
            }
            set
            {
                _userAccountList = value;
                NotifyOfPropertyChange(() => UserAccountList);
            }
        }
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void Save()
        {
            
        }
		        
        public void Stop()
        {
            
        }
		        
        public void Cancel()
        {
            
        }
		        
        public void CreateEmployeeAccount()
        {
            
        }
		        
        public void CreateNormalAccount()
        {
            
        }
				#endregion
		
        
        
    }
}
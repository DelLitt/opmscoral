			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;



namespace POSServer.ViewModels.Task
{
    [PerRequest]
    public class TaskMainViewModel : PosViewModel
    {

        private IShellViewModel _startViewModel;
        public TaskMainViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
				#endregion
		
		#region Methods
		        
        public void Login()
        {
            
        }
		        
        public void LogOut()
        {
            
        }
		        
        public void ChangePassword()
        {
            
        }
				#endregion
		
        
        
    }
}
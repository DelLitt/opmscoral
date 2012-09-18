			 

			 

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
using POSServer.BusinessLogic.Common;
using POSServer.Common;
using POSServer.ViewModels.Menu;


namespace POSServer.ViewModels.Synchronize
{
    [PerRequest]
    [AttachMenuAndMainScreen(typeof(MainMenuViewModel), typeof(MainViewModel))]
    public class SynchronizeMainViewModel : PosViewModel
    {

        private IShellViewModel _startViewModel;
        public SynchronizeMainViewModel()
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
		        
        public void ToDepartment()
        {
            ShellViewModel.Current.EnterFlow(FlowDefinition.SYNC_TO_DEPARTMENT);
        }
		        
        public void FromDepartment()
        {
            
        }
		        
        public void FromMainStock()
        {
            
        }
		        
        public void ToMainStock()
        {
            
        }

        public void CreateSyncUSB()
        {
            ShellViewModel.Current.EnterFlow(FlowDefinition.CreateSyncUSBFlow);
        }
				#endregion
		
        
        
    }
}
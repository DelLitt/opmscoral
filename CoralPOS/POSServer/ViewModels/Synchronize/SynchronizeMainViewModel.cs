			 

			 

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


namespace POSServer.ViewModels.Synchronize
{
    [PerRequest]
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
            _startViewModel.EnterFlow(FlowDefinition.SYNC_TO_DEPARTMENT);
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
            _startViewModel.EnterFlow(FlowDefinition.CreateSyncUSBFlow);
        }
				#endregion
		
        
        
    }
}
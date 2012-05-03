			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using POSClient.Common;
using POSClient.ViewModels.Menu;


namespace POSClient.ViewModels.Synchronize
{
    [PerRequest(typeof(ISynchronizeMainViewModel))]
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel), typeof(IMainViewModel))]
    public class SynchronizeMainViewModel : PosViewModel,ISynchronizeMainViewModel  
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
		        
        public void FromMainStock()
        {
            _startViewModel.EnterFlow(FlowConstants.SYNC_FROM_MAINSTOCK_FLOW);
        }
		        
        public void ToMainStock()
        {
            
        }
				#endregion
		
        
        
    }
}
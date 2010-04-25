			 

			 

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
using POSClient.Common;


namespace POSClient.ViewModels.Synchronize
{
    [PerRequest(typeof(ISynchronizeMainViewModel))]
    public class SynchronizeMainViewModel : PosViewModel,ISynchronizeMainViewModel  
    {

        private IShellViewModel _startViewModel;
        public SynchronizeMainViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
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
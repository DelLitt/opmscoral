			 

			 

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
using POSClient.ViewModels.Synchronize;


namespace POSClient.ViewModels.Menu
{
    [PerRequest(typeof(IMainMenuViewModel))]
    public class MainMenuViewModel : PosViewModel,IMainMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public MainMenuViewModel(IShellViewModel startViewModel)
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
		        
        public void Task()
        {
            
        }
		        
        public void Sale()
        {
            _startViewModel.EnterFlow(FlowDefinition.PURCHASE_ORDER_VIEW_FLOW);   
        }
		        
        public void DepartmentStock()
        {
            _startViewModel.EnterFlow(FlowDefinition.DEPARTMENT_STOCK_OUT_CREATE_FLOW);
        }
		        
        public void Report()
        {
            
        }
		        
        public void Management()
        {
            
        }
		        
        public void Utility()
        {
            
        }
		        
        public void Synchronize()
        {
            _startViewModel.Open<ISynchronizeMainViewModel>();
        }
				#endregion
		
        
        
    }
}
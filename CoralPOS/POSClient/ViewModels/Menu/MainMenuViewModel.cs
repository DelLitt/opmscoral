			 

			 

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
using POSClient.ViewModels.Management;
using POSClient.ViewModels.Sale;
using POSClient.ViewModels.Stock;
using POSClient.ViewModels.Synchronize;
using POSClient.ViewModels.Tool;


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
            MessageBox.Show("Task Menu!");   
        }
		        
        public void Sale()
        {
            _startViewModel.Open<ISaleMainViewModel>();
        }
		        
        public void DepartmentStock()
        {
            _startViewModel.Open<IStockMainViewModel>();
        }
		        
        public void Report()
        {
            MessageBox.Show("Report!");
        }
		        
        public void Management()
        {
            _startViewModel.Open<IManagementMainViewModel>();
        }
		        
        public void Utility()
        {
            _startViewModel.Open<IToolMainViewModel>();
        }
		        
        public void Synchronize()
        {
            _startViewModel.Open<ISynchronizeMainViewModel>();
        }
				#endregion
		
        
        
    }
}
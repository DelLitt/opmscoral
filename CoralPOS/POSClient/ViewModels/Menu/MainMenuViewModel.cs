			 

			 

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
        public MainMenuViewModel()
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
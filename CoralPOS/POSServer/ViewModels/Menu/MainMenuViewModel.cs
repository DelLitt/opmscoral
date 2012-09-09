			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Security;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using POSServer.ViewModels.Management;
using POSServer.ViewModels.ProductMaster;
using POSServer.ViewModels.Stock;
using POSServer.ViewModels.Synchronize;
using POSServer.ViewModels.Task;
using POSServer.ViewModels.Tool;


namespace POSServer.ViewModels.Menu
{
	[PerRequest]
	public class MainMenuViewModel : PosViewModel
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
            ShellViewModel.Current.Open<TaskMainViewModel>();
		}
				
		public void ProductMaster()
		{
            ShellViewModel.Current.Open<ProductMasterMainViewModel>();
			//_startViewModel.EnterFlow("ProductMasterCreateFlow");
		}
				
		public void Stock()
		{
            ShellViewModel.Current.Open<StockMainViewModel>();
			//_startViewModel.EnterFlow("StockInCreateFlow");
		}
				
		public void Report()
		{
			MessageBox.Show("Report Menu!");
		}
		
		public void Management()
		{
            ShellViewModel.Current.Open<ManagementMainViewModel>();
		}
				
		public void Utility()
		{
            ShellViewModel.Current.Open<ToolMainViewModel>();
		}
				
		public void Synchronize()
		{
            ShellViewModel.Current.Open<SynchronizeMainViewModel>();
		}
				#endregion
		
		
		
	}
}
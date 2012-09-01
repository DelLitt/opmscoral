			 

			 

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
			_startViewModel.Open<ITaskMainViewModel>();
		}
				
		public void ProductMaster()
		{
			_startViewModel.Open<IProductMasterMainViewModel>();
			//_startViewModel.EnterFlow("ProductMasterCreateFlow");
		}
				
		public void Stock()
		{
			_startViewModel.Open<IStockMainViewModel>();
			//_startViewModel.EnterFlow("StockInCreateFlow");
		}
				
		public void Report()
		{
			MessageBox.Show("Report Menu!");
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
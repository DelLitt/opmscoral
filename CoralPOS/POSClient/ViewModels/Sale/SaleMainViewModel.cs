			 

			 

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
using POSClient.ViewModels.Menu;


namespace POSClient.ViewModels.Sale
{
	[PerRequest(typeof(ISaleMainViewModel))]
	[AttachMenuAndMainScreen(typeof(IMainMenuViewModel),typeof(IMainViewModel))]
	public class SaleMainViewModel : PosViewModel,ISaleMainViewModel  
	{

		private IShellViewModel _startViewModel;
		public SaleMainViewModel()
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

		public void CreatePurchaseOrder()
		{
		    ShellViewModel.Current.EnterFlow("PurchaseOrderViewFlow");
		}

		public void PurchaseOrderList()
		{
			
		}

		public void ProductMasterList()
		{
			
		}

		public void PriceList()
		{
			
		}
				
		public void ExtendFunctions()
		{
			
		}
				#endregion
		
		
		
	}
}
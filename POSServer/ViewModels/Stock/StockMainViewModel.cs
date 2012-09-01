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
using POSServer.Common;
using POSServer.ViewModels.Menu;


namespace POSServer.ViewModels.Stock
{
	/// <summary>
	/// 
	/// </summary>
	[PerRequest(typeof(IStockMainViewModel))]
	[AttachMenuAndMainScreen(typeof(IMainMenuViewModel),typeof(IMainViewModel))]
	public class StockMainViewModel : PosViewModel,IStockMainViewModel  
	{

		private IShellViewModel _startViewModel;
		/// <summary>
		/// Initializes a new instance of the <see cref="StockMainViewModel"/> class.
		/// </summary>
		/// <param name="startViewModel">The start view model.</param>
		public StockMainViewModel()
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

		/// <summary>
		/// Stocks the in.
		/// </summary>
		public void StockIn()
		{
			_startViewModel.EnterFlow(FlowDefinition.StockInCreateFlow); 
		}

		/// <summary>
		/// Stocks the in list.
		/// </summary>
		public void StockInList()
		{
			_startViewModel.EnterFlow(FlowDefinition.StockInSearchFlow); 
		}

		/// <summary>
		/// Stocks the in back list.
		/// </summary>
		public void StockInBackList()
		{
			
		}
				
		public void StockInByExcel()
		{
			
		}
				
		public void StockOutToDepartment()
		{
			_startViewModel.EnterFlow(FlowDefinition.StockOutCreateFlow); 
		}
				
		public void StockOutToOther()
		{
			_startViewModel.EnterFlow(FlowDefinition.StockOutSpecificCreateFlow); 
		}
				
		public void StockOutList()
		{
			_startViewModel.EnterFlow(FlowDefinition.StockOutSearchFlow);  
		}
				
		public void StockOutByExcel()
		{
			
		}
				
		public void InventoryCollector()
		{
			_startViewModel.EnterFlow(FlowDefinition.StockInventoryViewFlow);  
		}
				
		public void AfterInventoryCollectorProcessing()
		{
			_startViewModel.EnterFlow(FlowDefinition.StockInventoryProcessingFlow);
		}
				
		public void StockSearch()
		{
			
		}
				
		public void StockCategorySearch()
		{
			
		}
				
		public void StockInConfirm()
		{
			
		}
				
		public void StockOutConfirm()
		{
			_startViewModel.EnterFlow(FlowDefinition.StockOutConfirmingFlow);
		}
				
		public void DepartmentStockOutConfirm()
		{
			
		}
				#endregion
		
		
		
	}
}
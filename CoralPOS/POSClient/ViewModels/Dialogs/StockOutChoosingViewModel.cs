using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Base;
using AppFrame.Utils;
using CoralPOS.Models;
using POSClient.BusinessLogic.Implement;

namespace POSClient.ViewModels.Dialogs
{
	public class StockOutChoosingViewModel : PosViewModel,IStockOutChoosingViewModel  
	{
		
		private IShellViewModel _startViewModel;
		public StockOutChoosingViewModel()
		{
			_startViewModel = ShellViewModel.Current;
			FromDate = DateTime.Now;
			ToDate = DateTime.Now;
		}
		
		#region Fields


		IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
				
		private IList _stockInList;
		public IList StockInList
		{
			get
			{
				return _stockInList;
			}
			set
			{
				_stockInList = value;
				NotifyOfPropertyChange(() => StockInList);
			}
		}
				#endregion
		
		#region Methods

		public DepartmentStockIn SelectedStockIn
		{
			get; set;
		}

		public void Close()
		{
			ShellViewModel.Current.HideDialog(this);
		}
				
		public void Search()
		{
			DeptStockInCriteria criteria = new DeptStockInCriteria
										   {
											   FromDate = FromDate,
											   ToDate = ToDate
										   };
			IList<DepartmentStockIn> list = DepartmentStockInLogic.FindByMultiCriteria(criteria);
			StockInList = ObjectConverter.ConvertFrom(list);
		}

		public DateTime ToDate { get; set; }
		public DateTime FromDate { get; set; }
		public event EventHandler<DepartmentStockInChoosingArg> ConfirmEvent;
		public void Choose()
		{
			DepartmentStockIn stockIn = DepartmentStockInLogic.Fetch(SelectedStockIn);
			DepartmentStockInLogic.FetchDeptStock(stockIn);
									 
			DepartmentStockInChoosingArg eventArgs = new DepartmentStockInChoosingArg();
			eventArgs.SelectedStockIn = stockIn;
			if (ConfirmEvent != null) ConfirmEvent(this, eventArgs);
			ShellViewModel.Current.HideDialog(this);
		}

		
		#endregion
		
		
		
	}

	public class DepartmentStockInChoosingArg : EventArgs
	{
		public DepartmentStockIn SelectedStockIn { get; set; }
	}
}
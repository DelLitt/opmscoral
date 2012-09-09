			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Invocation;
using AppFrame.WPF.Screens;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.ViewModels.Menu.Stock;


namespace POSServer.ViewModels.Stock.StockOut
{
	[AttachMenuAndMainScreen(typeof(StockOutMenuViewModel), typeof(StockMainViewModel))]
    [PerRequest]
	public class StockOutWaitingConfirmViewModel : PosViewModel
	{

		private IShellViewModel _startViewModel;
		public StockOutWaitingConfirmViewModel()
		{
			_startViewModel = ShellViewModel.Current;
		}
        [Autowired]
		private IMainStockLogic MainStockLogic { get; set; }
		#region Fields
				#endregion
		
		#region List use to fetch object for view
				
		private IList _category;
		public IList Category
		{
			get
			{
				return _category;
			}
			set
			{
				_category = value;
				NotifyOfPropertyChange(() => Category);
			}
		}
				
		private IList _department;
		public IList Department
		{
			get
			{
				return _department;
			}
			set
			{
				_department = value;
				NotifyOfPropertyChange(() => Department);
			}
		}
				#endregion
		
		#region List of boolean object
				#endregion
		
		#region List of date object
				
		private IList _fromDate;
		public IList FromDate
		{
			get
			{
				return _fromDate;
			}
			set
			{
				_fromDate = value;
				NotifyOfPropertyChange(() => FromDate);
			}
		}
				
		private IList _toDate;
		public IList ToDate
		{
			get
			{
				return _toDate;
			}
			set
			{
				_toDate = value;
				NotifyOfPropertyChange(() => ToDate);
			}
		}
				#endregion
		
		#region List which just using in Data Grid

		private IList _confirmingStockOutList;
		public IList ConfirmingStockOutList
		{
			get
			{
				return _confirmingStockOutList;
			}
			set
			{
				_confirmingStockOutList = value;
				NotifyOfPropertyChange(() => ConfirmingStockOutList);
			}
		}
				
		private IList _selectedstockOuts;
		public IList SelectedStockOuts
		{
			get
			{
				return _selectedstockOuts;
			}
			set
			{
				_selectedstockOuts = value;
				NotifyOfPropertyChange(() => SelectedStockOuts);
				NotifyOfPropertyChange(()=>CanConfirm);
				NotifyOfPropertyChange(() => CanUnconfirm);
			}
		}
		private IList<StockOutDetail> _stockOutDetailList;
		public IList<StockOutDetail> StockOutDetailList
		{
			get
			{
				return _stockOutDetailList;
			}
			set
			{
				_stockOutDetailList = value;
				NotifyOfPropertyChange(() => StockOutDetailList);
			}
		}
		private CoralPOS.Models.StockOut _selectedstockOut;
		public CoralPOS.Models.StockOut SelectedStockOut
		{
			get
			{
				return _selectedstockOut;
			}
			set
			{
				_selectedstockOut = value;
				NotifyOfPropertyChange(() => SelectedStockOut);
				NotifyOfPropertyChange(() => CanEdit);
				NotifyOfPropertyChange(()=>CanConfirm);
				NotifyOfPropertyChange(() => CanUnconfirm);
			}
		}
				#endregion
		
		#region Methods

		protected override void OnInitialize()
		{
			base.OnInitialize();
			IList stockOuts = Flow.Session.Get(FlowConstants.CONFIRMING_STOCK_OUT_LIST) as IList;
			ConfirmingStockOutList = stockOuts;
			SelectedStockOuts = new ArrayList();
			StockOutDetailList = new List<StockOutDetail>();
		}

		public void Help()
		{
			
		}

		public void GridSelectionChanged()
		{
			IList<StockOutDetail> details = SelectedStockOut.StockOutDetails;
			if (details == null) return;
			StockOutDetailList = details;
		}

		public bool CanUnconfirm
		{
			get { return SelectedStockOuts.Count > 0 || SelectedStockOut!=null; }
		}
		public void Unconfirm()
		{
			Flow.Session.Put(FlowConstants.SAVE_STOCK_OUT, SelectedStockOuts);
			Flow.Session.Put(FlowConstants.STOCK_OUT_CONFIRM_FLAG, false);
			GoToNextNode();
		}
				
		public void Stop()
		{
			Flow.End();
		}
		
		public bool CanConfirm
		{
			get { return SelectedStockOuts.Count > 0 || SelectedStockOut != null; }
		}
		public void Confirm()
		{
			Flow.Session.Put(FlowConstants.SAVE_STOCK_OUT,SelectedStockOuts);
			Flow.Session.Put(FlowConstants.STOCK_OUT_CONFIRM_FLAG, true);
			GoToNextNode();
		}
		
		public bool CanEdit
		{
			get { return SelectedStockOut != null; }
		}
		public void Edit()
		{
			
		}
				
		public void Recreate()
		{
			Flow.IsRepeated = true;
			Flow.End();
		}
				#endregion
		
		
		
	}
}
			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using AppFrame.Invocation;
using AppFrame.Utils;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.ViewModels.Menu.Stock;


namespace POSServer.ViewModels.Stock.StockIn
{
    [AttachMenuAndMainScreen(typeof(StockInMenuViewModel), typeof(StockMainViewModel))]
	public class StockInSearchViewModel : PosViewModel
	{

		private IShellViewModel _startViewModel;
		private string _productMasterNames;

		private string _productTypes;

		private bool _datePick;

		private IList _categoryList;

		private Category _selectedCategory;

		private DateTime _fromDate;

		private DateTime _toDate;

		public StockInSearchViewModel()
		{
			_startViewModel = ShellViewModel.Current;
		}
		
		#region Fields
				
		private string _textBox1;
		public string textBox1
		{
			get
			{
				return _textBox1;
			}
			set
			{
				_textBox1 = value;
				NotifyOfPropertyChange(() => textBox1);
			}
		}
				
		private string _description;
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
				NotifyOfPropertyChange(() => Description);
			}
		}
				
		private string _textBox2;
		public string textBox2
		{
			get
			{
				return _textBox2;
			}
			set
			{
				_textBox2 = value;
				NotifyOfPropertyChange(() => textBox2);
			}
		}

		public string ProductMasterNames
		{
			get { return _productMasterNames; }
			set { _productMasterNames = value;NotifyOfPropertyChange(()=>ProductMasterNames); }
		}

		public string ProductTypes
		{
			get { return _productTypes; }
			set { _productTypes = value; NotifyOfPropertyChange(() => ProductTypes); }
		}

		public bool DatePick
		{
			get { return _datePick; }
			set { _datePick = value; NotifyOfPropertyChange(() => DatePick); }
		}

		public IList CategoryList
		{
			get { return _categoryList; }
			set { _categoryList = value; NotifyOfPropertyChange(() => CategoryList); }
		}

		public Category SelectedCategory
		{
			get { return _selectedCategory; }
			set { _selectedCategory = value; NotifyOfPropertyChange(() => SelectedCategory); }
		}

		public DateTime FromDate
		{
			get { return _fromDate; }
			set { _fromDate = value; NotifyOfPropertyChange(() => FromDate); }
		}

		public DateTime ToDate
		{
			get { return _toDate; }
			set { _toDate = value; NotifyOfPropertyChange(() => ToDate); }
		}

		private CoralPOS.Models.StockIn _selectedStockIn;
		public CoralPOS.Models.StockIn SelectedStockIn
		{
			get { return _selectedStockIn; }
			set { _selectedStockIn = value; NotifyOfPropertyChange(()=>SelectedStockIn); }
		}

		public ICategoryLogic CategoryLogic
		{
			get; set;
		}

		public IStockInLogic StockInLogic
		{
			get; set;
		}

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
				
		public void Help()
		{
			
		}
				
		public void ViewDetail()
		{
			if (_selectedStockIn != null && !string.IsNullOrEmpty(_selectedStockIn.StockInId))
			{
				CoralPOS.Models.StockIn stockIn = SelectedStockIn;
				Flow.Session.Put(FlowConstants.STOCK_IN_SEARCH_RESULT, StockInList);
				BackgroundTask task = new BackgroundTask(()=>LoadStockInAndGoToDetail(stockIn));
				task.Completed += new System.ComponentModel.RunWorkerCompletedEventHandler(task_Completed);
				StartWaitingScreen(0);
				task.Start(stockIn);
			}
		}

		void task_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			StopWaitingScreen(0);
			GoToNextNode();
		}
		
		private object LoadStockInAndGoToDetail(CoralPOS.Models.StockIn stockOut)
		{
			stockOut = StockInLogic.Fetch(stockOut);
			Flow.Session.Put(FlowConstants.SAVE_STOCK_IN, stockOut);
			return null;
		}
		public void Stop()
		{
			Flow.End();
		}
				
		public void Search()
		{
			StockInCriteria criteria = new StockInCriteria();
			if (SelectedCategory != null) criteria.CategoryName = SelectedCategory.CategoryName;
			
			if (!string.IsNullOrEmpty(ProductMasterNames))
			{
				criteria.ProductMasterNames = ProductMasterNames.Split(',').ToList();
			}
			if (!string.IsNullOrEmpty(ProductTypes))
			{
				criteria.TypeNames = ProductTypes.Split(',').ToList();
			}
			criteria.DatePick = DatePick;
			if (criteria.DatePick)
			{
				criteria.FromDate = FromDate;
				criteria.ToDate = ToDate;
			}
			ExecuteHelper.OnBackgroundThread(() => FindStockIns(criteria), CompletedLoadStockIns);
		}

		private object FindStockIns(StockInCriteria criteria)
		{

			IoC.Get<ICircularLoadViewModel>().StartLoading();
			IList<CoralPOS.Models.StockIn> stockOuts = StockInLogic.FindByMultiCriteria(criteria);
			StockInList = ObjectConverter.ConvertFrom(stockOuts);
			return null;
		}

		void CompletedLoadStockIns(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			IoC.Get<ICircularLoadViewModel>().StopLoading();
		}
		public void Initialize()
		{
			FromDate = DateTime.Now;
			ToDate = DateTime.Now;
			CategoryList = CategoryLogic.FindAll(new ObjectCriteria<Category>()) as IList;
			
			IList searchedStockOut = Flow.Session.Get(FlowConstants.STOCK_IN_SEARCH_RESULT) as IList;
			CoralPOS.Models.StockIn selectedStockOut = Flow.Session.Get(FlowConstants.SAVE_STOCK_IN) as CoralPOS.Models.StockIn;
			if (searchedStockOut == null)
			{
				SelectedStockIn = new CoralPOS.Models.StockIn();
			}
			else
			{
				if (selectedStockOut != null) SelectedStockIn = selectedStockOut;
				else
				{
					SelectedStockIn = new CoralPOS.Models.StockIn();
				}
			}
		}

		#endregion
		
		
		
	}
}
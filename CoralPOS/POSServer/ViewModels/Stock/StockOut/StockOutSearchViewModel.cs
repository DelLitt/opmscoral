			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace POSServer.ViewModels.Stock.StockOut
{
    //[AttachMenuAndMainScreen(typeof(StockOutMenuViewModel), typeof(StockMainViewModel))]
    [PerRequest]
	public class StockOutSearchViewModel : PosViewModel
	{

		private IShellViewModel _startViewModel;
		private Department _selectedDepartment;

		private DateTime _fromDate;

		private DateTime _toDate;

		private IList _categoryList;

		private bool _departmentPick;

		private bool _datePick;

		public StockOutSearchViewModel()
		{
			_startViewModel = ShellViewModel.Current;
		}
		
		#region Fields
				
		private string _productMasterNames;
		public string ProductMasterNames
		{
			get
			{
				return _productMasterNames;
			}
			set
			{
				_productMasterNames = value;
				NotifyOfPropertyChange(() => ProductMasterNames);
			}
		}

		private string _productTypes;
		public string ProductTypes
		{
			get
			{
				return _productTypes;
			}
			set
			{
				_productTypes = value;
				NotifyOfPropertyChange(() => ProductTypes);
			}
		}

		public bool DepartmentPick
		{
			get { return _departmentPick; }
			set { _departmentPick = value; NotifyOfPropertyChange(()=>DepartmentPick); }
		}

		public bool DatePick
		{
			get { return _datePick; }
			set { _datePick = value; NotifyOfPropertyChange(()=>DatePick); }
		}

		public Department SelectedDepartment
		{
			get { return _selectedDepartment; }
			set { _selectedDepartment = value; 
				NotifyOfPropertyChange(()=>SelectedDepartment);
			}
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

		public IList CategoryList
		{
			get { return _categoryList; }
			set { _categoryList = value; NotifyOfPropertyChange(() => CategoryList); }
		}

		private CoralPOS.Models.StockOut _selectedStockOut;
		public CoralPOS.Models.StockOut SelectedStockOut
		{
			get
			{
				return _selectedStockOut;
			}
			set
			{
				_selectedStockOut = value;
				NotifyOfPropertyChange(() => SelectedStockOut);
			}
		}

        [Autowired]
		public IStockOutLogic StockOutLogic
		{
			get; set;
		}
        [Autowired]
		public ICategoryLogic CategoryLogic { get; set; }
        [Autowired]
		public IDepartmentLogic DepartmentLogic { get; set; }

		#endregion
		
		#region List use to fetch object for view

		private Category _selectedCategory;
		public Category SelectedCategory
		{
			get
			{
				return _selectedCategory;
			}
			set
			{
				_selectedCategory = value;
				NotifyOfPropertyChange(() => SelectedCategory);
			}
		}
				
		private IList _departments;
		public IList Departments
		{
			get
			{
				return _departments;
			}
			set
			{
				_departments = value;
				NotifyOfPropertyChange(() => Departments);
			}
		}
				#endregion
		
		#region List which just using in Data Grid
				
		private IList _stockOutList;
		public IList StockOutList
		{
			get
			{
				return _stockOutList;
			}
			set
			{
				_stockOutList = value;
				NotifyOfPropertyChange(() => StockOutList);
			}
		}
				#endregion
		
		#region Methods
				
		public void Help()
		{
			
		}
				
		public void ViewDetail()
		{
			if (_selectedStockOut != null && _selectedStockOut.StockOutId > 0 )
			{
				CoralPOS.Models.StockOut stockOut = SelectedStockOut;
				Flow.Session.Put(FlowConstants.STOCK_OUT_SEARCH_RESULT, StockOutList);
				BackgroundTask task = new BackgroundTask(() => LoadStockOutAndGoToDetail(stockOut));
				task.Completed += new System.ComponentModel.RunWorkerCompletedEventHandler(task_Completed);
				StartWaitingScreen(0);
				task.Start(stockOut);
				
			}
		}

		private void task_Completed(object sender, RunWorkerCompletedEventArgs e)
		{
			StopWaitingScreen(0);
			GoToNextNode();
		}

		private object LoadStockOutAndGoToDetail(CoralPOS.Models.StockOut stockOut)
		{
			stockOut = StockOutLogic.Fetch(stockOut);
			Flow.Session.Put(FlowConstants.SAVE_STOCK_OUT, stockOut);
			return null;
		}

		public void Stop()
		{
		   Flow.End(); 
		}
				
		public void Search()
		{
			StockOutCriteria criteria = new StockOutCriteria();
			if(SelectedCategory!=null) criteria.CategoryName = SelectedCategory.CategoryName;
			if (SelectedDepartment != null) criteria.DepartmentName = SelectedDepartment.DepartmentName;
			if(!string.IsNullOrEmpty(ProductMasterNames))
			{
				criteria.ProductMasterNames = ProductMasterNames.Split(',').ToList();
			}
			if(!string.IsNullOrEmpty(ProductTypes))
			{
				criteria.TypeNames = ProductTypes.Split(',').ToList();
			}
			criteria.DatePick = DatePick;
			criteria.DepartmentPick = DepartmentPick;
			criteria.FromDate = FromDate;
			criteria.ToDate = ToDate;
			ExecuteHelper.OnBackgroundThread(() => FindStockOuts(criteria), CompletedLoadStockOuts);
		}

		private object FindStockOuts(StockOutCriteria criteria)
		{
			
			IoC.Get<ICircularLoadViewModel>().StartLoading();
			IList<CoralPOS.Models.StockOut> stockOuts = StockOutLogic.FindByMultiCriteria(criteria);
			StockOutList = ObjectConverter.ConvertFrom(stockOuts);
			return null;
		}
		void CompletedLoadStockOuts(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			IoC.Get<ICircularLoadViewModel>().StopLoading();
		}

		protected override void OnInitialize()
		{
			FromDate = DateTime.Now;
			ToDate = DateTime.Now;
			CategoryList = CategoryLogic.FindAll(new ObjectCriteria<Category>()) as IList;
			Departments = DepartmentLogic.FindAll(new ObjectCriteria<Department>()) as IList;
			IList searchedStockOut = Flow.Session.Get(FlowConstants.STOCK_OUT_SEARCH_RESULT) as IList;
			CoralPOS.Models.StockOut selectedStockOut = Flow.Session.Get(FlowConstants.SAVE_STOCK_OUT) as CoralPOS.Models.StockOut;
			if (searchedStockOut == null)
			{
				SelectedStockOut = new CoralPOS.Models.StockOut();
			}
			else
			{
				if(selectedStockOut!=null) SelectedStockOut = selectedStockOut;
				else
				{
					SelectedStockOut = new CoralPOS.Models.StockOut();
				}
			}
		}

		#endregion
		
		
		
	}
}
			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.DataLayer;
using AppFrame.Utils;
using AppFrame.WPF.Screens;
using Caliburn.Core;
using Caliburn.Core.IoC;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Invocation;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using Microsoft.Practices.ServiceLocation;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;


namespace POSServer.ViewModels.Stock.StockIn
{
    public class StockInSearchViewModel : PosViewModel,IStockInSearchViewModel  
    {

        private IShellViewModel _startViewModel;
        private string _productMasterNames;

        private string _productTypes;

        private bool _datePick;

        private IList _categoryList;

        private Category _selectedCategory;

        private DateTime _fromDate;

        private DateTime _toDate;

        public StockInSearchViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
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
            if (_selectedStockIn != null && _selectedStockIn.StockInId > 0)
            {
                CoralPOS.Models.StockIn stockOut = SelectedStockIn;
                Flow.Session.Put(FlowConstants.STOCK_IN_SEARCH_RESULT, StockInList);
                stockOut = StockInLogic.Fetch(stockOut);
                Flow.Session.Put(FlowConstants.SAVE_STOCK_IN, stockOut);
                GoToNextNode();
            }
        }
		        
        public void Stop()
        {
            
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
            criteria.FromDate = FromDate;
            criteria.ToDate = ToDate;
            Execute.OnBackgroundThread(() => FindStockOuts(criteria), CompletedLoadStockIns);
        }

        private void FindStockOuts(StockInCriteria criteria)
        {

            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StartLoading();
            IList<CoralPOS.Models.StockIn> stockOuts = StockInLogic.FindByMultiCriteria(criteria);
            StockInList = ObjectConverter.ConvertFrom(stockOuts);
        }

        void CompletedLoadStockIns(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StopLoading();
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
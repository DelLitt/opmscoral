			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
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


namespace POSServer.ViewModels.Stock.StockOut
{
    
    public class StockOutSearchViewModel : PosViewModel,IStockOutSearchViewModel  
    {

        private IShellViewModel _startViewModel;
        private Department _selectedDepartment;

        private DateTime _fromDate;

        private DateTime _toDate;

        private IList _categoryList;

        public StockOutSearchViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
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

        public IStockOutLogic StockOutLogic
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
                stockOut = StockOutLogic.Fetch(stockOut);
                Flow.Session.Put(FlowConstants.SAVE_STOCK_OUT, stockOut);
                GoToNextNode();
            }
        }
		        
        public void Stop()
        {
           Flow.End(); 
        }
		        
        public void Search()
        {
            Execute.OnBackgroundThread(() => FindStockOuts(null), CompletedLoadStockOuts);
        }

        private void FindStockOuts(object criteria)
        {
            
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StartLoading();
            IList<CoralPOS.Models.StockOut> stockOuts = StockOutLogic.FindByMultiCriteria(null);
            StockOutList = ObjectConverter.ConvertFrom(stockOuts);
        }
        void CompletedLoadStockOuts(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StopLoading();
        }

        public override void Initialize()
        {
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
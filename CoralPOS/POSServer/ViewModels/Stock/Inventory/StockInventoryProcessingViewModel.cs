			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;



namespace POSServer.ViewModels.Stock.Inventory
{
    [PerRequest(typeof(IStockInventoryProcessingViewModel))]
    public class StockInventoryProcessingViewModel : PosViewModel,IStockInventoryProcessingViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockInventoryProcessingViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
        private string _createDate;
        public string CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
                NotifyOfPropertyChange(() => CreateDate);
            }
        }
		        
        private string _barcode;
        public string Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value;
                NotifyOfPropertyChange(() => Barcode);
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
		        
        private string _logicalSum;
        public string LogicalSum
        {
            get
            {
                return _logicalSum;
            }
            set
            {
                _logicalSum = value;
                NotifyOfPropertyChange(() => LogicalSum);
            }
        }
		        
        private string _realSum;
        public string RealSum
        {
            get
            {
                return _realSum;
            }
            set
            {
                _realSum = value;
                NotifyOfPropertyChange(() => RealSum);
            }
        }
				#endregion
		
		#region List use to fetch object for view
		        
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
		        
        private IList _productTypeList;
        public IList ProductTypeList
        {
            get
            {
                return _productTypeList;
            }
            set
            {
                _productTypeList = value;
                NotifyOfPropertyChange(() => ProductTypeList);
            }
        }
		        
        private IList _productMasterList;
        public IList ProductMasterList
        {
            get
            {
                return _productMasterList;
            }
            set
            {
                _productMasterList = value;
                NotifyOfPropertyChange(() => ProductMasterList);
            }
        }
				#endregion
		
		#region List of boolean object
		        
        private bool _filterDuplicate;
        public bool FilterDuplicate
        {
            get
            {
                return _filterDuplicate;
            }
            set
            {
                _filterDuplicate = value;
                NotifyOfPropertyChange(() => FilterDuplicate);
            }
        }
		        
        private bool _filterSlidedBarcode;
        public bool FilterSlidedBarcode
        {
            get
            {
                return _filterSlidedBarcode;
            }
            set
            {
                _filterSlidedBarcode = value;
                NotifyOfPropertyChange(() => FilterSlidedBarcode);
            }
        }
				#endregion
		
		#region List of date object
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _stockInventoryList;
        public IList StockInventoryList
        {
            get
            {
                return _stockInventoryList;
            }
            set
            {
                _stockInventoryList = value;
                NotifyOfPropertyChange(() => StockInventoryList);
            }
        }
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void TempLoad()
        {
            
        }
		        
        public void TempSave()
        {
            
        }
		        
        public void Stop()
        {
            
        }
		        
        public void button1()
        {
            
        }
		        
        public void SaveResult()
        {
            
        }
		        
        public void Delete()
        {
            
        }
		        
        public void Reset()
        {
            
        }
		        
        public void InputByFile()
        {
            
        }
		        
        public void ChangeDepartmentForEvaluate()
        {
            
        }
				#endregion
		
        
        
    }
}
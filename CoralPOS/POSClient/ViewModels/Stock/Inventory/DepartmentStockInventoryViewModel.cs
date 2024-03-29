			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;



namespace POSClient.ViewModels.Stock.Inventory
{
    [PerRequest(typeof(IDepartmentStockInventoryViewModel))]
    public class DepartmentStockInventoryViewModel : PosViewModel,IDepartmentStockInventoryViewModel  
    {

        private IShellViewModel _startViewModel;
        public DepartmentStockInventoryViewModel()
        {
            _startViewModel = ShellViewModel.Current;
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
				#endregion
		
		#region List use to fetch object for view
		        
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
		        
        private IList _productType;
        public IList ProductType
        {
            get
            {
                return _productType;
            }
            set
            {
                _productType = value;
                NotifyOfPropertyChange(() => ProductType);
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
				#endregion
		
        
        
    }
}
			 

			 

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



namespace POSClient.ViewModels.Stock.StockIn
{
    [PerRequest(typeof(IDepartmentStockInViewModel))]
    public class DepartmentStockInViewModel : PosViewModel,IDepartmentStockInViewModel  
    {

        private IShellViewModel _startViewModel;
        public DepartmentStockInViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
		
		#region Fields
		        
        private string _wholeSalePrice;
        public string WholeSalePrice
        {
            get
            {
                return _wholeSalePrice;
            }
            set
            {
                _wholeSalePrice = value;
                NotifyOfPropertyChange(() => WholeSalePrice);
            }
        }
		        
        private string _price;
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }
		        
        private string _inputPrice;
        public string InputPrice
        {
            get
            {
                return _inputPrice;
            }
            set
            {
                _inputPrice = value;
                NotifyOfPropertyChange(() => InputPrice);
            }
        }
		        
        private string _textBox4;
        public string textBox4
        {
            get
            {
                return _textBox4;
            }
            set
            {
                _textBox4 = value;
                NotifyOfPropertyChange(() => textBox4);
            }
        }
		        
        private string _productMaster;
        public string ProductMaster
        {
            get
            {
                return _productMaster;
            }
            set
            {
                _productMaster = value;
                NotifyOfPropertyChange(() => ProductMaster);
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
		        
        public void Recreate()
        {
            
        }
		        
        public void Save()
        {
            
        }
		        
        public void Stop()
        {
            
        }
		        
        public void CreateNewProductMaster()
        {
            
        }
		        
        public void EditProductMaster()
        {
            
        }
				#endregion
		
        
        
    }
}
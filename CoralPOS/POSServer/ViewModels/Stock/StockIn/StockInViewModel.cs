			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.DataLayer;
using Caliburn.Core;
using Caliburn.Core.IoC;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;


namespace POSServer.ViewModels.Stock.StockIn
{
    //[PerRequest(typeof(IStockInViewModel))]
    public class StockInViewModel : PosViewModel,IStockInViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockInViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
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
           Flow.End(); 
        }
		        
        public void CreateNewProductMaster()
        {
            
        }
		        
        public void EditProductMaster()
        {
            
        }

        public override void Initialize()
        {
            var list = Flow.Session.Get(FlowConstants.PRODUCT_NAMES_LIST);
            ProductMasterList = list as IList;
            LinqCriteria<CoralPOS.Models.ProductMaster> criteria = new LinqCriteria<CoralPOS.Models.ProductMaster>();
            criteria.AddCriteria(item => item.ProductName.Contains("AO"));
        }

        #endregion
		
        
        
    }
}
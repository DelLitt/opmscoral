			 

			 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;



namespace POSServer.ViewModels.ProductMaster
{
    [PerRequest(typeof(IProductMasterSummaryViewModel))]
    public class ProductMasterSummaryViewModel : PosViewModel,IProductMasterSummaryViewModel  
    {

        private IShellViewModel _startViewModel;
        public ProductMasterSummaryViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
        private string _productName;
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                NotifyOfPropertyChange(() => ProductName);
            }
        }
		        
        private string _productType;
        public string ProductType
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
		        
        private string _category;
        public string Category
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
		        
        private string _textBox5;
        public string textBox5
        {
            get
            {
                return _textBox5;
            }
            set
            {
                _textBox5 = value;
                NotifyOfPropertyChange(() => textBox5);
            }
        }
		        
        private string _productMasterId;
        public string ProductMasterId
        {
            get
            {
                return _productMasterId;
            }
            set
            {
                _productMasterId = value;
                NotifyOfPropertyChange(() => ProductMasterId);
            }
        }
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void ProductBack()
        {
            
        }
		        
        public void ProductSaveConfirm()
        {
            
        }
		        
        public void Stop()
        {
            
        }
		        
        public void button4()
        {
            
        }
		        
        public void button5()
        {
            
        }
		        
        public void button7()
        {
            
        }
		        
        public void button8()
        {
            
        }
		        
        public void button9()
        {
            
        }
		        
        public void button10()
        {
            
        }
		        
        public void button11()
        {
            
        }
		        
        public void button12()
        {
            
        }
		        
        public void MinorDetailEnter()
        {
            
        }
				#endregion
		
        
        
    }
}
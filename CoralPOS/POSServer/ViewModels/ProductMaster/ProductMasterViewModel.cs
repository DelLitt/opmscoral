			 

			 

using System;
using System.Collections;
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
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;


namespace POSServer.ViewModels.ProductMaster
{
    [PerRequest(typeof(IProductMasterViewModel))]
    public class ProductMasterViewModel : PosViewModel,IProductMasterViewModel  
    {

        private IShellViewModel _startViewModel;
        public ProductMasterViewModel(IShellViewModel startViewModel)
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

        private ProductType _productType;
        public ProductType ProductType
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
		        
        private Category _category;
        public Category Category
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
		        
        private IList _categoryList;
        public IList CategoryList
        {
            get
            {
                return _categoryList;
            }
            set
            {
                _categoryList = value;
                NotifyOfPropertyChange(() => CategoryList);
            }
        }

        private IList _productColorsList;
        public IList ProductColorsList
        {
            get
            {
                return _productColorsList;
            }
            set
            {
                _productColorsList = value;
                NotifyOfPropertyChange(() => ProductColorsList);
            }
        }

        private IList _productSizesList;
        public IList ProductSizesList
        {
            get
            {
                return _productSizesList;
            }
            set
            {
                _productSizesList = value;
                NotifyOfPropertyChange(() => ProductSizesList);
            }
        }
				#endregion
		
		#region List which just using in Data Grid
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void ProductRecreate()
        {
            
        }
		        
        public void ProductSave()
        {
            
        }
		        
        public void Stop()
        {
            Flow.End();
        }
		        
        public void ProductImageSelect()
        {
            
        }
		        
        public void NewType()
        {
            
        }
		        
        public void NewCategory()
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
		        
        public void NewColor()
        {
            
        }
		        
        public void NewSize()
        {
            
        }

        public override void Initialize()
        {
            CategoryList = Flow.Session.Get(FlowConstants.CATEGORY_LIST) as IList;
            ProductTypeList = Flow.Session.Get(FlowConstants.PRODUCT_TYPE_LIST) as IList;
            ProductColorsList = Flow.Session.Get(FlowConstants.PRODUCT_COLOR_LIST) as IList;
            ProductSizesList = Flow.Session.Get(FlowConstants.PRODUCT_SIZE_LIST) as IList;
        }

        #endregion
		
        
        
    }
}
			 

			 

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



namespace POSServer.ViewModels.ProductMaster
{
    [PerRequest(typeof(IProductCategoryViewModel))]
    public class ProductCategoryViewModel : PosViewModel,IProductCategoryViewModel  
    {

        private IShellViewModel _startViewModel;
        public ProductCategoryViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
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
		        
        private string _categoryName;
        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
                NotifyOfPropertyChange(() => CategoryName);
            }
        }
		        
        private string _categoryId;
        public string CategoryId
        {
            get
            {
                return _categoryId;
            }
            set
            {
                _categoryId = value;
                NotifyOfPropertyChange(() => CategoryId);
            }
        }
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _productCategoryList;
        public IList ProductCategoryList
        {
            get
            {
                return _productCategoryList;
            }
            set
            {
                _productCategoryList = value;
                NotifyOfPropertyChange(() => ProductCategoryList);
            }
        }
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void Delete()
        {
            
        }
		        
        public void Edit()
        {
            
        }
		        
        public void Stop()
        {
            
        }
		        
        public void Create()
        {
            
        }
				#endregion
		
        
        
    }
}
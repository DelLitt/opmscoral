			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Utils;
using Caliburn.Micro;


using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;


namespace POSServer.ViewModels.ProductMaster
{
    //[PerRequest(typeof(IProductCategoryViewModel))]
    public class ProductCategoryViewModel : PosViewModel,IProductCategoryViewModel  
    {

        private IShellViewModel _startViewModel;
        public ProductCategoryViewModel()
        {
            _startViewModel = ShellViewModel.Current;
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

        public Category SelectedProductCategory
        {
            get; set;
        }

        public ICategoryLogic CategoryLogic
        {
            get; set;
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
            IList list = new ArrayList(_productCategoryList);
            ObjectUtility.RemoveFromList(list, SelectedProductCategory, "CategoryName");
            ProductCategoryList = list;
        }
		        
        public void Edit()
        {
            
        }
		        
        public void Stop()
        {
            Flow.End(); 
        }
		        
        public void Create()
        {
            IList list = new ArrayList(_productCategoryList);
            list.Add(new Category
            {
                CategoryName = "NONAME"
            });
            ProductCategoryList = list;
        }

        public void Save()
        {
            CategoryLogic.Update(ProductCategoryList);
            SetBackToParentFlow(FlowConstants.CATEGORY_LIST, ProductCategoryList);
            GoToNextNode();
        }

        protected override void OnInitialize()
        {
            CategoryLogic.LoadDefinition(Flow.Session);
            IList list = null;
            list = Flow.Session.Get(FlowConstants.CATEGORY_LIST) as IList;
            //if (list == null) list = new ArrayList();
            ProductCategoryList = list;
            SelectedProductCategory = new Category();
            
        }

        #endregion
		
        
        
    }
}
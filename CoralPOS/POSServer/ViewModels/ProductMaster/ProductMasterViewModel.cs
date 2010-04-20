			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using AppFrame.Utils;
using AppFrame.WPF.ValidationAttributes;
using Caliburn.Core;
using Caliburn.Core.IoC;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Filters;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.ViewModels.Menu.ProductMaster;


namespace POSServer.ViewModels.ProductMaster
{

    [AttachMenuAndMainScreen(typeof(IProductMasterMenuViewModel), typeof(IProductMasterMainViewModel))]
    public class ProductMasterViewModel : PosViewModel,IProductMasterViewModel  
    {

        private IShellViewModel _startViewModel;
        private IList _productColors;

        private IList _productSizes;

        

        
        

        public ProductMasterViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
        private string _productName;

        private CoralPOS.Models.ProductMaster productMaster;
        public CoralPOS.Models.ProductMaster ProductMaster
        {
            get { return productMaster; }
            set 
            { 
                productMaster = value;
                NotifyOfPropertyChange(()=>ProductMaster); 
            }
        }

        [NotNullOrEmpty]
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

        public IList ProductColors
        {
            get { return _productColors; }
            set { _productColors = value; 
                NotifyOfPropertyChange(()=>ProductColors);
            }
        }

        public IList ProductSizes
        {
            get { return _productSizes; }
            set { _productSizes = value;
            NotifyOfPropertyChange(() => ProductSizes);
            }
        }

        private IList<ExProductColor> _selectedProductColors;
        public IList<ExProductColor> SelectedProductColors
        {
            get { return _selectedProductColors; }
            
        }

        private IList<ExProductColor> _removeProductColors;
        public IList<ExProductColor> RemoveProductColors
        {
            get { return _removeProductColors; }

        }

        private IList<ExProductSize> _selectedProductSizes;
        public IList<ExProductSize> SelectedProductSizes
        {
            get { return _selectedProductSizes; }
        }

        private IList<ExProductSize> _removeProductSizes;
        public IList<ExProductSize> RemoveProductSizes
        {
            get { return _removeProductSizes; }
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
		        
        public void Recreate()
        {
            
        }

        private bool _canSave;
        public bool CanSave
        {
            get
            {
                return _canSave;
            }
            set
            {
                _canSave = value;
                NotifyOfPropertyChange(()=>CanSave);
            }
        }

        [Dependencies("ProductMaster")]
        public void Save()
        {
            var savePM = new CoralPOS.Models.ProductMaster
                             {
                                ProductName = ProductName,
                                Category = Category,
                                ProductType = ProductType,
                                CreateDate = DateTime.Now,
                                CreateId = "admin",
                                UpdateDate = DateTime.Now,
                                UpdateId = "admin"
                             };
            var savePm = ProductMaster;
            /*savePm.Category = Category;
            savePm.ProductType = ProductType;*/
            savePm.CreateDate = DateTime.Now;
            savePm.CreateId = "admin";
            savePm.UpdateDate = DateTime.Now;
            savePm.UpdateId = "admin";

            var productColorList = ProductColors;
            var productSizeList = ProductSizes;
            Flow.Session.Put(FlowConstants.SAVE_PRODUCT_MASTER,savePm);
            Flow.Session.Put(FlowConstants.SAVE_PRODUCT_COLORS_LIST, productColorList);
            Flow.Session.Put(FlowConstants.SAVE_PRODUCT_SIZES_LIST, productSizeList);
            GoToNextNode();
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
            _startViewModel.EnterChildFlow("ProductTypeViewFlow", this.Flow);
        }
		        
        public void NewCategory()
        {
            _startViewModel.EnterChildFlow("ProductCategoryViewFlow", this.Flow);
        }

        public void ColorAddAll()
        {
            ProductColors = ProductColorsList;
        }

        public void ColorAdd()
        {
            IList newList = new ArrayList(_productColors);
            ObjectUtility.AddToList(newList, SelectedProductColors, "ColorName");
            ProductColors = newList; 
        }

        public void ColorRemove()
        {
            IList newList = new ArrayList(_productColors);
            ObjectUtility.RemoveFromList(newList, RemoveProductColors, "ColorName");
            ProductColors = newList; 
        }

        public void ColorRemoveAll()
        {
            ProductColors = new ArrayList();
        }

        public void SizeAddAll()
        {
            ProductSizes = ProductSizesList;
        }

        public void SizeAdd()
        {
            IList newList = new ArrayList(_productSizes);
            ObjectUtility.AddToList(newList, SelectedProductSizes, "SizeName");
            ProductSizes = newList;  
        }

        public void SizeRemove()
        {
            IList newList = new ArrayList(_productSizes);
            ObjectUtility.RemoveFromList(newList, RemoveProductSizes, "SizeName");
            ProductSizes = newList; 
        }

        public void SizeRemoveAll()
        {
            ProductSizes = new ArrayList();
            TestPro();
        }

        private void TestPro()
        {
            throw new NotImplementedException();
        }
        public void MinorDetailEnter()
        {
            
        }
		        
        public void NewColor()
        {
            _startViewModel.EnterChildFlow("ProductColorViewFlow", this.Flow);
        }
		        
        public void NewSize()
        {
            _startViewModel.EnterChildFlow("ProductSizeViewFlow", this.Flow);
        }

        public override void Initialize()
        {
            CategoryList = Flow.Session.Get(FlowConstants.CATEGORY_LIST) as IList;
            ProductTypeList = Flow.Session.Get(FlowConstants.PRODUCT_TYPE_LIST) as IList;
            ProductColorsList = Flow.Session.Get(FlowConstants.PRODUCT_COLOR_LIST) as IList;
            ProductSizesList = Flow.Session.Get(FlowConstants.PRODUCT_SIZE_LIST) as IList;
            if(_productColors==null) _productColors = new ArrayList();
            if (_productSizes == null) _productSizes = new ArrayList();
            if (_selectedProductColors == null) _selectedProductColors = new Collection<ExProductColor>();
            if (_removeProductColors == null) _removeProductColors = new List<ExProductColor>();
            if (_selectedProductSizes == null) _selectedProductSizes = new List<ExProductSize>();
            if (_removeProductSizes == null) _removeProductSizes = new List<ExProductSize>();
            ProductMaster = Flow.Session.Get(FlowConstants.SAVE_PRODUCT_MASTER) as CoralPOS.Models.ProductMaster;
            if(ProductMaster ==null) CreateNewProductMaster();
            
            
        }

        private void CreateNewProductMaster()
        {
            ProductMaster = DataErrorInfoFactory.Create<CoralPOS.Models.ProductMaster>();

        }

        void Session_OnFlowChanged(object sender, EventArgs e)
        {
            CategoryList = Flow.Session.Get(FlowConstants.CATEGORY_LIST) as IList;
            ProductTypeList = Flow.Session.Get(FlowConstants.PRODUCT_TYPE_LIST) as IList;
            ProductColorsList = Flow.Session.Get(FlowConstants.PRODUCT_COLOR_LIST) as IList;
            ProductSizesList = Flow.Session.Get(FlowConstants.PRODUCT_SIZE_LIST) as IList;
        }

        #endregion
        
    }
}
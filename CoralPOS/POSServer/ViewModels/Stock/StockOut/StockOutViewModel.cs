			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
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
using POSServer.ViewModels.Dialogs;
using POSServer.ViewModels.Menu.Stock;


namespace POSServer.ViewModels.Stock.StockOut
{
    [AttachMenuAndMainScreen(typeof(IStockOutMenuViewModel),typeof(IStockMainViewModel))]
    public class StockOutViewModel : PosViewModel,IStockOutViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockOutViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields

        private DateTime _createDate;
        public DateTime CreateDate
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
		        
        private CoralPOS.Models.ProductMaster _productMaster;
        public CoralPOS.Models.ProductMaster ProductMaster
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
		        
        private IList _department;
        public IList Departments
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                NotifyOfPropertyChange(() => Departments);
            }
        }
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _stockOutDetails;
        public IList StockOutDetails
        {
            get
            {
                return _stockOutDetails;
            }
            set
            {
                _stockOutDetails = value;
                NotifyOfPropertyChange(() => StockOutDetails);
            }
        }

        public string _productNameText;
        public string ProductNameText
        {
            get { return _productNameText; }
            set { _productNameText = value; NotifyOfPropertyChange(() => ProductNameText); }
        }
        public IMainStockLogic MainStockLogic { get; set; }
        public IProductMasterLogic ProductMasterLogic { get; set; }		
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
		        
        public void CreateByBlock()
        {
            
        }
		        
        public void CreateByFile()
        {
            
        }
		        
        public void FixQuantityByAvailable()
        {
            
        }

        public void ReloadProductMaster(string text)
        {
            Execute.OnBackgroundThread(() => LoadProductMaster(text), CompletedLoadProductMaster);
        }

        private void LoadProductMaster(string text)
        {
            if (string.IsNullOrEmpty(text)) text = "";
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StartLoading();
            IList productMasters = MainStockLogic.FindProductMasterAvailInStock(text);
            ProductMasterList = productMasters;
        }
        void CompletedLoadProductMaster(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StopLoading();
        }


        public void Create()
        {
            if(ObjectUtility.IsNullOrEmpty(ProductMaster)) return;
            var screen = _startViewModel.ServiceLocator.GetInstance<IStockProductPropertiesViewModel>("IStockProductPropertiesViewModel");
            screen.ProductName = ProductMaster.ProductName;
            screen.Setup();
            screen.ConfirmEvent += new EventHandler<ProductEventArgs>(ScreenConfirmEvent);
            _startViewModel.ShowDialog(screen);
        }

        void ScreenConfirmEvent(object sender, ProductEventArgs e)
        {
            CreateProductIdForInput(e.ProductColorList, e.ProductSizeList,e.StockList); 
        }

        private void CreateProductIdForInput(IList colorList, IList sizeList,IList stockList)
        {
            IList addStockList = new ArrayList();
            foreach (MainStock stock in stockList)
            {
                Product product = stock.Product;
                foreach (ExProductColor color in colorList)
                {
                    foreach (ExProductSize size in sizeList)
                    {
                        if(   product.ProductColor.ColorName.Equals(color.ColorName)
                           && product.ProductSize.SizeName.Equals(size.SizeName) )
                        {
                            addStockList.Add(stock);
                        }
                    }
                }
            }
            var details = new ArrayList(_stockOutDetails);
            foreach (MainStock stock in addStockList)
            {
                Product product = stock.Product;
                if(!ProductInStockOutList(details,product))
                {
                    // create new stockout detail for that product
                    StockOutDetail newDetail = new StockOutDetail
                                                   {
                                                       Product = stock.Product,
                                                       ProductMaster = stock.ProductMaster,
                                                       CreateDate = DateTime.Now,
                                                       UpdateDate = DateTime.Now,
                                                       CreateId = "admin",
                                                       UpdateId = "admin",
                                                       Quantity = stock.GoodQuantity,
                                                       StockQuantity = stock.Quantity
                                                   };
                    StockDefinitionStatus definitionStatus = new StockDefinitionStatus
                                                                 {
                                                                     DefectStatusId = 0,
                                                                     DefectStatusName = "NormalStockOut"
                                                                 };
                    details.Add(newDetail);
                }
            }
            StockOutDetails = details;
        }

        private bool ProductInStockOutList(ArrayList detail, Product product)
        {
            foreach (StockOutDetail outDetail in detail)
            {
                if(outDetail.Product.ProductId.Equals(product.ProductId))
                    return true;
            }
            return false;
        }

        public override void Initialize()
        {
            var list = Flow.Session.Get(FlowConstants.PRODUCT_NAMES_LIST);
            ProductMasterList = list as IList;
            var deptsList = Flow.Session.Get(FlowConstants.DEPARTMENTS);
            Departments = deptsList as IList;
            ProductMaster = new CoralPOS.Models.ProductMaster();
            var details = new ArrayList();
            StockOutDetails = details;
            CreateDate = DateTime.Now;
        }

        #endregion
		
        
        
    }
}
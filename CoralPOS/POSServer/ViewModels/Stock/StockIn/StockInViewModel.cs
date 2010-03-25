			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.DataLayer;
using AppFrame.Utils;
using Caliburn.Core;
using Caliburn.Core.IoC;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.Utils;
using POSServer.ViewModels.Dialogs;


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
		        
        private IList _productMasterDetailList;
        public IList ProductMasterList
        {
            get
            {
                return _productMasterDetailList;
            }
            set
            {
                _productMasterDetailList = value;
                NotifyOfPropertyChange(() => ProductMasterList);
            }
        }
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _stockInDetailList;
        public IList StockInDetailList
        {
            get
            {
                return _stockInDetailList;
            }
            set
            {
                _stockInDetailList = value;
                NotifyOfPropertyChange(() => StockInDetailList);
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
            CoralPOS.Models.StockIn stockIn = new CoralPOS.Models.StockIn
                                                  {
                                                      StockInType = 0,
                                                      ConfirmFlg = 0,
                                                      Description = Description,
                                                      CreateDate = DateTime.Now,
                                                      UpdateDate = DateTime.Now,
                                                      StockInDate = DateTime.Now,
                                                      CreateId = "admin",
                                                      UpdateId = "admin",
                                                      DelFlg = 0,
                                                      ExclusiveKey = 0
                                                  };
            stockIn.StockInDetails = ObjectConverter.ConvertTo<StockInDetail>(StockInDetailList);
            Flow.Session.Put(FlowConstants.SAVE_STOCK_IN, stockIn);
            GoToNextNode();
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
            _stockInDetailList = new ArrayList();
        }
        public void OpenProperty()
        {
            var screen = _startViewModel.ServiceLocator.GetInstance<IProductPropertiesViewModel>("IProductPropertiesViewModel");
            screen.ProductName = ProductMaster.ProductName;
            screen.Setup();
            screen.ConfirmEvent += new EventHandler<ProductEventArgs>(screen_ConfirmEvent);
            _startViewModel.ShowDialog(screen);
        }

        void screen_ConfirmEvent(object sender, ProductEventArgs e)
        {
            CreateProductIdForInput(e.ProductColorList, e.ProductSizeList);
        }

        private void CreateProductIdForInput(IList colorList, IList sizeList)
        {
            
            var productMaster = ProductMaster;
            IList<Product> products = StockInHelper.CreateProduct(productMaster, colorList, sizeList);
            foreach (Product newProduct in products)
            {
                    bool isFound = CheckProductInStockInDetailList(newProduct); 
                    if(isFound) continue;

                    string inputPrice = string.IsNullOrEmpty(InputPrice) ? "0" : InputPrice;
                    StockInDetail newDetail = new StockInDetail{
                            Product = newProduct,
                            ProductMaster = productMaster,
                            CreateDate = DateTime.Now,
                            UpdateDate = DateTime.Now,
                            CreateId = "admin",
                            UpdateId = "admin",
                            Quantity = 0,
                            Price = Int64.Parse(inputPrice)
                        };
                    StockInDetailPK detailPK = new StockInDetailPK
                                                   {
                                                       ProductId = newProduct.ProductId
                                                   };
                    newDetail.StockInDetailPK = detailPK;
                    string price = string.IsNullOrEmpty(Price) ? "0" : Price;
                    string wholesaleprice = string.IsNullOrEmpty(WholeSalePrice) ? "0" : WholeSalePrice;
                    
                    MainPrice newPrice = new MainPrice
                                             {
                                                Price = Int64.Parse(price),
                                                WholeSalePrice = Int64.Parse(wholesaleprice)
                                             };
                    MainPricePK newPricePK = new MainPricePK
                                                 {
                                                     DepartmentId = 0,
                                                     ProductMasterId = productMaster.ProductMasterId
                                                 };

                    newPrice.MainPricePK =newPricePK;
                    newDetail.MainPrice = newPrice;

                    IList list = new ArrayList(_stockInDetailList);
                    list.Add(newDetail);
                    StockInDetailList = list;
                
            }
        }

        private bool CheckProductInStockInDetailList(Product product)
        {
            foreach (StockInDetail inDetail in _stockInDetailList)
            {
                if(inDetail.Product.ProductId.Equals(product.ProductId)) return true;
            }
            return false;
        }
    }
        #endregion
		
}
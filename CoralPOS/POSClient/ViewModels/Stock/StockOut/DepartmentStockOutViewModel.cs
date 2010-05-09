			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.DataLayer;
using AppFrame.Utils;
using AppFrame.WPF.Screens;
using Caliburn.Core;
using Caliburn.Core.Invocation;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Invocation;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Common;
using CoralPOS.Models;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Win32;
using POSClient.BusinessLogic.Implement;
using POSClient.Common;
using POSClient.ViewModels.Dialogs;


namespace POSClient.ViewModels.Stock.StockOut
{
    
    public class DepartmentStockOutViewModel : PosViewModel,IDepartmentStockOutViewModel  
    {

        private IShellViewModel _startViewModel;
        public DepartmentStockOutViewModel(IShellViewModel startViewModel)
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

        private ProductMaster _productMaster;
        public ProductMaster ProductMaster
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
		        
        private Department _department;
        public Department Department
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
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _departmentStockOutDetails;
        private IList _departments;
        private DepartmentStockOut _departmentStockOut;

        public IList DepartmentStockOutDetails
        {
            get
            {
                return _departmentStockOutDetails;
            }
            set
            {
                _departmentStockOutDetails = value;
                NotifyOfPropertyChange(() => DepartmentStockOutDetails);
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
		        
        public void CreateByBlock()
        {
            var screen = _startViewModel.ServiceLocator.GetInstance<IStockOutChoosingViewModel>("IStockOutChoosingViewModel");
            screen.ConfirmEvent += new EventHandler<DepartmentStockInChoosingArg>(StockInConfirmEvent);
            _startViewModel.ShowDialog(screen);
        }


        void StockInConfirmEvent(object sender, DepartmentStockInChoosingArg e)
        {

            CoralPOS.Models.DepartmentStockIn selectedStockIn = e.SelectedStockIn;
            BackgroundTask backgroundTask = new BackgroundTask(() => PopulateStockOutList(selectedStockIn));
            backgroundTask.Completed += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundTask_Completed);
            StartWaitingScreen(0);
            backgroundTask.Start(selectedStockIn);
        }

        private object PopulateStockOutList(DepartmentStockIn selectedStockIn)
        {
            var details = new ArrayList(DepartmentStockOutDetails);
            foreach (DepartmentStockInDetail inDetail in selectedStockIn.DepartmentStockInDetails)
            {
                Product product = inDetail.Product;
                if (!ProductInStockOutList(details, product))
                {
                    // create new stockout detail for that product
                    DepartmentStockOutDetail newDetail = DataErrorInfoFactory.Create<DepartmentStockOutDetail>();
                    newDetail.Product = inDetail.Product;
                    newDetail.ProductMaster = inDetail.ProductMaster;
                    newDetail.CreateDate = DateTime.Now;
                    newDetail.UpdateDate = DateTime.Now;
                    newDetail.CreateId = "admin";
                    newDetail.UpdateId = "admin";
                    newDetail.Quantity = inDetail.Quantity;
                    newDetail.DepartmentStockQuantity = inDetail.DepartmentStock.Quantity;


                    details.Add(newDetail);
                }
                else
                {
                    DepartmentStockOutDetail result = (from sod in details.OfType<DepartmentStockOutDetail>()
                                             where sod.Product.ProductId.Equals(product.ProductId)
                                             select sod).FirstOrDefault();
                    result.Quantity += inDetail.Quantity;

                }
            }

            DepartmentStockOutDetails = details;
            return null;
        }

        void backgroundTask_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            StopWaitingScreen(0);
        }

        void ScreenConfirmEvent(object sender, ProductEventArgs e)
        {
            CreateProductIdForInput(e.ProductColorList, e.ProductSizeList, e.StockList);
        }

        public void CreateByFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.txt | Text Files";
            openFileDialog.CheckFileExists = true;
            openFileDialog.ShowDialog();
            // if has file to open
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                IList<string> errorList;
                IDictionary<string, long> productList = ObjectUtility.ReadProductList(openFileDialog.FileName, out errorList);

                // add to stockOut list
                ArrayList details = new ArrayList(DepartmentStockOutDetails);
                foreach (KeyValuePair<string, long> keyValuePair in productList)
                {
                    StockOutDetail result = (from sod in details.OfType<StockOutDetail>()
                                             where sod.Product.ProductId.Equals(keyValuePair.Key)
                                             select sod).FirstOrDefault();
                    if (result != null) // if exist in list
                    {
                        result.Quantity += keyValuePair.Value;
                    }
                    else
                    {
                        // get information from database
                        DepartmentStock stock = DepartmentStockLogic.FindByProductId(keyValuePair.Key);
                        errorList.Add(keyValuePair.Key);
                        // create new stockout detail for that product
                        StockOutDetail newDetail = DataErrorInfoFactory.Create<StockOutDetail>();
                        newDetail.Product = stock.Product;
                        newDetail.ProductMaster = stock.ProductMaster;
                        newDetail.CreateDate = DateTime.Now;
                        newDetail.UpdateDate = DateTime.Now;
                        newDetail.CreateId = "admin";
                        newDetail.UpdateId = "admin";
                        newDetail.Quantity = stock.GoodQuantity;
                        newDetail.StockQuantity = stock.Quantity;

                        details.Add(newDetail);
                    }
                }
                DepartmentStockOutDetails = details;
            }
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
            IList productMasters = DepartmentStockLogic.FindProductMasterAvailInStock(text);
            ProductMasterList = productMasters;
        }

        protected IDepartmentStockLogic DepartmentStockLogic { get; set; }

        void CompletedLoadProductMaster(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StopLoading();
        }

        public void Create()
        {
            if (ObjectUtility.IsNullOrEmpty(ProductMaster)) return;
            var screen = _startViewModel.ServiceLocator.GetInstance<IStockProductPropertiesViewModel>("IStockProductPropertiesViewModel");
            screen.ProductName = ProductMaster.ProductName;
            screen.Setup();
            screen.ConfirmEvent += new EventHandler<ProductEventArgs>(ScreenConfirmEvent);
            _startViewModel.ShowDialog(screen);
        }

        private void CreateProductIdForInput(IList colorList, IList sizeList, IList stockList)
        {
            IList addStockList = new ArrayList();
            foreach (MainStock stock in stockList)
            {
                Product product = stock.Product;
                foreach (ExProductColor color in colorList)
                {
                    foreach (ExProductSize size in sizeList)
                    {
                        if (product.ProductColor.ColorName.Equals(color.ColorName)
                           && product.ProductSize.SizeName.Equals(size.SizeName))
                        {
                            addStockList.Add(stock);
                        }
                    }
                }
            }
            var details = new ArrayList(DepartmentStockOutDetails);
            foreach (MainStock stock in addStockList)
            {
                Product product = stock.Product;
                if (!ProductInStockOutList(details, product))
                {
                    // create new stockout detail for that product
                    StockOutDetail newDetail = DataErrorInfoFactory.Create<StockOutDetail>();

                    newDetail.Product = stock.Product;
                    newDetail.ProductMaster = stock.ProductMaster;
                    newDetail.CreateDate = DateTime.Now;
                    newDetail.UpdateDate = DateTime.Now;
                    newDetail.CreateId = "admin";
                    newDetail.UpdateId = "admin";
                    newDetail.Quantity = stock.GoodQuantity;
                    newDetail.StockQuantity = stock.Quantity;


                    details.Add(newDetail);
                }
            }
            DepartmentStockOutDetails = details;
        }

        private bool ProductInStockOutList(ArrayList detail, Product product)
        {
            foreach (DepartmentStockOutDetail outDetail in detail)
            {
                if (outDetail.Product.ProductId.Equals(product.ProductId))
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
            DepartmentStockOutDetails = details;
            CreateDate = DateTime.Now;

            CoralPOS.Models.DepartmentStockOut stockOut = Flow.Session.Get(FlowConstants.SAVE_DEPT_STOCK_OUT) as CoralPOS.Models.DepartmentStockOut;
            if (stockOut != null)
            {
                DepartmentStockOutDetails = ObjectConverter.ConvertFrom(stockOut.DepartmentStockOutDetails);
                Department = new Department
                                 {
                                     DepartmentId = stockOut.DepartmentStockOutPK.DepartmentId,
                                     DepartmentName = "CK"
                                 };
            }
            else
            {
                StockDefinitionStatus definitionStatus = DataErrorInfoFactory.Create<StockDefinitionStatus>();
                definitionStatus.DefectStatusId = (int)StockOutType.Normal;
                definitionStatus.DefectStatusName = "NORMAL";

                stockOut = DataErrorInfoFactory.Create<CoralPOS.Models.DepartmentStockOut>();
                stockOut.ConfirmFlg = 0;
                stockOut.CreateDate = DateTime.Now;
                stockOut.UpdateDate = DateTime.Now;
                stockOut.StockOutDate = DateTime.Now;
                stockOut.CreateId = "admin";
                stockOut.UpdateId = "admin";
                stockOut.DelFlg = 0;
                stockOut.ExclusiveKey = 0;
                stockOut.StockDefinitionStatus = definitionStatus;


            }
            DepartmentStockOut = stockOut; 
        }

        protected DepartmentStockOut DepartmentStockOut
        {
            get {
                return _departmentStockOut;
            }
            set {
                _departmentStockOut = value;
                NotifyOfPropertyChange(()=>DepartmentStockOut);
            }
        }

        protected IList Departments
        {
            get {
                return _departments;
            }
            set {
                _departments = value;
                NotifyOfPropertyChange(()=>Departments);
            }
        }

        #endregion
		
        
        
    }
}
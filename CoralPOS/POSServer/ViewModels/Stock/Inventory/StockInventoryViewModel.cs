			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using Caliburn.Core;
using Caliburn.Core.Invocation;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;
using POSServer.ViewModels.Menu.Stock;


namespace POSServer.ViewModels.Stock.Inventory
{
    [AttachMenuAndMainScreen(typeof(IInventoryMenuViewModel),typeof(IStockMainViewModel))]
    public class StockInventoryViewModel : PosViewModel,IStockInventoryViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockInventoryViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
        private string _createDate;
        public string CreateDate
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
		        
        private string _barcode;
        public string Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value;
                NotifyOfPropertyChange(() => Barcode);
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

        private bool _checkSelectedDepartment;
        public bool CheckSelectedDepartment
        {
            get
            {
                return _checkSelectedDepartment;
            }
            set
            {
                _checkSelectedDepartment = value;
                NotifyOfPropertyChange(()=>CheckSelectedDepartment);
            }
        }

        private Department _selectedDepartment;
        public Department SelectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }
            set
            {
                _selectedDepartment = value;
                NotifyOfPropertyChange(() => SelectedDepartment);
            }
        }

        private ProductType _selectedProductType;
        public ProductType SelectedProductType
        {
            get
            {
                return _selectedProductType;
            }
            set
            {
                _selectedProductType = value;
                NotifyOfPropertyChange(() => SelectedProductType);
            }
        }
        public IDepartmentLogic DepartmentLogic { get; set; }
        public IDepartmentStockTempValidLogic DepartmentStockTempValidLogic { get; set; }
				#endregion
		
		#region List use to fetch object for view
		        
        private IList _departments;
        public IList Departments
        {
            get
            {
                return _departments;
            }
            set
            {
                _departments = value;
                NotifyOfPropertyChange(() => Departments);
            }
        }
		        
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
		
		#region List of boolean object
				#endregion
		
		#region List of date object
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _stockInventoryList;
        public IList StockInventoryList
        {
            get
            {
                return _stockInventoryList;
            }
            set
            {
                _stockInventoryList = value;
                NotifyOfPropertyChange(() => StockInventoryList);
            }
        }

        private IList _stockInventoryListFooter;
        public IList StockInventoryListFooter
        {
            get
            {
                return _stockInventoryListFooter;
            }
            set
            {
                _stockInventoryListFooter = value;
                NotifyOfPropertyChange(() => StockInventoryListFooter);
            }
        }
        
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void TempLoad()
        {
            
        }
		        
        public void TempSave()
        {
            
        }
		        
        public void Stop()
        {
            Flow.End();
        }
		        
        public void button1()
        {
            
        }
		        
        public void SaveResult()
        {
            
        }
		        
        public void Delete()
        {
            
        }
		        
        public void Reset()
        {
            
        }
		        
        public void InputByFile()
        {
            
        }

        public void ProcessProductTypeChange()
        {
            
        }
        public void ChangeDepartmentForEvaluate()
        {
            BackgroundTask backgroundTask = new BackgroundTask(() => PopulateStockTempValidList(SelectedDepartment));
            backgroundTask.Completed +=backgroundTask_Completed;
            StartWaitingScreen(0);
            backgroundTask.Start(SelectedDepartment);
            
        }

        private void backgroundTask_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            StopWaitingScreen(0);
            CheckSelectedDepartment = false;
        }

        private object PopulateStockTempValidList(Department selectedDepartment)
        {
            IList<DepartmentStockTempValid> list = DepartmentStockTempValidLogic.FindStockTempValidForDepartment(SelectedDepartment);
            StockInventoryList = list as IList;

            // populate ProductTypeList
            var productMasterList = (from stockValid in list
                                     select stockValid.ProductMaster).Distinct().ToList();
            var productTypeList = (from prdMaster in productMasterList
                                   select prdMaster.ProductType).Distinct().ToList();
            productTypeList.Insert(0,new ProductType{TypeId = 0,TypeName = "TAT CA CAC LOAI"});
            ProductTypeList = productTypeList as IList;
            ProductMasterList = productMasterList as IList;
            return 0;
        }

        public override void Initialize()
        {
            IList<Department> departments = DepartmentLogic.FindAll(new ObjectCriteria<Department>());
            departments.OrderBy(m => m.DepartmentId);
            Departments = departments as IList;
            SelectedDepartment = departments[0];
            StockInventoryList = new ArrayList();
            CheckSelectedDepartment = true;

            IList list = new ArrayList();
        }

        #endregion
		
        
        
    }
}
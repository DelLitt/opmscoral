			 

			 

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
using POSServer.BusinessLogic.Implement;


namespace POSServer.ViewModels.Stock.Inventory
{
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
		        
        private IList _productType;
        public IList ProductType
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

        public void ChangeDepartmentForEvaluate()
        {
            IList<DepartmentStockTempValid> list = DepartmentStockTempValidLogic.FindStockTempValidForDepartment(SelectedDepartment);
            StockInventoryList = list as IList;
        }
        public override void Initialize()
        {
            IList<Department> departments = DepartmentLogic.FindAll(new ObjectCriteria<Department>());
            departments.Insert(0,new Department { DepartmentId = 0,DepartmentName = "KHO CHINH"});
            Departments = departments as IList;
            SelectedDepartment = departments[0];
            StockInventoryList = new ArrayList();
        }

        #endregion
		
        
        
    }
}
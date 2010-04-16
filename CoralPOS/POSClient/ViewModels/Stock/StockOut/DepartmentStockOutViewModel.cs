			 

			 

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



namespace POSClient.ViewModels.Stock.StockOut
{
    [PerRequest(typeof(IDepartmentStockOutViewModel))]
    public class DepartmentStockOutViewModel : PosViewModel,IDepartmentStockOutViewModel  
    {

        private IShellViewModel _startViewModel;
        public DepartmentStockOutViewModel(IShellViewModel startViewModel)
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
		        
        private string _productMaster;
        public string ProductMaster
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
        public IList Department
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
		        
        private IList _stockOutList;
        public IList StockOutList
        {
            get
            {
                return _stockOutList;
            }
            set
            {
                _stockOutList = value;
                NotifyOfPropertyChange(() => StockOutList);
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
				#endregion
		
        
        
    }
}
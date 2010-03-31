			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Core;
using Caliburn.Core.IoC;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSServer.BusinessLogic.Common;
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

        public override void Initialize()
        {
            var list = Flow.Session.Get(FlowConstants.PRODUCT_NAMES_LIST);
            ProductMasterList = list as IList;
            var deptsList = Flow.Session.Get(FlowConstants.DEPARTMENTS);
            Departments = deptsList as IList;

            var details = new ArrayList();
            StockOutDetails = details;
            CreateDate = DateTime.Now;
        }

        #endregion
		
        
        
    }
}
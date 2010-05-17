			 

			 

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



namespace POSServer.ViewModels.Stock.StockOut
{
    [PerRequest(typeof(IStockOutWaitingConfirmViewModel))]
    public class StockOutWaitingConfirmViewModel : PosViewModel,IStockOutWaitingConfirmViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockOutWaitingConfirmViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
		        
        private IList _category;
        public IList Category
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
		
		#region List of boolean object
				#endregion
		
		#region List of date object
		        
        private IList _fromDate;
        public IList FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                _fromDate = value;
                NotifyOfPropertyChange(() => FromDate);
            }
        }
		        
        private IList _toDate;
        public IList ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                _toDate = value;
                NotifyOfPropertyChange(() => ToDate);
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
		        
        public void Unconfirm()
        {
            
        }
		        
        public void Stop()
        {
            
        }
		        
        public void Confirm()
        {
            
        }
		        
        public void Edit()
        {
            
        }
		        
        public void Search()
        {
            
        }
				#endregion
		
        
        
    }
}
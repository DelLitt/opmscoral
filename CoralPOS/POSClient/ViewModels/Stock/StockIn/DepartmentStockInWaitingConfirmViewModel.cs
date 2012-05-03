			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;



namespace POSClient.ViewModels.Stock.StockIn
{
    [PerRequest(typeof(IDepartmentStockInWaitingConfirmViewModel))]
    public class DepartmentStockInWaitingConfirmViewModel : PosViewModel,IDepartmentStockInWaitingConfirmViewModel  
    {

        private IShellViewModel _startViewModel;
        public DepartmentStockInWaitingConfirmViewModel()
        {
            _startViewModel = ShellViewModel.Current;
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
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _stockInList;
        public IList StockInList
        {
            get
            {
                return _stockInList;
            }
            set
            {
                _stockInList = value;
                NotifyOfPropertyChange(() => StockInList);
            }
        }
		        
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
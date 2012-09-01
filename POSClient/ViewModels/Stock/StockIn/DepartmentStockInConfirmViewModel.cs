			 

			 

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
    [PerRequest(typeof(IDepartmentStockInConfirmViewModel))]
    public class DepartmentStockInConfirmViewModel : PosViewModel,IDepartmentStockInConfirmViewModel  
    {

        private IShellViewModel _startViewModel;
        public DepartmentStockInConfirmViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
		
		#region Fields
		        
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
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void Back()
        {
            
        }
		        
        public void SaveConfirm()
        {
            
        }
		        
        public void Stop()
        {
            
        }
				#endregion
		
        
        
    }
}
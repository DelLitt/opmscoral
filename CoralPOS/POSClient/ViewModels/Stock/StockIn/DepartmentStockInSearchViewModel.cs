			 

			 

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



namespace POSClient.ViewModels.Stock.StockIn
{
    [PerRequest(typeof(IDepartmentStockInSearchViewModel))]
    public class DepartmentStockInSearchViewModel : PosViewModel,IDepartmentStockInSearchViewModel  
    {

        private IShellViewModel _startViewModel;
        public DepartmentStockInSearchViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
        private string _textBox1;
        public string textBox1
        {
            get
            {
                return _textBox1;
            }
            set
            {
                _textBox1 = value;
                NotifyOfPropertyChange(() => textBox1);
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
		        
        private string _textBox2;
        public string textBox2
        {
            get
            {
                return _textBox2;
            }
            set
            {
                _textBox2 = value;
                NotifyOfPropertyChange(() => textBox2);
            }
        }
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
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void ViewDetail()
        {
            
        }
		        
        public void Stop()
        {
            
        }
		        
        public void Search()
        {
            
        }
				#endregion
		
        
        
    }
}
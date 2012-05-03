			 

			 

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



namespace POSClient.ViewModels.Sale
{
    [PerRequest(typeof(IPurchaseOrderSearchViewModel))]
    public class PurchaseOrderSearchViewModel : PosViewModel,IPurchaseOrderSearchViewModel  
    {

        private IShellViewModel _startViewModel;
        public PurchaseOrderSearchViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
		
		#region Fields
		        
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
		        
        private IList _purchaseOrderList;
        public IList PurchaseOrderList
        {
            get
            {
                return _purchaseOrderList;
            }
            set
            {
                _purchaseOrderList = value;
                NotifyOfPropertyChange(() => PurchaseOrderList);
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
		        
        public void PrintInvoice()
        {
            
        }
		        
        public void Search()
        {
            
        }
				#endregion
		
        
        
    }
}
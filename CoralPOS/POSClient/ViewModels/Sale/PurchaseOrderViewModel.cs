			 

			 

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



namespace POSClient.ViewModels.Sale
{
    [PerRequest(typeof(IPurchaseOrderViewModel))]
    public class PurchaseOrderViewModel : PosViewModel,IPurchaseOrderViewModel  
    {

        private IShellViewModel _startViewModel;
        public PurchaseOrderViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
        private string _customerName;
        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                _customerName = value;
                NotifyOfPropertyChange(() => CustomerName);
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
		        
        private string _invoiceNo;
        public string InvoiceNo
        {
            get
            {
                return _invoiceNo;
            }
            set
            {
                _invoiceNo = value;
                NotifyOfPropertyChange(() => InvoiceNo);
            }
        }
		        
        private string _employee;
        public string Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                NotifyOfPropertyChange(() => Employee);
            }
        }
		        
        private string _discount;
        public string Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
                NotifyOfPropertyChange(() => Discount);
            }
        }
		        
        private string _payment;
        public string Payment
        {
            get
            {
                return _payment;
            }
            set
            {
                _payment = value;
                NotifyOfPropertyChange(() => Payment);
            }
        }
		        
        private string _totalQuantity;
        public string TotalQuantity
        {
            get
            {
                return _totalQuantity;
            }
            set
            {
                _totalQuantity = value;
                NotifyOfPropertyChange(() => TotalQuantity);
            }
        }
		        
        private string _tax;
        public string Tax
        {
            get
            {
                return _tax;
            }
            set
            {
                _tax = value;
                NotifyOfPropertyChange(() => Tax);
            }
        }
		        
        private string _changes;
        public string Changes
        {
            get
            {
                return _changes;
            }
            set
            {
                _changes = value;
                NotifyOfPropertyChange(() => Changes);
            }
        }
		        
        private string _period;
        public string Period
        {
            get
            {
                return _period;
            }
            set
            {
                _period = value;
                NotifyOfPropertyChange(() => Period);
            }
        }
		        
        private string _clockTime;
        public string ClockTime
        {
            get
            {
                return _clockTime;
            }
            set
            {
                _clockTime = value;
                NotifyOfPropertyChange(() => ClockTime);
            }
        }
		        
        private string _returnBarcode;
        public string ReturnBarcode
        {
            get
            {
                return _returnBarcode;
            }
            set
            {
                _returnBarcode = value;
                NotifyOfPropertyChange(() => ReturnBarcode);
            }
        }
		        
        private string _returnInvoice;
        public string ReturnInvoice
        {
            get
            {
                return _returnInvoice;
            }
            set
            {
                _returnInvoice = value;
                NotifyOfPropertyChange(() => ReturnInvoice);
            }
        }
		        
        private string _note;
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
                NotifyOfPropertyChange(() => Note);
            }
        }
				#endregion
		
		#region List use to fetch object for view
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
		        
        public void Recreate()
        {
            
        }
		        
        public void Save()
        {
            
        }
		        
        public void Stop()
        {
            
        }
		        
        public void SearchBarcode()
        {
            
        }
		        
        public void SearchReturnBarcode()
        {
            
        }
		        
        public void EnterReturnBarcode()
        {
            
        }
				#endregion
		
        
        
    }
}
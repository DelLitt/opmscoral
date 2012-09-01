
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSClient.ViewModels.Sale
{
    public interface IPurchaseOrderViewModel : IScreenNode
    {
        #region Fields
		                
        string CustomerName
        {
            get;
            set;            
        }
		                
        string Barcode
        {
            get;
            set;            
        }
		                
        string InvoiceNo
        {
            get;
            set;            
        }
		                
        string Employee
        {
            get;
            set;            
        }
		                
        long Discount
        {
            get;
            set;            
        }

        long Payment
        {
            get;
            set;            
        }

        long TotalQuantity
        {
            get;
            set;            
        }
		                
        string Tax
        {
            get;
            set;            
        }

        long Changes
        {
            get;
            set;            
        }
		                
        string Period
        {
            get;
            set;            
        }
		                
        string ClockTime
        {
            get;
            set;            
        }
		                
        string ReturnBarcode
        {
            get;
            set;            
        }
		                
        string ReturnInvoice
        {
            get;
            set;            
        }
		                
        string Note
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Recreate();
        
		        
        void Save();
        
		        
        void Stop();
        
		        
        void SearchBarcode();
        
		        
        void SearchReturnBarcode();
        
		        
        void EnterReturnBarcode();
        
			#endregion
    }
}
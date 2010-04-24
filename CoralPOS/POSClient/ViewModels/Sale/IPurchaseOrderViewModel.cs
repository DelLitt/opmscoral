
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

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
		                
        string Discount
        {
            get;
            set;            
        }
		                
        string Payment
        {
            get;
            set;            
        }
		                
        string TotalQuantity
        {
            get;
            set;            
        }
		                
        string Tax
        {
            get;
            set;            
        }
		                
        string Changes
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
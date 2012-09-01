
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.ProductMaster
{
    public interface IProductMasterSummaryViewModel : IScreenNode
    {
        #region Fields
		                
        string ProductName
        {
            get;
            set;            
        }
		                
        ProductType ProductType
        {
            get;
            set;            
        }
		                
        Category Category
        {
            get;
            set;            
        }
		                
        string textBox5
        {
            get;
            set;            
        }
		                
        string ProductMasterId
        {
            get;
            set;            
        }
        
        IList ProductColors { get; set; }
        IList ProductSizes { get; set; }
        #endregion
		
		#region Methods
		        
        void Help();
        
		        
        void ProductBack();
        
		        
        void ProductSaveConfirm();
        
		        
        void Stop();
        
		        
        void button4();
        
		        
        void button5();
        
		        
        void button7();
        
		        
        void button8();
        
		        
        void button9();
        
		        
        void button10();
        
		        
        void button11();
        
		        
        void button12();
        
		        
        void MinorDetailEnter();
        
			#endregion
    }
}
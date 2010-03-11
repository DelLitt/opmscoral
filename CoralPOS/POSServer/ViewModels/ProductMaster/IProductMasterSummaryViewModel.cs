
			 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

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
		                
        string ProductType
        {
            get;
            set;            
        }
		                
        string Category
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
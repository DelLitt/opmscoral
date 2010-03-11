
			 
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
		                
        public string ProductName
        {
            get;
            set;            
        }
		                
        public string ProductType
        {
            get;
            set;            
        }
		                
        public string Category
        {
            get;
            set;            
        }
		                
        public string textBox5
        {
            get;
            set;            
        }
		                
        public string ProductMasterId
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        public void Help();
        
		        
        public void ProductBack();
        
		        
        public void ProductSaveConfirm();
        
		        
        public void Stop();
        
		        
        public void button4();
        
		        
        public void button5();
        
		        
        public void button7();
        
		        
        public void button8();
        
		        
        public void button9();
        
		        
        public void button10();
        
		        
        public void button11();
        
		        
        public void button12();
        
		        
        public void MinorDetailEnter();
        
			#endregion
    }
}
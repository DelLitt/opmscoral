
			 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Stock.StockIn
{
    public interface IStockInViewModel : IScreenNode
    {
        #region Fields
		                
        public string WholeSalePrice
        {
            get;
            set;            
        }
		                
        public string Price
        {
            get;
            set;            
        }
		                
        public string InputPrice
        {
            get;
            set;            
        }
		                
        public string textBox4
        {
            get;
            set;            
        }
		                
        public string ProductMaster
        {
            get;
            set;            
        }
		                
        public string Description
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        public void Help();
        
		        
        public void Recreate();
        
		        
        public void Save();
        
		        
        public void Stop();
        
		        
        public void CreateNewProductMaster();
        
		        
        public void EditProductMaster();
        
			#endregion
    }
}
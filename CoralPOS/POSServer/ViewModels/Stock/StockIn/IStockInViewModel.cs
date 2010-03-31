
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Stock.StockIn
{
    public interface IStockInViewModel : IScreenNode
    {
        #region Fields
		                
        string WholeSalePrice
        {
            get;
            set;            
        }
		                
        string Price
        {
            get;
            set;            
        }
		                
        string InputPrice
        {
            get;
            set;            
        }
		                
        string textBox4
        {
            get;
            set;            
        }

        CoralPOS.Models.ProductMaster ProductMaster
        {
            get;
            set;            
        }
		                
        string Description
        {
            get;
            set;            
        }
        string ProductNameText { get; set; }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Recreate();
        
		        
        void Save();
        
		        
        void Stop();
        
		        
        void CreateNewProductMaster();
        
		        
        void EditProductMaster();
        
			#endregion
    }
}
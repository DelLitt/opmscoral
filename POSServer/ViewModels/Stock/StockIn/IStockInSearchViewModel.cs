
			 
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

namespace POSServer.ViewModels.Stock.StockIn
{
    public interface IStockInSearchViewModel : IScreenNode
    {
        #region Fields
		                
        string textBox1
        {
            get;
            set;            
        }
		                
        string Description
        {
            get;
            set;            
        }
		                
        string textBox2
        {
            get;
            set;            
        }

        string ProductMasterNames { get; set; }
        string ProductTypes { get; set; }
        bool DatePick { get; set; }
        IList CategoryList { get; set; }
        Category SelectedCategory { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        CoralPOS.Models.StockIn SelectedStockIn { get; set; }
        ICategoryLogic CategoryLogic { get; set; }
        IStockInLogic StockInLogic { get; set; }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void ViewDetail();
        
		        
        void Stop();
        
		        
        void Search();
        
			#endregion
    }
}
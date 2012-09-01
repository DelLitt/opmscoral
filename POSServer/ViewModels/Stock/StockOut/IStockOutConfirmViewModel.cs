
			 
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

namespace POSServer.ViewModels.Stock.StockOut
{
    public interface IStockOutConfirmViewModel : IScreenNode
    {
        #region Fields
		                
        string CreateDate
        {
            get;
            set;            
        }
		                
        string Description
        {
            get;
            set;            
        }

        Department Department
        {
            get;
            set;            
        }

        IList StockOutDetails { get; set; }
        IMainPriceLogic MainPriceLogic { get; set; }

        #endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Back();
        
		        
        void SaveConfirm();
        
		        
        void Stop();
        
			#endregion
    }
}
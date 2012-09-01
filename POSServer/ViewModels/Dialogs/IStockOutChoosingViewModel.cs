
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using Caliburn.Micro;
using CoralPOS.Models;

namespace POSServer.ViewModels.Dialogs
{
    public interface IStockOutChoosingViewModel : IScreenNode,IScreen
    {
        #region Fields

        StockIn SelectedStockIn { get; set; }
        DateTime ToDate { get; set; }
        DateTime FromDate { get; set; }
        
        #endregion
		
		#region Methods
		        
        void Close();
        
		        
        void Search();
        
		        
        void Choose();
        
			#endregion

        event EventHandler<StockInChoosingArg> ConfirmEvent;
    }
}
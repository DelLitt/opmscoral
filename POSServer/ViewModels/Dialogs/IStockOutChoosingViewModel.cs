
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;

namespace POSServer.ViewModels.Dialogs
{
    public interface IStockOutChoosingViewModel : IScreenNode,IScreenEx
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
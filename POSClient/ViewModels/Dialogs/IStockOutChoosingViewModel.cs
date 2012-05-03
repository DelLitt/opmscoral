using System;
using AppFrame.Base;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;

namespace POSClient.ViewModels.Dialogs
{
    public interface IStockOutChoosingViewModel : IScreenNode,IScreenEx
    {
        #region Fields

        DepartmentStockIn SelectedStockIn { get; set; }
        DateTime ToDate { get; set; }
        DateTime FromDate { get; set; }
        
        #endregion
		
		#region Methods
		        
        void Close();
        
		        
        void Search();
        
		        
        void Choose();
        
			#endregion

        event EventHandler<DepartmentStockInChoosingArg> ConfirmEvent;
    }
}
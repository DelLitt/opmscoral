using System;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Micro;
using CoralPOS.Models;

namespace POSClient.ViewModels.Dialogs
{
    public interface IStockOutChoosingViewModel : IScreenNode,IScreen
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
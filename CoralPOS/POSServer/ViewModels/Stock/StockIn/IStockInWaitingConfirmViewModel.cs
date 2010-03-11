
			 
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
    public interface IStockInWaitingConfirmViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        public void Help();
        
		        
        public void Unconfirm();
        
		        
        public void Stop();
        
		        
        public void Confirm();
        
		        
        public void Edit();
        
		        
        public void Search();
        
			#endregion
    }
}
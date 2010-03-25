
			 
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
    public interface IStockInConfirmViewModel : IScreenNode
    {
        #region Fields

        DateTime CreateDate
        {
            get;
            set;            
        }
		                
        string Description
        {
            get;
            set;            
        }

        IList StockInDetailList { get; set; }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Back();
        
		        
        void SaveConfirm();
        
		        
        void Stop();
        
			#endregion
    }
}
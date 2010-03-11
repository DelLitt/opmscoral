
			 
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
    public interface IStockInConfirmViewModel : IScreenNode
    {
        #region Fields
		                
        public string textBox4
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
        
		        
        public void Back();
        
		        
        public void SaveConfirm();
        
		        
        public void Stop();
        
			#endregion
    }
}

			 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Stock.StockOut
{
    public interface IStockOutSearchViewModel : IScreenNode
    {
        #region Fields
		                
        public string Description
        {
            get;
            set;            
        }
		                
        public string textBox2
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        public void Help();
        
		        
        public void ViewDetail();
        
		        
        public void Stop();
        
		        
        public void Search();
        
			#endregion
    }
}
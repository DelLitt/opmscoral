
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels.Stock.StockOut
{
    public interface IDepartmentStockOutSearchViewModel : IScreenNode
    {
        #region Fields
		                
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
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void ViewDetail();
        
		        
        void Stop();
        
		        
        void Search();
        
			#endregion
    }
}
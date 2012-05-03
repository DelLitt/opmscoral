
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Report
{
    public interface IReportsMainViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void StockIn();
        
		        
        void StockInList();
        
		        
        void StockInBackList();
        
		        
        void StockInByExcel();
        
		        
        void button1();
        
			#endregion
    }
}
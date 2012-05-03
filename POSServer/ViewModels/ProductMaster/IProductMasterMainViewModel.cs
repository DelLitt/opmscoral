
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.ProductMaster
{
    public interface IProductMasterMainViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void CreateProductMaster();
        
		        
        void CreateProductMasterByTemplate();
        
		        
        void ProductMasterList();
        
		        
        void StockInByExcel();
        
		        
        void ExtendFunctions();
        
			#endregion
    }
}
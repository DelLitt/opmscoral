
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

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
        
		        
        void PriceUpdate();
        
		        
        void ExtendFunctions();
        
			#endregion
    }
}
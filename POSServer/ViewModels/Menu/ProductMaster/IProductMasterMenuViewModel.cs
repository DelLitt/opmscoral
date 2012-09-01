
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.Menu.ProductMaster
{
    public interface IProductMasterMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void BackToParent();
        
		        
        void Back();
        
		        
        void CreateProductMaster();
        
		        
        void CreateProductMasterByTemplate();
        
		        
        void ProductMasterList();


        void UpdateProductMasterPrice();
        
		        
        void ExtendFunctions();
        
			#endregion
    }
}
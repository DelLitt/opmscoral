
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSClient.ViewModels.Menu.Sale
{
    public interface ISaleMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void BackToParent();
        
		        
        void Back();
        
		        
        void CreatePurchaseOrder();
        
		        
        void PurchaseOrderList();
        
		        
        void ProductMasterList();
        
		        
        void PriceList();
        
			#endregion
    }
}
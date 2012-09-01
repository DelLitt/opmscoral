
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSClient.ViewModels.Sale
{
    public interface ISaleMainViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods

        void CreatePurchaseOrder();


        void PurchaseOrderList();


        void ProductMasterList();


        void PriceList();
        
		        
        #endregion
    }
}
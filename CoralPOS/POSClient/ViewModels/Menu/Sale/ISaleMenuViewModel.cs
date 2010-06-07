
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

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
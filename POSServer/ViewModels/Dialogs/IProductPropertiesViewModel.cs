
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.Dialogs
{
    public interface IProductPropertiesViewModel : IScreenNode,IScreenEx
    {
        #region Fields
        string ProductName { get; set; }
        IList ProductColorList { get; set; }
        IList ProductSizeList { get; set; }
        IList ExtraProductColorList { get; set; }
        IList ExtraProductSizeList { get; set; }
        IList SelectedProductColors { get; set; }
        IList SelectedProductSizes { get; set; }
        IList ExtraSelectedProductColors { get; set; }
        IList ExtraSelectedProductSizes { get; set; }
        IExProductColorLogic ProductColorLogic { get; set; }
        IExProductSizeLogic ProductSizeLogic { get; set; }
        IProductLogic ProductLogic { get; set; }
        event EventHandler<ProductEventArgs> ConfirmEvent;
			#endregion
		
		#region Methods

        void Confirm();

        void Cancel();

        void Setup();
			#endregion
    }
}
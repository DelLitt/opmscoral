
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using Caliburn.Micro;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.Dialogs
{
	public interface IProductPropertiesViewModel : IScreenNode,IScreen
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
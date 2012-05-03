
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSClient.ViewModels.Stock.StockIn
{
	public interface IDepartmentStockInConfirmViewModel : IScreenNode
	{
		#region Fields
						
		string textBox4
		{
			get;
			set;            
		}
						
		string Description
		{
			get;
			set;            
		}
			#endregion
		
		#region Methods
				
		void Help();
		
				
		void Back();
		
				
		void SaveConfirm();
		
				
		void Stop();
		
			#endregion
	}
}
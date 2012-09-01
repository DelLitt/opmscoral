
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Micro;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.ProductMaster
{
	public interface IProductMasterPriceUpdateViewModel : IScreenNode
	{
        IMainPriceLogic MainPriceLogic { get; set; }
        
        
        #region Fields
		                
		string ProductName
		{
			get;
			set;            
		}
		                
		string ProductMasterId
		{
			get;
			set;            
		}
		                
		string WholeSalePrice
		{
			get;
			set;            
		}
		                
		string Price
		{
			get;
			set;            
		}
			#endregion
		
		#region Methods
		        
		void Help();
		
		        
		void Save();
		
		        
		void Edit();
		
		        
		void Stop();
		
		        
		void Cancel();
		
		        
		void ProductMasterSearch();
		
		        
		void button1();
		
			#endregion
	}
}

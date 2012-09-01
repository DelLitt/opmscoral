
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.Stock.StockOut
{
    public interface IStockOutSpecificViewModel : IScreenNode
    {
        #region Fields

        DateTime CreateDate
        {
            get;
            set;            
        }
		                
        string ProductName1
        {
            get;
            set;            
        }
		                
        string Description1
        {
            get;
            set;            
        }
		                
        string Barcode
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Recreate();
        
		        
        void Save();
        
		        
        void Stop();
        
		        
        void CreateByBlock();
        
		        
        void CreateByFile();
        
		        
        void FixQuantityByAvailable();
        
		        
        void Create();
        
			#endregion
    }
}
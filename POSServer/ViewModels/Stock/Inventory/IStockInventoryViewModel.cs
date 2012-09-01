
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.Stock.Inventory
{
    public interface IStockInventoryViewModel : IScreenNode
    {
        #region Fields
		                
        string CreateDate
        {
            get;
            set;            
        }
		                
        string Barcode
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
        
		        
        void TempLoad();
        
		        
        void TempSave();
        
		        
        void Stop();
        
		        
        void button1();
        
		        
        void SaveResult();
        
		        
        void Delete();
        
		        
        void Reset();
        
		        
        void InputByFile();
        
			#endregion
    }
}
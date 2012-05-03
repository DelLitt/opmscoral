
			 
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
    public interface IStockInventoryProcessingViewModel : IScreenNode
    {
        #region Fields
		                
        string Description
        {
            get;
            set;            
        }
		                
        string LogicalSum
        {
            get;
            set;            
        }
		                
        string RealSum
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Stop();
        
		        
        void ExcelExport();
        
		        
        void ProcessResult();
        
		        
        void Delete();
        
		        
        void Reset();
        
		        
        void SearchEvaluation();
        
		        
        void Fixing();
        
			#endregion
    }
}
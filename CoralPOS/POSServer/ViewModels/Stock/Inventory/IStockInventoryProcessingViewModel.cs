
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Stock.Inventory
{
    public interface IStockInventoryProcessingViewModel : IScreenNode
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
        
		        
        void TempLoad();
        
		        
        void TempSave();
        
		        
        void Stop();
        
		        
        void button1();
        
		        
        void SaveResult();
        
		        
        void Delete();
        
		        
        void Reset();
        
		        
        void InputByFile();
        
		        
        void ChangeDepartmentForEvaluate();
        
			#endregion
    }
}
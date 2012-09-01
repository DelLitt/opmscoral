
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.ProductMaster
{
    public interface IExProductColorViewModel : IScreenNode
    {
        #region Fields
        
        IExProductColorLogic ProductColorLogic { get; set; }
        IList ProductColorList { get; set; }

        ExProductColor SelectedProductColor { get; set; }
        bool IsCreateOrUpdate { get; set; }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Delete();
        
		        
        void Edit();
        
		        
        void Stop();
        
		        
        void Create();

        void Save();
			#endregion
    }
}
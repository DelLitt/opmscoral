
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;

namespace POSServer.ViewModels.ProductMaster
{
    public interface IProductMasterViewModel : IScreenNode
    {
        #region Fields
		                
        string ProductName
        {
            get;
            set;            
        }
		                
        ProductType ProductType
        {
            get;
            set;            
        }

        Category Category
        {
            get;
            set;            
        }

        IList ProductColors { get; set; }
        IList ProductSizes { get; set; }

        Collection<ExProductColor> SelectedProductColors
        {
            get;
        }

        IList SelectedProductSizes
        {
            get;
            set;
        }
        
        string ProductMasterId
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void ProductRecreate();
        
		        
        void ProductSave();
        
		        
        void Stop();
        
		        
        void ProductImageSelect();
        
		        
        void NewType();
        
		        
        void NewCategory();
        
		        
        void ColorAddAll();
        
		        
        void ColorAdd();
        
		        
        void ColorRemove();
        
		        
        void ColorRemoveAll();
        
		        
        void SizeAddAll();
        
		        
        void SizeAdd();
        
		        
        void SizeRemove();
        
		        
        void SizeRemoveAll();
        
		        
        void MinorDetailEnter();
        
		        
        void NewColor();
        
		        
        void NewSize();
        
			#endregion
    }
}
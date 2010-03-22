			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.DataLayer;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;


namespace POSServer.ViewModels.Dialogs
{
    
    public class ProductPropertiesViewModel : PosViewModel,IProductPropertiesViewModel  
    {

        private IShellViewModel _startViewModel;
        private IList _productColorList;

        private IList _productSizeList;

        private IList _extraProductColorList;

        private IList _extraProductSizeList;

        private IList _selectedProductColors;

        private IList _selectedProductSizes;

        private IList _extraSelectedProductColors;

        private IList _extraSelectedProductSizes;

        public ProductPropertiesViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
				#endregion
		
		#region Methods

        public IList ProductColorList
        {
            get { return _productColorList; }
            set { _productColorList = value; 
                NotifyOfPropertyChange(()=>ProductColorList);
            }
        }

        public IList ProductSizeList
        {
            get { return _productSizeList; }
            set { _productSizeList = value;
            NotifyOfPropertyChange(() => ProductSizeList);
            }
        }

        public IList ExtraProductColorList
        {
            get { return _extraProductColorList; }
            set { _extraProductColorList = value;
            NotifyOfPropertyChange(() => ExtraProductColorList);
            }
        }

        public IList ExtraProductSizeList
        {
            get { return _extraProductSizeList; }
            set { _extraProductSizeList = value;
            NotifyOfPropertyChange(() => ExtraProductSizeList);
            }
        }

        public IList SelectedProductColors
        {
            get { return _selectedProductColors; }
            set { _selectedProductColors = value; }
        }

        public IList SelectedProductSizes
        {
            get { return _selectedProductSizes; }
            set { _selectedProductSizes = value; }
        }

        public IList ExtraSelectedProductColors
        {
            get { return _extraSelectedProductColors; }
            set { _extraSelectedProductColors = value; }
        }

        public IList ExtraSelectedProductSizes
        {
            get { return _extraSelectedProductSizes; }
            set { _extraSelectedProductSizes = value; }
        }

        public IExProductColorLogic ProductColorLogic { get; set; }
        public IExProductSizeLogic ProductSizeLogic { get; set; }
        public IProductLogic ProductLogic { get; set; }

        public override void Initialize()
        {
            string productName = Flow.Session.Get(FlowConstants.PRODUCT_NAME) as string;
            IList colors =ProductLogic.GetColorsWithProductName(productName);
            IList sizes = ProductLogic.GetSizesWithProductName(productName);
            IList<ExProductColor> extraColors = ProductColorLogic.FindAll(new ObjectCriteria<ExProductColor>());
            IList<ExProductSize> extraSizes = ProductSizeLogic.FindAll(new ObjectCriteria<ExProductSize>());
            ProductColorList = colors;
            ProductSizeList = sizes;
            ExtraProductColorList = extraColors as IList;
            ExtraProductSizeList = extraSizes as IList;
        }

        public void Confirm()
        {
            
        }

        public void Cancel()
        {
            
        }

        #endregion
		
        
        
    }
}
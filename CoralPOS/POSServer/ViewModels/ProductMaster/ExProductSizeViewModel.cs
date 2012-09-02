			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Utils;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;


namespace POSServer.ViewModels.ProductMaster
{
    //[PerRequest(typeof(IExProductSizeViewModel))]
    public class ExProductSizeViewModel : PosViewModel
    {

        private IShellViewModel _startViewModel;
        public ExProductSizeViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
		
		#region Fields
		        
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
		        
        private string _sizeName;
        public string SizeName
        {
            get
            {
                return _sizeName;
            }
            set
            {
                _sizeName = value;
                NotifyOfPropertyChange(() => SizeName);
            }
        }
		        
        private string _sizeId;
        public string SizeId
        {
            get
            {
                return _sizeId;
            }
            set
            {
                _sizeId = value;
                NotifyOfPropertyChange(() => SizeId);
            }
        }

        public ExProductSize SelectedProductSize
        {
            get; set;
        }

        public IExProductSizeLogic ProductSizeLogic
        {
            get; set;
        }

        #endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _productSizeList;
        public IList ProductSizeList
        {
            get
            {
                return _productSizeList;
            }
            set
            {
                _productSizeList = value;
                NotifyOfPropertyChange(() => ProductSizeList);
            }
        }
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void Delete()
        {
            IList list = new ArrayList(_productSizeList);
            ObjectUtility.RemoveFromList(list, SelectedProductSize, "SizeName");
            ProductSizeList = list;
        }
		        
        public void Edit()
        {
            
        }
		        
        public void Stop()
        {
            Flow.End(); 
        }
		        
        public void Create()
        {
            IList list = new ArrayList(_productSizeList);
            list.Add(new ExProductSize
            {
                SizeName = "NONAME"
            });
            ProductSizeList = list;
        }

        public void Save()
        {
            ProductSizeLogic.Update(ProductSizeList);
            SetBackToParentFlow(FlowConstants.PRODUCT_SIZE_LIST, ProductSizeList);
            GoToNextNode();
        }

        protected override void OnInitialize()
        {
            ProductSizeLogic.LoadDefinition(Flow.Session);
            IList list = null;
            list = Flow.Session.Get(FlowConstants.PRODUCT_SIZE_LIST) as IList;
            //if (list == null) list = new ArrayList();
            ProductSizeList = list;
            SelectedProductSize = new ExProductSize();
        }

        #endregion
		
        
        
    }
}
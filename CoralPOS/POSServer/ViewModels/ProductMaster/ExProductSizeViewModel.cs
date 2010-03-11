			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;



namespace POSServer.ViewModels.ProductMaster
{
    [PerRequest(typeof(IExProductSizeViewModel))]
    public class ExProductSizeViewModel : PosViewModel,IExProductSizeViewModel  
    {

        private IShellViewModel _startViewModel;
        public ExProductSizeViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
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
            
        }
		        
        public void Edit()
        {
            
        }
		        
        public void Stop()
        {
            
        }
		        
        public void Create()
        {
            
        }
				#endregion
		
        
        
    }
}
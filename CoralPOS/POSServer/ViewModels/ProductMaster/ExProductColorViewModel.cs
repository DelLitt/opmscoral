			 

			 

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
    [PerRequest(typeof(IExProductColorViewModel))]
    public class ExProductColorViewModel : PosViewModel,IExProductColorViewModel  
    {

        private IShellViewModel _startViewModel;
        public ExProductColorViewModel(IShellViewModel startViewModel)
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
		        
        private string _colorName;
        public string ColorName
        {
            get
            {
                return _colorName;
            }
            set
            {
                _colorName = value;
                NotifyOfPropertyChange(() => ColorName);
            }
        }
		        
        private string _colorId;
        public string ColorId
        {
            get
            {
                return _colorId;
            }
            set
            {
                _colorId = value;
                NotifyOfPropertyChange(() => ColorId);
            }
        }
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _productColorList;
        public IList ProductColorList
        {
            get
            {
                return _productColorList;
            }
            set
            {
                _productColorList = value;
                NotifyOfPropertyChange(() => ProductColorList);
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
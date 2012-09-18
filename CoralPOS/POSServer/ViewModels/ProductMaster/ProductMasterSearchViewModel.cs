			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.Extensions;
using AppFrame.Utils;
using AppFrame.Validation;
using AppFrame.WPF.ValidationAttributes;
using Caliburn.Micro;
using POSServer.ViewModels.Menu.ProductMaster;

namespace POSServer.ViewModels.ProductMaster
{
	//[AttachMenuAndMainScreen(typeof(ProductMasterMenuViewModel), typeof(ProductMasterMainViewModel))]
    [PerRequest]
	public class ProductMasterSearchViewModel : PosViewModel
	{

		private IShellViewModel _startViewModel;
		public ProductMasterSearchViewModel()
		{
			_startViewModel = ShellViewModel.Current; 
		}
		
		#region Fields
				
		private string _productName;
		public string ProductName
		{
			get
			{
				return _productName;
			}
			set
			{
				_productName = value;
				NotifyOfPropertyChange(() => ProductName);
			}
		}
				
		private string _productMasterId;
		public string ProductMasterId
		{
			get
			{
				return _productMasterId;
			}
			set
			{
				_productMasterId = value;
				NotifyOfPropertyChange(() => ProductMasterId);
			}
		}
				#endregion
		
		#region List use to fetch object for view
				
		private IList _productTypeList;
		public IList ProductTypeList
		{
			get
			{
				return _productTypeList;
			}
			set
			{
				_productTypeList = value;
				NotifyOfPropertyChange(() => ProductTypeList);
			}
		}
				
		private IList _categoryList;
		public IList CategoryList
		{
			get
			{
				return _categoryList;
			}
			set
			{
				_categoryList = value;
				NotifyOfPropertyChange(() => CategoryList);
			}
		}
				#endregion
		
		#region List which just using in Data Grid
				
		private IList _productMasterList;
		public IList ProductMasterList
		{
			get
			{
				return _productMasterList;
			}
			set
			{
				_productMasterList = value;
				NotifyOfPropertyChange(() => ProductMasterList);
			}
		}
				#endregion
		
		#region Methods
				
		public void Help()
		{
			
		}
				
		public void Save()
		{
			
		}
				
		public void Edit()
		{
			
		}
				
		public void Stop()
		{
			
		}
				
		public void Cancel()
		{
			
		}
				
		public void ProductMasterSearch()
		{
			
		}
				#endregion
		
		
		
	}
}
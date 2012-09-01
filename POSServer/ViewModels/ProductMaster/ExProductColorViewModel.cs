			 

			 

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
	//[PerRequest(typeof(IExProductColorViewModel))]
	public class ExProductColorViewModel : PosViewModel,IExProductColorViewModel  
	{

		private IShellViewModel _startViewModel;
		private ExProductColor _selectedProductColor;

		private bool _isCreateOrUpdate;

		public ExProductColorViewModel()
		{
			_startViewModel = ShellViewModel.Current;
		}
		
		#region Fields

		public IExProductColorLogic ProductColorLogic
		{
			get; set;
		}

		public ExProductColor SelectedProductColor
		{
			get { return _selectedProductColor; }
			set
			{
				_selectedProductColor = value;
				NotifyOfPropertyChange(()=>SelectedProductColor);
			}
		}
		
		public bool IsCreateOrUpdate
		{
			get { return _isCreateOrUpdate; }
			set
			{
				_isCreateOrUpdate = value;
				NotifyOfPropertyChange(()=>IsCreateOrUpdate);
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
			IList list = new ArrayList(_productColorList);
			ObjectUtility.RemoveFromList(list, SelectedProductColor, "ColorName");

			ProductColorList = list;
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
			IList list= new ArrayList(_productColorList);
			list.Add(new ExProductColor
						 {
							 ColorName = "NONAME"
						 });
			ProductColorList = list;
		}

		public void Save()
		{
			ProductColorLogic.Update(ProductColorList);
			SetBackToParentFlow(FlowConstants.PRODUCT_COLOR_LIST,ProductColorList);
			GoToNextNode();
		}

		protected override void OnInitialize()
		{
			ProductColorLogic.LoadProductColorDefinition(Flow.Session);
			IList list = null;
			list = Flow.Session.Get(FlowConstants.PRODUCT_COLOR_LIST) as IList;
			//if (list == null) list = new ArrayList();
			ProductColorList = list;
			SelectedProductColor = new ExProductColor();
			IsCreateOrUpdate = false;
		}

		#endregion
		
		
		
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Micro;


using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;


namespace POSServer.ViewModels.ProductMaster
{
	//[PerRequest(typeof(IProductMasterSummaryViewModel))]
	public class ProductMasterSummaryViewModel : PosViewModel
	{

		private IShellViewModel _startViewModel;
		private CoralPOS.Models.ProductMaster _productMaster;

		private IList _productColors;

		private IList _productSizes;

		public ProductMasterSummaryViewModel()
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

		private ProductType _productType;
		public ProductType ProductType
		{
			get
			{
				return _productType;
			}
			set
			{
				_productType = value;
				NotifyOfPropertyChange(() => ProductType);
			}
		}
				
		private Category _category;
		public Category Category
		{
			get
			{
				return _category;
			}
			set
			{
				_category = value;
				NotifyOfPropertyChange(() => Category);
			}
		}

		public string textBox5
		{
			get; set;
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

		public CoralPOS.Models.ProductMaster ProductMaster
		{
			get { return _productMaster; }
			set { _productMaster = value; 
				NotifyOfPropertyChange(()=>ProductMaster);
			}
		}

		public IList ProductColors
		{
			get { return _productColors; }
			set { _productColors = value;
			NotifyOfPropertyChange(() => ProductColors);
			}
		}

		public IList ProductSizes
		{
			get { return _productSizes; }
			set { _productSizes = value;
			NotifyOfPropertyChange(() => ProductSizes);
			}
		}

		

		#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
				#endregion
		
		#region Methods
				
		public void Help()
		{
			
		}
				
		public void ProductBack()
		{
			Flow.Back();
		}
				
		public void ProductSaveConfirm()
		{
			GoToNextNode();
		}
				
		public void Stop()
		{
			
		}
				
		public void button4()
		{
			
		}
				
		public void button5()
		{
			
		}
				
		public void button7()
		{
			
		}
				
		public void button8()
		{
			
		}
				
		public void button9()
		{
			
		}
				
		public void button10()
		{
			
		}
				
		public void button11()
		{
			
		}
				
		public void button12()
		{
			
		}
				
		public void MinorDetailEnter()
		{
			
		}

		protected override void OnInitialize()
		{
			CoralPOS.Models.ProductMaster master = Flow.Session.Get(FlowConstants.SAVE_PRODUCT_MASTER) as CoralPOS.Models.ProductMaster;

			ProductMaster = master;
			Category = master.Category;
			ProductType = master.ProductType;
			ProductColors = Flow.Session.Get(FlowConstants.SAVE_PRODUCT_COLORS_LIST) as IList;
			ProductSizes = Flow.Session.Get(FlowConstants.SAVE_PRODUCT_SIZES_LIST) as IList;
			//Flow.Session.OnFlowChanged += new EventHandler(Session_OnFlowChanged);
		}

		#endregion
		
		
		
	}
}
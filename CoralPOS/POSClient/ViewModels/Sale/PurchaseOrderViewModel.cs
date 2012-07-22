using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.Invocation;
using AppFrame.Utils;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using AppFrame.Extensions;

using POSClient.BusinessLogic.Implement;
using POSClient.Common;
using POSClient.ViewModels.Menu;


namespace POSClient.ViewModels.Sale
{
	[AttachMenuAndMainScreen(typeof(IMainMenuViewModel),typeof(IMainViewModel))]
	public class PurchaseOrderViewModel : PosViewModel,IPurchaseOrderViewModel  
	{

		private IShellViewModel _startViewModel;
		public PurchaseOrderViewModel()
		{
			_startViewModel = ShellViewModel.Current;
		}
		
		#region Fields

		private DepartmentPurchaseOrder _departmentPurchaseOrder;
		public DepartmentPurchaseOrder DepartmentPurchaseOrder
		{
			get
			{
				return _departmentPurchaseOrder;  
			}
			set
			{
				_departmentPurchaseOrder = value;
				NotifyOfPropertyChange(()=>DepartmentPurchaseOrder);
			}
		}
		private string _customerName;
		public string CustomerName
		{
			get
			{
				return _customerName;
			}
			set
			{
				_customerName = value;
				NotifyOfPropertyChange(() => CustomerName);
			}
		}
				
		private string _barcode;
		public string Barcode
		{
			get
			{
				return _barcode;
			}
			set
			{
				_barcode = value;
				NotifyOfPropertyChange(() => Barcode);
			}
		}
				
		private string _invoiceNo;
		public string InvoiceNo
		{
			get
			{
				return _invoiceNo;
			}
			set
			{
				_invoiceNo = value;
				NotifyOfPropertyChange(() => InvoiceNo);
			}
		}
				
		private string _employee;
		public string Employee
		{
			get
			{
				return _employee;
			}
			set
			{
				_employee = value;
				NotifyOfPropertyChange(() => Employee);
			}
		}

		private long _discount;
		public long Discount
		{
			get
			{
				return _discount;
			}
			set
			{
				_discount = value;
				NotifyOfPropertyChange(() => Discount);
			}
		}

		private long _payment;
		public long Payment
		{
			get
			{
				return _payment;
			}
			set
			{
				_payment = value;
				NotifyOfPropertyChange(() => Payment);
			}
		}
				
		private long _totalQuantity;
		public long TotalQuantity
		{
			get
			{
				return _totalQuantity;
			}
			set
			{
				_totalQuantity = value;
				NotifyOfPropertyChange(() => TotalQuantity);
			}
		}
				
		private string _tax;
		public string Tax
		{
			get
			{
				return _tax;
			}
			set
			{
				_tax = value;
				NotifyOfPropertyChange(() => Tax);
			}
		}

		private long _changes;
		public long Changes
		{
			get
			{
				return _changes;
			}
			set
			{
				_changes = value;
				NotifyOfPropertyChange(() => Changes);
			}
		}
				
		private string _period;
		public string Period
		{
			get
			{
				return _period;
			}
			set
			{
				_period = value;
				NotifyOfPropertyChange(() => Period);
			}
		}
				
		private string _clockTime;
		public string ClockTime
		{
			get
			{
				return _clockTime;
			}
			set
			{
				_clockTime = value;
				NotifyOfPropertyChange(() => ClockTime);
			}
		}
				
		private string _returnBarcode;
		public string ReturnBarcode
		{
			get
			{
				return _returnBarcode;
			}
			set
			{
				_returnBarcode = value;
				NotifyOfPropertyChange(() => ReturnBarcode);
			}
		}
				
		private string _returnInvoice;
		public string ReturnInvoice
		{
			get
			{
				return _returnInvoice;
			}
			set
			{
				_returnInvoice = value;
				NotifyOfPropertyChange(() => ReturnInvoice);
			}
		}
				
		private string _note;
		public string Note
		{
			get
			{
				return _note;
			}
			set
			{
				_note = value;
				NotifyOfPropertyChange(() => Note);
			}
		}

		public IDepartmentPurchaseOrderLogic DepartmentPurchaseOrderLogic { get; set; }
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
				
		private IList _purchaseOrderDetails;
		public IList PurchaseOrderDetails
		{
			get
			{
				return _purchaseOrderDetails;
			}
			set
			{
				_purchaseOrderDetails = value;
				NotifyOfPropertyChange(() => PurchaseOrderDetails);
			}
		}
				#endregion
		
		#region Methods
				
		public void Help()
		{
			
		}
				
		public void Recreate()
		{
			
		}
				
		public void Save()
		{
			DepartmentPurchaseOrder.DepartmentPurchaseOrderDetails = ObjectConverter.ConvertTo<DepartmentPurchaseOrderDetail>(PurchaseOrderDetails);
			DepartmentPurchaseOrder.PurchasePrice = TotalQuantity;
			DepartmentPurchaseOrder.PurchaseDescription = CreateDescription();
			DepartmentPurchaseOrder.PurchaseQuantity = CreateQuantity();
			if(Changes < 0 )
			{
				MessageBox.Show(" So tien tra chua du");
				return;
			}
			BackgroundTask task = new BackgroundTask(() => DepartmentPurchaseOrderLogic.Add(DepartmentPurchaseOrder));
			task.Completed += task_Completed;
			StartWaitingScreen(0);
			task.Start(DepartmentPurchaseOrder);
		}

		void task_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			StopWaitingScreen(0);
			if(this.Flow is ChildFlow)
			{
				((ChildFlow) this.Flow).IsRepeated = true;
				GoToNextNode();
			}
		}

		private long CreateQuantity()
		{
			long amount = 0;
			foreach (var detail in PurchaseOrderDetails.OfType<DepartmentPurchaseOrderDetail>())
			{
				amount += detail.Quantity;
			}
			return amount;
		}

		private string CreateDescription()
		{
			string description = "";
			foreach(var purchaseOrderDetail in PurchaseOrderDetails.OfType<DepartmentPurchaseOrderDetail>())
			{
				description = purchaseOrderDetail.ProductMaster.ProductName + ":" +
							  purchaseOrderDetail.Quantity.ToString() + Environment.NewLine;
			}
			return description;
		}

		public void Stop()
		{
			GoToNextNode();
		}
				
		public void SearchBarcode()
		{
			MessageBox.Show("SearchBarcode"); 
		}
				
		public void SearchReturnBarcode()
		{
			MessageBox.Show("SearchReturnBarcode");
		}
				
		public void EnterReturnBarcode()
		{
			MessageBox.Show("EnterReturnBarcode");
		}

		public void ProcessBarcode()
		{
			this.CatchExecute(()=>LoadBarcode());
			
		}

		private object LoadBarcode()
		{
			if (ObjectUtility.LengthEqual(Barcode, 12))
			{
				IEnumerable enumerable = DepartmentPurchaseOrderLogic.ProcessBarcode(Barcode);
				IEnumerator enumerator = enumerable.GetEnumerator();
				enumerator.MoveNext();
				Product product = (Product)enumerator.Current;

				DepartmentPurchaseOrderDetail detail = new DepartmentPurchaseOrderDetail
				{
					DelFlg = 0,
					CreateDate = DateTime.Now,
					CreateId = "admin",
					UpdateDate = DateTime.Now,
					UpdateId = "admin",
					ExclusiveKey = 1,
					Product = product,
					ProductMaster = product.ProductMaster,
					DepartmentPurchaseOrder = DepartmentPurchaseOrder,
					Quantity = 1
				};

				if (product.AdhocCase > 0)
					detail.AdhocCase = product.AdhocCase;
				long maxId = 0;
				if (PurchaseOrderDetails.Count > 0)
				{
					 maxId = PurchaseOrderDetails.OfType<DepartmentPurchaseOrderDetail>().Max(
						det => det.DepartmentPurchaseOrderDetailPK.PurchaseOrderDetailId);
				}
				DepartmentPurchaseOrderDetailPK pk = new DepartmentPurchaseOrderDetailPK
				{
					DepartmentId = 1,
					PurchaseOrderDetailId = ++maxId,
					PurchaseOrderId = DepartmentPurchaseOrder.DepartmentPurchaseOrderPK.PurchaseOrderId
				};
				detail.DepartmentPurchaseOrderDetailPK = pk;
				var detailList = new ArrayList(PurchaseOrderDetails);
				DepartmentPurchaseOrderDetail current =
					detailList.OfType<DepartmentPurchaseOrderDetail>().FirstOrDefault(
						det => det.Product.ProductId.Equals(detail.Product.ProductId));

				if (current != null)
				{
					current.Quantity += 1;
				}
				else
				{
					enumerator.MoveNext();
					detail.Price = ((MainPrice)enumerator.Current).Price;
					detailList.Add(detail);
				}

				PurchaseOrderDetails = detailList;
				CalculatePrice();
				Barcode = "";

			}
			return null;
		}

		private void CalculatePrice()
		{
			long amount = 0;
			foreach (DepartmentPurchaseOrderDetail detail in PurchaseOrderDetails)
			{
				amount += detail.Price*detail.Quantity;
			}
			TotalQuantity = amount;
			CalculateCharge();
		}

		protected override void OnInitialize()
		{
			this.DepartmentPurchaseOrder = Flow.Session.Get(FlowDefinition.PURCHASE_ORDER) as DepartmentPurchaseOrder;
			if(DepartmentPurchaseOrder == null)
			{
				DepartmentPurchaseOrder = CreateNewDepartmentPurchaseOrder();
			}
			PurchaseOrderDetails = new ArrayList();
			TotalQuantity = 0;
			Payment = 0;
			Changes = 0;
			Discount = 0;
			Tax = "10%";
		}

		private DepartmentPurchaseOrder CreateNewDepartmentPurchaseOrder()
		{
			CoralPOS.Models.DepartmentPurchaseOrder order = new DepartmentPurchaseOrder
																{
																	CreateDate = DateTime.Now,
																	CreateId = "admin",
																	UpdateDate = DateTime.Now,
																	UpdateId = "admin",
																	ExclusiveKey = 1,
																	DelFlg = 0,
																};
			DepartmentPurchaseOrderPK pk = new DepartmentPurchaseOrderPK
											   {
												   DepartmentId = 1,
												   PurchaseOrderId = DepartmentPurchaseOrderLogic.FindNextId()
											   };
			order.DepartmentPurchaseOrderPK = pk;
			return order;
		}
		public void CalculateCharge()
		{
			long totalQty = TotalQuantity;
			long payment = Payment;
			long change = Changes;
			long discount = Discount;

			change = ( payment + discount) - totalQty;
			Changes = change;
		}
		#endregion
		
		
		
	}
}
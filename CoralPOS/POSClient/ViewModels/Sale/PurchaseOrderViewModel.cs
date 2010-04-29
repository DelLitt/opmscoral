			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Utils;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using AppFrame.Extensions;
using POSClient.BusinessLogic.Implement;
using POSClient.Common;


namespace POSClient.ViewModels.Sale
{
    public class PurchaseOrderViewModel : PosViewModel,IPurchaseOrderViewModel  
    {

        private IShellViewModel _startViewModel;
        public PurchaseOrderViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
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
		        
        private string _discount;
        public string Discount
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
		        
        private string _payment;
        public string Payment
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
		        
        private string _totalQuantity;
        public string TotalQuantity
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
		        
        private string _changes;
        public string Changes
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
            
        }
		        
        public void Stop()
        {
            Flow.End();
        }
		        
        public void SearchBarcode()
        {
            
        }
		        
        public void SearchReturnBarcode()
        {
            
        }
		        
        public void EnterReturnBarcode()
        {
            
        }

        public void ProcessBarcode(string barCode)
        {
            this.CatchExecute(()=>LoadBarcode(barCode));
            
        }

        private object LoadBarcode(string barCode)
        {
            if (ObjectUtility.LengthEqual(barCode, 12))
            {
                IEnumerable enumerable = DepartmentPurchaseOrderLogic.ProcessBarcode(barCode);
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
                    DepartmentPurchaseOrder = DepartmentPurchaseOrder,
                    Quantity = 1
                };

                long maxId = PurchaseOrderDetails.OfType<DepartmentPurchaseOrderDetail>().Max(
                    det => det.DepartmentPurchaseOrderDetailPK.PurchaseOrderDetailId);

                DepartmentPurchaseOrderDetailPK pk = new DepartmentPurchaseOrderDetailPK
                {
                    DepartmentId = 1,
                    PurchaseOrderDetailId = ++maxId
                };
                detail.DepartmentPurchaseOrderDetailPK = pk;
                var detailList = new ArrayList(PurchaseOrderDetails);
                DepartmentPurchaseOrderDetail current =
                    detailList.OfType<DepartmentPurchaseOrderDetail>().FirstOrDefault(
                        det => det.Product.ProductId.Equals(detail.Product.ProductId));

                if (current != null)
                {
                    current.Quantity += detail.Quantity;
                }
                else
                {
                    enumerator.MoveNext();
                    detail.Price = ((MainPrice)enumerator.Current).Price;
                    detailList.Add(detail);
                }

                PurchaseOrderDetails = detailList;
                CalculatePrice();
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
            DepartmentPurchaseOrder.PurchasePrice = amount;
        }

        public override void Initialize()
        {
            this.DepartmentPurchaseOrder = Flow.Session.Get(FlowDefinition.PURCHASE_ORDER) as DepartmentPurchaseOrder;
            if(DepartmentPurchaseOrder == null)
            {
                DepartmentPurchaseOrder = CreateNewDepartmentPurchaseOrder();
            }
            PurchaseOrderDetails = new ArrayList();
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
                                                   DepartmentId = 1
                                               };
            order.DepartmentPurchaseOrderPK = pk;
            return order;
        }

        #endregion
		
        
        
    }
}
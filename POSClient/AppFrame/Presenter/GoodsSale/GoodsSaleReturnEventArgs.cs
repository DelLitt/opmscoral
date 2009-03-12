using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsSale
{
    public class GoodsSaleReturnEventArgs : BaseEventArgs
    {
        public PurchaseOrderDetail SelectedPurchaseOrderDetail { get; set; }
        public string SearchPurchaseOrderId { get; set;}

        public PurchaseOrder RefPurchaseOrder { get; set; }
        public IList ReturnPurchaseOrderDetails { get; set; }
        public PurchaseOrder NextPurchaseOrder { get; set; }
    }
}

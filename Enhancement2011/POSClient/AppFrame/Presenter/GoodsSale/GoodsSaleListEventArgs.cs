using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsSale
{
    public class GoodsSaleListEventArgs  : BaseEventArgs
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public PurchaseOrderCollection PurchaseOrders { get; set; }
        public ObjectCriteria PurchaseOrderSearchCriteria { get; set; }
        public PurchaseOrder SelectedOrder { get; set; }
        public IList PurchaseOrderViewList { get; set; }
    }
}

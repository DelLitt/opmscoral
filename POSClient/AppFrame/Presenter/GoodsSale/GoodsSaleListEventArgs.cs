using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsSale
{
    public class GoodsSaleListEventArgs  : BaseEventArgs
    {
        public PurchaseOrderCollection PurchaseOrders { get; set; }
        public ObjectCriteria PurchaseOrderSearchCriteria { get; set; }
        public PurchaseOrder SelectedOrder { get; set; }
    }
}

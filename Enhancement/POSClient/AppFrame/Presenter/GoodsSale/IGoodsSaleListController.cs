using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Collection;
using AppFrame.Logic;
using AppFrame.ModelCriteria;
using AppFrame.View.GoodsSale;

namespace AppFrame.Presenter.GoodsSale
{
    public interface IGoodsSaleListController
    {
        #region View use
        IGoodsSaleListView GoodsSaleListView { get; set; }
        IDayGoodsSaleListView DayGoodsSaleListView { get; set; }
        IMonthGoodsSaleListView MonthGoodsSaleListView { get; set; }
        #endregion

        #region Logic
        IPurchaseOrderLogic PurchaseOrderLogic { get; set; }
        IPurchaseOrderDetailLogic PurchaseOrderDetailLogic { get; set; }
        IProductMasterLogic ProductMasterLogic { get; set; }
        #endregion

        #region Model
        PurchaseOrderCollection PurchaseOrders { get; set; }
        ObjectCriteria PurchaseOrderCriteria { get; set; }
        #endregion

        #region Event

        event EventHandler<GoodsSaleListEventArgs> CompletedGoodsSaleListSearchEvent;
        #endregion
    }
}

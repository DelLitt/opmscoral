using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.View.GoodsSale;

namespace AppFrame.Presenter.GoodsSale
{
    public interface IGoodsSaleReturnController
    {
        #region View use
        IGoodsSaleReturnView GoodsSaleReturnView { get; set; }
        #endregion

        #region logic use

        IPurchaseOrderLogic PurchaseOrderLogic { get; set; }
        IPurchaseOrderDetailLogic PurchaseOrderDetailLogic { get; set; }
        IProductMasterLogic ProductMasterLogic { get; set; }
        IProductLogic ProductLogic { get; set; }
        IDepartmentPriceLogic DepartmentPriceLogic { get; set; }
        IDepartmentStockLogic DepartmentStockLogic { get; set; }
        IReturnPoLogic ReturnPoLogic { get; set; }
        #endregion

        #region Model use
        PurchaseOrder ReturnPurchaseOrder { get; set; }
        PurchaseOrder NextPurchaseOrder { get; set; }
        IList ReturnPOs { get; set; }
        #endregion

        event EventHandler<GoodsSaleReturnEventArgs> CompletedSavePurchaseOrderEvent;
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.View.GoodsSale;

namespace AppFrame.Presenter.GoodsSale
{
    public interface IGoodsSaleController
    {
        #region View use
        IGoodsSaleView GoodsSaleView { get; set; }
        IGoodsSaleView GoodsSaleReturnView { get; set; }
        #endregion

        #region logic use

        IPurchaseOrderLogic PurchaseOrderLogic { get; set; }
        IPurchaseOrderDetailLogic PurchaseOrderDetailLogic { get; set; }
        IProductMasterLogic ProductMasterLogic { get; set; }
        IProductLogic ProductLogic { get; set; }
        IDepartmentStockLogic DepartmentStockLogic { get; set; }
        #endregion

        #region Model use
        PurchaseOrder PurchaseOrder { get; set;}
        #endregion

        event EventHandler<GoodsSaleEventArgs> CompletedSavePurchaseOrderEvent;
    }
}

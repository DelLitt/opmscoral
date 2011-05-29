using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockInExtraController : IDepartmentStockInController
    {
        IDepartmentStockInExtraView DepartmentStockInExtraView { get; set; }

        IProductColorLogic ProductColorLogic { get; set; }
        IProductSizeLogic ProductSizeLogic { get; set; }
        IProductLogic ProductLogic { get; set; }
        IProductMasterLogic ProductMasterLogic { get; set; }
        IDepartmentPriceLogic DepartmentPriceLogic { get; set; }

        event EventHandler<DepartmentStockInEventArgs> CompletedFindByStockInEvent;
    }
}

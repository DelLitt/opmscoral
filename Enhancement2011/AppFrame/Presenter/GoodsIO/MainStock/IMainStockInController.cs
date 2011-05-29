using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public interface IMainStockInController : IBaseController<MainStockInEventArgs>
    {
        IMainStockInView MainStockInView { get; set; }

        IProductColorLogic ProductColorLogic { get; set; }
        IProductSizeLogic ProductSizeLogic { get; set; }
    }
}

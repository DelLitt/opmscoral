using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentPriceUpdateController : IBaseController<DepartmentPriceUpdateEventArgs>
    {
        #region View use in IDepartmentStockDetailController
        IDepartmentPriceUpdateView DepartmentPriceUpdateView { get; set; }
        #endregion

        #region Logic use in IDepartmentPriceUpdateController
        #endregion
    }
}
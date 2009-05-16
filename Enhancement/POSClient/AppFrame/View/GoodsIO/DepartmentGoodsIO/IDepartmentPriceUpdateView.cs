using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentPriceUpdateView : IView<DepartmentPriceUpdateEventArgs>
    {
        #region main controller and event
        IDepartmentPriceUpdateController DepartmentPriceUpdateController { set; }
        event EventHandler<DepartmentPriceUpdateEventArgs> SaveDepartmentPriceEvent;
        event EventHandler<DepartmentPriceUpdateEventArgs> SearchDepartmentPriceEvent;
        event EventHandler<DepartmentPriceUpdateEventArgs> InitDepartmentPriceEvent;
        #endregion
    }
}

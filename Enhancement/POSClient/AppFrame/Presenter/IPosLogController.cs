using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.View;
using AppFrame.View.GoodsIO;

namespace AppFrame.Presenter
{
    public interface IPosLogController : IBaseController<PosLogEventArgs>
    {
        #region View use in IStockSearchController
        IPosLogView PosLogView { get; set; }
        #endregion

        #region Logic use in IStockSearchController
        #endregion
    }
}

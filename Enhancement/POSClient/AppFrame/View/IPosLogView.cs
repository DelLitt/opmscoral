using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Presenter;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Common;

namespace AppFrame.View
{
    public interface IPosLogView : IView<PosLogEventArgs>
    {
        #region main controller and event
        IPosLogController PosLogController { set; }
        event EventHandler<PosLogEventArgs> GetPosLogEvent;
        event EventHandler<PosLogEventArgs> SearchPosLogEvent;
        #endregion
    }
}

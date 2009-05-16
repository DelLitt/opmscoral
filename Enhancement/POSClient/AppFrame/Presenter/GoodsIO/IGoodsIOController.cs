using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Presenter.GoodsIO
{
    public interface IGoodsIOController<T> : IBaseController<T> where T : BaseEventArgs
    {
    }
}

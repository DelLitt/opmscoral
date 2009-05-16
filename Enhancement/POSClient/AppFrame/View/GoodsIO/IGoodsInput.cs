using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO;

namespace AppFrame.View.GoodsIO
{
    public interface IGoodsInput<T> where T : BaseEventArgs
    {
        IGoodsIOController<T> GoodsIOController { get; set; }
        event EventHandler<T> SaveGoodsInputEvent;
    }
}

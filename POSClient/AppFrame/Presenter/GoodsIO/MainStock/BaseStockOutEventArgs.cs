using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public class BaseStockOutEventArgs : BaseEventArgs
    {
        public IList ReturnStockViewList { get; set; }
    }
}

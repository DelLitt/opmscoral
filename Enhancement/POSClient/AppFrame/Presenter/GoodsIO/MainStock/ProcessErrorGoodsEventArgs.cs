using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public class ProcessErrorGoodsEventArgs : BaseEventArgs
    {
        public IList StockList { get; set; }
        public IList ReturnStockOutList { get; set; }
        public IList TempStockOutList { get; set; }
        public IList DestroyUnusedGoodsList { get; set; }
    }
}

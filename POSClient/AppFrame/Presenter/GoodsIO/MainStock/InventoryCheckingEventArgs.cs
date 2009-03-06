using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public class InventoryCheckingEventArgs : BaseEventArgs
    {
        public string InputBarcode { get; set; }
        public IList ReturnStockViewList { get; set; }

        public Stock ScannedStock { get; set; }
        public IList SaveStock { get; set; }
        public IList SaveStockDefectList { get; set; }
    }
}

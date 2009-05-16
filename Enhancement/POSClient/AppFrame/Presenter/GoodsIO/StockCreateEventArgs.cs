using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using System.Collections;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO
{
    public class StockCreateEventArgs : BaseEventArgs
    {
        public Form ParentForm { get; set; }
        public DateTime ImportDateFrom { get; set; }
        public DateTime ImportDateTo { get; set; }
        public StockInDetail.StockInStatus StockInStatus { get; set; }
        public IList StockInDetailList { get; set; }
        public IList StockList { get; set; }
        public IList ReturnProductList { get; set; }
        public bool IsNeedDelete { get; set; }
        public IList<Stock> CreateStockList { get; set; }
        public IList<ReturnProduct> CreateReturnProductList { get; set; }
        public IList<StockInDetail> UpdateStockInDetailList { get; set; }
    }
}

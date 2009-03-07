using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public class DepartmentStockCheckingEventArgs : BaseEventArgs
    {
        public string InputBarcode { get; set; }
        public System.Collections.IList ReturnStockViewList { get; set; }

        public DepartmentStock ScannedStock { get; set; }
        public DepartmentStockDefect ScannedStockDefect { get; set; }
        public System.Collections.IList SaveStock { get; set; }
        public IList SaveStockDefectList { get; set; }
    }
}

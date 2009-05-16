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
        public DepartmentStock ScannedDepartmentStock { get; set; }
        public DepartmentStockHistory ScannedDepartmentStockDefect { get; set; }
        public IList SaveDepartmentStock { get; set; }
        public IList SaveDepartmentStockDefectList { get; set; }

        public string InputBarcode { get; set; }
        public IList ReturnStockViewList { get; set; }

        public Stock ScannedStock { get; set; }
        public IList SaveStockList { get; set; }
    }
}

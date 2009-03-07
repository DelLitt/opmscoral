using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public class BaseStockOutEventArgs : BaseEventArgs
    {
        public IList ReturnStockViewList { get; set; }
        public ProductMaster RequestProductMaster { get; set; }
        public IList ReturnStockDefectList { get; set; }

        public IList SaveStockDefectList { get; set; }
        public IList SaveStockOutList { get; set; }
    }
}

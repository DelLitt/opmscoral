using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public class StockOutDialogEventArgs : BaseEventArgs
    {
        public IList ProductMastersList { get; set; }
        public IList ProductTypeList { get; set; }
        public IList ProductColorList { get; set; }
        public IList ProductSizeList { get; set; }
        public IList DepartmentsList { get; set; }
    }
}

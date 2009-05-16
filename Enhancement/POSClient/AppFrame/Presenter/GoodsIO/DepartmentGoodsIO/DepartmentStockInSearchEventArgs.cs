using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using System.Collections;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public class DepartmentStockInSearchEventArgs : BaseEventArgs
    {
        public Form ParentForm { get; set; }
        public IList DepartmeneStockInList { get; set; }
        public Department Department { get; set; }

        public string StockInId { get; set; }
        public DateTime StockInDateFrom { get; set; }
        public DateTime StockInDateTo { get; set; }
    }
}
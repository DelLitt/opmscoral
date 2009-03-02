using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using System.Collections;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public class DepartmentStockDetailEventArgs : BaseEventArgs
    {
        public Form ParentForm { get; set; }
        public Department Department { get; set; }

        public ProductMaster SelectedProductMaster { get; set; }
        public IList DepartmentStockInDetailList { get; set; }
        public DepartmentPrice ProductPrice { get; set; }
        public bool IsNewPrice { get; set; }

        public string ProductMasterId { get; set; }
        public DateTime StockInDateFrom { get; set; }
        public DateTime StockInDateTo { get; set; }
    }
}
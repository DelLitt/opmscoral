using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using System.Collections;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public class MainStockOutEventArgs : BaseEventArgs
    {
        public Form ParentForm { get; set; }
        public long DefectStatusId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public IList ProductSizeList { get; set; }
        public IList ProductColorList { get; set; }
        public IList FoundProductMasterList { get; set; }
        public IList SelectedProductMasterList { get; set; }

        public Stock Stock { get; set; }
        public StockOut StockOut { get; set; }
        public bool IsFillToComboBox { get; set; }
        public StockOutDetail SelectedStockOutDetail { get; set; }
        public string ComboBoxDisplayMember { get; set; }
        public int SelectedIndex { get; set; }

        public IList StockList { get; set; }

        public IList FoundStockOutDetailList { get; set; }
    }
}
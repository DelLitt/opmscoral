using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using System.Collections;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public class DepartmentStockOutEventArgs : BaseEventArgs
    {
        public Form ParentForm { get; set; }
        public DateTime LastSyncTime { get; set; }
        public bool IsConfirmPeriod { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public IList ProductSizeList { get; set; }
        public IList ProductColorList { get; set; }
        public IList FoundProductMasterList { get; set; }
        public IList SelectedProductMasterList { get; set; }

        public DepartmentStock DepartmentStock { get; set; }
        public DepartmentStockOut DepartmentStockOut { get; set; }
        public bool IsFillToComboBox { get; set; }
        public DepartmentStockOutDetail SelectedDepartmentStockOutDetail { get; set; }
        public string ComboBoxDisplayMember { get; set; }
        public int SelectedIndex { get; set; }

        public IList DepartmentStockList { get; set; }

        public IList FoundDepartmentStockOutDetailList { get; set; }

        public SyncFromDepartmentToMain SyncFromDepartmentToMain { get; set; }
    }
}
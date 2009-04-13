using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class SyncFromDepartmentToMain
    {
        public IList DepartmentStockList { get; set; }
        public IList DepartmentStockInList { get; set; }
        public IList DepartemntStockOutList { get; set; }
        public IList DepartmentStockHistoryList { get; set; }
        public IList PurchaseOrderList { get; set; }
        public IList ReturnPoList { get; set; }

        public DepartmentTimeline DepartmentTimeline
        {
            get; set;
        }
    }
}

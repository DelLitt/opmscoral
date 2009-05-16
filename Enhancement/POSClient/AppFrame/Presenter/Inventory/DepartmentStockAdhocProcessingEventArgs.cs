using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Presenter.Inventory
{
    public class DepartmentStockAdhocProcessingEventArgs : BaseEventArgs
    {
        public IList DeptStockAdhocList { get; set; }
        public IList DeptStockProcessedList { get; set; }
    }
}

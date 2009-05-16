using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.View.Reports;

namespace AppFrame.Presenter
{
    public class StockOutConfirmEventArgs : BaseEventArgs
    {
        public ReportDateStockOutParam ReportDateStockOutParam { get; set; }

        public IList ResultStockOutList { get; set; }
        public IList ProductMastersInList { get; set; }
        public IList DepartmentsList { get; set; }
        public Department SelectDepartment { get; set; }

        public IList ConfirmDepartmentStockOutList { get; set; }
        public IList DenyDepartmentStockOutList { get; set; }
    }
}

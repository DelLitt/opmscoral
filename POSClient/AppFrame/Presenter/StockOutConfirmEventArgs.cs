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
        public StockOut EditStockOut { get; set; }
        public long StockOutId { get; set;}
        public IList DenyStockOutIdsList { get; set; }
        public IList ConfirmStockOutIdsList { get; set; }
        public string ProductMasterIdForPrice { get; set;}
        public ReportDateStockOutParam ReportDateStockOutParam { get; set; }

        public DepartmentPrice DepartmentPrice { get; set; }
        public IList ResultStockOutList { get; set; }
        public IList ProductMastersInList { get; set; }
        public IList DepartmentsList { get; set; }
        public Department SelectDepartment { get; set; }

        public IList ConfirmStockInList { get; set; }
        public IList DenyStockInList { get; set; }
    }
}

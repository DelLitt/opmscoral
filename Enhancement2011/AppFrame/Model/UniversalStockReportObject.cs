using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    public class UniversalStockReportObject
    {
        public virtual Int64 StockInStartQuantity { get; set; }
        public virtual Int64 StockInEndQuantity { get; set; }
        public virtual Int64 DepartmentStockInStartQuantity { get; set; }
        public virtual Int64 DepartmentStockInEndQuantity { get; set; }
        public virtual Int64 SoldQuantity { get; set; }
        public virtual Int64 StockStartQuantity { get; set; }
        public virtual Int64 StockEndQuantity { get; set; }
        public virtual long GoodCount { get; set; }
        public virtual int ErrorCount { get; set; }
        public virtual int DamageCount { get; set; }
        public virtual int LostCount { get; set; }
        public virtual int UnconfirmCount { get; set; }
        public virtual ProductMaster ProductMaster { get; set; }
    }
}

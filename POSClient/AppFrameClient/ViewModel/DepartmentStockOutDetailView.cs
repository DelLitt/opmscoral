using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Model;

namespace AppFrameClient.ViewModel
{
    public class DepartmentStockOutDetailView
    {
        public DepartmentStockOutDetail StockOutDetail { get; set; }
        public long TotalCount { get; set; }
        public long GoodCount { get; set; }
        public long ErrorCount { get; set; }
        public long DamageCount { get; set; }
        public long LostCount { get; set; }
        public long UnconfirmCount { get; set; }
        // for printing
        public virtual string ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string ColorName { get; set; }
        public virtual string SizeName { get; set; }
        public virtual long Quantity { get; set; }
        public virtual long Price { get; set; }
    }
}

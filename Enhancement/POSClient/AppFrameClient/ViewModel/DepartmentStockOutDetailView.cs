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
    }
}

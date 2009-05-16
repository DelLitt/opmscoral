using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Model
{
    public class DepartmentStockSearchResult
    {
        public DepartmentStock DepartmentStock { get; set; }
        public DepartmentPrice DepartmentPrice { get; set; }
        public long SumInPrice { get; set; }
        public long SumSellPrice { get; set; }
        public long SumQuantity { get; set; }

    }
}

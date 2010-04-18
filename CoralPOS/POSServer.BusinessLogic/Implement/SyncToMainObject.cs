using System.Collections.Generic;
using CoralPOS.Models;

namespace POSServer.BusinessLogic.Implement
{
    public class SyncToMainObject
    {
        public bool HasCommonInfo { get; set;}
        public IList<DepartmentStockOut> DepartmentStockOutList { get; set;}
        public IList<DepartmentStockIn> DepartmentStockInList { get; set;}
        public IList<DepartmentStockHistory> DepartmentStockHistoryList { get; set;}
        public Department Department { get; set;} 
        public IList<Product> PurchaseOrderList { get; set;}
    }
}
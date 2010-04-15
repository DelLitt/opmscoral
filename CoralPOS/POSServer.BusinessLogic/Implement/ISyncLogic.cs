using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface ISyncLogic
    {
        ProductDao ProductDao { get; set; }
        ProductMasterDao ProductMasterDao { get; set; }
        StockOutDao StockOutDao { get; set; }
        DepartmentDao DepartmentDao { get; set; }
        MainPriceDao MainPriceDao { get; set; }       


        void SyncToMain(SyncToMainObject syncToMainObject);
        void SyncToDepartment(SyncToDepartmentObject syncToDept);
    }

    public class SyncToDepartmentObject
    {
        public IList<StockOut> StockOutList { get; set;}
        public Department Department { get; set;} 
        public IList<Product> ProductList { get; set;}
        public IList<MainPrice> PriceList { get; set;}

        public bool DepartmentInfo { get; set; }
        public bool ProductMasterInfo { get; set; }
        public bool PriceInfo { get; set; }
    }

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

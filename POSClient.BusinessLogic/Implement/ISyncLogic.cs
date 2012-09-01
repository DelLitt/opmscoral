using System.Collections.Generic;
using CoralPOS.Models;
using POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public interface ISyncLogic
    {
        ProductDao ProductDao { get; set; }
        ProductMasterDao ProductMasterDao { get; set; }
        StockOutDao StockOutDao { get; set; }
        DepartmentDao DepartmentDao { get; set; }
        MainPriceDao MainPriceDao { get; set; }


        SyncToMainObject SyncToMain(SyncToMainObject syncToMainObject);
        SyncResult SyncFromMain(SyncToDepartmentObject syncToDept);

        IList<SyncResult> SyncFromMain(string importPath);
    }
}

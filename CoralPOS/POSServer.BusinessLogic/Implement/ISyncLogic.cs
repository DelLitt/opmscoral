using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.DataLayer.Utils;
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

        SyncToMainObject SyncToMain(SyncToMainObject syncToMainObject);
        SyncToDepartmentObject SyncToDepartment(SyncToDepartmentObject syncToDept);

        IList<SyncResult> SyncToDepartment(string exportPath, SyncToDepartmentObject syncToDept);
        SyncResult SyncToDepartment(string exportPath);
    }
}

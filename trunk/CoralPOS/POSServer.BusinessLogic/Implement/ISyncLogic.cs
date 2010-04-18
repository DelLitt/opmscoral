﻿using System;
using System.Linq;
using System.Text;
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
    }
}

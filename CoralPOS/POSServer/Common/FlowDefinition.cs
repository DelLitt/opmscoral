using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSServer.Common
{
    public class FlowDefinition
    {
        
        #region Synchronize
        public const string SYNC_TO_DEPARTMENT = "SyncToDepartmentFlow";
        public const string CreateSyncUSBFlow = "CreateSyncUSBFlow";
        

        #endregion

        #region Task

        public const string LoginFlow = "LoginFlow";

        #endregion


        #region Management

        public const string DepartmentsViewFlow = "DepartmentsViewFlow";
        public const string UserInfoViewFlow = "UserInfoViewFlow";
        public const string EmployeesViewFlow = "EmployeesViewFlow";

        #endregion


        #region Product Master

        public const string ProductMasterCreateFlow = "ProductMasterCreateFlow";
        public const string ProductMasterPriceUpdateFlow = "ProductMasterPriceUpdateFlow";

        #endregion

        

        #region Stock flow
        public const string StockInventoryViewFlow = "StockInventoryViewFlow";
        public const string StockInventoryProcessingFlow = "StockInventoryProcessingFlow";
        public const string StockOutSearchFlow = "StockOutSearchFlow";
        public const string StockInSearchFlow = "StockInSearchFlow";
        public const string StockOutCreateFlow ="StockOutCreateFlow";
        public const string StockInCreateFlow = "StockInCreateFlow";
        public const string SyncToDepartmentFlow = "SyncToDepartmentFlow";
        public const string SystemConfigFlow = "SystemConfigFlow";
        public const string StockOutSpecificCreateFlow = "StockOutSpecificCreateFlow";
        public const string StockOutConfirmingFlow = "StockOutConfirmFlow";

        #endregion



    }
}

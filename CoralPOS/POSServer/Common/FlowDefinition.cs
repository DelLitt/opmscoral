using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSServer.Common
{
    public class FlowDefinition
    {
        #region Task

        public const string LoginFlow = "LoginFlow";

        #endregion


        #region Management

        public const string DepartmentsViewFlow = "DepartmentsViewFlow";

        #endregion


        #region Product Master

        public const string ProductMasterCreateFlow = "ProductMasterCreateFlow";

        #endregion

        

        #region Stock flow

        public const string StockOutSearchFlow = "StockOutSearchFlow";
        public const string StockInSearchFlow = "StockInSearchFlow";
        public const string StockOutCreateFlow ="StockOutCreateFlow";
        public const string StockInCreateFlow = "StockInCreateFlow";

        #endregion



    }
}

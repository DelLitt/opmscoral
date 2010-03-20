using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Stock.StockIn
{
    public class StockInPreLoadAction : PosAction,IStockInPreLoadAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }

        public override void DoExecute()
        {
            IList productNames = ProductMasterLogic.LoadAllProductNames();
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productNames);
            GoToNextNode();
        }
    }
}
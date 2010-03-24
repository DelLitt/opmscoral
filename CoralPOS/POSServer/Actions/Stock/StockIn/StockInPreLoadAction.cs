using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.DataLayer;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Stock.StockIn
{
    public class StockInPreLoadAction : PosAction,IStockInPreLoadAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }

        public override void DoExecute()
        {
            IList  productMasters = ProductMasterLogic.LoadAllProductMasterWIthType();
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productMasters);
            GoToNextNode();
        }
    }
}
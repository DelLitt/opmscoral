using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.DataLayer;
using AppFrame.WPF.Screens;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.Filters;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;

namespace POSServer.Actions.Stock.StockIn
{
    public class StockInPreLoadAction : PosAction,IStockInPreLoadAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }
        

        public StockInPreLoadAction()
        {
            
        }

        [AsyncAction(BlockInteraction = false)]
        public override void DoExecute()
        {
            
            DoWork();
        }

        private void DoWork()
        {
            IList productMasters = ProductMasterLogic.LoadAllProductMasterWithType();
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productMasters);
            GoToNextNode();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;

namespace POSServer.Actions.Stock.StockOut
{
    [PerRequest]
    public class StockOutConfirmPreLoadAction : DefaultPosAction
    {
        [Autowired]
        public IProductMasterLogic ProductMasterLogic { get; set; }
        [Autowired]
        public IMainStockLogic MainStockLogic
        {
            get; set;
        }
        [Autowired]
        public IDepartmentLogic DepartmentLogic
        {
            get; set;
        }
        [Autowired]
        public IStockOutLogic StockOutLogic
        {
            get; set; 
        }

        public override void DoExecute()
        {
            StartAsyncWork();
        }

        public override void AfterWorkCompleted()
        {
            GoToNextNode();
        }

        public override object Working()
        {
            
            var stockOutCriteria = new ObjectCriteria<CoralPOS.Models.StockOut>();
            stockOutCriteria.Add(x => x.ConfirmFlg == 1);
            var confirmingStockOuts = (IList) StockOutLogic.FindAll(stockOutCriteria);
            IList<CoralPOS.Models.StockOut> fetchedStockOuts = new List<CoralPOS.Models.StockOut>();
            foreach (CoralPOS.Models.StockOut confirmingStockOut in confirmingStockOuts)
            {
                CoralPOS.Models.StockOut fetchedStockOut = StockOutLogic.Fetch(confirmingStockOut);
                MainStockLogic.UpdateStockQuantity(fetchedStockOut.StockOutDetails);
                fetchedStockOuts.Add(fetchedStockOut);
            }

            Flow.Session.Put(FlowConstants.CONFIRMING_STOCK_OUT_LIST,confirmingStockOuts);
            return null;
        }
    }
}
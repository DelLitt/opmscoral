using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using AppFrame.Base;
using AppFrame.DataLayer;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;

namespace POSServer.Actions.Stock.StockOut
{
    public class StockOutConfirmPreLoadAction : PosAction, IStockOutConfirmPreLoadAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IMainStockLogic MainStockLogic
        {
            get; set;
        }

        public IDepartmentLogic DepartmentLogic
        {
            get; set;
        }

        public IStockOutLogic StockOutLogic
        {
            get; set; 
        }

        public override void DoExecute()
        {
            IoC.Get<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockOutPreLoadActionDoExecuteCompleted;
            DoExecuteAsync(DoWork, null);
        }

        void StockOutPreLoadActionDoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IoC.Get<ICircularLoadViewModel>().StopLoading();
            GoToNextNode();
        }

        private object DoWork()
        {
            IList productMasters = (IList) MainStockLogic.FetchAll(new LinqCriteria<MainStock>());
            //IList productMasters = ProductMasterLogic.LoadAllProductMasterWithType("%%");
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productMasters);
            var stockOutCriteria = new ObjectCriteria<CoralPOS.Models.StockOut>();
            stockOutCriteria.Add(x => x.ConfirmFlg == 1);
            var confirmingStockOuts = (IList) StockOutLogic.FindAll(stockOutCriteria);
            IList<CoralPOS.Models.StockOut> fetchedStockOuts = new List<CoralPOS.Models.StockOut>();
            foreach (CoralPOS.Models.StockOut confirmingStockOut in confirmingStockOuts)
            {
                fetchedStockOuts.Add(StockOutLogic.Fetch(confirmingStockOut));
            }
            Flow.Session.Put(FlowConstants.CONFIRMING_STOCK_OUT_LIST,confirmingStockOuts);
            return null;
        }
    }
}
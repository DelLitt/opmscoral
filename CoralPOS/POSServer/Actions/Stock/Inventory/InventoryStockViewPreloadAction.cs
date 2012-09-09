using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Stock.Inventory
{
    [PerRequest]
    public class InventoryStockViewPreloadAction : PosAction
    {
        [Autowired]
        public IProductMasterLogic ProductMasterLogic { get; set; }
        [Autowired]
        public IMainStockLogic MainStockLogic { get; set; }
        [Autowired]
        public IDepartmentStockLogic DepartmentStockLogic { get; set; }

        public override void DoExecute()
        {
            IoC.Get<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(InventoryStockViewPreloadAction_DoExecuteCompleted);
            DoExecuteAsync(DoWork,null);
        }

        private object DoWork()
        {
            IList productMasters = ProductMasterLogic.LoadAllProductMasterWithType("");
            Flow.Session.Put(FlowConstants.PRODUCT_MASTER_LIST,productMasters);
            return null;
        }

        void InventoryStockViewPreloadAction_DoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IoC.Get<ICircularLoadViewModel>().StopLoading();
            GoToNextNode();
        }
    }
}

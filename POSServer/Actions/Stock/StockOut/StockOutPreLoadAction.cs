using System.Collections;
using System.Collections.Generic;
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
    public class StockOutPreLoadAction : PosAction, IStockOutPreLoadAction
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

        public override void DoExecute()
        {
            IoC.Get<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockOutPreLoadActionDoExecuteCompleted;
            DoExecuteAsync(() => DoWork(), null);
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
            ObjectCriteria<Department> objectCriteria = new ObjectCriteria<Department>();
            objectCriteria.Add(x => x.DepartmentId > 0); // we don't get department 0 because department 0 is MAIN STOCK.
            IList<Department> departments = DepartmentLogic.FindAll(objectCriteria);
            Flow.Session.Put(FlowConstants.DEPARTMENTS,departments);
            return null;
        }
    }
}
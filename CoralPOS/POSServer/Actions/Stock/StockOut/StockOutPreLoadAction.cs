using System.Collections;
using System.Collections.Generic;
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
    public class StockOutPreLoadAction : DefaultPosAction
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

        public override void DoExecute()
        {
            StartAsyncWork();
        }

        public override object Working()
        {
            IList productMasters = (IList)MainStockLogic.FetchAll(new LinqCriteria<MainStock>());
            //IList productMasters = ProductMasterLogic.LoadAllProductMasterWithType("%%");
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productMasters);
            ObjectCriteria<Department> objectCriteria = new ObjectCriteria<Department>();
            objectCriteria.Add(x => x.DepartmentId > 0); // we don't get department 0 because department 0 is MAIN STOCK.
            IList<Department> departments = DepartmentLogic.FindAll(objectCriteria);
            Flow.Session.Put(FlowConstants.DEPARTMENTS, departments);
            return null;
        }

        public override void AfterWorkCompleted()
        {
            GoToNextNode();
        }

        
    }
}
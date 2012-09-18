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
    public class StockOutSpecificPreLoadAction : DefaultPosAction
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
        public IStockDefinitionStatusLogic StockDefinitionStatusLogic { get; set; }

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
            IList productMasters = MainStockLogic.FindProductMasterAvailInStock("");
            //IList productMasters = ProductMasterLogic.LoadAllProductMasterWithType("%%");
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productMasters);
            IList<StockDefinitionStatus> stockDefinitionStatuses = StockDefinitionStatusLogic.FindAll(new ObjectCriteria<StockDefinitionStatus>());
            Flow.Session.Put(FlowConstants.DEFINITION_STATUS_LIST,stockDefinitionStatuses);
            return null;
        }
    }
}
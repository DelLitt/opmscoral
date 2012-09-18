using System.Collections;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;


namespace POSServer.Actions.Stock.StockIn
{
    [PerRequest]
    public class StockInPreLoadAction : DefaultPosAction
    {
        [Autowired]
        public IProductMasterLogic ProductMasterLogic { get; set; }
        
        public override void DoExecute()
        {
            StartAsyncWork();
        }

        public override object Working()
        {
            IList productMasters = ProductMasterLogic.LoadAllProductMasterWithType("%%");
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productMasters);
            return null;
        }

        public override void AfterWorkCompleted()
        {
            GoToNextNode();
        }
    }
}
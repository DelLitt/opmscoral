using System.ComponentModel;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    [PerRequest]
    public class PmPreLoadDefinitionAction : DefaultPosAction
    {
        public override void DoExecute()
        {
            StartAsyncWork();
        }

        public override object Working()
        {
            return LoadProductMasterDefinition();
        }

        public override void AfterWorkCompleted()
        {
            GoToNextNode();
        }

        private object LoadProductMasterDefinition()
        {
            Flow.Session.Clear();
            ProductMasterLogic.PreloadDefinition(Flow.Session);
            return null;
        }
        
        [Autowired]
        public IProductMasterLogic ProductMasterLogic
        {
            get; set;
        }
    }
}

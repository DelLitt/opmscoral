using AppFrame.Base;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    
    public class PmPreLoadDefinitionAction : PosAction,IPmPreLoadDefinitionAction
    {
        public override void DoExecute()
        {
            LoadProductMasterDefinition();
        }

        private void LoadProductMasterDefinition()
        {
            ProductMasterLogic.PreloadDefinition(this.Flow.Session);
            GoToNextNode();
        }
        
        public IProductMasterLogic ProductMasterLogic
        {
            get; set;
        }
    }
}

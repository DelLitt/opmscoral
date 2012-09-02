using System.ComponentModel;
using AppFrame.Base;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    
    public class PmPreLoadDefinitionAction : PosAction
    {
        public override void DoExecute()
        {
            IoC.Get<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted += LoadProductMasterDefinitionCompleted;
            DoExecuteAsync(LoadProductMasterDefinition, null);
            
        }

        private void LoadProductMasterDefinitionCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IoC.Get<ICircularLoadViewModel>().StopLoading();
            GoToNextNode();
        }

        private object LoadProductMasterDefinition()
        {
            ProductMasterLogic.PreloadDefinition(this.Flow.Session);
            return null;
        }
        
        public IProductMasterLogic ProductMasterLogic
        {
            get; set;
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    [PerRequest]
    public class PmPricePreLoadDefinitionAction : PosAction
    {
        public override void DoExecute()
        {
            IoC.Get<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted +=  LoadProductCompleted;
            DoExecuteAsync(LoadProductMasterDefinition, null);
        }

        private void LoadProductCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IoC.Get<ICircularLoadViewModel>().StopLoading();
            GoToNextNode();
        }

        private object LoadProductMasterDefinition()
        {
            ProductMasterLogic.PreloadDefinition(this.Flow.Session);
            MainPriceLogic.PreloadDefinition(Flow.Session);
            //IList<CoralPOS.Models.ProductMaster> productMasterList = ProductMasterLogic.FindAll(new ObjectCriteria<CoralPOS.Models.ProductMaster>());
            //Flow.Session.Put(FlowConstants.PRODUCT_MASTER_LIST,productMasterList);
            return null;
        }
        
        [Autowired]
        public IProductMasterLogic ProductMasterLogic
        {
            get; set;
        }

        [Autowired]
        public IMainPriceLogic MainPriceLogic
        {
            get; set; 
        }
    }
}

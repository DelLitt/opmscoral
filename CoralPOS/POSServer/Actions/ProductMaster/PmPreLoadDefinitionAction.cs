using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.IoC;
using Ninject;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    
    public class PmPreLoadDefinitionAction : PosAction,IPmPreLoadDefinitionAction
    {
        public void DoExecute()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.IoC;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    [PerRequest(typeof(IPmPreLoadDefinitionAction))]
    public class PmPreLoadDefinitionAction : PosAction,IPmPreLoadDefinitionAction
    {
        public void DoExecute()
        {
            LoadProductMasterDefinition();
        }

        private void LoadProductMasterDefinition()
        {
            
        }

        public IProductMasterLogic ProductMasterLogic
        {
            get; set;
        }
    }
}

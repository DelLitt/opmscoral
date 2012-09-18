using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    [PerRequest]
    public class ExProductColorsViewPreLoadAction : DefaultPosAction
    {
        [Autowired]
        public IExProductColorLogic ProductColorLogic
        {
            get; set;
        }

        public override void DoExecute()
        {
            LoadProductColorDefinition();
            GoToNextNode();
        }

        private void LoadProductColorDefinition()
        {
            ProductColorLogic.LoadProductColorDefinition(Flow.Session);
        }
    }
}

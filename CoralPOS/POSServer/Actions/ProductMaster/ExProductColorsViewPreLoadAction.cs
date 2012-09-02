using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    public class ExProductColorsViewPreLoadAction : PosAction
    {
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

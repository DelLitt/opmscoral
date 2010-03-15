using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    public class ExProductColorsViewPreLoadAction : PosAction, IExProductColorsViewPreLoadAction
    {
        public IExProductColorLogic ProductColorLogic
        {
            get; set;
        }

        public override void DoExecute()
        {
            LoadProductColorDefinition();
        }

        private void LoadProductColorDefinition()
        {
            ProductColorLogic.LoadProductColorDefinition(Flow.Session);
        }
    }
}

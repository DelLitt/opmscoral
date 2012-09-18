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
    public class ExProductColorsViewSaveAction : DefaultPosAction
    {
        [Autowired]
        public IExProductColorLogic ProductColorLogic
        {
            get; set;
        }

        public override void DoExecute()
        {
            ProductColorLogic.Process(Flow.Session);
            GoToNextNode();
        }
    }
}

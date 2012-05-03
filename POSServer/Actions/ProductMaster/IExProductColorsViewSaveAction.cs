using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    public interface IExProductColorsViewSaveAction : IActionNode
    {
        IExProductColorLogic ProductColorLogic { get; set; }
    }
}

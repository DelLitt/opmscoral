using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Stock.StockIn
{
    public interface IStockInPreLoadAction : IActionNode
    {
        IProductMasterLogic ProductMasterLogic { get; set; }
    }
}

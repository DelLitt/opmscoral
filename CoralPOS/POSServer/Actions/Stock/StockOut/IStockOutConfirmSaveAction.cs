using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Stock.StockOut
{
    public interface IStockOutConfirmSaveAction : IActionNode
    {
        IStockOutLogic StockOutLogic { get; set; }
        IMainStockLogic MainStockLogic { get; set; }
    }
}
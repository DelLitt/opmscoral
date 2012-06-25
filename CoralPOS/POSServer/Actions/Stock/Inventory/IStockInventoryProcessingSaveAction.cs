using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Stock.Inventory
{
    public interface IStockInventoryProcessingSaveAction : IActionNode
    {
        IDepartmentLogic DepartmentLogic { get; set; }
        IStockOutLogic StockOutLogic { get; set; }
        IStockInLogic StockInLogic { get; set; }
        IDepartmentStockTempValidLogic DepartmentStockTempValidLogic { get; set; }
        IMainPriceLogic MainPriceLogic { get; set; }
    }
}

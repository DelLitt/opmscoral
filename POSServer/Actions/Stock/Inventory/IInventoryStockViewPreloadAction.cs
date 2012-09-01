using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Stock.Inventory
{
    public interface IInventoryStockViewPreloadAction : IActionNode
    {
        IProductMasterLogic ProductMasterLogic {get;set;}
        IMainStockLogic MainStockLogic { get;set;}
        IDepartmentStockLogic DepartmentStockLogic { get;set;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Stock.StockOut
{
    public interface IStockOutSaveAction : IActionNode
    {
        IProductMasterLogic ProductMasterLogic { get; set; }
        IProductLogic ProductLogic { get; set; }
        IExProductColorLogic ProductColorLogic { get; set; }
        IExProductSizeLogic ProductSizeLogic { get; set; }
        ICategoryLogic CategoryLogic { get; set; }
        IProductTypeLogic ProductTypeLogic { get; set; }
        IStockOutLogic StockOutLogic { get; set; }
    }
}
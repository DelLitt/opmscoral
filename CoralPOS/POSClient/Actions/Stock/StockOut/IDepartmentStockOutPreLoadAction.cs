using AppFrame.Base;
using POSClient.BusinessLogic.Implement;

namespace POSClient.Actions.Stock.StockOut
{
    public interface IDepartmentStockOutPreLoadAction : IActionNode
    {
        IProductMasterLogic ProductMasterLogic { get; set; }
        IDepartmentStockLogic DepartmentStockLogic { get; set; }
        IDepartmentLogic DepartmentLogic { get; set; }
    }
}

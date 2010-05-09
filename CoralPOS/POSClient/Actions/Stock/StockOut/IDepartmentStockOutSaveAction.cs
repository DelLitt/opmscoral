using AppFrame.Base;
using POSClient.BusinessLogic.Implement;

namespace POSClient.Actions.Stock.StockOut
{
    public interface IDepartmentStockOutSaveAction : IActionNode
    {
        IProductMasterLogic ProductMasterLogic { get; set; }
        IProductLogic ProductLogic { get; set; }
        IExProductColorLogic ProductColorLogic { get; set; }
        IExProductSizeLogic ProductSizeLogic { get; set; }
        ICategoryLogic CategoryLogic { get; set; }
        IProductTypeLogic ProductTypeLogic { get; set; }
        IDepartmentStockOutLogic DepartmentStockOutLogic { get; set; }
    }
}
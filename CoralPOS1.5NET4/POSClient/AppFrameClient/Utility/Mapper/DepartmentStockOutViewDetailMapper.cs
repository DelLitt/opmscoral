using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Model;
using AppFrame.Utility.Mapper;
using AppFrameClient.ViewModel;

namespace AppFrameClient.Utility.Mapper
{
    public class DepartmentStockOutViewDetailMapper : BaseMapper<DepartmentStockOutDetailView, DepartmentStockOutDetail>
    {
        public DepartmentStockOutDetailView Convert(DepartmentStockOutDetail source)
        {
            DepartmentStockOutDetailView view = new DepartmentStockOutDetailView();
            view.ProductName = source.Product.ProductMaster.ProductName;
            view.ColorName = source.Product.ProductMaster.ProductColor.ColorName;
            view.SizeName = source.Product.ProductMaster.ProductSize.SizeName;
            view.Quantity = source.Quantity;
            view.StockOutDetail = source;
            view.ProductId = source.Product.ProductId;
            view.GoodCount = source.GoodQuantity;
            view.ErrorCount = source.ErrorQuantity;
            view.LostCount = source.LostQuantity;
            view.UnconfirmCount = source.UnconfirmQuantity;
            return view;
        }
    }
}

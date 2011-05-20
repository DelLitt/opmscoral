using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Utility.Mapper
{
    public class DepartmentStockInMapper : BaseMapper<DepartmentStockIn,StockOut>
    {
        #region BaseMapper<DepartmentStockIn,StockOut> Members

        public DepartmentStockIn Convert(StockOut source)
        {
            DepartmentStockIn deptStockIn = new DepartmentStockIn();
            
            deptStockIn.DepartmentStockInPK = new DepartmentStockInPK { DepartmentId = source.DepartmentId};
            deptStockIn.DepartmentId = source.DepartmentId;
            deptStockIn.CreateDate = DateTime.Now;
            deptStockIn.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            deptStockIn.UpdateDate = DateTime.Now;
            deptStockIn.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            deptStockIn.StockInDate = DateTime.Now;
            deptStockIn.DelFlg = 0;
            deptStockIn.ExclusiveKey = 1;
            IList deptStockInDetails = new ArrayList();
            foreach (StockOutDetail stockOutDetail in source.StockOutDetails)
            {
                DepartmentStockInDetail detail =new DepartmentStockInDetail();
                detail.Price = stockOutDetail.Price;
                detail.OnStorePrice = stockOutDetail.WholeSalePrice;
                detail.Product = stockOutDetail.Product;
                detail.ProductId = detail.Product.ProductId;
                detail.ProductMaster = stockOutDetail.ProductMaster;
                
                detail.CreateDate = DateTime.Now;
                detail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                detail.UpdateDate = DateTime.Now;
                detail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

                detail.DelFlg = 0;
                detail.ExclusiveKey = 1;
                detail.Quantity = stockOutDetail.Quantity;
                detail.DepartmentStockInDetailPK = 
                     new DepartmentStockInDetailPK{ DepartmentId = source.DepartmentId,
                                                    ProductId   = detail.Product.ProductId};
                deptStockInDetails.Add(detail);
            }
            deptStockIn.DepartmentStockInDetails = deptStockInDetails;
            return deptStockIn;
        }

        #endregion
    }
}

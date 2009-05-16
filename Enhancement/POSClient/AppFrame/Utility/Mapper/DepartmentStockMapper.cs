using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Utility.Mapper
{
    public class DepartmentStockMapper : BaseMapper<DepartmentStock, DepartmentStockTemp>
    {
        #region Implementation of BaseMapper<DepartmentStock,DepartmentStockTemp>

        public DepartmentStock Convert(DepartmentStockTemp source)
        {
            DepartmentStock temp = new DepartmentStock();

            temp.Quantity = source.Quantity;
            temp.DepartmentStockPK = new DepartmentStockPK
            {
                DepartmentId = source.DepartmentStockTempPK.DepartmentId,
                ProductId = source.DepartmentStockTempPK.ProductId
            };
            temp.DelFlg = 0;
            temp.UpdateDate = DateTime.Now;
            temp.CreateId = source.CreateId;
            temp.UpdateId = source.UpdateId;

            //temp.ExclusiveKey = 1;
            temp.DepartmentId = temp.DepartmentStockPK.DepartmentId;
            temp.Product = source.Product;
            temp.ProductMaster = source.Product.ProductMaster;
            temp.Quantity = source.Quantity;
            temp.GoodQuantity = source.GoodQuantity;
            temp.ErrorQuantity = source.ErrorQuantity;
            temp.DamageQuantity = source.DamageQuantity;
            temp.LostQuantity = source.LostQuantity;
            temp.UnconfirmQuantity = source.UnconfirmQuantity;

            return temp;
        }

        #endregion
    }
}

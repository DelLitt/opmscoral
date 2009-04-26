using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Utility.Mapper
{
    public class DepartmentStockTempMapper : BaseMapper<DepartmentStockTemp, DepartmentStock>
    {
        public DepartmentStockTemp Convert(DepartmentStock source)
        {
            DepartmentStockTemp temp = new DepartmentStockTemp();

            temp.Quantity = source.Quantity;
            temp.DepartmentStockTempPK = new DepartmentStockTempPK
                                         {
                                             DepartmentId = source.DepartmentStockPK.DepartmentId,
                                             ProductId = source.DepartmentStockPK.ProductId,
                                             CreateDate = DateTime.Now
                                         };
            temp.DelFlg = 0;
            temp.UpdateDate = DateTime.Now;
            temp.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            temp.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            temp.ExclusiveKey = 1;
            temp.DepartmentId = temp.DepartmentStockTempPK.DepartmentId;
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
    }
}

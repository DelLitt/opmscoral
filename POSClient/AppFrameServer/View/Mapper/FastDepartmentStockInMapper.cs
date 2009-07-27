using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Utility.Mapper;

namespace AppFrameServer.View.Mapper
{
    public class FastDepartmentStockInMapper : BaseMapper<DepartmentStockIn, DepartmentStockOut>
    {
        public DepartmentStockIn Convert(DepartmentStockOut source)
        {
            DepartmentStockIn stockIn = new DepartmentStockIn();
            stockIn.CreateDate = DateTime.Now;
            stockIn.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            stockIn.UpdateDate = DateTime.Now;
            stockIn.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            stockIn.StockInDate = DateTime.Now;
            stockIn.DepartmentStockInPK = new DepartmentStockInPK
                                              {
                                                  DepartmentId = source.OtherDepartmentId
                                              };
            IList stockInDetailList = new ArrayList();
            foreach (DepartmentStockOutDetail outDetail in source.DepartmentStockOutDetails)
            {
                DepartmentStockInDetail inDetail = new DepartmentStockInDetail();
                inDetail.CreateDate = DateTime.Now;
                inDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                inDetail.UpdateDate = DateTime.Now;
                inDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                inDetail.Quantity = outDetail.Quantity;
                inDetail.Product = outDetail.Product;
                inDetail.ProductMaster = outDetail.Product.ProductMaster;
                inDetail.DepartmentStockInDetailPK = new DepartmentStockInDetailPK
                                                         {
                                                             DepartmentId    = source.OtherDepartmentId,
                                                             ProductId = outDetail.Product.ProductId
                                                         };
                // check it in case stock-in back
                if (outDetail.DepartmentPrice != null)
                {
                    inDetail.Price = outDetail.DepartmentPrice.Price;
                }

                stockInDetailList.Add(inDetail);
            }
            stockIn.DepartmentStockInDetails = stockInDetailList;
            return stockIn;
        }
    }
}
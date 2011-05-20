using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Utility.Mapper;

namespace AppFrameClient.Utility.Mapper
{
    public class FastDepartmentStockOutMapper : BaseMapper<DepartmentStockOut, DepartmentStockIn>
    {
        public DepartmentStockOut Convert(DepartmentStockIn source)
        {
            DepartmentStockOut stockOut = new DepartmentStockOut();
            stockOut.CreateDate = DateTime.Now;
            stockOut.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            stockOut.UpdateDate = DateTime.Now;
            stockOut.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            stockOut.OtherDepartmentId = source.DepartmentStockInPK.DepartmentId;
            stockOut.StockOutDate = DateTime.Now;
            stockOut.DefectStatus = new StockDefectStatus
                                       {
                                           DefectStatusId = 7 // Xuat qua cua hang khac
                                       };
            stockOut.DepartmentStockOutPK = new DepartmentStockOutPK
                                              {
                                                 DepartmentId = CurrentDepartment.Get().DepartmentId
                                              };
            IList outDetails = new ArrayList();
            foreach (DepartmentStockInDetail stockInDetail in source.DepartmentStockInDetails)
            {
                DepartmentStockOutDetail outDetail = new DepartmentStockOutDetail();
                outDetail.DepartmentStockOutDetailPK = new DepartmentStockOutDetailPK
                                                           {
                                                              DepartmentId = CurrentDepartment.Get().DepartmentId
                                                           };
                outDetail.CreateDate = DateTime.Now;
                outDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                outDetail.UpdateDate = DateTime.Now;
                outDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                outDetail.DefectStatus = new StockDefectStatus
                {
                    DefectStatusId = 7 // Xuat qua cua hang khac
                };
                outDetail.Quantity = stockInDetail.Quantity;
                outDetail.GoodQuantity = stockInDetail.Quantity;
                outDetail.Product = stockInDetail.Product;
                outDetail.ProductMaster = stockInDetail.Product.ProductMaster;
                outDetails.Add(outDetail);
            }
            stockOut.DepartmentStockOutDetails = outDetails;
            return stockOut;
        }
    }
}

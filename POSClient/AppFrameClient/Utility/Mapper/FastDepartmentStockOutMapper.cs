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
            DepartmentStockOut stockIn = new DepartmentStockOut();
            stockIn.CreateDate = DateTime.Now;
            stockIn.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            stockIn.UpdateDate = DateTime.Now;
            stockIn.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            stockIn.OtherDepartmentId = source.DepartmentStockInPK.DepartmentId;
            stockIn.StockOutDate = DateTime.Now;
            stockIn.DefectStatus = new StockDefectStatus
                                       {
                                           DefectStatusId = 6 // Xuat qua cua hang khac
                                       };
            stockIn.DepartmentStockOutPK = new DepartmentStockOutPK
                                              {
                                                 DepartmentId = CurrentDepartment.Get().DepartmentId
                                              };
            IList outDetails = new ArrayList();
            foreach (DepartmentStockInDetail outDetail in source.DepartmentStockInDetails)
            {
                DepartmentStockOutDetail inDetail = new DepartmentStockOutDetail();
                inDetail.CreateDate = DateTime.Now;
                inDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                inDetail.UpdateDate = DateTime.Now;
                inDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                inDetail.DefectStatus = new StockDefectStatus
                {
                    DefectStatusId = 6 // Xuat qua cua hang khac
                };
                inDetail.Quantity = outDetail.Quantity;
                inDetail.Product = outDetail.Product;
                inDetail.ProductMaster = outDetail.Product.ProductMaster;
                
                outDetails.Add(inDetail);
            }
            stockIn.DepartmentStockOutDetails = outDetails;
            return stockIn;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class SyncFromDepartmentToMain
    {
        public IList DepartmentCostList { get; set;}
        public IList EmployeeMoneyList { get; set;}
        public IList DepartmentStockList { get; set; }
        public IList DepartmentStockInList { get; set; }
        
        public IList DepartmentStockHistoryList { get; set; }
        public IList PurchaseOrderList { get; set; }
        public IList ReturnPoList { get; set; }
        public IList DepartmentTimelineList { get; set; }
        public IList DepartmentStockTempList { get; set; }
        public IList DepartmentStockOutList { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Đồng bộ về kho chính: ").Append("\r\n");
            if (DepartmentStockList != null && DepartmentStockList.Count > 0)
            {
                sb.Append("    ").Append("Kho cửa hàng:\r\n");
                foreach (DepartmentStock deptSotck in DepartmentStockList)
                {
                    sb.Append("    Tên sản phẩm:").Append(deptSotck.Product.ProductMaster.ProductName).Append(", Mã vạch: ").Append(deptSotck.Product.ProductId)
                        .Append(" Số lượng: ").Append(deptSotck.Quantity).Append("\r\n");
                }
            }
            if (DepartmentStockInList != null && DepartmentStockInList.Count > 0)
            {
                sb.Append("    ").Append("Nhập kho cửa hàng:\r\n");
                foreach (DepartmentStockIn deptSotck in DepartmentStockInList)
                {
                    sb.Append("        Mã nhập kho: ").Append(deptSotck.StockInId).Append(", Ngày nhập kho: ").Append(
                        deptSotck.StockInDate.ToString("dd/MM/yyyyy hh:mm:ss")).Append("\r\n");
                    foreach (DepartmentStockInDetail detail in deptSotck.DepartmentStockInDetails)
                    {
                        sb.Append("        Tên sản phẩm:").Append(detail.Product.ProductMaster.ProductName).Append(", Mã vạch: ").Append(detail.Product.ProductId)
                            .Append(" Số lượng: ").Append(detail.Quantity).Append("\r\n");                        
                    }
                }
            }

            if (DepartmentStockOutList != null && DepartmentStockOutList.Count > 0)
            {
                sb.Append("    ").Append("Xuất kho cửa hàng:\r\n");
                foreach (DepartmentStockOut deptSotck in DepartmentStockOutList)
                {
                    sb.Append("        Mã xuất kho: ").Append(deptSotck.StockOutId).Append(", Ngày xuất kho: ").Append(
                        deptSotck.StockOutDate.ToString("dd/MM/yyyyy hh:mm:ss")).Append("\r\n");
                    foreach (DepartmentStockOutDetail detail in deptSotck.DepartmentStockOutDetails)
                    {
                        sb.Append("        Tên sản phẩm:").Append(detail.Product.ProductMaster.ProductName).Append(", Mã vạch: ").Append(detail.Product.ProductId)
                            .Append(" Số lượng: ").Append(detail.Quantity).Append("\r\n");
                    }
                }
            }
            if (DepartmentStockOutList != null && DepartmentStockOutList.Count > 0)
            {
                sb.Append("    ").Append("Xuất kho cửa hàng:\r\n");
                foreach (DepartmentStockOut deptSotck in DepartmentStockOutList)
                {
                    sb.Append("        Mã nhập kho: ").Append(deptSotck.StockOutId).Append(", Ngày nhập kho: ").Append(
                        deptSotck.StockOutDate.ToString("dd/MM/yyyyy hh:mm:ss")).Append("\r\n");
                    foreach (DepartmentStockOutDetail detail in deptSotck.DepartmentStockOutDetails)
                    {
                        sb.Append("        Tên sản phẩm:").Append(detail.Product.ProductMaster.ProductName).Append(", Mã vạch: ").Append(detail.Product.ProductId)
                            .Append(" Số lượng: ").Append(detail.Quantity).Append("\r\n");
                    }
                }
            }
            return sb.ToString();
        }
    }
}

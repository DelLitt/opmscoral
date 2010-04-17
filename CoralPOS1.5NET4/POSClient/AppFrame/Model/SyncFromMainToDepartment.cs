using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class SyncFromMainToDepartment
    {
        public IList UserInfoList { get; set;}
        public IList ProductMasterList { get; set;}
        public IList DepartmentPriceMasterList { get; set; }
        public IList StockOutList { get; set; }
        public Department Department { get; set; }
        public IList DepartmentList { get; set; }
        public IList EmployeeList { get; set; }

        public IList DepartmentStockTemps { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Đồng bộ về cửa hàng: ");
            if (Department != null)
            {
                sb.Append(Department.DepartmentName).Append(", Địa chỉ: ").Append(Department.Address);
            }
            sb.Append("\r\n");
            if (StockOutList != null && StockOutList.Count > 0)
            {
                sb.Append("    ").Append("Xuất kho \r\n");
                foreach (StockOut deptSotck in StockOutList)
                {
                    sb.Append("        Mã xuất kho: ").Append(deptSotck.StockoutId).Append(", Ngày xuất kho: ").Append(
                        deptSotck.StockOutDate.ToString("dd/MM/yyyyy hh:mm:ss")).Append("\r\n");
                    foreach (StockOutDetail detail in deptSotck.StockOutDetails)
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

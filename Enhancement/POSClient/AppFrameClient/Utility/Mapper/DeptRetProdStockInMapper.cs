using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Utility.Mapper;

namespace AppFrameClient.Utility.Mapper
{
    public class DeptRetProdStockInMapper : BaseMapper<StockIn, DepartmentStockOut>
    {
        #region Implementation of BaseMapper<StockOut,DepartmentStockOut>

        
        #endregion

        #region Implementation of BaseMapper<StockIn,DepartmentStockOut>

        public StockIn Convert(DepartmentStockOut source)
        {
            StockIn dest = new StockIn();
            dest.Description = "Tạm nhập từ kết quả xử lý kiểm kê";
            dest.StockInType = 0;
            dest.StockInDate = DateTime.Now;
            dest.CreateDate = DateTime.Now;
            dest.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            dest.UpdateDate = DateTime.Now;
            dest.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            return dest;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Utility.Mapper;
using AppFrameClient.ViewModel;

namespace AppFrameClient.Utility.Mapper
{
    public class DepartmentStockOutViewMapper : BaseMapper<DepartmentStockOutView, DepartmentStockOut>
    {
        public DepartmentStockOutView Convert(DepartmentStockOut source)
        {
            DepartmentStockOutView view = new DepartmentStockOutView();
            view.DepartmentStockOut = source;
            view.DepartmentName = CurrentDepartment.Get().DepartmentName;
            view.Description = source.DefectStatus.DefectStatusName;
            view.StockOutId = source.DepartmentStockOutPK.StockOutId;

            return view;
        }
    }
}

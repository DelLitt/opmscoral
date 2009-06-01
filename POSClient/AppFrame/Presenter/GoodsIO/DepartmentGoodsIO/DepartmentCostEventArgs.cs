using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public class DepartmentCostEventArgs : BaseEventArgs
    {
        public IList CostList;
        public DepartmentCost UpdateCost { get; set;}
        public DepartmentCost CreateCost { get; set;}

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}

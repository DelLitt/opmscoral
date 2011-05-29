using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class SyncFromDeptToDept
    {
        public Department DestinationDept { get; set; }
        public IList DepartmentStockOutList { get; set; }
    }
}

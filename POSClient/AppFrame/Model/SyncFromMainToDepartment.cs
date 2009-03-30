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
        public IList StockOutList { get; set; }
        public Department Department { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public class ScanType
    {
        public string TypeName { get; set; }

        public IList ScannedProducts { get; set; }
        public IList UnscanProducts { get; set; }
    }
}
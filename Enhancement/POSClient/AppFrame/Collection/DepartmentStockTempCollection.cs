using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class DepartmentStockTempCollection : BaseCollection<DepartmentStockTemp>
    {
        public DepartmentStockTempCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockTempCollection()
        {
        }

        public DepartmentStockTempCollection(IList<DepartmentStockTemp> list) : base(list)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class DepartmentStockOutCollection : AFBaseCollection<DepartmentStockOut>
    {
        public DepartmentStockOutCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockOutCollection()
        {
        }

        public DepartmentStockOutCollection(IList<DepartmentStockOut> list) : base(list)
        {
        }
    }
}

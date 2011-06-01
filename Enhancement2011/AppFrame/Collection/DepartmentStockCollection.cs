using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class DepartmentStockCollection : AFBaseCollection<DepartmentStock>
    {
        public DepartmentStockCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockCollection()
        {
        }

        public DepartmentStockCollection(IList<DepartmentStock> list) : base(list)
        {
        }
    }
}

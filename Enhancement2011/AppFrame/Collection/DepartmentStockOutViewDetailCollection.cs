using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Collection
{
    public class DepartmentStockOutViewDetailCollection : AfBaseCollection<DepartmentStockOutViewDetailCollection>
    {
        public DepartmentStockOutViewDetailCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockOutViewDetailCollection()
        {
        }

        public DepartmentStockOutViewDetailCollection(IList<DepartmentStockOutViewDetailCollection> list) : base(list)
        {
        }
    }
}

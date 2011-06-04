using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class DepartmentStockOutDetailCollection : AfBaseCollection<DepartmentStockOutDetail>
    {
        public DepartmentStockOutDetailCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockOutDetailCollection()
        {
        }

        public DepartmentStockOutDetailCollection(IList<DepartmentStockOutDetail> list) : base(list)
        {
        }
    }
}

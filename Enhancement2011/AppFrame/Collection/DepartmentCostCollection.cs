using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class DepartmentCostCollection : AfBaseCollection<DepartmentCost>
    {
        public DepartmentCostCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentCostCollection()
        {
        }

        public DepartmentCostCollection(IList<DepartmentCost> list) : base(list)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    [Serializable()]
    public class DepartmentStockInDetailCollection : BaseCollection<DepartmentStockInDetail>
    {
        public DepartmentStockInDetailCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockInDetailCollection()
        {
        }

        public DepartmentStockInDetailCollection(IList<DepartmentStockInDetail> list) : base(list)
        {
        }
    }
}

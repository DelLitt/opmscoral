using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;

namespace AppFrameClient.ViewModel
{
    public class DepartmentStockInResultDetailCollection : BaseCollection<DepartmentStockInResultDetail>
    {
        public DepartmentStockInResultDetailCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockInResultDetailCollection()
        {
        }

        public DepartmentStockInResultDetailCollection(IList<DepartmentStockInResultDetail> list) : base(list)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Model;

namespace AppFrameClient.ViewModel
{
    public class DepartmentStockDefectCollection : BaseCollection<DepartmentStockDefect>
    {
        public DepartmentStockDefectCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockDefectCollection()
        {
        }

        public DepartmentStockDefectCollection(IList<DepartmentStockDefect> list) : base(list)
        {
        }
    }
}

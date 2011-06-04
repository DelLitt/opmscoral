using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Model;

namespace AppFrameClient.ViewModel
{
    public class DepartmentStockDefectCollection : AfBaseCollection<DepartmentStockHistory>
    {
        public DepartmentStockDefectCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockDefectCollection()
        {
        }

        public DepartmentStockDefectCollection(IList<DepartmentStockHistory> list) : base(list)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;

namespace AppFrameClient.ViewModel
{
    public class DepartmentStockTempViewCollection : AfBaseCollection<DepartmentStockTempView>
    {
        public DepartmentStockTempViewCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockTempViewCollection()
        {
        }

        public DepartmentStockTempViewCollection(IList<DepartmentStockTempView> list) : base(list)
        {
        }
    }
}

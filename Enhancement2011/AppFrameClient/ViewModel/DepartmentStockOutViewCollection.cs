using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;

namespace AppFrameClient.ViewModel
{
    public class DepartmentStockOutViewCollection : AFBaseCollection<DepartmentStockOutView>
    {
        public DepartmentStockOutViewCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockOutViewCollection()
        {
        }

        public DepartmentStockOutViewCollection(IList<DepartmentStockOutView> list) : base(list)
        {
        }
    }
}

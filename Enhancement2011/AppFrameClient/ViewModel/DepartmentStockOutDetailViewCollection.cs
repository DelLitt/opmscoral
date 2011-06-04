using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;

namespace AppFrameClient.ViewModel
{
    public class DepartmentStockOutDetailViewCollection : AfBaseCollection<DepartmentStockOutDetailView>
    {
        public DepartmentStockOutDetailViewCollection(BindingSource source) : base(source)
        {
        }

        public DepartmentStockOutDetailViewCollection()
        {
        }

        public DepartmentStockOutDetailViewCollection(IList<DepartmentStockOutDetailView> list) : base(list)
        {
        }
    }
}

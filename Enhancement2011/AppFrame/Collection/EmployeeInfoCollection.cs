using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class EmployeeInfoCollection : AFBaseCollection<EmployeeInfo>
    {
        public EmployeeInfoCollection(BindingSource source) : base(source)
        {
        }

        public EmployeeInfoCollection()
        {
        }

        public EmployeeInfoCollection(IList<EmployeeInfo> list) : base(list)
        {
        }
    }
}

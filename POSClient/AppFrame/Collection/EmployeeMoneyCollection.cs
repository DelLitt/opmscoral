using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class EmployeeMoneyCollection : BaseCollection<EmployeeMoney>
    {
        public EmployeeMoneyCollection(BindingSource source) : base(source)
        {
        }

        public EmployeeMoneyCollection()
        {
        }

        public EmployeeMoneyCollection(IList<EmployeeMoney> list) : base(list)
        {
        }
    }
}
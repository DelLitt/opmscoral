using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class EmployeeWorkingDaysCollection : AFBaseCollection<EmployeeWorkingDay>
    {
        public EmployeeWorkingDaysCollection(BindingSource source) : base(source)
        {
        }

        public EmployeeWorkingDaysCollection()
        {
        }

        public EmployeeWorkingDaysCollection(IList<EmployeeWorkingDay> list) : base(list)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    public class DepartmentTimelinePK
    {
        public virtual long DepartmentId {
            get;
            set;}
        public virtual long Period { get; set; }
    }
}

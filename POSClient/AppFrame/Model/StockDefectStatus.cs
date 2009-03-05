using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    public class StockDefectStatus
    {
        public virtual Int64 DefectStatusId 
        {
            get;
            set;
        }
        public virtual string DefectStatusName
        {
            get; set;
        }
    }
}

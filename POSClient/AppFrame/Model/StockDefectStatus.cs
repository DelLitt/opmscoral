using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class StockDefectStatus
    {
        private string test = " Kiểm tra";
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

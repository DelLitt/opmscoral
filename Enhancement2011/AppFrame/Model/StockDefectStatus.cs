using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class StockDefectStatus
    {
        public const int TEMP_STOCK_OUT = 4;
        public const int SEND_BACK_TO_PRODUCER = 5;
        public const int SEND_BACK_TO_MAIN = 6;
        public const int SEND_TO_OTHER_DEPT = 7;
        public const int DESTROY_DAMAGE_AND_LOST = 8;

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

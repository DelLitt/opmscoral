using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter
{
    public class PosLogEventArgs : BaseEventArgs
    {
        public DateTime LogDateFrom { get; set; }
        public DateTime LogDateTo { get; set; }
        public string Action { get; set; }
        public string Username { get; set; }
        public int PosLogId { get; set; }

        public IList PosLogList { get; set; }
        public PosLog PosLog { get; set; }
    }
}

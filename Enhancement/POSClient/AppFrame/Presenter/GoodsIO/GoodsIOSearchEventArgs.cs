using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using System.Collections;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO
{
    public class GoodsIOSearchEventArgs : BaseEventArgs
    {
        public Form ParentForm { get; set; }
        public string BlockDetailId { get; set; }
        public DateTime ImportDateFrom { get; set; }
        public DateTime ImportDateTo { get; set; }
        public IList BlockDetailList { get; set; }
        public bool IsNeedDelete { get; set; }
        public IList<BlockInDetail> DeleteList { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSServer.ViewModels.Dialogs
{
    public class ProductEventArgs : EventArgs
    {
        public IList ProductColorList { get; set; }
        public IList ProductSizeList { get; set; }
    }
}

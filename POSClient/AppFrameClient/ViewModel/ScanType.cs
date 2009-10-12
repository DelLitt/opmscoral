using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrameClient.ViewModel
{
    public class ScanType
    {
        public string TypeName { get; set; }

        public IList ScannedProducts { get; set; }
        public IList UnscanProducts { get; set; }
    }
}

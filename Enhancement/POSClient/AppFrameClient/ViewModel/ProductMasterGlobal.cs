using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Model;

namespace AppFrameClient.ViewModel
{
    public class ProductMasterGlobal
    {
        public string ProductName { get; set; }
        public IList ProductMasters { get; set; }
        public ProductMaster ProductMaster { get; set; }
    }
}

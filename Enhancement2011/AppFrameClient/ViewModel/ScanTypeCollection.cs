using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrameClient.ViewModel
{
     public class ScanTypeCollection : AFBaseCollection<ScanType>
    {
         public ScanTypeCollection(BindingSource source) : base(source)
         {
         }

         public ScanTypeCollection()
         {
         }

         public ScanTypeCollection(IList<ScanType> list) : base(list)
         {
         }
    }
}

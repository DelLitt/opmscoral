using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;

namespace AppFrameClient.ViewModel
{
    public class StockInResultDetailCollection : AfBaseCollection<StockInResultDetail>
    {
        public StockInResultDetailCollection(BindingSource source) : base(source)
        {
        }

        public StockInResultDetailCollection()
        {
        }

        public StockInResultDetailCollection(IList<StockInResultDetail> list) : base(list)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;

namespace AppFrameClient.ViewModel
{
    public class StockViewCollection : BaseCollection<StockView>
    {
        public StockViewCollection(BindingSource source) : base(source)
        {
        }

        public StockViewCollection()
        {
        }

        public StockViewCollection(IList<StockView> list) : base(list)
        {
        }
    }
}

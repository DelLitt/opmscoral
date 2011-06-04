using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;

namespace AppFrameClient.ViewModel
{
    public class StockOutViewCollection : AfBaseCollection<StockOutView>
    {
        public StockOutViewCollection(BindingSource source) : base(source)
        {
        }

        public StockOutViewCollection()
        {
        }

        public StockOutViewCollection(IList<StockOutView> list) : base(list)
        {
        }
    }
}

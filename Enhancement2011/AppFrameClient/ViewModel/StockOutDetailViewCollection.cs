using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;

namespace AppFrameClient.ViewModel
{
    public class StockOutDetailViewCollection : AfBaseCollection<StockOutDetailView>
    {
        public StockOutDetailViewCollection(BindingSource source) : base(source)
        {
        }

        public StockOutDetailViewCollection()
        {
        }

        public StockOutDetailViewCollection(IList<StockOutDetailView> list) : base(list)
        {
        }
    }
}

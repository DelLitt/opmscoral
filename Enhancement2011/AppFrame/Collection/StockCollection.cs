using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class StockCollection : AfBaseCollection<Stock>
    {
        public StockCollection(BindingSource source) : base(source)
        {
        }

        public StockCollection()
        {
        }

        public StockCollection(IList<Stock> list) : base(list)
        {
        }
    }
}

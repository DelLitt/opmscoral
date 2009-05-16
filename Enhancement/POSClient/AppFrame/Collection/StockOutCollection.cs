using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class StockOutCollection :  BaseCollection<StockOut>
    {
        public StockOutCollection(BindingSource source) : base(source)
        {
        }

        public StockOutCollection()
        {
        }

        public StockOutCollection(IList<StockOut> list) : base(list)
        {
        }
    }
}

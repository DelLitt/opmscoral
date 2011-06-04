using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class StockOutCollection :  AfBaseCollection<StockOut>
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

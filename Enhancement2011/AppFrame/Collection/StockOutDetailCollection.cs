using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class StockOutDetailCollection : BaseCollection<StockOutDetail>
    {
        public StockOutDetailCollection(BindingSource source) : base(source)
        {
        }

        public StockOutDetailCollection()
        {
        }

        public StockOutDetailCollection(IList<StockOutDetail> list) : base(list)
        {
        }
    }
}

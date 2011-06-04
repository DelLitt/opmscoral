using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Model;

namespace AppFrameClient.ViewModel
{
    public class StockDefectCollection :AfBaseCollection<StockHistory>
    {
        public StockDefectCollection(BindingSource source) : base(source)
        {
        }

        public StockDefectCollection()
        {
        }

        public StockDefectCollection(IList<StockHistory> list)
            : base(list)
        {

        }
    }
}

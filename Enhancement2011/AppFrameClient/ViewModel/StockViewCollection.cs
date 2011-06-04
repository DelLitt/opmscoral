using System.Collections.Generic;
using System.Windows.Forms;

namespace AppFrameClient.ViewModel
{
    public class StockViewCollection : AppFrame.Collection.AfBaseCollection<StockView>
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

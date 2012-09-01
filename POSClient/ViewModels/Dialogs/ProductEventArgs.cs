using System;
using System.Collections;

namespace POSClient.ViewModels.Dialogs
{
    public class ProductEventArgs : EventArgs
    {
        public IList StockList { get; set;}
        public IList ProductColorList { get; set; }
        public IList ProductSizeList { get; set; }
    }
}

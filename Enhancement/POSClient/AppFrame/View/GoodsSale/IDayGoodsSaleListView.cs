using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Presenter.GoodsSale;

namespace AppFrame.View.GoodsSale
{
    public interface IDayGoodsSaleListView : IView<GoodsSaleListEventArgs>
    {
        IGoodsSaleListController GoodsSaleListController { get; set; }

        event EventHandler<GoodsSaleListEventArgs> GoodsSaleListSearchEvent;
        event EventHandler<GoodsSaleListEventArgs> ExportToExcelEvent;
        event EventHandler<GoodsSaleListEventArgs> PrintGoodsSaleEvent;
    }
}

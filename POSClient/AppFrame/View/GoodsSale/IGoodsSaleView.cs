using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsSale;

namespace AppFrame.View.GoodsSale
{
    public interface IGoodsSaleView : IView<GoodsSaleEventArgs>
    {
        IGoodsSaleController GoodsSaleController { get; set;}

        event EventHandler<GoodsSaleEventArgs> AddGoodsEvent;
        event EventHandler<GoodsSaleEventArgs> DeleteGoodsEvent;
        event EventHandler<GoodsSaleEventArgs> LoadGoodsEvent;
        event EventHandler<GoodsSaleEventArgs> HelpEvent;
        event EventHandler<GoodsSaleEventArgs> FirstRecordEvent;
        event EventHandler<GoodsSaleEventArgs> PreviousRecordEvent;
        event EventHandler<GoodsSaleEventArgs> NextRecordEvent;
        event EventHandler<GoodsSaleEventArgs> LastRecordEvent;
        event EventHandler<GoodsSaleEventArgs> PrintCheckEvent;
        event EventHandler<GoodsSaleEventArgs> SaveCheckEvent;
        event EventHandler<GoodsSaleEventArgs> ResetCheckEvent;
        event EventHandler<GoodsSaleEventArgs> CloseFormEvent;
        event EventHandler<GoodsSaleEventArgs> FillProductToComboEvent;

        event EventHandler<GoodsSaleEventArgs> SavePurchaseOrderEvent;
    }
}

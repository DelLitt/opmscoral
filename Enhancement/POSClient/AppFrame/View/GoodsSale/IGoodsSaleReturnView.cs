using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsSale;

namespace AppFrame.View.GoodsSale
{
    public interface IGoodsSaleReturnView
    {
        IGoodsSaleReturnController GoodsSaleReturnController { get; set; }
        IGoodsSaleController GoodsSaleController { get; set; }

        event EventHandler<GoodsSaleReturnEventArgs> AddGoodsEvent;
        event EventHandler<GoodsSaleReturnEventArgs> DeleteGoodsEvent;
        event EventHandler<GoodsSaleReturnEventArgs> HelpEvent;
        event EventHandler<GoodsSaleReturnEventArgs> LoadPurchaseOrderEvent;
        event EventHandler<GoodsSaleReturnEventArgs> FirstRecordEvent;
        event EventHandler<GoodsSaleReturnEventArgs> PreviousRecordEvent;
        event EventHandler<GoodsSaleReturnEventArgs> NextRecordEvent;
        event EventHandler<GoodsSaleReturnEventArgs> LastRecordEvent;
        event EventHandler<GoodsSaleReturnEventArgs> PrintCheckEvent;
        event EventHandler<GoodsSaleReturnEventArgs> SaveCheckEvent;
        event EventHandler<GoodsSaleReturnEventArgs> ResetCheckEvent;
        event EventHandler<GoodsSaleReturnEventArgs> CloseFormEvent;
        event EventHandler<GoodsSaleReturnEventArgs> FillProductToComboEvent;


        event EventHandler<GoodsSaleEventArgs> LoadGoodsEvent;

        event EventHandler<GoodsSaleReturnEventArgs> SavePurchaseOrderEvent;
    }
}

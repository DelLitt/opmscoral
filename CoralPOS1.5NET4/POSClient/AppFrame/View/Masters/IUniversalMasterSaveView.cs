using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.Masters;

namespace AppFrame.View.Masters
{
    public interface IUniversalMasterSaveView : IView<UniversalMasterSaveEventArgs>
    {
        IUniversalMasterSaveController UniversalMasterSaveController { get; set; }
        event EventHandler<UniversalMasterSaveEventArgs> SaveUniversalMasterEvent;
    }
}
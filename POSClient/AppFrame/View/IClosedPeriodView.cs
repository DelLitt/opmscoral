using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.Presenter;

namespace AppFrame.View
{
    public interface IClosedPeriodView
    {
        IClosedPeriodLogic ClosedPeriodLogic { get; set; }

        event EventHandler<ClosedPeriodEventArgs> LoadClosedPeriodEvent;
    }
}
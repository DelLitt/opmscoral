using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Validation;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using AppFrame.Base;

namespace POSServer.ViewModels.Dialogs
{
    public interface IErrorDialogViewModel : IScreenNode, IScreenEx
    {
        POSErrorResult ErrorResult { get; set; }
    }
}

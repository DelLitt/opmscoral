using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Validation;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using AppFrame.Base;
using Caliburn.Micro;

namespace POSServer.ViewModels.Dialogs
{
    public interface IErrorDialogViewModel : IScreenNode
    {
        IList ErrorResult { get; set; }
    }
}

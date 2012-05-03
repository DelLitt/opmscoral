using System.Collections;
using AppFrame.CustomAttributes;
using AppFrame.Base;
using Caliburn.Micro;

namespace POSClient.ViewModels.Dialogs
{
    public interface IErrorDialogViewModel : IScreenNode, IScreen
    {
        IList ErrorResult { get; set; }
    }
}

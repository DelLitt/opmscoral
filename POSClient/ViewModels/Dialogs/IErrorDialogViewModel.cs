using System.Collections;
using Caliburn.PresentationFramework.Screens;
using AppFrame.Base;

namespace POSClient.ViewModels.Dialogs
{
    public interface IErrorDialogViewModel : IScreenNode, IScreenEx
    {
        IList ErrorResult { get; set; }
    }
}

using System.Collections;
using AppFrame.Base;
using AppFrame.CustomAttributes;


namespace POSClient.ViewModels.Dialogs
{
    [PerRequest(typeof(IErrorDialogViewModel))]
    public class ErrorDialogViewModel : PosViewModel,IErrorDialogViewModel
    {
        //public IList ErrorsList { get; set; }

        private IList _errorResult;
        public IList ErrorResult
        {
            get
            {
                return _errorResult;  
            }
            set
            {
                _errorResult = value;
                NotifyOfPropertyChange(()=>ErrorResult);
            }
        }

        public void Close()
        {
            ShellViewModel.Current.HideDialog(this);
            //Shutdown();
        }
    }
}

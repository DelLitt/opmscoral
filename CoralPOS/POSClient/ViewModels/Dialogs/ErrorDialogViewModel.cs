using System.Collections;
using AppFrame.Base;
using Caliburn.Core.IoC;

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

        public override void Initialize()
        {
            
        }
        public void Close()
        {
            Shutdown();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.Validation;
using Caliburn.Core.IoC;

namespace POSServer.ViewModels.Dialogs
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

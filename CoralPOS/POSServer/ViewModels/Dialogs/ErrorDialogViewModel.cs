using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.Extensions;
using AppFrame.Validation;


namespace POSServer.ViewModels.Dialogs
{
    [PerRequest]
    public class ErrorDialogViewModel : PosViewModel
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

        protected override void OnInitialize()
        {
            
        }

        public void Close()
        {
            DialogExtensions.HideDialog(this);
            //Shutdown();
        }
    }
}

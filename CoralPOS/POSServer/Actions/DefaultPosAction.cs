using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.WPF.Screens;
using Caliburn.Micro;

namespace POSServer.Actions
{
    public class DefaultPosAction : PosAction
    {
        public void StartAsyncWork()
        {
            IoC.Get<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted += WorkCompleted;
            DoExecuteAsync(Working, null);
        }

        public virtual object Working() {return null;}

        protected void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IoC.Get<ICircularLoadViewModel>().StopLoading();
            DoExecuteCompleted -= WorkCompleted;
            AfterWorkCompleted();
        }

        public virtual void AfterWorkCompleted() {}
    }
}

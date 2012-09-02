using System;
using AppFrame.Base;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using POSServer.Utils;

namespace POSServer.Actions
{
    public class StartLoadScreen : PosAction
    {
        public override void DoExecute()
        {
            ILoadViewModel var = IoC.Get<ILoadViewModel>("ILoadViewModel");
            GlobalSession.Instance.Put("GLOBALLOADSCREEN", var);
            var.StartLoading();
        }

        void var_NextNodeEvent(object sender, EventArgs e)
        {
            GoToNextNode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.WPF.Screens;
using Microsoft.Practices.ServiceLocation;

namespace POSServer.Actions
{
    public class StartLoadScreen : PosAction, IStartLoadScreen
    {
        public override void DoExecute()
        {
            ILoadViewModel var = ServiceLocator.Current.GetInstance<ILoadViewModel>("ILoadViewModel");
            GlobalSession.Instance.Put("GLOBALLOADSCREEN", var);
            var.StartLoading();
        }

        void var_NextNodeEvent(object sender, EventArgs e)
        {
            GoToNextNode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using ILoadViewModel=POSServer.ViewModels.ILoadViewModel;

namespace POSServer.Actions
{
    public class StopLoadScreen : PosAction, IStopLoadScreen
    {
        public void DoExecute()
        {
            ILoadViewModel var = GlobalSession.Instance.Get("GLOBALLOADSCREEN") as ILoadViewModel;
            var.StopLoading();
            var.WasShutdown += new EventHandler(var_WasShutdown);
            
        }

        void var_WasShutdown(object sender, EventArgs e)
        {
            GoToNextNode();
        }
    }
}

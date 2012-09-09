using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.WPF.Screens;

namespace POSServer.Actions
{
    [PerRequest]
    public class StopLoadScreen : PosAction
    {
        public override void DoExecute()
        {
            ILoadViewModel var = GlobalSession.Instance.Get("GLOBALLOADSCREEN") as ILoadViewModel;
            var.StopLoading();
            var.Deactivated += new EventHandler<Caliburn.Micro.DeactivationEventArgs>(var_Deactivated);
            
            //var.WasShutdown += new EventHandler(var_WasShutdown);
            
        }

        void var_Deactivated(object sender, Caliburn.Micro.DeactivationEventArgs e)
        {
            GoToNextNode();            
        }

        
    }
}

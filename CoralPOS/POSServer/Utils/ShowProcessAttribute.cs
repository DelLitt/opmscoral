using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.WPF.Screens;
using Microsoft.Practices.ServiceLocation;
using PostSharp.Aspects;

namespace POSServer.Utils
{
    [Serializable]
    public class ShowProcessAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            ILoadViewModel _loadViewModel = ServiceLocator.Current.GetInstance<ILoadViewModel>("ILoadViewModel");
            _loadViewModel.StartLoading();
            
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            ILoadViewModel _loadViewModel = ServiceLocator.Current.GetInstance<ILoadViewModel>("ILoadViewModel");
            _loadViewModel.StopLoading();
        }
    }
}

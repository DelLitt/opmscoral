using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

namespace POSServer.ViewModels
{
    public interface INavigationShellViewModel : IScreen
    {
        void Open<T>() where T : IScreen;
    }
}
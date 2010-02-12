using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels
{
    public interface INavigationShellViewModel : IScreen
    {
        void Open<T>() where T : IScreen;
    }
}
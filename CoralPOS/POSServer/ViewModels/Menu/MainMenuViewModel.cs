using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Menu
{
    [PerRequest(typeof(IMainMenuViewModel))]
    public class MainMenuViewModel : Screen, IMainMenuViewModel
    {
        
    }
}

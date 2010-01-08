using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels
{
    [PerRequest(typeof(IMainView))]
    public class MainView : Screen, IMainView
    {
    }
}

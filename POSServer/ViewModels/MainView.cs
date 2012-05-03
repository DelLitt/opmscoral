using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Screens;
using POSServer.ViewModels.Menu;

namespace POSServer.ViewModels
{
    [PerRequest(typeof(IMainView))]
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel))]
    public class MainView : PosViewModel, IMainView
    {
        private IShellViewModel _startViewModel;
        public MainView(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel;
        }
    }
}
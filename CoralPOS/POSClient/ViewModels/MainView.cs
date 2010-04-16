using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Screens;
using POSClient.ViewModels.Menu;

namespace POSClient.ViewModels
{
    
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel))]
    public class MainViewModel : PosViewModel, IMainViewModel
    {
        private IShellViewModel _startViewModel;
        public MainViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel;
        }
    }
}

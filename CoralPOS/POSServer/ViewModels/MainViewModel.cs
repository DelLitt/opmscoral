using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;

using AppFrame.CustomAttributes;
using POSServer.ViewModels.Menu;

namespace POSServer.ViewModels
{
    [PerRequest(Type = typeof(MainViewModel))]
    [AttachMenuAndMainScreen(typeof(MainMenuViewModel))]
    public class MainViewModel : PosViewModel
    {
        private IShellViewModel _startViewModel;
        public MainViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
    }
}
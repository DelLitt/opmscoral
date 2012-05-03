using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.WPF.Screens;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

namespace POSServer.ViewModels
{
    public class CircularLoadViewModel : Screen,ICircularLoadViewModel
    {
        private IShellViewModel _startViewModel;

        public CircularLoadViewModel()
        {
            _startViewModel = ShellViewModel.Current;
            Parent = _startViewModel;

        }
        public void StartLoading()
        {
            _startViewModel.ShowDialog(this); 
        }

        public void StopLoading()
        {
            TryClose();
            _startViewModel.HideDialog(this);
            ////Shutdown();
        }
    }
}

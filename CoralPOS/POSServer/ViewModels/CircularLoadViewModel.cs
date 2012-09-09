using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.WPF.Screens;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

namespace POSServer.ViewModels
{
    [PerRequest(Type = typeof(ICircularLoadViewModel))]
    public class CircularLoadViewModel : Screen,ICircularLoadViewModel
    {
        private IShellViewModel _startViewModel;

        public CircularLoadViewModel()
        {
            _startViewModel = ShellViewModel.Current;
            Parent = ShellViewModel.Current;

        }
        public void StartLoading()
        {
            ShellViewModel.Current.ShowDialog(this); 
        }

        public void StopLoading()
        {
            TryClose();
            ShellViewModel.Current.HideDialog(this);
            ////Shutdown();
        }
    }
}

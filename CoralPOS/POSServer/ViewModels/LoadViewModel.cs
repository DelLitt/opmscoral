using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using AppFrame.WPF.Screens;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Screens;
using System.Windows.Documents;

namespace POSServer.ViewModels
{
    
    public class LoadViewModel : Screen,ILoadViewModel
    {
        private IShellViewModel _startViewModel;
        private Timer timer = null;
        public LoadViewModel(IShellViewModel shellPresenter)
        {
            _startViewModel = shellPresenter;
            timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
            ProgressValue = 0;
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int val = ProgressValue;
            if (val < 100) val += 10;
            else
            {
                val=0;
            }
            ProgressValue = val;
        }

        private int progressValue;
        public int ProgressValue { 
            get
            {
                return progressValue;
            }
            set
            {
                progressValue = value;
                NotifyOfPropertyChange(()=>ProgressValue);
            }
        }

        public void StartLoading()
        {
            _startViewModel.ShowDialog(this);
        }

        public void StopLoading()
        {
            timer.Stop();
            Shutdown(); 
        }
    }
}

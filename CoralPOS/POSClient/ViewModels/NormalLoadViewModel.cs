using System.Timers;
using AppFrame.WPF.Screens;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels
{

    public class NormalLoadViewModel : Screen, INormalLoadViewModel
    {
        private IShellViewModel _startViewModel;
        private Timer timer = null;
        public NormalLoadViewModel(IShellViewModel shellPresenter)
        {
            _startViewModel = shellPresenter;
            /*timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += TimerElapsed;
            timer.Start();
            ProgressValue = 0;*/
        }
        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            int val = ProgressValue;
            if (val < 100) val += 10;
            else
            {
                val=0;
            }
            ProgressValue = val;
        }

        

        private int _progressValue;
        public int ProgressValue { 
            get
            {
                return _progressValue;
            }
            set
            {
                _progressValue = value;
                NotifyOfPropertyChange(()=>ProgressValue);
            }
        }

        public void StartLoading()
        {
            _startViewModel.ShowDialog(this);
        }

        public void StopLoading()
        {
            //timer.Stop();
            Shutdown(); 
        }

        protected override void OnInitialize()
        {
            
        }

        
    }
}

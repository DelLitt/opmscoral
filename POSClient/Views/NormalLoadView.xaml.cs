using System.Timers;
using System.Windows.Controls;

namespace POSClient.Views
{
    /// <summary>
    /// Interaction logic for NormalLoadView.xaml
    /// </summary>
    public partial class NormalLoadView : UserControl
    {
        private Timer timer = null;
        public NormalLoadView()
        {
            InitializeComponent();
            /*timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += TimerElapsed;
            timer.Start();*/
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            //Execute.OnUIThread(() => UpdateStatus(sender, e));
        }

        private void UpdateStatus(object sender, ElapsedEventArgs args)
        {
            /*double val = Progress.Value;
            if (val < 100) val += 10;
            else
            {
                val = 0;
            }
            Progress.Value = val;*/
        }
    }
}

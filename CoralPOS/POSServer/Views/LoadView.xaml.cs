using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Caliburn.PresentationFramework.Invocation;

namespace POSServer.Views
{
    /// <summary>
    /// Interaction logic for LoadView.xaml
    /// </summary>
    public partial class LoadView : UserControl
    {
        private Timer timer = null;
        public LoadView()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Execute.OnUIThread(() => UpdateStatus(sender, e));
            
        }

        private void UpdateStatus(object sender, ElapsedEventArgs args)
        {
            double val = Progress.Value;
            if (val < 100) val += 10;
            else
            {
                val = 0;
            }
            Progress.Value = val;
        }
    }
}

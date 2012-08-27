using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace POSServer.Views.Stock.StockIn
{
    /// <summary>
    /// Interaction logic for TemplatePage.xaml
    /// </summary>
    public partial class StockInView : UserControl
    {
        private System.Windows.Threading.DispatcherTimer timer = null;
        public StockInView()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            DateTimeBox.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
        
    }
}
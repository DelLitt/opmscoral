using System.Windows;
using AppFrame.WPF.Screens;

namespace POSServer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();
            serverBootstrapper = new ServerBootstrapper();
        }

        private ServerBootstrapper serverBootstrapper;

    }
}
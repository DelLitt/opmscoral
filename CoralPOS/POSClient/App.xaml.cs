using System.Windows;

namespace POSClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            clientBootstrapper = new ClientBootstrapper();

        }

        private ClientBootstrapper clientBootstrapper;
    }
}

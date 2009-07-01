using System;
using System.ServiceModel;
using System.Windows.Forms;
using AppFrameServer.Services;

namespace AppFrameServer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            log4net.Config.XmlConfigurator.Configure();            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            
        }
    }
}
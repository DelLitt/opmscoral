using System;
using System.Windows.Forms;
using AppFrame.View;
using AppFrameClient.Common;
using AppFrameClient.View;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrameClient
{
    internal static class Program
    {
        private static SplashScreen _splashScreen = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!ClientSetting.IsClient()
                && !ClientSetting.IsServer()
                && !ClientSetting.IsSubStock())
            {
                ClientServerSettingForm clientServerSettingForm = new ClientServerSettingForm();
                clientServerSettingForm.ShowDialog();
                clientServerSettingForm.Refresh();

                SettingForm settingForm = new SettingForm();
                settingForm.ShowDialog();
                settingForm.Refresh();
            }

            _splashScreen = new SplashScreen();
            _splashScreen.Show();
            _splashScreen.Refresh();

            IApplicationContext ctx = ContextRegistry.GetContext();
            MainForm mainForm = null;
            mainForm = ctx.GetObject(FormConstants.MAIN_FORM) as MainForm;
            mainForm.Shown += new EventHandler(mainForm_Shown);
            Application.Run(mainForm);
            //splashScreen.Close();
            //Application.Run(new SettingForm());                

            //Application.Run(new ProductMasterSearchDepartmentForm());
        }

        static void mainForm_Shown(object sender, EventArgs e)
        {
            if (_splashScreen != null)
            {
                _splashScreen.Close();
            }
        }
    }
}
using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Utility;
using AppFrame.View;
using AppFrameClient;
using AppFrameClient.Common;
using AppFrameClient.View;
using AppFrameClient.View.GoodsIO;
using AppFrameClient.View.GoodsIO.DepartmentStockData;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Spring.Objects.Factory.Xml;
using MainForm=AppFrame.View.MainForm;

namespace AppFrame
{
    internal static class Program
    {
        private static SplashScreen splashScreen = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(    !ClientSetting.IsClient() 
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

            splashScreen = new SplashScreen();
            splashScreen.Show();
            splashScreen.Refresh();
            
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
            if(splashScreen!=null)
            {
                splashScreen.Close();
            }
        }
    }
}
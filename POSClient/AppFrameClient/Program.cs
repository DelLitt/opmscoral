using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Utility;
using AppFrame.View;
using AppFrameClient.Common;
using AppFrameClient.View.GoodsIO;
using AppFrameClient.View.GoodsIO.DepartmentStockData;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Spring.Objects.Factory.Xml;

namespace AppFrame
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            IApplicationContext ctx = ContextRegistry.GetContext();
            MainForm mainForm = null;
            mainForm = ctx.GetObject(FormConstants.MAIN_FORM) as MainForm;
            Stream inStream = mainForm.GetType().Assembly.GetManifestResourceStream("AppFrameClient.MenuPermissions.xml");

            // load menu permission
            MenuItemPermission menuItemPermission = new MenuItemPermission(MenuItemPermission.INVISIBLE);
            menuItemPermission.loadRoles(inStream);
            ClientInfo clientInfo = ClientInfo.getInstance();
            clientInfo.MenuPermissions = menuItemPermission;

            // register main form
            GlobalCache.Instance().MainForm = mainForm;
            
            // check menu permission
            MenuUtility.setPermission(clientInfo.LoggedUser,ref mainForm.mnuMenu,menuItemPermission);
            Application.Run(mainForm);
            //Application.Run(new ProductMasterSearchDepartmentForm());
        }
    }
}
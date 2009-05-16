using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClientManagementTool.Common;
using ClientManagementTool.View;
using ClientManagementTool.View.Management;
using Spring.Context;
using Spring.Context.Support;

namespace ClientManagementTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            IApplicationContext ctx = ContextRegistry.GetContext();
            MainForm mainForm = null;
            mainForm = ctx.GetObject(FormConstants.MAIN_FORM) as MainForm;
            Application.Run(mainForm);
        }
    }
}

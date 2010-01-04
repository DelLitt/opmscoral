using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Caliburn.PresentationFramework.ApplicationModel;
using Spring.Context;
using Spring.Context.Support;

namespace POSClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : CaliburnApplication
    {
        public App()
        {
            InitializeComponent();
            InitSpring();
        }

        private void InitSpring()
        {
            //IApplicationContext ctx = ContextRegistry.GetContext("App1.config");
        }
    }
}

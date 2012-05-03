using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using AppFrame.Base;
using AppFrame.WPF;
using Caliburn.Castle;
using Caliburn.Core.Configuration;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Configuration;
using Caliburn.PresentationFramework.ViewModels;
using Caliburn.Spring;
using Microsoft.Practices.ServiceLocation;
using POSClient.Common;
using POSClient.ViewModels;
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
            InitSpring();
        }

        private void InitSpring()
        {
            
            GlobalSession.Instance.Put(CommonConstants.IS_LOGGED,false);
            //IApplicationContext ctx = ContextRegistry.GetContext();
            /*var cxt = ContextRegistry.GetContext();
            GenericApplicationContext context = new GenericApplicationContext(cxt);*/
            
        }

        protected override object CreateRootModel()
        {
            return Container.GetInstance<IShellViewModel>();   
            //return Container.GetInstance<INavLoginViewModel>();   
        }

        protected override IServiceLocator CreateContainer()
        {
            var cxt = ContextRegistry.GetContext();
            GenericApplicationContext context = new GenericApplicationContext(cxt);
            
            return new SpringAdapter(context);
        }

        /*protected override void ConfigurePresentationFramework(PresentationFrameworkConfiguration module)
        {
            module.Using(x => x.WindowManager<NavigationViewManager>()); 
        }*/
    }
}

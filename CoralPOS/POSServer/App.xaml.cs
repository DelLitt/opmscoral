using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.Spring;
using Microsoft.Practices.ServiceLocation;
using POSServer.Common;
using POSServer.ViewModels;
using Spring.Context.Support;

namespace POSServer
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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using AppFrame.Base;
using AppFrame.Validation;
using AppFrame.WPF.Screens;
using Caliburn.Core.Configuration;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.Spring;
using CoralPOS.Models;
using CoralPOS.ObjectValidators;
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
        private TLoadScreen screen;
        public App()
        {
            InitSpring();
            InitValidators();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
        }

        private void InitValidators()
        {
            ValidatorProvider.Register(typeof(StockIn), new StockInValidator());
        }

        private void InitSpring()
        {
            GlobalSession.Instance.Put(CommonConstants.IS_LOGGED,false);
        }

        protected override object CreateRootModel()
        {
            IShellViewModel viewModel = Container.GetInstance<IShellViewModel>("IShellViewModel");
            viewModel.ServiceLocator = Container;
            return viewModel;
        }

        protected override IServiceLocator CreateContainer()
        {
            var cxt = ContextRegistry.GetContext();
            GenericApplicationContext context = new GenericApplicationContext(cxt);
            
            return new SpringAdapter(context);
        }
        
    }
}
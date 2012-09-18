using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Micro;
using POSServer.Common;
using POSServer.ViewModels;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory.Config;
using Spring.Objects.Factory.Support;

namespace POSServer
{

    public class ServerBootstrapper : Bootstrapper<IShellViewModel>
    {
        private IApplicationContext context;

        public ServerBootstrapper()
            : base()
        {

        }

        private void InitValidators()
        {
            //ValidatorProvider.Register(typeof(StockIn), new StockInValidator());
        }

        private void InitSpring()
        {
            GlobalSession.Instance.Put(CommonConstants.IS_LOGGED, false);
            context = ContextRegistry.GetContext();
            
            //context.Refresh();

        }

        protected override void Configure()
        {
            base.Configure();
            InitSpring();
            InitValidators();
            InitCommands();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";


        }

        private void InitCommands()
        {
            AppFrameCommands.CutExecuted = Commands.POSServerCommands.CutExecutedEventHandler;
            AppFrameCommands.CopyExecuted = Commands.POSServerCommands.CopyExecutedEventHandler;
            AppFrameCommands.PasteExecuted = Commands.POSServerCommands.PasteExecutedEventHandler;
            AppFrameCommands.CanExecute = Commands.POSServerCommands.CommandCanExecute;
        }


        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            ICollection collections = context.GetObjectsOfType(service).Values;
            ICollection<object> typedColls = new List<object>();
            foreach (var object1 in collections)
            {
                typedColls.Add(object1);
            }
            return typedColls.AsEnumerable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override object GetInstance(Type service, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (context.ContainsObject(service.Name))
                {
                    object firstTry = context.GetObject(service.Name);
                    return firstTry;
                }
                if (service.IsInterface) // we use interface as key name for get object
                {

                    if (context.ContainsObject(service.FullName))
                    {
                        object secondTry = context.GetObject(service.FullName);
                        return secondTry;
                    }
                }

                // we get object by its type
                IDictionary thirdTry = context.GetObjectsOfType(service, true, false);
                IEnumerator enumerator = thirdTry.Values.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    return enumerator.Current;
                }
                else
                    throw new Exception("Object is not registered in context");
            }
            else
            {
                return context.GetObject(key, service);
            }
        }
    }
}

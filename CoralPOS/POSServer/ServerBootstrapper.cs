﻿using System;
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
using Spring.Context.Support;
using Spring.Objects.Factory.Config;
using Spring.Objects.Factory.Support;

namespace POSServer
{
    public class ServerBootstrapper : Bootstrapper<IShellViewModel>
    {
        private GenericApplicationContext context;

        public ServerBootstrapper() :base()
        {
            
        }

        private void InitValidators()
        {
            //ValidatorProvider.Register(typeof(StockIn), new StockInValidator());
        }

        private void InitSpring()
        {
            GlobalSession.Instance.Put(CommonConstants.IS_LOGGED, false);
            var cxt = ContextRegistry.GetContext();
            context = new GenericApplicationContext(cxt);
            var factory = new DefaultObjectDefinitionFactory();
            // scan for all attributes of Spring.
            var assembly = Assembly.GetEntryAssembly();
            
            // register all singleton attribute
            (from type in assembly.GetTypes()
             let attributes = type.GetCustomAttributes(typeof (SingletonAttribute), false)
             where attributes != null && attributes.Length > 0
             select new { CreateType = type, Attribute = attributes.Cast<SingletonAttribute>().First() })
                .ToList()
                .ForEach(x => context.ObjectFactory.RegisterSingleton(x.Attribute.Type.Name, Activator.CreateInstance(x.CreateType)));

            // register all perrequest attribute
            (from type in assembly.GetTypes()
             let attributes = type.GetCustomAttributes(typeof(PerRequestAttribute), false)
             where attributes != null && attributes.Length > 0
             select new { CreateType = type, Attribute = attributes.Cast<PerRequestAttribute>().First() })
                .ToList()
                .ForEach(x =>
                             {
                                 IObjectDefinition def = factory.CreateObjectDefinition(x.CreateType.FullName + "," + x.CreateType.Assembly.GetName(), null, AppDomain.CurrentDomain);
                                 
                                 string name = x.CreateType.Name;
                                 if (x.Attribute.Type != null) name = x.Attribute.Type.Name;
                                 if (x.Attribute.Name != null) name = x.Attribute.Name;
                                 context.ObjectFactory.RegisterObjectDefinition(name, def);
                             });
            context.Refresh();
            
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
                if (service.IsInterface) // we use interface as key name for get object
                {
                    object firstTry = context.GetObject(service.Name);
                    if (firstTry != null) return firstTry;
                    object secondTry = context.GetObject(service.FullName);
                    if (secondTry != null) return secondTry;
                }
                // we get object by its type
                object testTry = context.GetObject(service.Name);
                if (testTry != null) return testTry;
                IDictionary thirdTry = context.GetObjectsOfType(service);
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

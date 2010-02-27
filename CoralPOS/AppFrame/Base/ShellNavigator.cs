using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using Microsoft.Practices.ServiceLocation;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrame.Base
{
    public class ShellNavigator<T,U> : Navigator<T>,IRootNode<U> 
                                                       where T:class,IScreen
                                                       where U:class,INode
    {
        private IServiceLocator _serviceLocator;
        private IScreen _dialogModel;
        
        private IDictionary<string,IFlow> _freezeFlows = new Dictionary<string,IFlow>();
        private IFlow _currentFlow;
        public ShellNavigator(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public IServiceLocator ServiceLocator
        {
            get
            {
                return _serviceLocator;
            }
            set
            {
                _serviceLocator = value;
            }
        }
        
        private IScreen _activeMenu;
        public IScreen ActiveMenu
        {
            get
            {
                return _activeMenu;
            }
            set
            {
                _activeMenu = value;
                NotifyOfPropertyChange(() => ActiveMenu);
            }
        }

        public void Open(U node) 
        {
            if( node is T)
            {
                T screen = node as T;
                this.OpenScreen(screen);
            }
        }
        public void Open<V>() where V: IScreen 
        {
            var screen = _serviceLocator.GetInstance<V>();
            T scr = screen as T;
            this.OpenScreen(scr);
        }

        public virtual bool EnterFlow(string flowName)
        {
           if(_freezeFlows.ContainsKey(flowName))
           {
               return ResumeFlow(flowName);
           }
           else
           {
               return StartFlow(flowName);
           }
        }
        public virtual bool StartFlow(string flowName)
        {
            try
            {
                IFlow flow = (IFlow)_serviceLocator.GetInstance<IFlow>(flowName);
                /*IApplicationContext ctx = ContextRegistry.GetContext();
                DefaultFlow flow = (DefaultFlow)ctx.GetObject(flowName);*/
                flow.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public virtual bool ResumeFlow(string flowName)
        {

            try
            {
                IFlow flow = _freezeFlows[flowName];
                flow.Resume();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public virtual U CreateNode(string typeName)
        {
            var type = System.Reflection.Assembly.GetEntryAssembly().GetType(typeName);
            var instance = _serviceLocator.GetInstance(type);
            return (U) instance;
        }

        public virtual void LeaveFlow()
        {
            
        }

        /*protected override void ChangeActiveScreenCore(T newActiveScreen)
        {
            base.ChangeActiveScreenCore(newActiveScreen);
            ActiveMenu = newActiveScreen.ActiveMenu;
            NotifyOfPropertyChange(()=> ActiveMenu);
        }*/
    }
}

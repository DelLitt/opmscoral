using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.CustomAttributes;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using Microsoft.Practices.ServiceLocation;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrame.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Type of screen view</typeparam>
    /// <typeparam name="U">Type of node in a flow</typeparam>
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

        /// <summary>
        /// Service locator
        /// </summary>
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
        
        /// <summary>
        /// Menu attach with ActiveScreen
        /// </summary>
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
        public IFlow ActiveFlow
        {
            get; set;
        }
        /// <summary>
        /// Open a screen node
        /// </summary>
        /// <param name="node">screen node need to open</param>
        public void Open(U node) 
        {
            if( node is T)
            {
                T screen = node as T;
                this.OpenScreen(screen);
            }
        }

        /// <summary>
        /// Open screen with type
        /// </summary>
        /// <typeparam name="V">interface of screen</typeparam>
        public void Open<V>() where V: IScreen 
        {
            var screen = _serviceLocator.GetInstance<V>();
            T scr = screen as T;
            this.OpenScreen(scr);
        }
        
    
        /// <summary>
        /// Enter a flow with specific name, resume flow if flow has exist and start a new flow in vice versa
        /// </summary>
        /// <param name="flowName">flow name</param>
        /// <returns></returns>
        public virtual bool EnterFlow(string flowName)
        {

           // put active flow back to freeze flows if not end flow
           if (ActiveFlow != null)
           {
               if (ActiveFlow.Name.Equals(flowName)) return true;

               _freezeFlows[ActiveFlow.Name] = ActiveFlow;
           }
 
           if(_freezeFlows.ContainsKey(flowName))
           {
               return ResumeFlow(flowName);
           }
           else
           {
               return StartFlow(flowName);
           }
        }

        /// <summary>
        /// Start a flow with specific name
        /// </summary>
        /// <param name="flowName">flow name</param>
        /// <returns>true if start successfully</returns>
        public virtual bool StartFlow(string flowName)
        {
            try
            {
                IFlow flow = _serviceLocator.GetInstance<IFlow>(flowName);
                flow.Name = flowName;
                flow.Navigator = this as ShellNavigator<IScreen, INode>;
                flow.InitFlow();
                ActiveFlow = flow;
                flow.Start();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Resume an exist flow
        /// </summary>
        /// <param name="flowName">flow name</param>
        /// <returns>true if start successfully</returns>
        public virtual bool ResumeFlow(string flowName)
        {

            try
            {
                // get flow in freezeflows and remove it from freeze flows.
                IFlow flow = _freezeFlows[flowName];
                _freezeFlows.Remove(flow.Name);
                
                //set active flow equal to your flow
                ActiveFlow = flow;
                // resume it
                flow.Resume();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Create a scren from type name
        /// </summary>
        /// <param name="typeName">name type of screen</param>
        /// <returns>instance of screen</returns>
        public virtual U CreateNode(string typeName)
        {
            var type = System.Reflection.Assembly.GetEntryAssembly().GetType(typeName);
            var instance = _serviceLocator.GetInstance(type);
            return (U) instance;
        }

        /// <summary>
        /// Leave flow
        /// </summary>
        public virtual void LeaveFlow()
        {
            
        }

        protected override void ChangeActiveScreenCore(T newActiveScreen)
        {
            base.ChangeActiveScreenCore(newActiveScreen);

            Type type = newActiveScreen.GetType();
            object[] attachMenuAttributes = type.GetCustomAttributes(typeof (AttachMenuAttribute), false);
            if(attachMenuAttributes!= null && attachMenuAttributes.Count() > 0)
            {
                AttachMenuAttribute attribute = (AttachMenuAttribute) attachMenuAttributes[0];
                IScreen menuScreen=(IScreen)_serviceLocator.GetInstance(attribute.AttachMenu);
                ActiveMenu = menuScreen;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;
using Microsoft.Practices.ServiceLocation;

namespace AppFrame.Base
{
    public class ShellNavigator<T,U> : Navigator<T>,IRootNode<U> 
                                                       where T:class,IScreen 
                                                       where U:class,INode
    {
        private readonly IServiceLocator _serviceLocator;
        private IScreen _dialogModel;
        
        private IDictionary<string,IFlow> _freezeFlows = new Dictionary<string,IFlow>();
        private IFlow _currentFlow;
        public ShellNavigator(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
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
            var screen = _serviceLocator.GetInstance<U>();
            this.Open(screen);
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
        public U CreateNode(string typeName)
        {
            return (U)_serviceLocator.GetInstance(Type.GetType(typeName));
        }
    }
}

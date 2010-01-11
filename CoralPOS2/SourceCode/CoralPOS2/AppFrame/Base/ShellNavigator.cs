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
        
        private IDictionary<string,IFlow> freezeFlows = new Dictionary<string,IFlow>();
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

        public void StartFlow(string flowName)
        {
            
        }
    }
}

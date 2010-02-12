using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.Utils;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using Microsoft.Practices.ServiceLocation;
using POSServer.Common;
using Spring.Context;
using Spring.Context.Support;

namespace POSServer.ViewModels
{
    [Singleton(typeof(IShellViewModel))]
    public class ShellViewModel : ShellNavigator<IScreen,INode>, IShellViewModel
    {
        
        //private readonly IServiceLocator _serviceLocator;
        private IScreen _dialogModel;

        public string CurrentPath { get;set; }

        public ShellViewModel(IServiceLocator serviceLocator) : base(serviceLocator)
        {
            
        }

        public override void Activate()
        {
           
        }

        public override void Initialize() 
        {
            bool isLogged = (bool)GlobalSession.Instance.Get(CommonConstants.IS_LOGGED);
            if(isLogged)
            {
                Open<IMainView>();  
            }
            else
            {
                EnterFlow("LoginFlow");    
            }
        }

        public override void LeaveFlow()
        {
            Open<IMainView>();
        }
        public override bool StartFlow(string flowName)
        {
            try
            {
                
                /*IApplicationContext ctx = ContextRegistry.GetContext();
                DefaultFlow flow = (DefaultFlow)ctx.GetObject(flowName);*/
                DefaultFlow flow = ObjectUtility.GetObject<DefaultFlow>(flowName);
                flow.InitFlow();
                flow.Navigator = this;
                flow.Start();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        
        }

        /*public override INode CreateNode(string typeName)
        {
            var type = Type.GetType(typeName);
            return null;
        }*/
    }
}
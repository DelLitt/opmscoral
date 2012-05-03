using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.Utils;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

using POSClient.Common;
using POSClient.ViewModels.Security;
using Spring.Context;
using Spring.Context.Support;

namespace POSClient.ViewModels
{
    
    public class ShellViewModel : ShellNavigator<IScreen,INode>, IShellViewModel
    {
        
        //private readonly IServiceLocator _serviceLocator;
        private IScreen _dialogModel;

        public string CurrentPath { get;set; }
        private static ShellViewModel _currentShellNavigator;
        public static ShellViewModel Current
        {
            get { return _currentShellNavigator; }
            //private set { _currentShellNavigator = value; }
        }
        //public ShellViewModel(IServiceLocator serviceLocator) : base(serviceLocator) { }
        public ShellViewModel()
            : base()
        {
            if (_currentShellNavigator == null)
            {
                _currentShellNavigator = this;
            }
        }
        /*public override void Activate()
        {
           
        }*/


        protected override void OnInitialize() 
        {
            RootScreen = IoC.Get<IMainViewModel>();
            MainScreen = RootScreen;
            bool isLogged = (bool)GlobalSession.Instance.Get(CommonConstants.IS_LOGGED);
            if(isLogged)
            {
                Open<IMainViewModel>();  
            }
            else
            {
                EnterFlow("LoginFlow");    
            }
        }

        /*public override void LeaveFlow()
        {
            Open<IMainView>();
        }*/
        /*public override bool StartFlow(string flowName)
        {
            try
            {
                
                /*IApplicationContext ctx = ContextRegistry.GetContext();
                DefaultFlow flow = (DefaultFlow)ctx.GetObject(flowName);♥1♥
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
        
        }*/

        /*public override INode CreateNode(string typeName)
        {
            var type = Type.GetType(typeName);
            return null;
        }*/
    }
}

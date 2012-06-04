using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AppFrame.CustomAttributes;
using AppFrame.Utils;
using Caliburn.Micro;


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

        private IScreen _dialogModel;
        private IDictionary<string,IFlow> _freezeFlows = new Dictionary<string,IFlow>();
        private IFlow _currentFlow;
         
        public ShellNavigator()
        {
            //_serviceLocator = (Caliburn.PresentationFramework.ApplicationModel.CaliburnApplication) Application.Current).Container;
            /*var bootstrapper = (Bootstrapper)Application.Current.Resources["bootstrapper"];*/
        }
        
        /*/// <summary>
        /// Service locator
        /// </summary>
        public IServiceLocator ServiceLocator
        {
            get
            {
                if (_serviceLocator == null)
                {
                    var bootstrapper = (Bootstrapper)Application.Current.Resources["bootstrapper"];
                    _serviceLocator = bootstrapper.Container;
                }
                return _serviceLocator;
            }
            set
            {
                _serviceLocator = value;
            }
        }*/
        
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

        /// <summary>
        /// Root screen
        /// </summary>
        public T RootScreen
        {
            get; set;
        }

        /// <summary>
        /// Dialog viewmodel
        /// </summary>
        public IScreen DialogModel
        {
            get
            {
                return _dialogModel;
            }
            set
            {
                _dialogModel = value;
                NotifyOfPropertyChange(()=>DialogModel);
            }
        }

        /// <summary>
        /// Flow whic navigator are using
        /// </summary>
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
                //this.OpenScreen(screen);
                this.ActivateItem(screen);
            }
        }

        /// <summary>
        /// Open screen with type
        /// </summary>
        /// <typeparam name="V">interface of screen</typeparam>
        public void Open<V>() where V:IScreen
        {
            V screen = IoC.Get<V>();
            T scr = screen as T;
            this.ActivateItem(scr);
            NotifyOfPropertyChange("ActiveItem");
        }

        public void ShowDialog<T>(T screen) where T : IScreen
        {
            if (screen is PosViewModel)
            {

                screen.Deactivated += delegate { DialogModel = null; };
            }
            DialogModel = screen;
        }
        public void HideDialog<T>(T screen) where T : IScreen
        {
            if (screen is PosViewModel)
            {
                screen.Deactivate(true);
            }
            DialogModel = null;
        }

        public override void ActivateItem(T item)
        {
            if (item != null && item.Equals(ActiveItem))
            {
                /*if (IsActive)
                {*/
                    ScreenExtensions.TryActivate(item);
                    OnActivationProcessed(item, true);
                /*}*/
                RaiseChangeNotifications();
                return;
            }

            CloseStrategy.Execute(new[] { ActiveItem }, (canClose, items) =>
            {
                if (canClose)
                    ChangeActiveItem(item, true);
                else OnActivationProcessed(item, false);
            });
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
               bool isParentFlow = false;
              if(ActiveFlow is ChildFlow)
              {
                  ChildFlow childFlow = (ChildFlow) ActiveFlow;
                  if (childFlow.ParentFlow != null)
                  {
                      if (flowName.Equals(childFlow.ParentFlow.Name)) isParentFlow = true;
                  }
              }
              if (!isParentFlow)
              {
                  _freezeFlows[ActiveFlow.Name] = ActiveFlow;
              }
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
        /// 
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="isResume"></param>
        protected void ExecuteFlow(IFlow flow,bool isResume)
        {
            if (!isResume)
            {
                flow.Navigator = this as ShellNavigator<IScreen, INode>;
                flow.InitFlow();
                ActiveFlow = flow;
                flow.Start();
            }
            else
            {
                //set active flow equal to your flow
                ActiveFlow = flow;
                // resume it
                flow.Resume();
            }
        }
        /// <summary>
        /// Start a flow with specific name
        /// </summary>
        /// <param name="flowName">flow name</param>
        /// <returns>true if start successfully</returns>
        public virtual bool StartFlow(string flowName)
        {
            /*try
            {*/
                IFlow flow = IoC.Get<IFlow>(flowName);
                flow.Name = flowName;
                ExecuteFlow(flow,false);
                return true;
            /*}
            catch (Exception exception)
            {
                return false;
            }*/
        }

        /// <summary>
        /// Resume an exist flow
        /// </summary>
        /// <param name="flowName">flow name</param>
        /// <returns>true if start successfully</returns>
        public virtual bool ResumeFlow(string flowName)
        {

            /*try
            {*/
                // get flow in freezeflows and remove it from freeze flows.
                IFlow flow = _freezeFlows[flowName];
                _freezeFlows.Remove(flow.Name);
                ExecuteFlow(flow,true);
                
                return true;
            /*}
            catch (Exception)
            {
                return false;
            }*/
        }

        /// <summary>
        /// Create a screen from type name
        /// </summary>
        /// <param name="typeName">name type of screen</param>
        /// <returns>instance of screen</returns>
        public virtual U CreateNode(string typeName)
        {
            // if lookup by name not by type
            if(typeName.StartsWith("[") && typeName.EndsWith("]"))
            {
                string name = typeName.Replace("[", "");
                       name = name.Replace("]", "");
                var instanceByName = IoC.Get<U>(name);
                return instanceByName;
            }
            var type = System.Reflection.Assembly.GetEntryAssembly().GetType(typeName);
            var instance = IoC.GetInstance(type,null);
            return (U) instance;
        }

        public T MainScreen
        {
            get; set;
        }

        /// <summary>
        /// Leave flow
        /// </summary>
        public virtual void LeaveFlow()
        {
            IFlow flow = ActiveFlow;
            ActiveFlow = null;
            if(flow is ChildFlow)
            {
                ChildFlow childFlow = (ChildFlow) flow;
                if(childFlow.ParentFlow!= null)
                {
                    ResumeFlow(childFlow.ParentFlow.Name);
                }
                else
                {
                    if(childFlow.IsRepeated)
                    {
                        EnterFlow(childFlow.Name);
                        childFlow.IsRepeated = false;
                    }
                    else
                    {
                        OpenMainScreen();    
                    }
                }
            }
            else
            {
                if (flow.IsRepeated)
                {
                    EnterFlow(flow.Name);
                    flow.IsRepeated = false;
                }
                else
                {
                    OpenMainScreen();    
                }
            }
        }

        /// <summary>
        /// Open Main Screen
        /// </summary>
        public void OpenMainScreen()
        {
            if (MainScreen != null) this.ActivateItem(MainScreen);
            // if active flow is not null so freeze it
            if (ActiveFlow != null)
            {
                if(!_freezeFlows.Keys.Contains(ActiveFlow.Name)) _freezeFlows[ActiveFlow.Name] = ActiveFlow;
                ActiveFlow = null;
            }
        }

        /// <summary>
        /// Leave current flow
        /// </summary>
        /// <param name="isRepeated">repeat the flow or not</param>
        public virtual void LeaveFlow(bool isRepeated)
        {
            if (isRepeated)
            {
                string name = ActiveFlow.Name;
                ActiveFlow = null;
                EnterFlow(name);
            }
            else
            {
                ActiveFlow = null;
                if (MainScreen != null) this.ActivateItem(MainScreen);
            }
        }
        /// <summary>
        /// Override original ChangeActiveScreenCore
        /// </summary>
        /// <param name="newActiveScreen"></param>
        /// 
        protected override void ChangeActiveItem(T newActiveScreen,bool closePrevious)
        {
            base.ChangeActiveItem(newActiveScreen,closePrevious);
            
            // process AttachMenu
            Type type = newActiveScreen.GetType();
            object[] attachMenuAttributes = type.GetCustomAttributes(typeof (AttachMenuAndMainScreenAttribute), false);
            if(attachMenuAttributes!= null && attachMenuAttributes.Count() > 0)
            {
                AttachMenuAndMainScreenAttribute attribute = (AttachMenuAndMainScreenAttribute) attachMenuAttributes[0];
                IScreen menuScreen=(IScreen)IoC.GetInstance(attribute.AttachMenu,null);
                ActiveMenu = menuScreen;
                //ScreenExtensions.TryActivate(menuScreen);
                if(attribute.MainScreen!=null)
                {
                    MainScreen = (T) IoC.GetInstance(attribute.MainScreen,null);
                }
                else
                {
                    MainScreen = null;
                }
            }
        }

       
        public virtual void EnterChildFlow(string childFlowName, IFlow parentFlow)
        {
            ChildFlow flow = ObjectUtility.GetObject<ChildFlow>(childFlowName);
            flow.Name = childFlowName;
            flow.ParentFlow = parentFlow;
            _freezeFlows[ActiveFlow.Name] = ActiveFlow;
            ExecuteFlow(flow,false);
        }
    }
}

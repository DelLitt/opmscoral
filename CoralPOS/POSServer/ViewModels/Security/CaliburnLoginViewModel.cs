using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Base.Generic;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using CoralPOS2.Models;
using NHibernate.Mapping;

namespace POSServer.ViewModels.Security
{
    [PerRequest(typeof(CaliburnLoginViewModel))]
    public class CaliburnLoginViewModel : GenericPosViewModel<CaliburnLoginModel>
    {

        public string Path
        {
            get;
            set;
        }

        
        //[Preview("CanSave")]
        public void LoginAction()
        {
            /*Subject.EndEdit();
            var dto = Map.ToDto(Subject);

            LoginModel model = new LoginModel();
            model.Username = Username;
            model.Password = Password;
            LoginLogic loginLogic = new LoginLogic();
            bool result = loginLogic.Login(model);

            if (result)
            {
                GlobalSession.Instance.Put(CommonConstants.IS_LOGGED, true);
                Flow.Session.Put(CommonConstants.LOGGED_USER, model);
                //_startViewModel.Open<IMainViewModel>();
                GoToNextNode();
            }
            else
            {
                MessageBox.Show("Login failed babe !");
            }*/

        }

        protected override void OnActivate()
        {
            base.OnActivate();

            /*Subject.PropertyChanged += OnPropertyChangedEvent;

            Subject.BeginEdit();
            Subject.Validate();*/
        }


        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            //Subject.PropertyChanged -= OnPropertyChangedEvent;
        }

        /*protected void OnShutdown()
        {
            //base.On//Shutdown();
            Subject.CancelEdit();
        }*/

        /*public bool CanSave
        {
            get { return Subject.IsDirty && Subject.IsValid; }
        }*/


        private void OnPropertyChangedEvent(object s, PropertyChangedEventArgs e)
        {
            /*if (e.PropertyName == "IsDirty" || e.PropertyName == "IsValid")
                NotifyOfPropertyChange(() => CanSave);*/
        }
    }
}
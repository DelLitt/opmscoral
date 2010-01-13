using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Base.Generic;
using Caliburn.Core.IoC;
using Caliburn.ModelFramework;
using Caliburn.PresentationFramework.Screens;
using Caliburn.WPF.ApplicationFramework;
using Caliburn.PresentationFramework.Filters;
using Caliburn.PresentationFramework.Screens;
using NHibernate.Mapping;
using POSClient.BusinessLogic.Logic.Security;
using POSClient.Common;
using POSClient.DataLayer.Models;

namespace POSClient.ViewModels.Security
{
    [PerRequest(typeof(ICaliburnLoginViewModel))]
    public class CaliburnLoginViewModel : GenericPosViewModel<CaliburnLoginModel>, ICaliburnLoginViewModel
    {

        public string Path
        {
            get;
            set;
        }

        
        [Preview("CanSave")]
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
                //_startViewModel.Open<IMainView>();
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

            Subject.PropertyChanged += OnPropertyChangedEvent;

            Subject.BeginEdit();
            Subject.Validate();
        }

        protected override void OnDeactivate()
        {
            base.OnDeactivate();
            Subject.PropertyChanged -= OnPropertyChangedEvent;
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
            Subject.CancelEdit();
        }

        public bool CanSave
        {
            get { return Subject.IsDirty && Subject.IsValid; }
        }

        private void OnPropertyChangedEvent(object s, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsDirty" || e.PropertyName == "IsValid")
                NotifyOfPropertyChange(() => CanSave);
        }
    }
}

using System.ComponentModel;
using AppFrame.Base.Generic;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using POSServer.ViewModels.Security;

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
            this.PropertyChanged += OnPropertyChangedEvent;
            
            /*Subject.PropertyChanged += OnPropertyChangedEvent;

            Subject.BeginEdit();
            Subject.Validate();*/
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            //Subject.PropertyChanged -= OnPropertyChangedEvent;
        }

        protected void OnShutdown()
        {
            /*base.OnShutdown();
            Subject.CancelEdit();*/
            
        }

        public bool CanSave
        {
            get
            {
                return true;
                //return Subject.IsDirty && Subject.IsValid;
            }
        }

        private void OnPropertyChangedEvent(object s, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsDirty" || e.PropertyName == "IsValid")
                NotifyOfPropertyChange(() => CanSave);
        }
    }
}
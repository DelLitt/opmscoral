using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Common
{
    public class BasePresenter : IPresenter
    {
        private IViewNew _view;

        private IViewModel _viewModel;

        public IViewNew View
        {
            get { return _view; }
            set
            {
                _view = value;
                _view.Presenter = this;
            }
        }

        public IViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }

        public BasePresenter()
        {
            StartUp();
        }

        private void StartUp()
        {
            Type type = GetType();
            object[] viewModelAttributes = type.GetCustomAttributes(typeof(ViewModelAttribute), false);
            object[] viewAttributes = type.GetCustomAttributes(typeof(ViewAttribute), false);
            if (viewModelAttributes.Count() > 0)
            {
                ViewModelAttribute attribute = (ViewModelAttribute)viewModelAttributes[0];
                Type vmType = attribute.GetType();
                object obj = Activator.CreateInstance(vmType);
                ViewModel = (IViewModel)obj;
            }

            OnStartUp();
        }

        public virtual void OnStartUp(){ }

    
    }
}

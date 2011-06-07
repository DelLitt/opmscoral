using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Common
{
    public abstract class ViewControl : UserControl, IViewNew
    {
        private BindingSource ControlBindingSource { get; set; }
        private IPresenter _presenter;
        public IPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                _presenter = value;
                _presenter.View = this;
                ViewModel = _presenter.ViewModel;
            }
        }

        private IViewModel _viewModel;

        public IViewModel ViewModel
        {
            get { return _viewModel; }
            set 
            { 
                _viewModel = value;
                ControlBindingSource.DataSource = _viewModel;
            }
        }


    }
}

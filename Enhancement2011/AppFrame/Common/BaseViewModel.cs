using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AppFrame.Common
{
    public class BaseViewModel : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
